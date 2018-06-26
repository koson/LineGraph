//#define TCPServer
#define TCPClient
//#define UDP
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Common.Extension;
using System.Net;
//using Common.Helper;
//using ProtocolConverter.ProtocolModel;
//using ProtocolConverter.ProtocolModel.SystemProtocol;
//using EntityFramework6.Cache;

namespace LineGraph.DataReceiver
{
    public partial class BroadcastForm : Form
    {
        public BroadcastForm()
        {
            InitializeComponent();
            ////关闭多线程对控件访问检查
            //CheckForIllegalCrossThreadCalls = false;

            //EntityFramework6.EBDBContext db = new EntityFramework6.EBDBContext();
            //Config.GetInstance().InitData(db.S_Config.ToList());

            //InitializeComponent();

            //Task task = Task.Factory.StartNew(SystemStatusThread);
            //Task.Factory.StartNew(TCPServer);

        }
        private void TCPServer()
        {
//            #region 连接中控系统
//            Socket serverSocket = SocketHelper.CreateTCPServer(Config.GetInstance().SystemDetector_IP, Config.GetInstance().SystemDetector_TCP_Port);
//            //Cache.RAM.SystemSocketCache.GetInstance().AddTCPServer(Enums.SystemType.中控系统, serverSocket);

//            while (true)
//            {
//                Socket clientSocket = serverSocket.Accept();
//                //Console.WriteLine($"有客户端连接{clientSocket.RemoteEndPoint.ToString()}");
//                #region 接收客户端信息线程
//                Cache.RAM.TaskCache.GetInstance().AddTask(Task.Factory.StartNew(() =>
//                {
//                    byte[] buffer = new byte[4056];
//                    while (true)
//                    {
//                        int recvCount = 0;

//                        //客户端异常断开
//                        try
//                        {
//                            recvCount = clientSocket.Receive(buffer);
//                        }
//                        catch (Exception)
//                        {
//                        }


//                        //客户端正常断开
//                        bool isClose = clientSocket.Poll(10, SelectMode.SelectRead);

//                        if (recvCount == 0)
//                        {
//                            isClose = true;
//                        }

//                        if (isClose)
//                        {
//                            break;
//                            //    Console.WriteLine($"{clientSocket.RemoteEndPoint.ToString()}已经断开了");
//                            //    Enums.SystemType currentClientType = Cache.RAM.SystemSocketCache.GetInstance().DestroyTCPClient(clientSocket);
//                            //    if (currentClientType == Enums.SystemType.None)
//                            //    {
//                            //        break;
//                            //    }


//                            //    Enums.SystemType showMessageSystem = CurrSystemType == Enums.SystemType.中控系统 ? Enums.SystemType.图形监控系统 : Enums.SystemType.None;
//                            //    SystemTextMessageSender.Send(Cache.RAM.SystemSocketCache.GetInstance().FindTCPClient(showMessageSystem), $"[{CurrSystemType}]→[{currentClientType}]断开连接");
//                            //    break;
//                        }

//                        List<byte[]> cmdList = ProtocolConverter.ProtocolSplitter.Split(buffer, recvCount);
//                        foreach (var item in cmdList)
//                        {
//                            Execute(item.Length, item, clientSocket, clientSocket.RemoteEndPoint);
//                        }

//                    }
//                }));
//                #endregion
//            }
//            #endregion

//#warning 这里插入连接上级TCP服务器代码
        }



