namespace LineGraph.DataReceiver
{
    partial class DataReceiverWnd
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statueProgressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.statueMessageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_DataGridViewerWnd = new SQLUtility.DataGridViewWnd();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statueProgressbar,
            this.statueMessageLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 780-22);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(720, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statueProgressbar
            // 
            this.statueProgressbar.Name = "statueProgressbar";
            this.statueProgressbar.Size = new System.Drawing.Size(500, 16);
            this.statueProgressbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statueMessageLabel
            // 
            this.statueMessageLabel.Name = "statueMessageLabel";
            this.statueMessageLabel.Size = new System.Drawing.Size(69, 17);
            this.statueMessageLabel.Text = "系统就绪 ...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            //// 
            //// m_DataViewerWnd
            //// 
            this.m_DataGridViewerWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_DataGridViewerWnd.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.m_DataGridViewerWnd.Location = new System.Drawing.Point(0, 0);
            this.m_DataGridViewerWnd.Name = "m_DataViewerWnd";
            this.m_DataGridViewerWnd.Size = new System.Drawing.Size(720, 780 - 22);
            this.m_DataGridViewerWnd.TabIndex = 0;

            // 
            // DataReceiverWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 780);
            this.Controls.Add(this.m_DataGridViewerWnd);
            this.Controls.Add(this.statusStrip1);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataReceiverWnd";
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据接收";
            this.Load += new System.EventHandler(this.Form1_Load);
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closeing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private LineGraph.SQLUtility.DataGridViewWnd m_DataGridViewerWnd;
        private System.Windows.Forms.ToolStripProgressBar statueProgressbar;
        private System.Windows.Forms.ToolStripStatusLabel statueMessageLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

