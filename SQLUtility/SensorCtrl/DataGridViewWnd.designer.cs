namespace LineGraph.SQLUtility
{
    partial class DataGridViewWnd 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layers_tabControl = new System.Windows.Forms.TabControl();
            this.水准仪Page = new System.Windows.Forms.TabPage();
            this.倾角仪Page = new System.Windows.Forms.TabPage();
            this.加速计Page = new System.Windows.Forms.TabPage();
            m_QingJiao_DataViewWnd = new QingJiao_DataViewWnd();
            m_JiaSu_DataViewWnd = new JiaSu_DataViewWnd();
            m_ShuiZhun_DataViewWnd = new ShuiZhun_DataViewWnd();


            this.layers_tabControl.SuspendLayout();
            this.水准仪Page.SuspendLayout();
            this.倾角仪Page.SuspendLayout();
            this.加速计Page.SuspendLayout();

            m_QingJiao_DataViewWnd.SuspendLayout();
            m_JiaSu_DataViewWnd.SuspendLayout();
            m_ShuiZhun_DataViewWnd.SuspendLayout();

            this.SuspendLayout();


            // 
            // 水准仪Page
            // 
            this.m_ShuiZhun_DataViewWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.水准仪Page.Controls.Add(this.m_ShuiZhun_DataViewWnd);
            this.水准仪Page.Location = new System.Drawing.Point(0, 0);
            this.水准仪Page.Name = "mapLayerPage";
            this.水准仪Page.Padding = new System.Windows.Forms.Padding(3);
            this.水准仪Page.Size = new System.Drawing.Size(200, 390);
            this.水准仪Page.TabIndex = 0;
            this.水准仪Page.Text = "水准仪";
            //this.水准仪Page.Text = "压电传感器";
            this.水准仪Page.UseVisualStyleBackColor = true;
            // 
            // 倾角仪Page
            // 
            this.m_QingJiao_DataViewWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.倾角仪Page.Controls.Add(this.m_QingJiao_DataViewWnd);
            this.倾角仪Page.Location = new System.Drawing.Point(0, 0);
            this.倾角仪Page.Name = "sceneLayerPage";
            this.倾角仪Page.Padding = new System.Windows.Forms.Padding(3);
            this.倾角仪Page.Size = new System.Drawing.Size(200, 390);
            this.倾角仪Page.TabIndex = 1;
            this.倾角仪Page.Text = "倾角仪";
            //this.倾角仪Page.Text = "微波交通检测器";
            this.倾角仪Page.UseVisualStyleBackColor = true;
            // 
            // 加速计Page
            // 
            this.m_JiaSu_DataViewWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.加速计Page.Controls.Add(this.m_JiaSu_DataViewWnd);
            this.加速计Page.Location = new System.Drawing.Point(0, 0);
            this.加速计Page.Name = "sceneLayerPage";
            this.加速计Page.Padding = new System.Windows.Forms.Padding(3);
            this.加速计Page.Size = new System.Drawing.Size(200, 390);
            this.加速计Page.TabIndex = 1;
            this.加速计Page.Text = "加速计";
            //this.加速计Page.Text = "超声波传感器";
            this.加速计Page.UseVisualStyleBackColor = true;
            // 
            // layers_tabControl
            // 
            this.layers_tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.layers_tabControl.Controls.Add(this.水准仪Page);
            this.layers_tabControl.Controls.Add(this.倾角仪Page);
            this.layers_tabControl.Controls.Add(this.加速计Page);
            this.layers_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layers_tabControl.Location = new System.Drawing.Point(0, 0);
            this.layers_tabControl.Name = "layers_tabControl";
            this.layers_tabControl.SelectedIndex = 0;
            this.layers_tabControl.Size = new System.Drawing.Size(200, 390);
            this.layers_tabControl.TabIndex = 0;


            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 399);
            this.Controls.Add(this.layers_tabControl);
            this.Text = "DataGridWnd";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AutoScroll = true;
    
            this.layers_tabControl.ResumeLayout(false);
            this.水准仪Page.ResumeLayout(false);
            this.倾角仪Page.ResumeLayout(false);
            this.加速计Page.ResumeLayout(false);
            m_QingJiao_DataViewWnd.ResumeLayout(false);
            m_JiaSu_DataViewWnd.ResumeLayout(false);
            m_ShuiZhun_DataViewWnd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

      
        public QingJiao_DataViewWnd m_QingJiao_DataViewWnd;
        public JiaSu_DataViewWnd m_JiaSu_DataViewWnd;
        public ShuiZhun_DataViewWnd m_ShuiZhun_DataViewWnd;


        private System.Windows.Forms.TabControl layers_tabControl;
        private System.Windows.Forms.TabPage 水准仪Page;
        private System.Windows.Forms.TabPage 倾角仪Page;
        private System.Windows.Forms.TabPage 加速计Page;
    }
}