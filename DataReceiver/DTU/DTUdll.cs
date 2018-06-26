using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LineGraph.DataReceiver
{
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    [StructLayout(LayoutKind.Sequential, Size = 40)]
    //可以指定编码类型
    internal struct DTUInfoStruct
    {
        public uint m_modemId;              //Modem模块的ID号
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] m_phoneno;             //Modem的11位电话号码，必须以'\0'字符结尾  
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_dynip;              //Modem的4位动态ip地址   
        public uint m_conn_time;            //Modem模块最后一次建立TCP连接的时间 
        public uint m_refresh_time;         //Modem模块最后一次收发数据的时间 
    }

    // DTU数据包的数据结构
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]//可以指定编码类型
    public struct DTUDataStruct
    {
        public uint m_modemId;                  // Modem模块的ID号
        public uint m_recv_time;                //接收到数据包的时间
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1451)]
        public byte[] m_data_buf;               //存储接收到的数据
        public ushort m_data_len;               //接收到的数据包长度
        public byte m_data_type;                //接收到的数据包类型,
                                                //	0x01：用户数据包 
                                                //	0x02：对控制命令帧的回应
    }

    internal class DTUdll
    {
        #region API

        [DllImport(@"gprsdll.dll")]
        //public static extern bool DLLStartService(UInt16 port);
        private static extern bool DLLStartService(ushort uiListenPort);
        //功能：启动服务器的数据服务

        [DllImport(@"gprsdll.dll")]
        //public static extern bool DLLStopService();
        private static extern bool DLLStopService();
        //功能：停止服务器的数据服务

        [DllImport(@"gprsdll.dll")]
        //public static extern bool DLLGetNextData(ref DTUDataStruct pDataStruct, ushort waitseconds);
        private static extern bool DLLGetNextData(ref DTUDataStruct pDataStruct, ushort waitseconds);
        //功能：读取下一条DTU送上来的信息

        [DllImport(@"gprsdll.dll")]
        //public static extern bool DLLSendData(uint modemId, ushort len, byte[] buf);
        private static extern bool DLLSendData(uint modemId, ushort len, byte[] buf);
        //功能：向指定ID号的DTU发送数据

        [DllImport(@"gprsdll.dll")]
        //public static extern bool DLLSendControl(uint modemId, ushort len, byte[] buf);
        private static extern bool DLLSendControl(uint modemId, ushort len, byte[] buf);
        //功能：取得指定ID号的Modem发送控制命令

        [DllImport(@"gprsdll.dll")]
        //public static extern UInt32 DLLGetModemCount();
        private static extern int DLLGetModemCount();
        //功能：取得当前在线的所有的DTU的总数

        [DllImport(@"gprsdll.dll")]
       // public static extern bool DLLGetModemByPosition(UInt32 pos, ref DTUInfoStruct pModemInfo);
        private static extern bool DLLGetModemByPosition(uint pos, ref DTUInfoStruct pModemInfo);
        //功能：取得指定位置的DTU的数据

        [DllImport(@"gprsdll.dll")]
        //public static extern void DLLGetLastError(byte[] str, Int32 nMaxBufSize);
        private static extern void DLLGetLastError(System.Text.StringBuilder str, int nMaxBufSize); 
        //功能：获得先前API执行时发生的错误

        [DllImport(@"gprsdll.dll")]
        public static extern bool DLLCloseModemById(UInt32 modemId);
        //功能：断开指定ID号的Socket连接
        #endregion

        private DTUdll()
        {
        }

        private static DTUdll _instance;
        public static DTUdll Instance
        {
            get
            {
                if (_instance == null) _instance = new DTUdll();
                return _instance;
            }
        }

        private bool _started = false;
        public bool Started
        {
            private set
            {
                _started = value;
            }
            get
            {
                return _started;
            }
        }

        public string _lastError;
        public string LastError
        {
            private set
            {
                _lastError = value;
            }
            get
            {
                return _lastError;
            }
        }

        private ushort _listenPort = 0;
        public ushort ListenPort
        {
            private set
            {
                _listenPort = value;
            }
            get
            {
                return _listenPort;
            }
        }

        private void GetLastError()
        {
            try
            {
                StringBuilder sb = new StringBuilder(256);
                DLLGetLastError(sb, 256);
                LastError = sb.ToString();
            }
            catch(Exception ee)
            {
                LastError = ee.Message;
            }
        }

        public bool StartService(ushort port)
        {
            try
            {
                if (this.Started) throw new Exception("服务已经启动");
                bool flag = DLLStartService(port);
                if (!flag)
                    this.GetLastError();
                else
                    LastError = null;
                this.Started = flag;
                return flag;
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }

        public bool StopService()
        {
            try
            {
                if (!this.Started) throw new Exception("服务尚未启动");
                bool flag = DLLStopService();
                if (!flag)
                    this.GetLastError();
                else
                    LastError = null;
                this.Started = !flag;
                return flag;
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }

        public bool GetDTUList(out Dictionary<uint, DTUInfoStruct> dtuList)
        {
            try
            {
                int cnt = DLLGetModemCount();
                //System.Diagnostics.Debug.WriteLine("Count="+cnt.ToString());
                dtuList = new Dictionary<uint, DTUInfoStruct>();
                for (uint ii = 0; ii < cnt; ii++)
                {
                    DTUInfoStruct dtu = new DTUInfoStruct();
                    bool flag = DLLGetModemByPosition(ii, ref dtu);
                    if (!flag)
                    {
                        this.GetLastError();
                        return false;
                    }
                    else
                    {
                        dtuList.Add(dtu.m_modemId,dtu);
                    }
                }
                LastError = null;
                return true;
            }
            catch(Exception ee)
            {
                LastError = ee.Message;
                dtuList = new Dictionary<uint, DTUInfoStruct>();
                return false;
            }
        }

        public bool GetNextData(out DTUDataStruct dat)
        {
            dat = new DTUDataStruct();
            return DLLGetNextData(ref dat, 0);
        }

        public bool SendControl(uint id, string text)
        {
            try
            {
                byte[] bts = UnicodeEncoding.Default.GetBytes(text+"\r");
                // 采用普通控制方式, 请屏蔽专用控制方式内容
                //return this.SendHex(id, bts); 
                // 采用专用控制方式, 请屏蔽普通控制方式内容
                if (DLLSendControl(id, (ushort)bts.Length, bts))
                {
                    LastError = null;
                    return true;
                }
                else
                {
                    this.GetLastError();
                    return false;
                } 
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }

        public bool SendText(uint id, string text)
        {
            try
            {
                return this.SendHex(id, UnicodeEncoding.Default.GetBytes(text));
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }

        public bool SendHex(uint id, byte[] bts)
        {
            try
            {
                return this.SendHex(id, bts, (ushort)bts.Length);
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }

        public bool SendHex(uint id, byte[] bts, int startIndex, ushort lenth)
        {
            try
            {
                lenth = (ushort)Math.Min(lenth, bts.Length - startIndex);
                byte[] bsnd = new byte[lenth];
                Array.Copy(bts, startIndex, bsnd, 0, lenth);
                return SendHex(id, bsnd, lenth);
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }

        public bool SendHex(uint id, byte[] bts,ushort lenth)
        {
            try
            {
                if (DLLSendData(id, lenth, bts))
                {
                    LastError = null;
                    return true;
                }
                else
                {
                    this.GetLastError();
                    return false;
                }
            }
            catch (Exception ee)
            {
                LastError = ee.Message;
                return false;
            }
        }
    }
}