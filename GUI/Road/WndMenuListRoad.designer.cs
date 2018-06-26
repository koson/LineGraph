namespace LineGraph.GUI
{
    partial class WndMenuListRoad 
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
            this.toolStrip1_Menue = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProject = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItem_项目信息 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_视频素材 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_工作空间 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonMeasure = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItem_Length = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Area = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Height = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ClearResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonDataCapture = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItem_DataCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.气象信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交通异常事件信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonMonitor = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItem_监测区域 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_视频监控 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_静力水准监测 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_动态监测 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResource = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItem_User = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Goods = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Finance = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_3Ddesigner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.MenuItem_AddKml = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_RemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Feature3DVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_FlyToObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_RemoveObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Visible = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Selectable = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Editable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1_Menue.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1_Menue
            // 
            this.toolStrip1_Menue.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1_Menue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonProject,
            this.toolStripButtonMeasure,
            this.toolStripButtonDataCapture,
            this.toolStripButtonMonitor,
            this.toolStripButton3,
            this.toolStripButtonResource,
            this.toolStripButton7});
            this.toolStrip1_Menue.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1_Menue.Name = "toolStrip1_Menue";
            this.toolStrip1_Menue.Size = new System.Drawing.Size(1440, 48);
            this.toolStrip1_Menue.Stretch = true;
            this.toolStrip1_Menue.TabIndex = 1;
            this.toolStrip1_Menue.Text = "toolStrip1";
            // 
            // toolStripButtonProject
            // 
            this.toolStripButtonProject.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_项目信息,
            this.MenuItem_视频素材,
            this.MenuItem_工作空间});
            this.toolStripButtonProject.Image = global::LineGraph.GUI.Properties.Resources.项目情况1;
            this.toolStripButtonProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProject.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonProject.Name = "toolStripButtonProject";
            this.toolStripButtonProject.Size = new System.Drawing.Size(109, 46);
            this.toolStripButtonProject.Text = "项目情况";
            // 
            // MenuItem_项目信息
            // 
            this.MenuItem_项目信息.Name = "MenuItem_项目信息";
            this.MenuItem_项目信息.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_项目信息.Text = "项目信息";
            this.MenuItem_项目信息.Click += new System.EventHandler(this.MenuItem_项目信息_Click);
            // 
            // MenuItem_视频素材
            // 
            this.MenuItem_视频素材.Name = "MenuItem_视频素材";
            this.MenuItem_视频素材.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_视频素材.Text = "视频素材";
            this.MenuItem_视频素材.Click += new System.EventHandler(this.MenuItem_视频素材_Click);
            // 
            // MenuItem_工作空间
            // 
            this.MenuItem_工作空间.Name = "MenuItem_工作空间";
            this.MenuItem_工作空间.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_工作空间.Text = "三维场景";
            this.MenuItem_工作空间.Click += new System.EventHandler(this.MenuItem_WorkSpaceCtrl_Click);
            // 
            // toolStripButtonMeasure
            // 
            this.toolStripButtonMeasure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Length,
            this.MenuItem_Area,
            this.MenuItem_Height,
            this.MenuItem_ClearResult});
            this.toolStripButtonMeasure.Image = global::LineGraph.GUI.Properties.Resources.场景测量1;
            this.toolStripButtonMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMeasure.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripButtonMeasure.Name = "toolStripButtonMeasure";
            this.toolStripButtonMeasure.Size = new System.Drawing.Size(109, 44);
            this.toolStripButtonMeasure.Text = "场景测量";
            // 
            // MenuItem_Length
            // 
            this.MenuItem_Length.Name = "MenuItem_Length";
            this.MenuItem_Length.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_Length.Text = "距离";
            this.MenuItem_Length.Click += new System.EventHandler(this.MenuItem_Length_Click);
            // 
            // MenuItem_Area
            // 
            this.MenuItem_Area.Name = "MenuItem_Area";
            this.MenuItem_Area.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_Area.Text = "面积";
            this.MenuItem_Area.Click += new System.EventHandler(this.MenuItem_Area_Click);
            // 
            // MenuItem_Height
            // 
            this.MenuItem_Height.Name = "MenuItem_Height";
            this.MenuItem_Height.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_Height.Text = "高度";
            this.MenuItem_Height.Click += new System.EventHandler(this.MenuItem_Height_Click);
            // 
            // MenuItem_ClearResult
            // 
            this.MenuItem_ClearResult.Name = "MenuItem_ClearResult";
            this.MenuItem_ClearResult.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_ClearResult.Text = "清空";
            this.MenuItem_ClearResult.Click += new System.EventHandler(this.MenuItem_ClearResult_Click);
            // 
            // toolStripButtonDataCapture
            // 
            this.toolStripButtonDataCapture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_DataCapture,
            this.气象信息ToolStripMenuItem,
            this.交通异常事件信息ToolStripMenuItem});
            this.toolStripButtonDataCapture.Image = global::LineGraph.GUI.Properties.Resources.信息采集1;
            this.toolStripButtonDataCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDataCapture.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripButtonDataCapture.Name = "toolStripButtonDataCapture";
            this.toolStripButtonDataCapture.Size = new System.Drawing.Size(109, 44);
            this.toolStripButtonDataCapture.Text = "信息采集";
            // 
            // MenuItem_DataCapture
            // 
            this.MenuItem_DataCapture.Name = "MenuItem_DataCapture";
            this.MenuItem_DataCapture.Size = new System.Drawing.Size(148, 22);
            this.MenuItem_DataCapture.Text = "交通信息";
            this.MenuItem_DataCapture.Click += new System.EventHandler(this.MenuItem_DataCapture_Click);
            // 
            // 气象信息ToolStripMenuItem
            // 
            this.气象信息ToolStripMenuItem.Name = "气象信息ToolStripMenuItem";
            this.气象信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.气象信息ToolStripMenuItem.Text = "气象信息";
            // 
            // 交通异常事件信息ToolStripMenuItem
            // 
            this.交通异常事件信息ToolStripMenuItem.Name = "交通异常事件信息ToolStripMenuItem";
            this.交通异常事件信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.交通异常事件信息ToolStripMenuItem.Text = "交通异常信息";
            // 
            // toolStripButtonMonitor
            // 
            this.toolStripButtonMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_监测区域,
            this.MenuItem_视频监控,
            this.MenuItem_静力水准监测,
            this.MenuItem_动态监测});
            this.toolStripButtonMonitor.Image = global::LineGraph.GUI.Properties.Resources.实时监测1;
            this.toolStripButtonMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMonitor.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripButtonMonitor.Name = "toolStripButtonMonitor";
            this.toolStripButtonMonitor.Size = new System.Drawing.Size(109, 44);
            this.toolStripButtonMonitor.Text = "实时监测";
            // 
            // MenuItem_监测区域
            // 
            this.MenuItem_监测区域.Name = "MenuItem_监测区域";
            this.MenuItem_监测区域.Size = new System.Drawing.Size(148, 22);
            this.MenuItem_监测区域.Text = "车流量监测";
            this.MenuItem_监测区域.Click += new System.EventHandler(this.MenuItem_监测区域_Click);
            // 
            // MenuItem_视频监控
            // 
            this.MenuItem_视频监控.Name = "MenuItem_视频监控";
            this.MenuItem_视频监控.Size = new System.Drawing.Size(148, 22);
            this.MenuItem_视频监控.Text = "路况监视";
            this.MenuItem_视频监控.Click += new System.EventHandler(this.MenuItem_视频监控_Click);
            // 
            // MenuItem_静力水准监测
            // 
            this.MenuItem_静力水准监测.Name = "MenuItem_静力水准监测";
            this.MenuItem_静力水准监测.Size = new System.Drawing.Size(148, 22);
            this.MenuItem_静力水准监测.Text = "公路设备监测";
            this.MenuItem_静力水准监测.Click += new System.EventHandler(this.MenuItem_静力水准监测_Click);
            // 
            // MenuItem_动态监测
            // 
            this.MenuItem_动态监测.Name = "MenuItem_动态监测";
            this.MenuItem_动态监测.Size = new System.Drawing.Size(148, 22);
            this.MenuItem_动态监测.Text = "路面监测";
            this.MenuItem_动态监测.Click += new System.EventHandler(this.MenuItem_动态监测_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton3.Image = global::LineGraph.GUI.Properties.Resources.数据查询1;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(100, 44);
            this.toolStripButton3.Text = "数据查询";
            // 
            // toolStripButtonResource
            // 
            this.toolStripButtonResource.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_User,
            this.MenuItem_Goods,
            this.MenuItem_Finance,
            this.MenuItem_3Ddesigner});
            this.toolStripButtonResource.Image = global::LineGraph.GUI.Properties.Resources.资源管理1;
            this.toolStripButtonResource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResource.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripButtonResource.Name = "toolStripButtonResource";
            this.toolStripButtonResource.Size = new System.Drawing.Size(109, 44);
            this.toolStripButtonResource.Text = "资源管理";
            // 
            // MenuItem_User
            // 
            this.MenuItem_User.Name = "MenuItem_User";
            this.MenuItem_User.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_User.Text = "人员管理";
            this.MenuItem_User.Click += new System.EventHandler(this.MenuItem_User_Click);
            // 
            // MenuItem_Goods
            // 
            this.MenuItem_Goods.Name = "MenuItem_Goods";
            this.MenuItem_Goods.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_Goods.Text = "物品管理";
            this.MenuItem_Goods.Click += new System.EventHandler(this.MenuItem_Goods_Click);
            // 
            // MenuItem_Finance
            // 
            this.MenuItem_Finance.Name = "MenuItem_Finance";
            this.MenuItem_Finance.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_Finance.Text = "财务管理";
            this.MenuItem_Finance.Click += new System.EventHandler(this.MenuItem_Finance_Click);
            // 
            // MenuItem_3Ddesigner
            // 
            this.MenuItem_3Ddesigner.Name = "MenuItem_3Ddesigner";
            this.MenuItem_3Ddesigner.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_3Ddesigner.Text = "三维规划";
            this.MenuItem_3Ddesigner.Click += new System.EventHandler(this.MenuItem_3Ddesigner_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::LineGraph.GUI.Properties.Resources.系统帮助1;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(100, 44);
            this.toolStripButton7.Text = "系统帮助";
            // 
            // MenuItem_AddKml
            // 
            this.MenuItem_AddKml.Name = "MenuItem_AddKml";
            this.MenuItem_AddKml.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_AddKml.Text = "加载图层";
            this.MenuItem_AddKml.Click += new System.EventHandler(this.MenuItem_AddKml_Click);
            // 
            // MenuItem_Save
            // 
            this.MenuItem_Save.Name = "MenuItem_Save";
            this.MenuItem_Save.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_Save.Text = "保存图层";
            this.MenuItem_Save.Click += new System.EventHandler(this.MenuItem_Save_Click);
            // 
            // MenuItem_RemoveLayer
            // 
            this.MenuItem_RemoveLayer.Name = "MenuItem_RemoveLayer";
            this.MenuItem_RemoveLayer.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_RemoveLayer.Text = "移除图层";
            this.MenuItem_RemoveLayer.Click += new System.EventHandler(this.MenuItem_RemoveLayer_Click);
            // 
            // MenuItem_Feature3DVisible
            // 
            this.MenuItem_Feature3DVisible.Name = "MenuItem_Feature3DVisible";
            this.MenuItem_Feature3DVisible.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_Feature3DVisible.Text = "显示传感";
            this.MenuItem_Feature3DVisible.Click += new System.EventHandler(this.MenuItem_Feature3DVisible_Click);
            // 
            // MenuItem_FlyToObject
            // 
            this.MenuItem_FlyToObject.Name = "MenuItem_FlyToObject";
            this.MenuItem_FlyToObject.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_FlyToObject.Text = "定位传感";
            this.MenuItem_FlyToObject.Click += new System.EventHandler(this.MenuItem_FlyToObject_Click);
            // 
            // MenuItem_RemoveObject
            // 
            this.MenuItem_RemoveObject.Name = "MenuItem_RemoveObject";
            this.MenuItem_RemoveObject.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_RemoveObject.Text = "移除传感";
            this.MenuItem_RemoveObject.Click += new System.EventHandler(this.MenuItem_RemoveObject_Click);
            // 
            // MenuItem_Visible
            // 
            this.MenuItem_Visible.Name = "MenuItem_Visible";
            this.MenuItem_Visible.Size = new System.Drawing.Size(32, 19);
            // 
            // MenuItem_Selectable
            // 
            this.MenuItem_Selectable.Name = "MenuItem_Selectable";
            this.MenuItem_Selectable.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_Selectable.Text = "选择传感";
            this.MenuItem_Selectable.Click += new System.EventHandler(this.MenuItem_Selectable_Click);
            // 
            // MenuItem_Editable
            // 
            this.MenuItem_Editable.Name = "MenuItem_Editable";
            this.MenuItem_Editable.Size = new System.Drawing.Size(152, 22);
            this.MenuItem_Editable.Text = "编辑传感";
            this.MenuItem_Editable.Click += new System.EventHandler(this.MenuItem_Editable_Click);
            // 
            // WndMenuListRoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1_Menue);
            this.Name = "WndMenuListRoad";
            this.Size = new System.Drawing.Size(1440, 48);
            this.toolStrip1_Menue.ResumeLayout(false);
            this.toolStrip1_Menue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonProject;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_项目信息;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_视频素材;

        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonMeasure;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Length;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Area;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Height;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ClearResult;

        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonDataCapture;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DataCapture;

        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonMonitor;
        

        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonResource;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_User;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Goods;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Finance;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_3Ddesigner;

        private System.Windows.Forms.ToolStripMenuItem MenuItem_监测区域;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_视频监控;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_静力水准监测;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_动态监测;

        private System.Windows.Forms.ToolStripButton toolStripButton3;
       
        private System.Windows.Forms.ToolStripButton toolStripButton7;

        private System.Windows.Forms.ToolStripMenuItem MenuItem_AddKml;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Feature3DVisible;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_FlyToObject;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Visible;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Selectable;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Editable;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RemoveLayer;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RemoveObject;

        private System.Windows.Forms.ToolStrip toolStrip1_Menue;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_工作空间;
        private System.Windows.Forms.ToolStripMenuItem 气象信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交通异常事件信息ToolStripMenuItem;
    }
}