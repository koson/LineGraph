namespace LineGraph.GUI
{
    partial class WndMenu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
           
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_WorkSpaceCtrl = new System.Windows.Forms.ToolStripMenuItem();

            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Length = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Area = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Height = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ClearResult = new System.Windows.Forms.ToolStripMenuItem();

            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_LayerStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Property = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SQL = new System.Windows.Forms.ToolStripMenuItem();
            //this.MenuItem_Buffer = new System.Windows.Forms.ToolStripMenuItem();

            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            MenuItem_Sensor = new System.Windows.Forms.ToolStripMenuItem();
            MenuItem_Worker = new System.Windows.Forms.ToolStripMenuItem();
            MenuItem_Videoer = new System.Windows.Forms.ToolStripMenuItem();

            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Designer = new System.Windows.Forms.ToolStripMenuItem();

            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.menuStrip6 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_ShowScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_CloseWnd = new System.Windows.Forms.ToolStripMenuItem();

            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.menuStrip6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1440, 30);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1440, 30);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件";
            //this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_WorkSpaceCtrl});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1440, 21);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_WorkSpaceCtrl
            // 
            this.MenuItem_WorkSpaceCtrl.Name = "MenuItem_WorkSpaceCtrl";
            this.MenuItem_WorkSpaceCtrl.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_WorkSpaceCtrl.Text = "工作空间";
            this.MenuItem_WorkSpaceCtrl.Click += new System.EventHandler(this.MenuItem_WorkSpaceCtrl_Click);

            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.menuStrip2);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1440, 30);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "测量";
            //this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Length,
            this.MenuItem_Area,
            this.MenuItem_Height,
            this.MenuItem_ClearResult});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1440, 21);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // MenuItem_Length
            // 
            this.MenuItem_Length.Name = "MenuItem_Length";
            this.MenuItem_Length.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Length.Text = "距离";
            this.MenuItem_Length.Click += new System.EventHandler(this.MenuItem_Length_Click);
            // 
            // MenuItem_Area
            // 
            this.MenuItem_Area.Name = "MenuItem_Area";
            this.MenuItem_Area.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Area.Text = "面积";
            this.MenuItem_Area.Click += new System.EventHandler(this.MenuItem_Area_Click);
            // 
            // MenuItem_Height
            // 
            this.MenuItem_Height.Name = "MenuItem_Angle";
            this.MenuItem_Height.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Height.Text = "高度";
            this.MenuItem_Height.Click += new System.EventHandler(this.MenuItem_Height_Click);
            // 
            // MenuItem_ClearResult
            // 
            this.MenuItem_ClearResult.Name = "MenuItem_ClearResult";
            this.MenuItem_ClearResult.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_ClearResult.Text = "清空";
            this.MenuItem_ClearResult.Click += new System.EventHandler(this.MenuItem_ClearResult_Click);

            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.menuStrip3);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1440, 30);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "单体";
            //this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_LayerStyle,
            this.MenuItem_Property,
            this.MenuItem_SQL});
            this.menuStrip3.Location = new System.Drawing.Point(3, 3);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(1440, 21);
            this.menuStrip3.TabIndex = 1;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // MenuItem_LayerStyle
            // 
            this.MenuItem_LayerStyle.Name = "MenuItem_LayerStyle";
            this.MenuItem_LayerStyle.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_LayerStyle.Text = "图层风格";
            this.MenuItem_LayerStyle.Click += new System.EventHandler(this.MenuItem_LayerStyle_Click);
            // 
            // MenuItem_Property
            // 
            this.MenuItem_Property.Name = "MenuItem_Property";
            this.MenuItem_Property.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Property.Text = "属性查询";
            this.MenuItem_Property.Click += new System.EventHandler(this.MenuItem_Property_Click);
            // 
            // MenuItem_SQL
            // 
            this.MenuItem_SQL.Name = "MenuItem_SQL";
            this.MenuItem_SQL.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_SQL.Text = "SQL查询";
            this.MenuItem_SQL.Click += new System.EventHandler(this.MenuItem_SQL_Click);
            //// 
            //// MenuItem_Buffer
            //// 
            //this.MenuItem_Buffer.Name = "MenuItem_Buffer";
            //this.MenuItem_Buffer.Size = new System.Drawing.Size(68, 21);
            //this.MenuItem_Buffer.Text = "Buffer查询";
            //this.MenuItem_Buffer.Click += new System.EventHandler(this.MenuItem_Buffer_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.menuStrip4);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1440, 30);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "监测";
            //this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // menuStrip4
            // 
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Sensor,
            this.MenuItem_Worker,
            this.MenuItem_Videoer});
            this.menuStrip4.Location = new System.Drawing.Point(3, 3);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(1440, 21);
            this.menuStrip4.TabIndex = 1;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // MenuItem_Sensor
            // 
            this.MenuItem_Sensor.Name = "MenuItem_Sensor";
            this.MenuItem_Sensor.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Sensor.Text = "传感监测";
            this.MenuItem_Sensor.Click += new System.EventHandler(this.MenuItem_Sensor_Click);
            // 
            // MenuItem_Worker
            // 
            this.MenuItem_Worker.Name = "MenuItem_Worker";
            this.MenuItem_Worker.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Worker.Text = "人员监测";
            this.MenuItem_Worker.Click += new System.EventHandler(this.MenuItem_Worker_Click);
            // 
            // MenuItem_Videoer
            // 
            this.MenuItem_Videoer.Name = "MenuItem_Videoer";
            this.MenuItem_Videoer.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Videoer.Text = "视频监控";
            this.MenuItem_Videoer.Click += new System.EventHandler(this.MenuItem_Videoer_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.menuStrip5);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1440, 30);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "设计";
            //this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // menuStrip5
            // 
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Designer});
            this.menuStrip5.Location = new System.Drawing.Point(3, 3);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Size = new System.Drawing.Size(1440, 21);
            this.menuStrip5.TabIndex = 1;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // MenuItem_ShowScreen
            // 
            this.MenuItem_Designer.Name = "MenuItem_Designer";
            this.MenuItem_Designer.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Designer.Text = "草图设计";
            this.MenuItem_Designer.Click += new System.EventHandler(this.MenuItem_Designer_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.menuStrip6);
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1440, 30);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "桌面";
            //this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // menuStrip6
            // 
            this.menuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ShowScreen,
            this.MenuItem_CloseWnd});
            this.menuStrip6.Location = new System.Drawing.Point(3, 3);
            this.menuStrip6.Name = "menuStrip6";
            this.menuStrip6.Size = new System.Drawing.Size(1440, 21);
            this.menuStrip6.TabIndex = 1;
            this.menuStrip6.Text = "menuStrip6";
            // 
            // MenuItem_ShowScreen
            // 
            this.MenuItem_ShowScreen.Name = "MenuItem_ShowScreen";
            this.MenuItem_ShowScreen.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_ShowScreen.Text = "显示桌面";
            this.MenuItem_ShowScreen.Click += new System.EventHandler(this.MenuItem_ShowScreen_Click);
            // 
            // MenuItem_CloseWnd
            // 
            this.MenuItem_CloseWnd.Name = "MenuItem_CloseWnd";
            this.MenuItem_CloseWnd.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_CloseWnd.Text = "关闭窗口";
            this.MenuItem_CloseWnd.Click += new System.EventHandler(this.MenuItem_CloseWnd_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WndMenu";
            this.Controls.Add(this.tabControl1);
            this.ClientSize = new System.Drawing.Size(1440, 60);

            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.menuStrip6.ResumeLayout(false);
            this.menuStrip6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_WorkSpaceCtrl;

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Length;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Area;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Height;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ClearResult;

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_LayerStyle;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Property;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SQL;
        //private System.Windows.Forms.ToolStripMenuItem MenuItem_Buffer;

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Sensor;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Worker;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Videoer;

        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Designer;


        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.MenuStrip menuStrip6;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_CloseWnd;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ShowScreen;

    }
}