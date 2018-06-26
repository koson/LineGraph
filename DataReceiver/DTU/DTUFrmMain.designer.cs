namespace LineGraph.DataReceiver
{
    partial class DTUFrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTUFrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsbMain = new System.Windows.Forms.ToolStrip();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbClearLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            //this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            //this.tsbQuit = new System.Windows.Forms.ToolStripButton();
            this.ssbMain = new System.Windows.Forms.StatusStrip();
            this.ssbDatetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssbTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssbSvcState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrSSBTime = new System.Windows.Forms.Timer(this.components);
            this.grpSvcSetting = new System.Windows.Forms.GroupBox();
            this.cboSet_RcvType = new System.Windows.Forms.ComboBox();
            this.chkSet_AutoReply = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSet_Port = new System.Windows.Forms.NumericUpDown();
            this.numSet_LiveSecs = new System.Windows.Forms.NumericUpDown();
            this.tabFunc = new System.Windows.Forms.TabControl();
            this.tabFuncSendData = new System.Windows.Forms.TabPage();
            this.cboSendDataType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSendDataTarg = new System.Windows.Forms.ComboBox();
            this.bindDTUList = new System.Windows.Forms.BindingSource(this.components);
            this.dtuListDataset1 = new LineGraph.DataReceiver.DTUListDataset();
            this.numAutoSendDataCycle = new System.Windows.Forms.NumericUpDown();
            this.chkAutoSendData = new System.Windows.Forms.CheckBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.tabFuncSendFile = new System.Windows.Forms.TabPage();
            this.cboSendFileType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSendFileTarg = new System.Windows.Forms.ComboBox();
            this.numAutoSendFileCycle = new System.Windows.Forms.NumericUpDown();
            this.chkAutoSendFile = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtSendFileName = new System.Windows.Forms.TextBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.txtSendFileContent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabFuncControl = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtATHis = new System.Windows.Forms.TextBox();
            this.btnSendAT = new System.Windows.Forms.Button();
            this.txtATCmd = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDTUSetClear = new System.Windows.Forms.Button();
            this.txtDTULiveCycle = new System.Windows.Forms.TextBox();
            this.txtDTUMainPort = new System.Windows.Forms.TextBox();
            this.txtDTUSecondPort = new System.Windows.Forms.TextBox();
            this.btnDTUSetGet = new System.Windows.Forms.Button();
            this.btnDTUSetEntry = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnDTUSetSend = new System.Windows.Forms.Button();
            this.cboDTUActiveMode = new System.Windows.Forms.ComboBox();
            this.cboDTUWorkMode = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDTUSecondDNS = new System.Windows.Forms.TextBox();
            this.txtDTUMainDNS = new System.Windows.Forms.TextBox();
            this.txtDTUSecondIP = new System.Windows.Forms.TextBox();
            this.txtDTUMainIP = new System.Windows.Forms.TextBox();
            this.txtDTUID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboControlTarg = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDTUReset = new System.Windows.Forms.Button();
            this.dgvDTUList = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dynIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastActTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
            this.tmrDTU = new System.Windows.Forms.Timer(this.components);
            this.tmrAutoSendData = new System.Windows.Forms.Timer(this.components);
            this.tmrAutoSendFile = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tmrData = new System.Windows.Forms.Timer(this.components);
            m_DataReceiverWnd = DataReceiverWnd.Create();
            this.tsbMain.SuspendLayout();
            this.ssbMain.SuspendLayout();
            this.grpSvcSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSet_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSet_LiveSecs)).BeginInit();
            this.tabFunc.SuspendLayout();
            this.tabFuncSendData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindDTUList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtuListDataset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSendDataCycle)).BeginInit();
            this.tabFuncSendFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSendFileCycle)).BeginInit();
            this.tabFuncControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTUList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbMain
            // 
            this.tsbMain.AutoSize = false;
            this.tsbMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.tsbStop,
            this.tsbSend,
            this.toolStripButton1,
            this.tsbClearLog,
            this.toolStripSeparator1});
            this.tsbMain.Location = new System.Drawing.Point(0, 0);
            this.tsbMain.Name = "tsbMain";
            this.tsbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsbMain.ShowItemToolTips = false;
            this.tsbMain.Size = new System.Drawing.Size(872, 56);
            this.tsbMain.TabIndex = 0;
            this.tsbMain.Text = "工具条";
            // 
            // tsbStart
            // 
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(60, 53);
            this.tsbStart.Text = "启动服务";
            this.tsbStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(60, 53);
            this.tsbStop.Text = "停止服务";
            this.tsbStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbSend
            // 
            this.tsbSend.Enabled = false;
            this.tsbSend.Image = ((System.Drawing.Image)(resources.GetObject("tsbSend.Image")));
            this.tsbSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSend.Name = "tsbSend";
            this.tsbSend.Size = new System.Drawing.Size(60, 53);
            this.tsbSend.Text = "发送数据";
            this.tsbSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSend.Click += new System.EventHandler(this.tsbSend_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton1.Text = "保存日志";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbClearLog
            // 
            this.tsbClearLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearLog.Image")));
            this.tsbClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearLog.Name = "tsbClearLog";
            this.tsbClearLog.Size = new System.Drawing.Size(60, 53);
            this.tsbClearLog.Text = "清空日志";
            this.tsbClearLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClearLog.Click += new System.EventHandler(this.tsbClearLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            //// 
            //// tsbAbout
            //// 
            //this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            //this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.tsbAbout.Name = "tsbAbout";
            //this.tsbAbout.Size = new System.Drawing.Size(68, 53);
            //this.tsbAbout.Text = "关于";
            //this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            //// 
            //// tsbQuit
            //// 
            //this.tsbQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuit.Image")));
            //this.tsbQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.tsbQuit.Name = "tsbQuit";
            //this.tsbQuit.Size = new System.Drawing.Size(68, 53);
            //this.tsbQuit.Text = "退出";
            //this.tsbQuit.Click += new System.EventHandler(this.tsbQuit_Click);
            // 
            // ssbMain
            // 
            this.ssbMain.AutoSize = false;
            this.ssbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssbDatetime,
            this.ssbTips,
            this.ssbSvcState});
            this.ssbMain.Location = new System.Drawing.Point(0, 509);
            this.ssbMain.Name = "ssbMain";
            this.ssbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ssbMain.Size = new System.Drawing.Size(872, 24);
            this.ssbMain.TabIndex = 5;
            this.ssbMain.Text = "状态栏";
            // 
            // ssbDatetime
            // 
            this.ssbDatetime.AutoSize = false;
            this.ssbDatetime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ssbDatetime.Name = "ssbDatetime";
            this.ssbDatetime.Size = new System.Drawing.Size(120, 19);
            this.ssbDatetime.Text = "2009-04-03 08:08:08";
            // 
            // ssbTips
            // 
            this.ssbTips.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ssbTips.Name = "ssbTips";
            this.ssbTips.Size = new System.Drawing.Size(586, 19);
            this.ssbTips.Spring = true;
            this.ssbTips.Text = "提示";
            this.ssbTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ssbSvcState
            // 
            this.ssbSvcState.AutoSize = false;
            this.ssbSvcState.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ssbSvcState.Enabled = false;
            this.ssbSvcState.Image = ((System.Drawing.Image)(resources.GetObject("ssbSvcState.Image")));
            this.ssbSvcState.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ssbSvcState.Name = "ssbSvcState";
            this.ssbSvcState.Size = new System.Drawing.Size(120, 19);
            this.ssbSvcState.Text = "服务状态：停止";
            // 
            // tmrSSBTime
            // 
            this.tmrSSBTime.Enabled = true;
            this.tmrSSBTime.Interval = 1000;
            this.tmrSSBTime.Tick += new System.EventHandler(this.tmrSSBTime_Tick);
            // 
            // grpSvcSetting
            // 
            this.grpSvcSetting.Controls.Add(this.cboSet_RcvType);
            this.grpSvcSetting.Controls.Add(this.chkSet_AutoReply);
            this.grpSvcSetting.Controls.Add(this.label3);
            this.grpSvcSetting.Controls.Add(this.label2);
            this.grpSvcSetting.Controls.Add(this.label1);
            this.grpSvcSetting.Controls.Add(this.numSet_Port);
            this.grpSvcSetting.Controls.Add(this.numSet_LiveSecs);
            this.grpSvcSetting.Location = new System.Drawing.Point(4, 59);
            this.grpSvcSetting.Name = "grpSvcSetting";
            this.grpSvcSetting.Size = new System.Drawing.Size(320, 120);
            this.grpSvcSetting.TabIndex = 1;
            this.grpSvcSetting.TabStop = false;
            this.grpSvcSetting.Text = "服务器设置";
            // 
            // cboSet_RcvType
            // 
            this.cboSet_RcvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSet_RcvType.FormattingEnabled = true;
            this.cboSet_RcvType.Items.AddRange(new object[] {
            "Text",
            "Hex"});
            this.cboSet_RcvType.Location = new System.Drawing.Point(129, 73);
            this.cboSet_RcvType.Name = "cboSet_RcvType";
            this.cboSet_RcvType.Size = new System.Drawing.Size(121, 20);
            this.cboSet_RcvType.TabIndex = 5;
            // 
            // chkSet_AutoReply
            // 
            this.chkSet_AutoReply.AutoSize = true;
            this.chkSet_AutoReply.Location = new System.Drawing.Point(129, 99);
            this.chkSet_AutoReply.Name = "chkSet_AutoReply";
            this.chkSet_AutoReply.Size = new System.Drawing.Size(72, 16);
            this.chkSet_AutoReply.TabIndex = 6;
            this.chkSet_AutoReply.Text = "自动回应";
            this.chkSet_AutoReply.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "接收数据格式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "列表维持秒数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务侦听端口：";
            // 
            // numSet_Port
            // 
            this.numSet_Port.Location = new System.Drawing.Point(130, 19);
            this.numSet_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSet_Port.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSet_Port.Name = "numSet_Port";
            this.numSet_Port.Size = new System.Drawing.Size(120, 21);
            this.numSet_Port.TabIndex = 1;
            this.numSet_Port.Value = new decimal(new int[] {
            6300,
            0,
            0,
            0});
            // 
            // numSet_LiveSecs
            // 
            this.numSet_LiveSecs.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSet_LiveSecs.Location = new System.Drawing.Point(130, 46);
            this.numSet_LiveSecs.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numSet_LiveSecs.Name = "numSet_LiveSecs";
            this.numSet_LiveSecs.Size = new System.Drawing.Size(120, 21);
            this.numSet_LiveSecs.TabIndex = 3;
            this.numSet_LiveSecs.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // tabFunc
            // 
            this.tabFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabFunc.Controls.Add(this.tabFuncSendData);
            this.tabFunc.Controls.Add(this.tabFuncSendFile);
            this.tabFunc.Controls.Add(this.tabFuncControl);
            this.tabFunc.ItemSize = new System.Drawing.Size(99, 17);
            this.tabFunc.Location = new System.Drawing.Point(4, 185);
            this.tabFunc.Name = "tabFunc";
            this.tabFunc.SelectedIndex = 0;
            this.tabFunc.Size = new System.Drawing.Size(325, 321);
            this.tabFunc.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabFunc.TabIndex = 2;
            this.tabFunc.SelectedIndexChanged += new System.EventHandler(this.tabFunc_SelectedIndexChanged);
            // 
            // tabFuncSendData
            // 
            this.tabFuncSendData.Controls.Add(this.cboSendDataType);
            this.tabFuncSendData.Controls.Add(this.label4);
            this.tabFuncSendData.Controls.Add(this.label5);
            this.tabFuncSendData.Controls.Add(this.cboSendDataTarg);
            this.tabFuncSendData.Controls.Add(this.numAutoSendDataCycle);
            this.tabFuncSendData.Controls.Add(this.chkAutoSendData);
            this.tabFuncSendData.Controls.Add(this.btnSendData);
            this.tabFuncSendData.Controls.Add(this.label6);
            this.tabFuncSendData.Controls.Add(this.txtSendData);
            this.tabFuncSendData.Location = new System.Drawing.Point(4, 21);
            this.tabFuncSendData.Name = "tabFuncSendData";
            this.tabFuncSendData.Padding = new System.Windows.Forms.Padding(3);
            this.tabFuncSendData.Size = new System.Drawing.Size(317, 296);
            this.tabFuncSendData.TabIndex = 0;
            this.tabFuncSendData.Text = "发送数据";
            this.tabFuncSendData.UseVisualStyleBackColor = true;
            // 
            // cboSendDataType
            // 
            this.cboSendDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendDataType.FormattingEnabled = true;
            this.cboSendDataType.Items.AddRange(new object[] {
            "Text",
            "Hex"});
            this.cboSendDataType.Location = new System.Drawing.Point(248, 6);
            this.cboSendDataType.Name = "cboSendDataType";
            this.cboSendDataType.Size = new System.Drawing.Size(63, 20);
            this.cboSendDataType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "输入格式：";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "秒/次";
            // 
            // cboSendDataTarg
            // 
            this.cboSendDataTarg.DataSource = this.bindDTUList;
            this.cboSendDataTarg.DisplayMember = "ID";
            this.cboSendDataTarg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendDataTarg.FormatString = "X";
            this.cboSendDataTarg.FormattingEnabled = true;
            this.cboSendDataTarg.Location = new System.Drawing.Point(56, 6);
            this.cboSendDataTarg.Name = "cboSendDataTarg";
            this.cboSendDataTarg.Size = new System.Drawing.Size(120, 20);
            this.cboSendDataTarg.TabIndex = 1;
            this.cboSendDataTarg.ValueMember = "ID";
            this.cboSendDataTarg.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboSendDataTarg_Format);
            // 
            // bindDTUList
            // 
            this.bindDTUList.DataMember = "DTUList";
            this.bindDTUList.DataSource = this.dtuListDataset1;
            this.bindDTUList.Filter = "visible";
            // 
            // dtuListDataset1
            // 
            this.dtuListDataset1.DataSetName = "DTUListDataset";
            this.dtuListDataset1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // numAutoSendDataCycle
            // 
            this.numAutoSendDataCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAutoSendDataCycle.Location = new System.Drawing.Point(84, 267);
            this.numAutoSendDataCycle.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numAutoSendDataCycle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoSendDataCycle.Name = "numAutoSendDataCycle";
            this.numAutoSendDataCycle.Size = new System.Drawing.Size(60, 21);
            this.numAutoSendDataCycle.TabIndex = 6;
            this.numAutoSendDataCycle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkAutoSendData
            // 
            this.chkAutoSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoSendData.AutoSize = true;
            this.chkAutoSendData.Location = new System.Drawing.Point(6, 270);
            this.chkAutoSendData.Name = "chkAutoSendData";
            this.chkAutoSendData.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSendData.TabIndex = 5;
            this.chkAutoSendData.Text = "自动发送";
            this.chkAutoSendData.UseVisualStyleBackColor = true;
            this.chkAutoSendData.CheckedChanged += new System.EventHandler(this.chkAutoSendData_CheckedChanged);
            // 
            // btnSendData
            // 
            this.btnSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendData.Location = new System.Drawing.Point(248, 266);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(63, 23);
            this.btnSendData.TabIndex = 8;
            this.btnSendData.Text = "发送";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "目标ID：";
            // 
            // txtSendData
            // 
            this.txtSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendData.Location = new System.Drawing.Point(6, 32);
            this.txtSendData.Multiline = true;
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(305, 228);
            this.txtSendData.TabIndex = 4;
            // 
            // tabFuncSendFile
            // 
            this.tabFuncSendFile.Controls.Add(this.cboSendFileType);
            this.tabFuncSendFile.Controls.Add(this.label8);
            this.tabFuncSendFile.Controls.Add(this.cboSendFileTarg);
            this.tabFuncSendFile.Controls.Add(this.numAutoSendFileCycle);
            this.tabFuncSendFile.Controls.Add(this.chkAutoSendFile);
            this.tabFuncSendFile.Controls.Add(this.label9);
            this.tabFuncSendFile.Controls.Add(this.btnLoadFile);
            this.tabFuncSendFile.Controls.Add(this.txtSendFileName);
            this.tabFuncSendFile.Controls.Add(this.btnSendFile);
            this.tabFuncSendFile.Controls.Add(this.txtSendFileContent);
            this.tabFuncSendFile.Controls.Add(this.label7);
            this.tabFuncSendFile.Location = new System.Drawing.Point(4, 21);
            this.tabFuncSendFile.Name = "tabFuncSendFile";
            this.tabFuncSendFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFuncSendFile.Size = new System.Drawing.Size(317, 296);
            this.tabFuncSendFile.TabIndex = 1;
            this.tabFuncSendFile.Text = "发送文件";
            this.tabFuncSendFile.UseVisualStyleBackColor = true;
            // 
            // cboSendFileType
            // 
            this.cboSendFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendFileType.FormattingEnabled = true;
            this.cboSendFileType.Items.AddRange(new object[] {
            "Text",
            "Hex"});
            this.cboSendFileType.Location = new System.Drawing.Point(248, 6);
            this.cboSendFileType.Name = "cboSendFileType";
            this.cboSendFileType.Size = new System.Drawing.Size(63, 20);
            this.cboSendFileType.TabIndex = 3;
            this.cboSendFileType.SelectedIndexChanged += new System.EventHandler(this.cboSendFileType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "秒/次";
            // 
            // cboSendFileTarg
            // 
            this.cboSendFileTarg.DataSource = this.bindDTUList;
            this.cboSendFileTarg.DisplayMember = "ID";
            this.cboSendFileTarg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendFileTarg.FormatString = "X";
            this.cboSendFileTarg.FormattingEnabled = true;
            this.cboSendFileTarg.Location = new System.Drawing.Point(56, 6);
            this.cboSendFileTarg.Name = "cboSendFileTarg";
            this.cboSendFileTarg.Size = new System.Drawing.Size(120, 20);
            this.cboSendFileTarg.TabIndex = 1;
            this.cboSendFileTarg.ValueMember = "ID";
            this.cboSendFileTarg.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboSendDataTarg_Format);
            // 
            // numAutoSendFileCycle
            // 
            this.numAutoSendFileCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAutoSendFileCycle.Location = new System.Drawing.Point(84, 267);
            this.numAutoSendFileCycle.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numAutoSendFileCycle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoSendFileCycle.Name = "numAutoSendFileCycle";
            this.numAutoSendFileCycle.Size = new System.Drawing.Size(60, 21);
            this.numAutoSendFileCycle.TabIndex = 8;
            this.numAutoSendFileCycle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkAutoSendFile
            // 
            this.chkAutoSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoSendFile.AutoSize = true;
            this.chkAutoSendFile.Location = new System.Drawing.Point(6, 270);
            this.chkAutoSendFile.Name = "chkAutoSendFile";
            this.chkAutoSendFile.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSendFile.TabIndex = 7;
            this.chkAutoSendFile.Text = "自动发送";
            this.chkAutoSendFile.UseVisualStyleBackColor = true;
            this.chkAutoSendFile.CheckedChanged += new System.EventHandler(this.chkAutoSendFile_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "目标ID：";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(271, 32);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(40, 21);
            this.btnLoadFile.TabIndex = 5;
            this.btnLoadFile.Text = "加载";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtSendFileName
            // 
            this.txtSendFileName.Location = new System.Drawing.Point(6, 32);
            this.txtSendFileName.Name = "txtSendFileName";
            this.txtSendFileName.ReadOnly = true;
            this.txtSendFileName.Size = new System.Drawing.Size(265, 21);
            this.txtSendFileName.TabIndex = 4;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendFile.Location = new System.Drawing.Point(248, 266);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(63, 23);
            this.btnSendFile.TabIndex = 10;
            this.btnSendFile.Text = "发送";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // txtSendFileContent
            // 
            this.txtSendFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendFileContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSendFileContent.Location = new System.Drawing.Point(6, 59);
            this.txtSendFileContent.Multiline = true;
            this.txtSendFileContent.Name = "txtSendFileContent";
            this.txtSendFileContent.ReadOnly = true;
            this.txtSendFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendFileContent.Size = new System.Drawing.Size(305, 201);
            this.txtSendFileContent.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "显示格式：";
            // 
            // tabFuncControl
            // 
            this.tabFuncControl.Controls.Add(this.groupBox3);
            this.tabFuncControl.Controls.Add(this.groupBox2);
            this.tabFuncControl.Controls.Add(this.cboControlTarg);
            this.tabFuncControl.Controls.Add(this.label10);
            this.tabFuncControl.Controls.Add(this.btnDTUReset);
            this.tabFuncControl.Location = new System.Drawing.Point(4, 21);
            this.tabFuncControl.Name = "tabFuncControl";
            this.tabFuncControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabFuncControl.Size = new System.Drawing.Size(317, 296);
            this.tabFuncControl.TabIndex = 2;
            this.tabFuncControl.Text = "远程控制";
            this.tabFuncControl.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Location = new System.Drawing.Point(6, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 80);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "直接AT命令控制";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtATHis);
            this.panel2.Controls.Add(this.btnSendAT);
            this.panel2.Controls.Add(this.txtATCmd);
            this.panel2.Location = new System.Drawing.Point(0, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 72);
            this.panel2.TabIndex = 0;
            // 
            // txtATHis
            // 
            this.txtATHis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtATHis.Location = new System.Drawing.Point(2, 7);
            this.txtATHis.Multiline = true;
            this.txtATHis.Name = "txtATHis";
            this.txtATHis.ReadOnly = true;
            this.txtATHis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtATHis.Size = new System.Drawing.Size(300, 35);
            this.txtATHis.TabIndex = 0;
            // 
            // btnSendAT
            // 
            this.btnSendAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendAT.Location = new System.Drawing.Point(242, 48);
            this.btnSendAT.Name = "btnSendAT";
            this.btnSendAT.Size = new System.Drawing.Size(63, 23);
            this.btnSendAT.TabIndex = 2;
            this.btnSendAT.Text = "发送";
            this.btnSendAT.UseVisualStyleBackColor = true;
            this.btnSendAT.Click += new System.EventHandler(this.btnSendAT_Click);
            // 
            // txtATCmd
            // 
            this.txtATCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtATCmd.Location = new System.Drawing.Point(2, 49);
            this.txtATCmd.Name = "txtATCmd";
            this.txtATCmd.Size = new System.Drawing.Size(240, 21);
            this.txtATCmd.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(6, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 177);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 1;
            this.label21.Text = "修改DTU配置";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDTUSetClear);
            this.panel1.Controls.Add(this.txtDTULiveCycle);
            this.panel1.Controls.Add(this.txtDTUMainPort);
            this.panel1.Controls.Add(this.txtDTUSecondPort);
            this.panel1.Controls.Add(this.btnDTUSetGet);
            this.panel1.Controls.Add(this.btnDTUSetEntry);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.btnDTUSetSend);
            this.panel1.Controls.Add(this.cboDTUActiveMode);
            this.panel1.Controls.Add(this.cboDTUWorkMode);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtDTUSecondDNS);
            this.panel1.Controls.Add(this.txtDTUMainDNS);
            this.panel1.Controls.Add(this.txtDTUSecondIP);
            this.panel1.Controls.Add(this.txtDTUMainIP);
            this.panel1.Controls.Add(this.txtDTUID);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 169);
            this.panel1.TabIndex = 0;
            // 
            // btnDTUSetClear
            // 
            this.btnDTUSetClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDTUSetClear.Location = new System.Drawing.Point(7, 144);
            this.btnDTUSetClear.Name = "btnDTUSetClear";
            this.btnDTUSetClear.Size = new System.Drawing.Size(70, 23);
            this.btnDTUSetClear.TabIndex = 24;
            this.btnDTUSetClear.Text = " 清空配置";
            this.btnDTUSetClear.UseVisualStyleBackColor = true;
            this.btnDTUSetClear.Click += new System.EventHandler(this.btnDTUSetClear_Click);
            // 
            // txtDTULiveCycle
            // 
            this.txtDTULiveCycle.Location = new System.Drawing.Point(227, 3);
            this.txtDTULiveCycle.Name = "txtDTULiveCycle";
            this.txtDTULiveCycle.Size = new System.Drawing.Size(75, 21);
            this.txtDTULiveCycle.TabIndex = 11;
            // 
            // txtDTUMainPort
            // 
            this.txtDTUMainPort.Location = new System.Drawing.Point(227, 32);
            this.txtDTUMainPort.Name = "txtDTUMainPort";
            this.txtDTUMainPort.Size = new System.Drawing.Size(75, 21);
            this.txtDTUMainPort.TabIndex = 13;
            // 
            // txtDTUSecondPort
            // 
            this.txtDTUSecondPort.Location = new System.Drawing.Point(227, 61);
            this.txtDTUSecondPort.Name = "txtDTUSecondPort";
            this.txtDTUSecondPort.Size = new System.Drawing.Size(75, 21);
            this.txtDTUSecondPort.TabIndex = 15;
            // 
            // btnDTUSetGet
            // 
            this.btnDTUSetGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDTUSetGet.Location = new System.Drawing.Point(159, 144);
            this.btnDTUSetGet.Name = "btnDTUSetGet";
            this.btnDTUSetGet.Size = new System.Drawing.Size(70, 23);
            this.btnDTUSetGet.TabIndex = 22;
            this.btnDTUSetGet.Text = "获取配置";
            this.btnDTUSetGet.UseVisualStyleBackColor = true;
            this.btnDTUSetGet.Click += new System.EventHandler(this.btnDTUSetGet_Click);
            // 
            // btnDTUSetEntry
            // 
            this.btnDTUSetEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDTUSetEntry.Location = new System.Drawing.Point(83, 144);
            this.btnDTUSetEntry.Name = "btnDTUSetEntry";
            this.btnDTUSetEntry.Size = new System.Drawing.Size(70, 23);
            this.btnDTUSetEntry.TabIndex = 21;
            this.btnDTUSetEntry.Text = "进入配置";
            this.btnDTUSetEntry.UseVisualStyleBackColor = true;
            this.btnDTUSetEntry.Click += new System.EventHandler(this.btnDTUSetEntry_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(164, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 10;
            this.label18.Text = "心跳时间：";
            // 
            // btnDTUSetSend
            // 
            this.btnDTUSetSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDTUSetSend.Location = new System.Drawing.Point(235, 144);
            this.btnDTUSetSend.Name = "btnDTUSetSend";
            this.btnDTUSetSend.Size = new System.Drawing.Size(70, 23);
            this.btnDTUSetSend.TabIndex = 23;
            this.btnDTUSetSend.Text = "发送配置";
            this.btnDTUSetSend.UseVisualStyleBackColor = true;
            this.btnDTUSetSend.Click += new System.EventHandler(this.btnDTUSetSend_Click);
            // 
            // cboDTUActiveMode
            // 
            this.cboDTUActiveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDTUActiveMode.FormattingEnabled = true;
            this.cboDTUActiveMode.Items.AddRange(new object[] {
            "AUTO",
            "CTRL",
            "SMSD"});
            this.cboDTUActiveMode.Location = new System.Drawing.Point(227, 115);
            this.cboDTUActiveMode.Name = "cboDTUActiveMode";
            this.cboDTUActiveMode.Size = new System.Drawing.Size(75, 20);
            this.cboDTUActiveMode.TabIndex = 19;
            // 
            // cboDTUWorkMode
            // 
            this.cboDTUWorkMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDTUWorkMode.FormattingEnabled = true;
            this.cboDTUWorkMode.Items.AddRange(new object[] {
            "PORT",
            "TRAN",
            "TTRN",
            "LONG",
            "TLNT",
            "TCST"});
            this.cboDTUWorkMode.Location = new System.Drawing.Point(227, 88);
            this.cboDTUWorkMode.Name = "cboDTUWorkMode";
            this.cboDTUWorkMode.Size = new System.Drawing.Size(75, 20);
            this.cboDTUWorkMode.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(164, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "激活方式：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(164, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 16;
            this.label16.Text = "工作模式：";
            // 
            // txtDTUSecondDNS
            // 
            this.txtDTUSecondDNS.Location = new System.Drawing.Point(48, 114);
            this.txtDTUSecondDNS.Name = "txtDTUSecondDNS";
            this.txtDTUSecondDNS.Size = new System.Drawing.Size(100, 21);
            this.txtDTUSecondDNS.TabIndex = 9;
            // 
            // txtDTUMainDNS
            // 
            this.txtDTUMainDNS.Location = new System.Drawing.Point(48, 87);
            this.txtDTUMainDNS.Name = "txtDTUMainDNS";
            this.txtDTUMainDNS.Size = new System.Drawing.Size(100, 21);
            this.txtDTUMainDNS.TabIndex = 7;
            // 
            // txtDTUSecondIP
            // 
            this.txtDTUSecondIP.Location = new System.Drawing.Point(48, 60);
            this.txtDTUSecondIP.Name = "txtDTUSecondIP";
            this.txtDTUSecondIP.Size = new System.Drawing.Size(100, 21);
            this.txtDTUSecondIP.TabIndex = 5;
            // 
            // txtDTUMainIP
            // 
            this.txtDTUMainIP.Location = new System.Drawing.Point(48, 33);
            this.txtDTUMainIP.Name = "txtDTUMainIP";
            this.txtDTUMainIP.Size = new System.Drawing.Size(100, 21);
            this.txtDTUMainIP.TabIndex = 3;
            // 
            // txtDTUID
            // 
            this.txtDTUID.Location = new System.Drawing.Point(48, 6);
            this.txtDTUID.Name = "txtDTUID";
            this.txtDTUID.Size = new System.Drawing.Size(100, 21);
            this.txtDTUID.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(164, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 12;
            this.label19.Text = "主IP端口：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(164, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 14;
            this.label20.Text = "副IP端口：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "副DNS：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "主DNS：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "副IP：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "ID号：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "主IP：";
            // 
            // cboControlTarg
            // 
            this.cboControlTarg.DataSource = this.bindDTUList;
            this.cboControlTarg.DisplayMember = "ID";
            this.cboControlTarg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboControlTarg.FormatString = "X";
            this.cboControlTarg.FormattingEnabled = true;
            this.cboControlTarg.Location = new System.Drawing.Point(56, 6);
            this.cboControlTarg.Name = "cboControlTarg";
            this.cboControlTarg.Size = new System.Drawing.Size(120, 20);
            this.cboControlTarg.TabIndex = 1;
            this.cboControlTarg.ValueMember = "ID";
            this.cboControlTarg.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cboSendDataTarg_Format);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "目标ID：";
            // 
            // btnDTUReset
            // 
            this.btnDTUReset.Location = new System.Drawing.Point(241, 6);
            this.btnDTUReset.Name = "btnDTUReset";
            this.btnDTUReset.Size = new System.Drawing.Size(70, 23);
            this.btnDTUReset.TabIndex = 20;
            this.btnDTUReset.Text = "重启DTU";
            this.btnDTUReset.UseVisualStyleBackColor = true;
            this.btnDTUReset.Click += new System.EventHandler(this.btnDTUReset_Click);
            // 
            // dgvDTUList
            // 
            this.dgvDTUList.AllowUserToAddRows = false;
            this.dgvDTUList.AllowUserToDeleteRows = false;
            this.dgvDTUList.AllowUserToResizeRows = false;
            this.dgvDTUList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDTUList.AutoGenerateColumns = false;
            this.dgvDTUList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDTUList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDTUList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDTUList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDTUList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.phoneNODataGridViewTextBoxColumn,
            this.dynIPDataGridViewTextBoxColumn,
            this.connectTimeDataGridViewTextBoxColumn,
            this.lastActTimeDataGridViewTextBoxColumn});
            this.dgvDTUList.DataSource = this.bindDTUList;
            this.dgvDTUList.Location = new System.Drawing.Point(335, 59);
            this.dgvDTUList.MultiSelect = false;
            this.dgvDTUList.Name = "dgvDTUList";
            this.dgvDTUList.ReadOnly = true;
            this.dgvDTUList.RowHeadersWidth = 24;
            this.dgvDTUList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDTUList.RowTemplate.Height = 23;
            this.dgvDTUList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDTUList.Size = new System.Drawing.Size(533, 150);
            this.dgvDTUList.TabIndex = 3;
            this.dgvDTUList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDTUList_CellFormatting);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "X";
            dataGridViewCellStyle2.NullValue = null;
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.iDDataGridViewTextBoxColumn.HeaderText = "用户ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 60;
            // 
            // phoneNODataGridViewTextBoxColumn
            // 
            this.phoneNODataGridViewTextBoxColumn.DataPropertyName = "PhoneNO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phoneNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.phoneNODataGridViewTextBoxColumn.HeaderText = "电话号码";
            this.phoneNODataGridViewTextBoxColumn.Name = "phoneNODataGridViewTextBoxColumn";
            this.phoneNODataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneNODataGridViewTextBoxColumn.Width = 80;
            // 
            // dynIPDataGridViewTextBoxColumn
            // 
            this.dynIPDataGridViewTextBoxColumn.DataPropertyName = "DynIP";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dynIPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dynIPDataGridViewTextBoxColumn.HeaderText = "动态IP";
            this.dynIPDataGridViewTextBoxColumn.Name = "dynIPDataGridViewTextBoxColumn";
            this.dynIPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // connectTimeDataGridViewTextBoxColumn
            // 
            this.connectTimeDataGridViewTextBoxColumn.DataPropertyName = "ConnectTime";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "G";
            dataGridViewCellStyle5.NullValue = null;
            this.connectTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.connectTimeDataGridViewTextBoxColumn.HeaderText = "连接时间";
            this.connectTimeDataGridViewTextBoxColumn.Name = "connectTimeDataGridViewTextBoxColumn";
            this.connectTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.connectTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // lastActTimeDataGridViewTextBoxColumn
            // 
            this.lastActTimeDataGridViewTextBoxColumn.DataPropertyName = "LastActTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = null;
            this.lastActTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.lastActTimeDataGridViewTextBoxColumn.HeaderText = "上次活动时间";
            this.lastActTimeDataGridViewTextBoxColumn.Name = "lastActTimeDataGridViewTextBoxColumn";
            this.lastActTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastActTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // rtxLog
            // 
            this.rtxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtxLog.Location = new System.Drawing.Point(335, 215);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.ReadOnly = true;
            this.rtxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtxLog.Size = new System.Drawing.Size(533, 291);
            this.rtxLog.TabIndex = 4;
            this.rtxLog.Text = "";
            // 
            // saveLogDialog
            // 
            this.saveLogDialog.DefaultExt = "*.rtf";
            this.saveLogDialog.Filter = "RTF文件(*.rtf)|*.rtf|文本文件(*.txt)|*.txt";
            this.saveLogDialog.Title = "保存日志";
            // 
            // tmrDTU
            // 
            this.tmrDTU.Interval = 60000;
            this.tmrDTU.Tick += new System.EventHandler(this.tmrDTU_Tick);
            // 
            // tmrAutoSendData
            // 
            this.tmrAutoSendData.Tick += new System.EventHandler(this.tmrAutoSendData_Tick);
            // 
            // tmrAutoSendFile
            // 
            this.tmrAutoSendFile.Tick += new System.EventHandler(this.tmrAutoSendFile_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "所有文件(*.*)|*.*";
            this.openFileDialog.Title = "加载文件";
            // 
            // tmrData
            // 
            this.tmrData.Interval = 1000;
            this.tmrData.Tick += new System.EventHandler(this.tmrData_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 533);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.dgvDTUList);
            this.Controls.Add(this.tabFunc);
            this.Controls.Add(this.grpSvcSetting);
            this.Controls.Add(this.ssbMain);
            this.Controls.Add(this.tsbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 540);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DTU控制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tsbMain.ResumeLayout(false);
            this.tsbMain.PerformLayout();
            this.ssbMain.ResumeLayout(false);
            this.ssbMain.PerformLayout();
            this.grpSvcSetting.ResumeLayout(false);
            this.grpSvcSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSet_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSet_LiveSecs)).EndInit();
            this.tabFunc.ResumeLayout(false);
            this.tabFuncSendData.ResumeLayout(false);
            this.tabFuncSendData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindDTUList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtuListDataset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSendDataCycle)).EndInit();
            this.tabFuncSendFile.ResumeLayout(false);
            this.tabFuncSendFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSendFileCycle)).EndInit();
            this.tabFuncControl.ResumeLayout(false);
            this.tabFuncControl.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTUList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsbMain;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbSend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        //private System.Windows.Forms.ToolStripButton tsbAbout;
        //private System.Windows.Forms.ToolStripButton tsbQuit;
        private System.Windows.Forms.StatusStrip ssbMain;
        private System.Windows.Forms.ToolStripStatusLabel ssbTips;
        private System.Windows.Forms.ToolStripStatusLabel ssbSvcState;
        private System.Windows.Forms.ToolStripStatusLabel ssbDatetime;
        private System.Windows.Forms.Timer tmrSSBTime;
        private System.Windows.Forms.ToolStripButton tsbClearLog;
        private System.Windows.Forms.GroupBox grpSvcSetting;
        private System.Windows.Forms.TabControl tabFunc;
        private System.Windows.Forms.TabPage tabFuncSendData;
        private System.Windows.Forms.TabPage tabFuncSendFile;
        private System.Windows.Forms.TabPage tabFuncControl;
        private System.Windows.Forms.DataGridView dgvDTUList;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSet_Port;
        private System.Windows.Forms.NumericUpDown numSet_LiveSecs;
        private System.Windows.Forms.CheckBox chkSet_AutoReply;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.ComboBox cboSet_RcvType;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.TextBox txtSendFileContent;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtSendFileName;
        private System.Windows.Forms.ComboBox cboSendDataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSendDataTarg;
        private System.Windows.Forms.NumericUpDown numAutoSendDataCycle;
        private System.Windows.Forms.CheckBox chkAutoSendData;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSendFileType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSendFileTarg;
        private System.Windows.Forms.NumericUpDown numAutoSendFileCycle;
        private System.Windows.Forms.CheckBox chkAutoSendFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDTUSetSend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboControlTarg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboDTUActiveMode;
        private System.Windows.Forms.ComboBox cboDTUWorkMode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDTUSecondDNS;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDTUMainDNS;
        private System.Windows.Forms.TextBox txtDTUSecondIP;
        private System.Windows.Forms.TextBox txtDTUMainIP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDTUID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnDTUSetGet;
        private System.Windows.Forms.Button btnDTUSetEntry;
        private System.Windows.Forms.Button btnDTUReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtATCmd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnSendAT;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtATHis;
        private System.Windows.Forms.TextBox txtDTULiveCycle;
        private System.Windows.Forms.TextBox txtDTUMainPort;
        private System.Windows.Forms.TextBox txtDTUSecondPort;
        private System.Windows.Forms.Button btnDTUSetClear;
        private DTUListDataset dtuListDataset1;
        private System.Windows.Forms.BindingSource bindDTUList;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SaveFileDialog saveLogDialog;
        private System.Windows.Forms.Timer tmrDTU;
        private System.Windows.Forms.Timer tmrAutoSendData;
        private System.Windows.Forms.Timer tmrAutoSendFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dynIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastActTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer tmrData;

        public DataReceiverWnd m_DataReceiverWnd;
    }
}

