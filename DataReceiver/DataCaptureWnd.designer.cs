namespace LineGraph.DataReceiver
{
    partial class DataCaptureWnd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataCaptureWnd));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            //this.txtIpv4 = new System.Windows.Forms.TextBox();
            //this.lblIpv4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            //this.listMessage = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            m_DataReceiverWnd = DataReceiverWnd.Create();

            m_ModbusDataAcquisitionWnd = new ModbusDataAcquisition();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "go.png");
            this.iconList.Images.SetKeyName(1, "start.png");
            this.iconList.Images.SetKeyName(2, "stop.png");
            this.iconList.Images.SetKeyName(3, "pause.png");
            this.iconList.Images.SetKeyName(4, "accepte.png");
            this.iconList.Images.SetKeyName(5, "cross.png");

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnStop);
            this.splitContainer2.Panel1.Controls.Add(this.btnStart);
            //this.splitContainer2.Panel1.Controls.Add(this.txtIpv4);
            //this.splitContainer2.Panel1.Controls.Add(this.lblIpv4);
            this.splitContainer2.Panel1.Controls.Add(this.txtPort);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            //this.splitContainer2.Panel2.Controls.Add(this.listMessage);
            this.splitContainer2.Size = new System.Drawing.Size(260, 399);
            this.splitContainer2.SplitterDistance = 242;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.ImageKey = "stop.png";
            this.btnStop.ImageList = this.iconList;
            this.btnStop.Location = new System.Drawing.Point(19, 154);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(170, 57);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止（&T）";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.ImageKey = "go.png";
            this.btnStart.ImageList = this.iconList;
            this.btnStart.Location = new System.Drawing.Point(19, 91);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(170, 57);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始（&S）";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //// 
            //// txtIpv4
            //// 
            //this.txtIpv4.Enabled = false;
            //this.txtIpv4.Location = new System.Drawing.Point(89, 53);
            //this.txtIpv4.Name = "txtIpv4";
            //this.txtIpv4.ReadOnly = true;
            //this.txtIpv4.Size = new System.Drawing.Size(100, 21);
            //this.txtIpv4.TabIndex = 4;
            //// 
            //// lblIpv4
            //// 
            //this.lblIpv4.AutoSize = true;
            //this.lblIpv4.Location = new System.Drawing.Point(17, 59);
            //this.lblIpv4.Name = "lblIpv4";
            //this.lblIpv4.Size = new System.Drawing.Size(65, 12);
            //this.lblIpv4.TabIndex = 3;
            //this.lblIpv4.Text = "Ipv4地址：";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(89, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "通信端口：";
            // 
            // listMessage
            // 
            //this.listMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            //this.columnHeader6,
            //this.columnHeader7});
            //this.listMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.listMessage.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            //this.listMessage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            //this.listMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            //this.listMessage.Location = new System.Drawing.Point(0, 0);
            //this.listMessage.Name = "listMessage";
            //this.listMessage.Size = new System.Drawing.Size(260, 149);
            //this.listMessage.TabIndex = 0;
            //this.listMessage.UseCompatibleStateImageBehavior = false;
            //this.listMessage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 19;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 156;
            // 
            // DataCaptureWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 421);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataCaptureWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据采集";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closeing);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
       // private System.Windows.Forms.TextBox txtIpv4;
        //private System.Windows.Forms.Label lblIpv4;
        //private System.Windows.Forms.ListView listMessage;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;

        public DataReceiverWnd m_DataReceiverWnd;

        public ModbusDataAcquisition m_ModbusDataAcquisitionWnd;
    }
}

