using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Win32;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace LineGraph.Data
{
    public class SerialData
    {
        private SerialPort serialPort = null;
        private Thread _readThread;
        private bool _keepReading;
        private Object thisLock = new object();
        private Byte[] m_readBuffer = null;
        private int m_dataLength;
        /// <summary>
        /// 开启串口监听
        /// </summary>
        public void StartSerialPortMonitor()
        {
            List<string> comList = GetComlist(false); //首先获取本机关联的串行端口列表            
            if (comList.Count == 0)
            {
                MessageBox.Show("提示信息", "当前设备不存在串行端口！"); 
            }
            else
            {
                //string targetCOMPort = ConfigurationManager.AppSettings["COMPort"].ToString();
                //判断串口列表中是否存在目标串行端口
                //if (!comList.Contains(targetCOMPort))
               // {
                   // MessageBox.Show("提示信息", "当前设备不存在配置的串行端口！");
                //}

                serialPort = new SerialPort();

                //设置参数
                //serialPort.PortName = ConfigurationManager.AppSettings["COMPort"].ToString(); //通信端口
                serialPort.PortName = "COM1";
                serialPort.BaudRate = 38400;//Int32.Parse(ConfigurationManager.AppSettings["BaudRate"].ToString()); //串行波特率
                serialPort.DataBits = 8; //每个字节的标准数据位长度
                serialPort.StopBits = StopBits.One; //设置每个字节的标准停止位数
                serialPort.Parity = Parity.None; //设置奇偶校验检查协议
                serialPort.ReadTimeout = 3000; //单位毫秒
                serialPort.WriteTimeout = 3000; //单位毫秒
                                                //串口控件成员变量，字面意思为接收字节阀值，
                                                //串口对象在收到这样长度的数据之后会触发事件处理函数
                                                //一般都设为1
                serialPort.ReceivedBytesThreshold = 1;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(CommDataReceived); //设置数据接收事件（监听）

                try
                {
                    serialPort.Open(); //打开串口
                }
                catch (Exception ex)
                {
                    MessageBox.Show("提示信息", "串行端口打开失败！具体原因：" + ex.Message);
                }

                m_dataLength = 15;
                m_readBuffer = new Byte[m_dataLength];
                
            }
        }

        public void GetSerialData(Byte[] Buffer)
        {
            lock(thisLock)
            {
                Array.Copy(Buffer,m_readBuffer, m_dataLength);
            
            }
        }

        /// <summary>
        /// 串口数据处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommDataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
               lock(thisLock)
                {
                    serialPort.Read(m_readBuffer, 0, m_dataLength); //将数据读入缓存
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示信息", "接收返回消息异常！具体原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Stop()
        {
            serialPort.Close();
        }

        /// <summary>
        /// 获取本机串口列表
        /// </summary>
        /// <param name="isUseReg"></param>
        /// <returns></returns>
        private List<string> GetComlist(bool isUseReg)
        {
            List<string> list = new List<string>();
            try
            {
                if (isUseReg)
                {
                    RegistryKey RootKey = Registry.LocalMachine;
                    RegistryKey Comkey = RootKey.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");

                    String[] ComNames = Comkey.GetValueNames();

                    foreach (String ComNamekey in ComNames)
                    {
                        string TemS = Comkey.GetValue(ComNamekey).ToString();
                        list.Add(TemS);
                    }
                }
                else
                {
                    foreach (string com in SerialPort.GetPortNames())  //自动获取串行口名称  
                        list.Add(com);
                }
            }
            catch
            {
                MessageBox.Show("提示信息", "串行端口检查异常！");
            }
            return list;
        }

        private void StartReadThread()
        {
            _keepReading = true;
            _readThread = new Thread(ReadPort);
            _readThread.Start();
        }
        private void ReadPort()
        {
            while (_keepReading)
            {

                //byte[] readBuffer = new byte[com.ReadBufferSize + 1];
                //try
                //{
                //    int count = 0;
                //    String SerialIn = System.Text.Encoding.ASCII.GetString(readBuffer, 0, count);
                //}
                //catch (TimeoutException) { }
            }

        }
    }
}
