using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineGraph.DataReceiver
{
    public partial class DataReceiverWnd : UserControl
    {
        public delegate void MapDataColorAdjustEventHandler(object sender);
        public event MapDataColorAdjustEventHandler MapDataColorAdjustHandler;


        #region 实现窗体的单例
        private static DataReceiverWnd _frm;

        public static DataReceiverWnd Create()
        {
            if (_frm == null)
            {
                _frm = new DataReceiverWnd();
            }
            return _frm;
        }

        #endregion

        private DataReceiverWnd()
        {
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeStateMessage(OperatorCode.None);
        }

        private void Form1_Closeing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public void DatagramAnalyzerCtrl_OnOpened(object sender, UdpEventArg e)
        {
            //此处标识网络数据服务打开
            ChangeStateMessage(OperatorCode.Opened);
        }

        public void DatagramAnalyzer_OnReceived(object sender, UdpEventArg e)
        {
            //此处标识接收到数据
            ChangeStateMessage(OperatorCode.Received);
        }

        public void DatagramAnalyzerCtrl_OnAnalyzed(object sender, VCDatagramEventArg e)
        {
            ChangeStateMessage(OperatorCode.Analyzed);

            if (e.Data != null && !string.IsNullOrWhiteSpace(e.Data.DeviceID))
            {
                //此处做数据调用处理//
                if(e.Data.QingQiaodataCount > 0)
                {
                    OperateQJDatagram(e.Data);
                }

                if(e.Data.JIASUDUdataCount > 0)
                {
                    OperateJSDatagram(e.Data);
                }
                
                if(e.Data.CHENJIANGdataCount > 0)
                {
                    OperateSZDatagram(e.Data);
                }
            }
        }

        private async void OperateQJDatagram(VCParamsDatagramModel data)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    Data.UDPData UDPData = new Data.UDPData();

                    UDPData.DeviceID = "QJ" + data.DeviceID;
                 
                    UDPData.QINGJIAO_X = data.QingQiao[0, 0];
                    UDPData.QINGJIAO_Y = data.QingQiao[0, 1];

                    UDPData.Time = data.Time;

                    UDPData.Temprature = data.Temprature;

                    try
                    {
                        m_DataGridViewerWnd.m_QingJiao_DataViewWnd.UpdateListView(UDPData);

                        if (MapDataColorAdjustHandler != null)
                        {
                            object ID = UDPData.DeviceID;
                            MapDataColorAdjustHandler(ID);
                        }
                    }
                    catch (Exception) { }

                    
                });
            }
            catch (Exception) { }
        }

        private async void OperateJSDatagram(VCParamsDatagramModel data)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    Data.UDPData UDPData = new Data.UDPData();

                    UDPData.DeviceID = "JS" + data.DeviceID;

                    UDPData.JIASUDU_X = data.JIASUDU[0, 0];
                    UDPData.JIASUDU_Y = data.JIASUDU[0, 1];
                    UDPData.JIASUDU_Z = data.JIASUDU[0, 2];

                    UDPData.Time = data.Time;

                    UDPData.Temprature = data.Temprature;

                    try
                    {
                        m_DataGridViewerWnd.m_JiaSu_DataViewWnd.UpdateListView(UDPData);

                        if (MapDataColorAdjustHandler != null)
                        {
                            object ID = UDPData.DeviceID;
                            MapDataColorAdjustHandler(ID);
                        }
                    }
                    catch (Exception) { }

                });
            }
            catch (Exception) { }
        }

        private async void OperateSZDatagram(VCParamsDatagramModel data)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    Data.UDPData UDPData = new Data.UDPData();

                    UDPData.DeviceID = "SZ" + data.DeviceID;
                      
                    //UDPData.ZHENDONG = data.ZHENDONG[0];

                    UDPData.CHENJIANG = data.CHENJIANG[0];

                    UDPData.Time = data.Time;

                    //UDPData.Temprature = data.Temprature;

                    try
                    {
                        m_DataGridViewerWnd.m_ShuiZhun_DataViewWnd.UpdateListView(UDPData);

                        if (MapDataColorAdjustHandler != null)
                        {
                            object ID = UDPData.DeviceID;
                            MapDataColorAdjustHandler(ID);
                        }
                    }
                    catch (Exception) { }
                });
            }
            catch (Exception) { }
        }

        public  void DatagramAnalyzerCtrl_OnClosed(object sender, UdpEventArg e)
        {
            //此处标识网络数据服务关闭
            ChangeStateMessage(OperatorCode.Closed);
        }


        private void ChangeStateMessage(OperatorCode code)
        {
            if(this.statusStrip1.InvokeRequired)
            {
                Action<OperatorCode> action = new Action<OperatorCode>(ChangeStateMessage);
                this.Invoke(action, code);
                return;
            }

            switch (code)
            {
                case OperatorCode.Opening:
                    this.statueMessageLabel.Text = "正在打开网络服务 ...";
                    break;
                case OperatorCode.Opened:
                    this.statueMessageLabel.Text = "网络服务已经就绪 .";
                    break;
                case OperatorCode.Closing:
                    this.statueMessageLabel.Text = "正在停止网络服务 ...";
                    break;
                case OperatorCode.Closed:
                    this.statueMessageLabel.Text = "网络服务已经停止 .";
                    this.statueProgressbar.Value = 0;
                    break;
                case OperatorCode.Received:
                    this.statueMessageLabel.Text = "接收到数据报";
                    this.statueProgressbar.Value = 0;
                    this.statueProgressbar.Value = 50;
                    break;
                case OperatorCode.Analyzed:
                    this.statueMessageLabel.Text = "解析数据报";
                    this.statueProgressbar.Value = 100;
                    break;
                case OperatorCode.Error:
                    this.statueMessageLabel.Text = "发生错误，重新接收数据 .";
                    break;
                default:
                    this.statueMessageLabel.Text = "以就绪，等待操作 .";
                    break;
            }
        }

        //操作方式
        enum OperatorCode : byte
        {
            None = 0x00,
            Closing,
            Closed,
            Opening,
            Opened,
            Received,
            Analyzed,
            Error,
        }
    }
}