        public void Execute(int recvCount, byte[] buffer, Socket clientSocket, EndPoint clientPoint)
        {
            //if (recvCount <= 0)
            //{
            //    return;
            //}

            //byte[] dataBuffer = new byte[recvCount];
            //Array.Copy(buffer, 0, dataBuffer, 0, recvCount);
            //Array.Clear(buffer, 0, buffer.Length);
            //#region crc效验
            //if (!CRC32Helper.Check(dataBuffer))
            //{
            //    //FormLogHelper.GetInstance().Error($"crc效验失败. 错误数据: {dataBuffer.M5_ToHexString()}");
            //    return;
            //}

            //#endregion

            //BaseProtocol baseModel = null;
            //switch (dataBuffer[0])
            //{
            //    case (byte)Enums.Protocol.ProtocolTag.私有协议头:
            //        baseModel = PrivateProtocolExecute(recvCount, dataBuffer, clientSocket, clientPoint);
            //        break;
            //    case (byte)Enums.Protocol.ProtocolTag.系统内部协议头:
            //        baseModel = SystemProtocolExecute(recvCount, dataBuffer, clientSocket, clientPoint);
            //        break;
            //    default:
            //        //Console.WriteLine($"未被识别的指令:{dataBuffer.M5_ToHexString()}");
            //        break;
            //}


            //if (baseModel != null)
            //{
            //    byte[] sendData = ProtocolConverter.Converter.ToBuffer(baseModel);
            //    clientSocket.SendTo(sendData, clientPoint);
            //}
        }


        /// <summary>
        /// 私有协议执行
        /// </summary>
        /// <param name="recvCount"></param>
        /// <param name="buffer"></param>
        /// <param name="clientSocket"></param>
        /// <param name="clientPoint"></param>
        //private BaseProtocol PrivateProtocolExecute(int recvCount, byte[] dataBuffer, Socket clientSocket, EndPoint clientPoint)
        //{
        //    Enums.Protocol.PrivateProtocolCMD cmd = (Enums.Protocol.PrivateProtocolCMD)dataBuffer[4];
        //    switch (cmd)
        //    {
        //        default:
        //            break;
        //    }
        //    return null;
        //}

        /// <summary>
        /// 系统内部协议执行
        /// </summary>
        /// <param name="recvCount"></param>
        /// <param name="buffer"></param>
        /// <param name="clientSocket"></param>
        /// <param name="clientPoint"></param>
        //private BaseProtocol SystemProtocolExecute(int recvCount, byte[] dataBuffer, Socket clientSocket, EndPoint clientPoint)
        //{
            //Enums.Protocol.SystemProtocolCMD cmd = (Enums.Protocol.SystemProtocolCMD)dataBuffer[4];
            //switch (cmd)
            //{
            //    case Enums.Protocol.SystemProtocolCMD.上报文本消息:
            //        var model_98 = ProtocolConverter.Converter.ToModel<ProtocolConverter.ProtocolModel.SystemProtocol.SystemCMD_0x98>(dataBuffer);
            //        richTextBox1.Text = richTextBox1.Text.Insert(0, $"{model_98.Message + Environment.NewLine}");
            //        break;
            //    default:
            //        break;
            //}
            //return null;
       // }


        private void btn_Start_CentralController_Click(object sender, EventArgs e)
        {
            //bool isDebug = true;

            //Common.Helper.WindowsCMDHelper.StartNetCore($@"{(isDebug ? @"E:\Project\EB_V2\CentralController\bin\Debug\netcoreapp2.0\" : @"D:\EB_V2\CentralController\")}CentralController.dll");
            //Thread.Sleep(2000);

            //btn_Start_CentralController.Enabled = false;

            //btn_start_other_system.Enabled = true;
            //btn_stop_CentralController.Enabled = true;
        }

        private void btn_stop_CentralController_Click(object sender, EventArgs e)
        {
            //Socket centralCtrlSystem = SocketHelper.ConnectTCPServer(Config.GetInstance().CentralControllerSystem_IP, Config.GetInstance().CentralControllerSystem_TCP_Port);
            //byte[] buffer = centralCtrlSystem.M5_TCP_VirtualHTTP(ProtocolConverter.Converter.ToBuffer(new SystemCMD_0x06()));
            //SystemCMD_0x99 result = ProtocolConverter.Converter.ToModel<SystemCMD_0x99>(buffer);
            //if(result.Is_Success == (byte)Enums.Protocol.Is_Success.成功)
            //{
            //    //Cache.RAM.SystemSocketCache.GetInstance().DestroyTCPServer(Enums.SystemType.中控系统);
            //    btn_Start_CentralController.Enabled = true;

            //    btn_stop_CentralController.Enabled = false;
            //    btn_start_other_system.Enabled = false;
            //}
        }

