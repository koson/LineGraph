/*
 * Copyright (c) 2017 Stefan Roßmann.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 * 
 * http://www.rossmann-engineering.de
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;
using System.IO.Ports;
using System.Threading.Tasks;

namespace LineGraph.DataReceiver
{

#region structs
    struct NetworkConnectionParameter
    {
        public NetworkStream stream;        //For TCP-Connection only
        public Byte[] bytes;
        public int portIn;                  //For UDP-Connection only
        public IPAddress ipAddressIn;       //For UDP-Connection only
    }
#endregion

#region TCPHandler class
    internal class TCPHandler
    {
        public delegate void DataChanged(object networkConnectionParameter);
        public event DataChanged dataChanged;

        //public delegate void NumberOfClientsChanged();
        //public event NumberOfClientsChanged numberOfClientsChanged;

        TcpListener server = null;
        
        private List<Client> tcpClientLastRequestList = new List<Client>();

        public int NumberOfConnectedClients { get; set; }

        public string ipAddress = null;

        public TCPHandler(int port)
        {
            IPAddress localAddr = IPAddress.Any;
            server = new TcpListener(localAddr, port);
            server.Start();
            server.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
        }

        public TCPHandler(string ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            IPAddress localAddr = IPAddress.Any;
            server = new TcpListener(localAddr, port);
            server.Start();
            server.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
        }


        private void AcceptTcpClientCallback(IAsyncResult asyncResult)
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient = server.EndAcceptTcpClient(asyncResult);
                tcpClient.ReceiveTimeout = 4000;
                if (ipAddress != null)
                {
                    string ipEndpoint = tcpClient.Client.RemoteEndPoint.ToString();
                    ipEndpoint = ipEndpoint.Split(':')[0];
                    if (ipEndpoint != ipAddress)
                    {
                        tcpClient.Client.Disconnect(false);
                        return;
                    }
                }
            }
            catch (Exception) { }
            try
            {
                server.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
                Client client = new Client(tcpClient);
                NetworkStream networkStream = client.NetworkStream;
                networkStream.ReadTimeout = 4000;
                networkStream.BeginRead(client.Buffer, 0, client.Buffer.Length, ReadCallback, client);
            }
            catch (Exception) { }
        }

        private int GetAndCleanNumberOfConnectedClients(Client client)
        {
            lock (this)
            {
                bool objetExists = false;
                foreach (Client clientLoop in tcpClientLastRequestList)
                {
                    if (client.Equals(clientLoop))
                        objetExists = true;
                }
                try
                {
                    tcpClientLastRequestList.RemoveAll(delegate (Client c)
                        {
                            return ((DateTime.Now.Ticks - c.Ticks) > 40000000);
                        }

                        );
                }
                catch (Exception) { }
                if (!objetExists)
                    tcpClientLastRequestList.Add(client);


                return tcpClientLastRequestList.Count;
            }
        }

        private void ReadCallback(IAsyncResult asyncResult)
        {
            NetworkConnectionParameter networkConnectionParameter = new NetworkConnectionParameter();
            Client client = asyncResult.AsyncState as Client;
            client.Ticks = DateTime.Now.Ticks;
            NumberOfConnectedClients = GetAndCleanNumberOfConnectedClients(client);
            //if (numberOfClientsChanged != null)
                //numberOfClientsChanged();
            if (client != null)
            {
                int read;
                NetworkStream networkStream = null;
                try
                {
                    networkStream = client.NetworkStream;

                    read = networkStream.EndRead(asyncResult);
                }
                catch (Exception)
                {
                    return;
                }


                if (read == 0)
                {
                    //OnClientDisconnected(client.TcpClient);
                    //connectedClients.Remove(client);
                    return;
                }
                byte[] data = new byte[read];
                Buffer.BlockCopy(client.Buffer, 0, data, 0, read);
                networkConnectionParameter.bytes = data;
                networkConnectionParameter.stream = networkStream;
                if (dataChanged != null)
                    dataChanged(networkConnectionParameter);
                try
                {
                    networkStream.BeginRead(client.Buffer, 0, client.Buffer.Length, ReadCallback, client);
                }
                catch (Exception)
                {
                }
            }
        }

        public void Disconnect()
        {
            try
            {
                foreach (Client clientLoop in tcpClientLastRequestList)
                {
                    clientLoop.NetworkStream.Close(00);
                }
            }
            catch (Exception) { }
            server.Stop();
            
        }


        internal class Client
        {
            private readonly TcpClient tcpClient;
            private readonly byte[] buffer;
            public long Ticks { get; set; }

            public Client(TcpClient tcpClient)
            {
                this.tcpClient = tcpClient;
                int bufferSize = tcpClient.ReceiveBufferSize;
                buffer = new byte[bufferSize];
            }

            public TcpClient TcpClient
            {
                get { return tcpClient; }
            }

            public byte[] Buffer
            {
                get { return buffer; }
            }

            public NetworkStream NetworkStream
            {
                get {
                        return tcpClient.GetStream();
                }
            }
        }
    }
#endregion
    
    /// <summary>
    /// Modbus TCP Server.
    /// </summary>
    public class ModbusServer
    {
        Int32 port = 6301;

        Byte[] bytes = new Byte[2100];
   
        private int numberOfConnections = 0;
        private bool udpFlag;

        private int portIn;
        private IPAddress ipAddressIn;
        private UdpClient udpClient;
        private IPEndPoint iPEndPoint;
        private TCPHandler tcpHandler;
        Thread listenerThread;
        //Thread clientConnectionThread;

        NetworkStream m_Netstream;

        public bool PortChanged { get; set; }
        object lockCoils = new object();
        object lockHoldingRegisters = new object();
        internal object lockMQTT = new object();
        private volatile bool shouldStop = false;

        /// <summary>
        /// Udp 打开指定网络端口，并开始接收数据工作，触发当前事件
        /// </summary>
        public event EventHandler<UdpEventArg> OnOpened;

        /// <summary>
        /// Udp 网络数据端口被关闭，触发当前事件
        /// </summary>
        public event EventHandler<UdpEventArg> OnClosed;

        /// <summary>
        /// 程序接收到网络数据，触发当前事件
        /// </summary>
        public event EventHandler<UdpEventArg> OnReceived;

        /// <summary>
        /// 程序执行错误，触发当前事件
        /// </summary>
        public event EventHandler<UdpEventArg> OnException;

        /// <summary>
        /// 触发 OnOpened 事件
        /// </summary>
        /// <param name="sender">触发当前事件对象</param>
        protected virtual void OpenTrigger(object sender = null)
        {
            if (OnOpened != null)
                OnOpened(sender ?? this, UdpEventArg.CreateOpen());
        }

        /// <summary>
        /// 触发 OnClosed 事件
        /// </summary>
        /// <param name="sender">触发当前事件对象</param>
        protected virtual void CloseTrigger(object sender = null)
        {
            if (OnClosed != null)
                OnClosed(sender ?? this, UdpEventArg.CreateClose());
        }

        /// <summary>
        /// 触发 OnReceived 事件
        /// </summary>
        /// <param name="sender">触发当前事件对象</param>
        /// <param name="data">接收到的数据正文信息</param>
        protected virtual void ReceiveTrigger(byte[] data, object sender = null)
        {
            if (OnReceived != null)
                OnReceived(sender ?? this, UdpEventArg.CreateReceive(data));
        }

        /// <summary>
        /// 触发 OnException 事件
        /// </summary>
        /// <param name="sender">触发当前事件对象</param>
        /// <param name="e">程序执行时，发生的错误信息对象</param>
        protected virtual void ExceptionTrigger(Exception e, object sender = null)
        {
            if (OnException != null)
                OnException(sender ?? this, UdpEventArg.CreateException(e));
        }


        public ModbusServer(int nPort)
        {
            port = nPort;
        }

 
       // public delegate void NumberOfConnectedClientsChanged();
        //public event NumberOfConnectedClientsChanged numberOfConnectedClientsChanged;


        public void Listen()
        {
            listenerThread = new Thread(ListenerThread);
            listenerThread.Start();

            //程序开始执行
            OpenTrigger();
        }

        public void StopListening()
        {
            try
            {
                tcpHandler.Disconnect();
                listenerThread.Abort();
                
            }
            catch (Exception) { }
            listenerThread.Join();
            try
            {
                //clientConnectionThread.Abort();
            }
            catch (Exception e)
            {
                ExceptionTrigger(e);
            }

            CloseTrigger();
        }
        
        private void ListenerThread()
        {
            if (!udpFlag )
            {
                if (udpClient != null)
                {
                    try
                    {
                        udpClient.Close();
                    }
                    catch (Exception) { }
                }             
                tcpHandler = new TCPHandler(port);
                tcpHandler.dataChanged += new TCPHandler.DataChanged(ProcessReceivedData);
                //tcpHandler.numberOfClientsChanged += new TCPHandler.NumberOfClientsChanged(numberOfClientsChanged);
            }
            else
               while (!shouldStop)
               {
            	if (udpFlag)
            	{
                    if (udpClient == null | PortChanged)
                    {
                        udpClient = new UdpClient(port);
                        udpClient.Client.ReceiveTimeout = 1000;
                        iPEndPoint = new IPEndPoint(IPAddress.Any, port);
                        PortChanged = false;                      
                    }
                    if (tcpHandler != null)
                        tcpHandler.Disconnect();
                    try
                    {                       
                        bytes = udpClient.Receive(ref iPEndPoint);
                        portIn = iPEndPoint.Port;
                        NetworkConnectionParameter networkConnectionParameter = new NetworkConnectionParameter();
                        networkConnectionParameter.bytes = bytes;
                        ipAddressIn = iPEndPoint.Address;
                        networkConnectionParameter.portIn = portIn;
                        networkConnectionParameter.ipAddressIn = ipAddressIn;
                        ParameterizedThreadStart pts = new ParameterizedThreadStart(this.ProcessReceivedData);
                        Thread processDataThread = new Thread(pts);
                        processDataThread.Start(networkConnectionParameter);
                    }
                    catch (Exception)
                    {                       
                    }    
            	}

                }
        }
    
 
		//#region Method numberOfClientsChanged
  //      private void numberOfClientsChanged()
  //      {
  //          numberOfConnections = tcpHandler.NumberOfConnectedClients;
  //          if (numberOfConnectedClientsChanged != null)
  //              numberOfConnectedClientsChanged();
  //      }
  //      #endregion

        object lockProcessReceivedData = new object();

        private void ProcessReceivedData(object networkConnectionParameter)
        {
            lock (lockProcessReceivedData)
            {
                Byte[] bytes = new byte[((NetworkConnectionParameter)networkConnectionParameter).bytes.Length];

                NetworkStream stream = ((NetworkConnectionParameter)networkConnectionParameter).stream;
                int portIn = ((NetworkConnectionParameter)networkConnectionParameter).portIn;
                IPAddress ipAddressIn = ((NetworkConnectionParameter)networkConnectionParameter).ipAddressIn;
                m_Netstream = stream;

                Array.Copy(((NetworkConnectionParameter)networkConnectionParameter).bytes, 0, bytes, 0, ((NetworkConnectionParameter)networkConnectionParameter).bytes.Length);

                try
                {
                    Byte[] Buffer = new byte[bytes.Length];
                    Array.Copy(bytes, 0, Buffer, 0, bytes.Length);
                    ReceiveTrigger(Buffer);
                }
                catch (Exception e)
                {
                    ExceptionTrigger(e);
                }
            }
        }

        public void CreateTCPAnswer(Byte[] data)
        {
            try
            {
                if (m_Netstream != null)
                {
                    m_Netstream.Write(data, 0, data.Length);
                }
            }
            catch (Exception) { }
        }


        public int NumberOfConnections
        {
            get
            {
                return numberOfConnections;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
                

            }
        }

        public bool UDPFlag
        {
            get
            {
                return udpFlag;
            }
            set
            {
                udpFlag = value;
            }
        }
        
    }
}
   