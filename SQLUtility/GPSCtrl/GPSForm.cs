using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineGraph.SQLUtility
{
    public partial class GPSForm : Form
    {

        public GPSForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
            ChangeStateMessage(OperatorCode.None);
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
                    this.statueMessageLabel.Text = "接收到网络协议（UDP）数据报，开始解析数据报 .";
                    this.statueProgressbar.Value = 0;
                    this.statueProgressbar.Value = 50;
                    break;
                case OperatorCode.Analyzed:
                    this.statueMessageLabel.Text = "接收网络协议（UDP）数据报，并解析 .";
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