        private void btn_start_other_system_Click(object sender, EventArgs e)
        {
            //Socket centralCtrlSystem = SocketHelper.ConnectTCPServer(Config.GetInstance().CentralControllerSystem_IP, Config.GetInstance().CentralControllerSystem_TCP_Port);
            //centralCtrlSystem.Send(ProtocolConverter.Converter.ToBuffer(new SystemCMD_0x02()));

            //btn_close_other_system.Enabled = true;
            //btn_start_other_system.Enabled = false;
            //btn_stop_CentralController.Enabled = false;
        }

        private void btn_close_other_system_Click(object sender, EventArgs e)
        {
            //Socket centralCtrlSystem = SocketHelper.ConnectTCPServer(Config.GetInstance().CentralControllerSystem_IP, Config.GetInstance().CentralControllerSystem_TCP_Port);
            ////centralCtrlSystem.Send(ProtocolConverter.Converter.ToBuffer(new SystemCMD_0x04()));
            //Task t = Task.Factory.StartNew(()=>
            //{
            //    // 要运行的代码
            //    byte[] buffer = centralCtrlSystem.M5_TCP_VirtualHTTP(ProtocolConverter.Converter.ToBuffer(new SystemCMD_0x04()));

            //    btn_close_other_system.Enabled = false;
            //    btn_start_other_system.Enabled = true;
            //    btn_stop_CentralController.Enabled = true;
            //});
        }

        private void btn_get_all_system_starus_Click(object sender, EventArgs e)
        {
            //SystemStatusThread();
        }

        private void SystemStatusThread()
        {
            while (true)
            {
                try
                {
                    //Socket centralCtrlSystem = SocketHelper.ConnectTCPServer(Config.GetInstance().CentralControllerSystem_IP, Config.GetInstance().CentralControllerSystem_TCP_Port);
                    //if (centralCtrlSystem != null)
                    //{
                    //    byte[] dataBuffer = centralCtrlSystem.M5_TCP_VirtualHTTP(ProtocolConverter.Converter.ToBuffer(new SystemCMD_0x20()));
                    //    var model_06 = ProtocolConverter.Converter.ToModel<SystemCMD_0x20>(dataBuffer);
                    //    foreach (var item in model_06.SystemList)
                    //    {
                    //        Color fontColor = item.IsOnline ? Color.Green : Color.OrangeRed;
                    //        string text = item.IsOnline ? "●运行中●" : "×未启动×";
                    //        switch (item.SystemType)
                    //        {
                    //            case Enums.SystemType.消息指令调度系统:
                    //                lbl_MessageDispatcher_status.ForeColor = fontColor;
                    //                lbl_MessageDispatcher_status.Text = text;
                    //                break;
                    //            case Enums.SystemType.音频转码处理系统:
                    //                lbl_AudioCoder_status.ForeColor = fontColor;
                    //                lbl_AudioCoder_status.Text = text;
                    //                break;
                    //            case Enums.SystemType.指令转码处理系统:
                    //                lbl_CMDCoder_status.ForeColor = fontColor;
                    //                lbl_CMDCoder_status.Text = text;
                    //                break;
                    //            case Enums.SystemType.音频存储处理系统:
                    //                lbl_FileStorager_status.ForeColor = fontColor;
                    //                lbl_FileStorager_status.Text = text;
                    //                break;
                    //            case Enums.SystemType.异步回传处理系统:
                    //                lbl_AsynReceiver_status.ForeColor = fontColor;
                    //                lbl_AsynReceiver_status.Text = text;
                    //                break;
                    //            case Enums.SystemType.心跳检测处理系统:
                    //                lbl_HeartbeatChecker_status.ForeColor = fontColor;
                    //                lbl_HeartbeatChecker_status.Text = text;
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //}
                }
                catch (Exception)
                {

                }
                Thread.Sleep(2000);
            }
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认是否退出", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Socket centralCtrlSystem = SocketHelper.ConnectTCPServer(Config.GetInstance().CentralControllerSystem_IP, Config.GetInstance().CentralControllerSystem_TCP_Port);
                //if (centralCtrlSystem != null)
                //    centralCtrlSystem.Close();
                //System.Diagnostics.Process.GetCurrentProcess().Kill();

            }
        }


    }
}
