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
    public partial class DataCaptureWnd : Form
    {
        //private const string MESSAGEPREFIX = "#";
        private static readonly VCDatagramAnalyzer VCDatagramAnalyzer;
        private readonly int _Port = 6300;

        #region 实现窗体的单例
        private static DataCaptureWnd _frm;

        public static DataCaptureWnd Create()
        {
            if (_frm == null)
            {
                _frm = new DataCaptureWnd();
            }
            return _frm;
        }

        #endregion

        static DataCaptureWnd()
        {
            VCDatagramAnalyzer = new VCDatagramAnalyzer();
        }

        private DataCaptureWnd()
        {
            InitializeComponent();

            this.txtPort.Text = string.Format("{0}", _Port);

            VCDatagramAnalyzer.OnOpened += VCDatagramAnalyzer_OnOpened;
            VCDatagramAnalyzer.OnClosed += VCDatagramAnalyzer_OnClosed;
            VCDatagramAnalyzer.OnReceived += VCDatagramAnalyzer_OnReceived;
            VCDatagramAnalyzer.OnAnalyzed += VCDatagramAnalyzer_OnAnalyzed;
            VCDatagramAnalyzer.OnException += VCDatagramAnalyzer_OnException;

            //InsertTipDisplayAt();
            //ChangeStateMessage(OperatorCode.None);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void Form1_Closeing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ChangeBtnStatue(bool flag = true)
        {
            if(this.btnStart.InvokeRequired)
            {
                this.Invoke(new Action<bool>(ChangeBtnStatue), flag);
                return;
            }

            this.btnStop.Enabled = !flag;
            this.btnStart.Enabled = flag;
        }

        void VCDatagramAnalyzer_OnException(object sender, UdpEventArg e)
        {
            //此处代码执行发生异常
            //日志文件记录当前错误
            //ChangeStateMessage(OperatorCode.Error);
        }

        void VCDatagramAnalyzer_OnAnalyzed(object sender, VCDatagramEventArg e)
        {
            //ChangeStateMessage(OperatorCode.Analyzed);

            m_DataReceiverWnd.DatagramAnalyzerCtrl_OnAnalyzed(sender, e);
        }

        void VCDatagramAnalyzer_OnReceived(object sender, UdpEventArg e)
        {
            //此处标识接收到数据
            //ChangeStateMessage(OperatorCode.Received);
            m_DataReceiverWnd.DatagramAnalyzer_OnReceived(sender,e);
        }

        void VCDatagramAnalyzer_OnClosed(object sender, UdpEventArg e)
        {
            //此处标识网络数据服务关闭
            //ChangeStateMessage(OperatorCode.Closed);
            ChangeBtnStatue(true);

            m_DataReceiverWnd.DatagramAnalyzerCtrl_OnClosed(sender,e);
        }

        void VCDatagramAnalyzer_OnOpened(object sender, UdpEventArg e)
        {
            //此处标识网络数据服务打开
            //ChangeStateMessage(OperatorCode.Opened);
            ChangeBtnStatue(false);

            m_DataReceiverWnd.DatagramAnalyzerCtrl_OnOpened(sender,e);
        }

        //private void DisplayAt(string msg)
        //{
        //    if(listMessage.InvokeRequired)
        //    {
        //        Action<string> action = new Action<string>(DisplayAt);
        //        this.Invoke(action, msg);
        //        return;
        //    }
        //    int count = this.listMessage.Items.Count;
        //    this.listMessage.Items[count - 1].SubItems[1].Text = msg;

        //    if (count == 8)
        //        this.listMessage.Items.RemoveAt(0);

        //    InsertTipDisplayAt();
        //}

        //private void InsertTipDisplayAt()
        //{
        //    ListViewItem item = new ListViewItem(new string[] { MESSAGEPREFIX, "" });
        //    this.listMessage.Items.Add(item);
        //}

        //获取本地Ipv4地址
        //private string GetLocalIpv4()
        //{
        //    string hostname = System.Net.Dns.GetHostName();
        //    System.Net.IPAddress[] addresses = System.Net.Dns.GetHostAddresses(hostname);
        //    System.Net.IPAddress addr = addresses.FirstOrDefault(t =>
        //        t.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        //    return addr.ToString();
        //}

        public void StartNetData()
        {
            btnStart_Click(null,null);
        }

        public void CloseNetData()
        {
            btnStop_Click(null,null);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            VCDatagramAnalyzer.Open(_Port);
            //ChangeStateMessage(OperatorCode.Opening);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            VCDatagramAnalyzer.Close();
            //ChangeStateMessage(OperatorCode.Closing);
        }

        //private void ChangeStateMessage(OperatorCode code)
        //{
        //    string text;

        //    switch (code)
        //    {
        //        case OperatorCode.Opening:
        //            text = "正在打开网络服务 ...";
        //            this.btnStart.Enabled = false;
        //            break;
        //        case OperatorCode.Opened:
        //            text = "网络服务已经就绪 .";
        //            break;
        //        case OperatorCode.Closing:
        //            text = "正在停止网络服务 ...";
        //            this.btnStop.Enabled = false;
        //            break;
        //        case OperatorCode.Closed:
        //            text = "网络服务已经停止 .";
        //            break;
        //        case OperatorCode.Received:
        //            text = "接收到网络协议数据报，开始解析数据报 .";
        //            break;
        //        case OperatorCode.Analyzed:
        //            text = "接收网络协议数据报，并解析 .";
        //            break;
        //        case OperatorCode.Error:
        //            text = "发生错误，重新接收数据 .";
        //            break;
        //        default:
        //            text = "以就绪，等待操作 .";
        //            break;
        //    }

        //    //DisplayAt(text);
        //}

        //操作方式
        //enum OperatorCode : byte
        //{
        //    None = 0x00,
        //    Closing,
        //    Closed,
        //    Opening,
        //    Opened,
        //    Received,
        //    Analyzed,
        //    Error,
        //}
    }
}
