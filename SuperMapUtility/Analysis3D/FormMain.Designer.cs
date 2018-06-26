using SuperMap.UI;
using SuperMap.Realspace;

namespace SuperMap.SampleCode.Realspace
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.场景属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowFPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.SetSunVisible_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SunTrajectorySetting_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.SetShadowType_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShadowAll_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShadowSelection_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoShadow_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewShedAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SightlineAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SkylineAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Profile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClippingPlane_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShadowAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContourAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SlopeAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FloodAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_PanScene = new System.Windows.Forms.ToolStripButton();
            this.btn_SelectScene = new System.Windows.Forms.ToolStripButton();
            this.btn_Pan2Scene = new System.Windows.Forms.ToolStripButton();
            this.btn_EntireScene = new System.Windows.Forms.ToolStripButton();
            this.btn_RefreshScene = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.workspaceControl = new SuperMap.UI.WorkspaceControl();
            this.layersControl = new SuperMap.UI.LayersControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelDiagram = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panel3 = new System.Windows.Forms.Panel();
            this.m_panel2 = new System.Windows.Forms.Panel();
            this.m_panel1 = new System.Windows.Forms.Panel();
            this.m_panel0 = new System.Windows.Forms.Panel();
            this.m_labelTitle = new System.Windows.Forms.Label();
            this.workspace = new SuperMap.Data.Workspace(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStripDataset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.DelDataset_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripLayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlyToLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelDiagram.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStripDataset.SuspendLayout();
            this.contextMenuStripLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.场景属性ToolStripMenuItem,
            this.ViewShedAnalysis_ToolStripMenuItem,
            this.SightlineAnalysis_ToolStripMenuItem,
            this.SkylineAnalysis_ToolStripMenuItem,
            this.Profile_ToolStripMenuItem,
            this.ClippingPlane_ToolStripMenuItem,
            this.ShadowAnalysis_ToolStripMenuItem,
            this.ContourAnalysis_ToolStripMenuItem,
            this.SlopeAnalysis_ToolStripMenuItem,
            this.FloodAnalysis_ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 场景属性ToolStripMenuItem
            // 
            this.场景属性ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFPSToolStripMenuItem,
            this.toolStripSeparator26,
            this.SetSunVisible_ToolStripMenuItem,
            this.SunTrajectorySetting_ToolStripMenuItem,
            this.toolStripSeparator6,
            this.SetShadowType_ToolStripMenuItem});
            this.场景属性ToolStripMenuItem.Name = "场景属性ToolStripMenuItem";
            this.场景属性ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.场景属性ToolStripMenuItem.Text = "场景属性";
            // 
            // ShowFPSToolStripMenuItem
            // 
            this.ShowFPSToolStripMenuItem.Name = "ShowFPSToolStripMenuItem";
            this.ShowFPSToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ShowFPSToolStripMenuItem.Text = "显示帧率";
            this.ShowFPSToolStripMenuItem.Click += new System.EventHandler(this.ShowFPSToolStripMenuItem_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(169, 6);
            // 
            // SetSunVisible_ToolStripMenuItem
            // 
            this.SetSunVisible_ToolStripMenuItem.Checked = true;
            this.SetSunVisible_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SetSunVisible_ToolStripMenuItem.Name = "SetSunVisible_ToolStripMenuItem";
            this.SetSunVisible_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SetSunVisible_ToolStripMenuItem.Text = "开启太阳";
            this.SetSunVisible_ToolStripMenuItem.Click += new System.EventHandler(this.SetSunVisible_ToolStripMenuItem_Click);
            // 
            // SunTrajectorySetting_ToolStripMenuItem
            // 
            this.SunTrajectorySetting_ToolStripMenuItem.Name = "SunTrajectorySetting_ToolStripMenuItem";
            this.SunTrajectorySetting_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SunTrajectorySetting_ToolStripMenuItem.Text = "设置太阳轨迹";
            this.SunTrajectorySetting_ToolStripMenuItem.Click += new System.EventHandler(this.SunTrajectorySetting_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(169, 6);
            // 
            // SetShadowType_ToolStripMenuItem
            // 
            this.SetShadowType_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShadowAll_ToolStripMenuItem,
            this.ShadowSelection_ToolStripMenuItem,
            this.NoShadow_ToolStripMenuItem});
            this.SetShadowType_ToolStripMenuItem.Name = "SetShadowType_ToolStripMenuItem";
            this.SetShadowType_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SetShadowType_ToolStripMenuItem.Text = "设置图层阴影类型";
            this.SetShadowType_ToolStripMenuItem.Click += new System.EventHandler(this.SetShadowType_ToolStripMenuItem_Click);
            // 
            // ShadowAll_ToolStripMenuItem
            // 
            this.ShadowAll_ToolStripMenuItem.Name = "ShadowAll_ToolStripMenuItem";
            this.ShadowAll_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ShadowAll_ToolStripMenuItem.Text = "所有对象产生阴影";
            this.ShadowAll_ToolStripMenuItem.Click += new System.EventHandler(this.ShadowAll_ToolStripMenuItem_Click);
            // 
            // ShadowSelection_ToolStripMenuItem
            // 
            this.ShadowSelection_ToolStripMenuItem.Name = "ShadowSelection_ToolStripMenuItem";
            this.ShadowSelection_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ShadowSelection_ToolStripMenuItem.Text = "选中对象产生阴影";
            this.ShadowSelection_ToolStripMenuItem.Click += new System.EventHandler(this.ShadowSeletion_ToolStripMenuItem_Click);
            // 
            // NoShadow_ToolStripMenuItem
            // 
            this.NoShadow_ToolStripMenuItem.Checked = true;
            this.NoShadow_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoShadow_ToolStripMenuItem.Name = "NoShadow_ToolStripMenuItem";
            this.NoShadow_ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.NoShadow_ToolStripMenuItem.Text = "不产生阴影";
            this.NoShadow_ToolStripMenuItem.Click += new System.EventHandler(this.NoShadow_ToolStripMenuItem_Click);
            // 
            // ViewShedAnalysis_ToolStripMenuItem
            // 
            this.ViewShedAnalysis_ToolStripMenuItem.Name = "ViewShedAnalysis_ToolStripMenuItem";
            this.ViewShedAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ViewShedAnalysis_ToolStripMenuItem.Text = "可视域分析";
            this.ViewShedAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.ViewShedAnalysis_ToolStripMenuItem_Click);
            // 
            // SightlineAnalysis_ToolStripMenuItem
            // 
            this.SightlineAnalysis_ToolStripMenuItem.Name = "SightlineAnalysis_ToolStripMenuItem";
            this.SightlineAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.SightlineAnalysis_ToolStripMenuItem.Text = "视线分析";
            this.SightlineAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.SightlineAnalysis_ToolStripMenuItem_Click);
            // 
            // SkylineAnalysis_ToolStripMenuItem
            // 
            this.SkylineAnalysis_ToolStripMenuItem.Name = "SkylineAnalysis_ToolStripMenuItem";
            this.SkylineAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.SkylineAnalysis_ToolStripMenuItem.Text = "天际线分析";
            this.SkylineAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.SkylineAnalysis_ToolStripMenuItem_Click);
            // 
            // Profile_ToolStripMenuItem
            // 
            this.Profile_ToolStripMenuItem.Name = "Profile_ToolStripMenuItem";
            this.Profile_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.Profile_ToolStripMenuItem.Text = "剖面线分析";
            this.Profile_ToolStripMenuItem.Click += new System.EventHandler(this.Profile_ToolStripMenuItem_Click);
            // 
            // ClippingPlane_ToolStripMenuItem
            // 
            this.ClippingPlane_ToolStripMenuItem.Name = "ClippingPlane_ToolStripMenuItem";
            this.ClippingPlane_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ClippingPlane_ToolStripMenuItem.Text = "裁剪面分析";
            this.ClippingPlane_ToolStripMenuItem.Click += new System.EventHandler(this.ClippingPlane_ToolStripMenuItem_Click);
            // 
            // ShadowAnalysis_ToolStripMenuItem
            // 
            this.ShadowAnalysis_ToolStripMenuItem.Name = "ShadowAnalysis_ToolStripMenuItem";
            this.ShadowAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ShadowAnalysis_ToolStripMenuItem.Text = "阴影分析";
            this.ShadowAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.ShadowAnalysis_ToolStripMenuItem_Click);
            // 
            // ContourAnalysis_ToolStripMenuItem
            // 
            this.ContourAnalysis_ToolStripMenuItem.Name = "ContourAnalysis_ToolStripMenuItem";
            this.ContourAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ContourAnalysis_ToolStripMenuItem.Text = "等高线分析";
            this.ContourAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.ContourAnalysis_ToolStripMenuItem_Click);
            // 
            // SlopeAnalysis_ToolStripMenuItem
            // 
            this.SlopeAnalysis_ToolStripMenuItem.Name = "SlopeAnalysis_ToolStripMenuItem";
            this.SlopeAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.SlopeAnalysis_ToolStripMenuItem.Text = "坡度坡向分析";
            this.SlopeAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.SlopeAnalysis_ToolStripMenuItem_Click);
            // 
            // FloodAnalysis_ToolStripMenuItem
            // 
            this.FloodAnalysis_ToolStripMenuItem.Name = "FloodAnalysis_ToolStripMenuItem";
            this.FloodAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.FloodAnalysis_ToolStripMenuItem.Text = "淹没分析";
            this.FloodAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.FloodAnalysis_ToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8,
            this.btn_PanScene,
            this.btn_SelectScene,
            this.btn_Pan2Scene,
            this.btn_EntireScene,
            this.btn_RefreshScene});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(984, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_PanScene
            // 
            this.btn_PanScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_PanScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_PanScene.Image")));
            this.btn_PanScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PanScene.Name = "btn_PanScene";
            this.btn_PanScene.Size = new System.Drawing.Size(23, 22);
            this.btn_PanScene.Text = "Pan";
            this.btn_PanScene.Click += new System.EventHandler(this.btn_PanScene_Click);
            // 
            // btn_SelectScene
            // 
            this.btn_SelectScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SelectScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectScene.Image")));
            this.btn_SelectScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SelectScene.Name = "btn_SelectScene";
            this.btn_SelectScene.Size = new System.Drawing.Size(23, 22);
            this.btn_SelectScene.Text = "Select";
            this.btn_SelectScene.Click += new System.EventHandler(this.btn_SelectScene_Click);
            // 
            // btn_Pan2Scene
            // 
            this.btn_Pan2Scene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Pan2Scene.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pan2Scene.Image")));
            this.btn_Pan2Scene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Pan2Scene.Name = "btn_Pan2Scene";
            this.btn_Pan2Scene.Size = new System.Drawing.Size(23, 22);
            this.btn_Pan2Scene.Text = "Pan2";
            this.btn_Pan2Scene.Click += new System.EventHandler(this.btn_Pan2Scene_Click);
            // 
            // btn_EntireScene
            // 
            this.btn_EntireScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_EntireScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_EntireScene.Image")));
            this.btn_EntireScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_EntireScene.Name = "btn_EntireScene";
            this.btn_EntireScene.Size = new System.Drawing.Size(23, 22);
            this.btn_EntireScene.Text = "ViewEntire";
            this.btn_EntireScene.Click += new System.EventHandler(this.btn_EntireScene_Click);
            // 
            // btn_RefreshScene
            // 
            this.btn_RefreshScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_RefreshScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_RefreshScene.Image")));
            this.btn_RefreshScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_RefreshScene.Name = "btn_RefreshScene";
            this.btn_RefreshScene.Size = new System.Drawing.Size(23, 22);
            this.btn_RefreshScene.Text = "Refresh";
            this.btn_RefreshScene.Click += new System.EventHandler(this.btn_RefreshScene_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(984, 388);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.workspaceControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.layersControl);
            this.splitContainer2.Size = new System.Drawing.Size(251, 388);
            this.splitContainer2.SplitterDistance = 185;
            this.splitContainer2.TabIndex = 0;
            // 
            // workspaceControl
            // 
            this.workspaceControl.AllowDefaultAction = true;
            this.workspaceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.workspaceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceControl.Location = new System.Drawing.Point(0, 0);
            this.workspaceControl.Name = "workspaceControl";
            this.workspaceControl.Size = new System.Drawing.Size(251, 185);
            this.workspaceControl.TabIndex = 0;
            // 
            // 
            // 
            this.workspaceControl.WorkspaceToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.workspaceControl.WorkspaceToolBar.Location = new System.Drawing.Point(0, 0);
            this.workspaceControl.WorkspaceToolBar.Name = "WorkspaceToolBar";
            this.workspaceControl.WorkspaceToolBar.Size = new System.Drawing.Size(251, 25);
            this.workspaceControl.WorkspaceToolBar.TabIndex = 0;
            // 
            // 
            // 
            this.workspaceControl.WorkspaceTree.AllowDrop = true;
            this.workspaceControl.WorkspaceTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.workspaceControl.WorkspaceTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workspaceControl.WorkspaceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceControl.WorkspaceTree.HideSelection = false;
            this.workspaceControl.WorkspaceTree.ItemHeight = 17;
            this.workspaceControl.WorkspaceTree.Location = new System.Drawing.Point(0, 50);
            this.workspaceControl.WorkspaceTree.Name = "WorkspaceTree";
            this.workspaceControl.WorkspaceTree.SelectedNodes = new System.Windows.Forms.TreeNode[0];
            this.workspaceControl.WorkspaceTree.Size = new System.Drawing.Size(251, 135);
            this.workspaceControl.WorkspaceTree.TabIndex = 1;
            this.workspaceControl.WorkspaceTree.Workspace = null;
            // 
            // layersControl
            // 
            this.layersControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layersControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersControl.Location = new System.Drawing.Point(0, 0);
            this.layersControl.Map = null;
            this.layersControl.Name = "layersControl";
            this.layersControl.Scene = null;
            this.layersControl.Size = new System.Drawing.Size(251, 199);
            this.layersControl.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(729, 388);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelDiagram);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "场景";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelDiagram
            // 
            this.panelDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDiagram.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDiagram.Controls.Add(this.label7);
            this.panelDiagram.Controls.Add(this.m_panel4);
            this.panelDiagram.Controls.Add(this.label4);
            this.panelDiagram.Controls.Add(this.label3);
            this.panelDiagram.Controls.Add(this.label2);
            this.panelDiagram.Controls.Add(this.label1);
            this.panelDiagram.Controls.Add(this.m_panel3);
            this.panelDiagram.Controls.Add(this.m_panel2);
            this.panelDiagram.Controls.Add(this.m_panel1);
            this.panelDiagram.Controls.Add(this.m_panel0);
            this.panelDiagram.Controls.Add(this.m_labelTitle);
            this.panelDiagram.Location = new System.Drawing.Point(532, 191);
            this.panelDiagram.Name = "panelDiagram";
            this.panelDiagram.Size = new System.Drawing.Size(181, 163);
            this.panelDiagram.TabIndex = 26;
            this.panelDiagram.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "100米以下";
            // 
            // m_panel4
            // 
            this.m_panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel4.BackColor = System.Drawing.SystemColors.Control;
            this.m_panel4.Location = new System.Drawing.Point(6, 123);
            this.m_panel4.Name = "m_panel4";
            this.m_panel4.Size = new System.Drawing.Size(77, 23);
            this.m_panel4.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "1200米以上";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "800米-1200米";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "500米-800米";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "100米-500米";
            // 
            // m_panel3
            // 
            this.m_panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel3.Location = new System.Drawing.Point(6, 100);
            this.m_panel3.Name = "m_panel3";
            this.m_panel3.Size = new System.Drawing.Size(77, 23);
            this.m_panel3.TabIndex = 4;
            // 
            // m_panel2
            // 
            this.m_panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel2.Location = new System.Drawing.Point(6, 77);
            this.m_panel2.Name = "m_panel2";
            this.m_panel2.Size = new System.Drawing.Size(77, 23);
            this.m_panel2.TabIndex = 3;
            // 
            // m_panel1
            // 
            this.m_panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel1.Location = new System.Drawing.Point(6, 54);
            this.m_panel1.Name = "m_panel1";
            this.m_panel1.Size = new System.Drawing.Size(77, 23);
            this.m_panel1.TabIndex = 2;
            // 
            // m_panel0
            // 
            this.m_panel0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel0.BackColor = System.Drawing.SystemColors.Control;
            this.m_panel0.Location = new System.Drawing.Point(6, 31);
            this.m_panel0.Name = "m_panel0";
            this.m_panel0.Size = new System.Drawing.Size(77, 23);
            this.m_panel0.TabIndex = 1;
            // 
            // m_labelTitle
            // 
            this.m_labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelTitle.AutoSize = true;
            this.m_labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.m_labelTitle.Location = new System.Drawing.Point(52, 7);
            this.m_labelTitle.Name = "m_labelTitle";
            this.m_labelTitle.Size = new System.Drawing.Size(29, 12);
            this.m_labelTitle.TabIndex = 0;
            this.m_labelTitle.Text = "水深";
            this.m_labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workspace
            // 
            this.workspace.Caption = "UntitledWorkspace";
            this.workspace.Description = "";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 416);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            this.statusStrip.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // contextMenuStripDataset
            // 
            this.contextMenuStripDataset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToSceneToolStripMenuItem,
            this.toolStripSeparator9,
            this.DelDataset_ToolStripMenuItem});
            this.contextMenuStripDataset.Name = "contextMenuStripDsVector";
            this.contextMenuStripDataset.Size = new System.Drawing.Size(137, 54);
            // 
            // AddToSceneToolStripMenuItem
            // 
            this.AddToSceneToolStripMenuItem.Name = "AddToSceneToolStripMenuItem";
            this.AddToSceneToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AddToSceneToolStripMenuItem.Text = "添加到场景";
            this.AddToSceneToolStripMenuItem.Click += new System.EventHandler(this.AddToSceneToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(133, 6);
            // 
            // DelDataset_ToolStripMenuItem
            // 
            this.DelDataset_ToolStripMenuItem.Name = "DelDataset_ToolStripMenuItem";
            this.DelDataset_ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.DelDataset_ToolStripMenuItem.Text = "删除数据集";
            this.DelDataset_ToolStripMenuItem.Click += new System.EventHandler(this.DelDataset_ToolStripMenuItem_Click);
            // 
            // contextMenuStripLayer
            // 
            this.contextMenuStripLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VisibleToolStripMenuItem,
            this.SelectableToolStripMenuItem,
            this.EditableToolStripMenuItem,
            this.toolStripSeparator5,
            this.RemoveLayerToolStripMenuItem,
            this.FlyToLayerToolStripMenuItem});
            this.contextMenuStripLayer.Name = "contextMenuStripLayer";
            this.contextMenuStripLayer.Size = new System.Drawing.Size(173, 120);
            // 
            // VisibleToolStripMenuItem
            // 
            this.VisibleToolStripMenuItem.Checked = true;
            this.VisibleToolStripMenuItem.CheckOnClick = true;
            this.VisibleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VisibleToolStripMenuItem.Name = "VisibleToolStripMenuItem";
            this.VisibleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.VisibleToolStripMenuItem.Text = "可显示";
            this.VisibleToolStripMenuItem.Click += new System.EventHandler(this.VisibleToolStripMenuItem_Click);
            // 
            // SelectableToolStripMenuItem
            // 
            this.SelectableToolStripMenuItem.Checked = true;
            this.SelectableToolStripMenuItem.CheckOnClick = true;
            this.SelectableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectableToolStripMenuItem.Name = "SelectableToolStripMenuItem";
            this.SelectableToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SelectableToolStripMenuItem.Text = "可选择";
            this.SelectableToolStripMenuItem.Click += new System.EventHandler(this.SelectableToolStripMenuItem_Click);
            // 
            // EditableToolStripMenuItem
            // 
            this.EditableToolStripMenuItem.Name = "EditableToolStripMenuItem";
            this.EditableToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.EditableToolStripMenuItem.Text = "可编辑";
            this.EditableToolStripMenuItem.Click += new System.EventHandler(this.EditableToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(169, 6);
            // 
            // RemoveLayerToolStripMenuItem
            // 
            this.RemoveLayerToolStripMenuItem.Name = "RemoveLayerToolStripMenuItem";
            this.RemoveLayerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.RemoveLayerToolStripMenuItem.Text = "移除图层";
            this.RemoveLayerToolStripMenuItem.Click += new System.EventHandler(this.RemoveLayerToolStripMenuItem_Click);
            // 
            // FlyToLayerToolStripMenuItem
            // 
            this.FlyToLayerToolStripMenuItem.Name = "FlyToLayerToolStripMenuItem";
            this.FlyToLayerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.FlyToLayerToolStripMenuItem.Text = "快速定位的本图层";
            this.FlyToLayerToolStripMenuItem.Click += new System.EventHandler(this.FlyToLayerToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 438);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "三维分析";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelDiagram.ResumeLayout(false);
            this.panelDiagram.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStripDataset.ResumeLayout(false);
            this.contextMenuStripLayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private SuperMap.UI.WorkspaceControl workspaceControl;
        private SuperMap.UI.LayersControl layersControl;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private SuperMap.Data.Workspace workspace;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataset;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem AddToSceneToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLayer;
        private System.Windows.Forms.ToolStripMenuItem FlyToLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btn_PanScene;
        private System.Windows.Forms.ToolStripButton btn_Pan2Scene;
        private System.Windows.Forms.ToolStripButton btn_EntireScene;
        private System.Windows.Forms.ToolStripButton btn_RefreshScene;
        private System.Windows.Forms.ToolStripButton btn_SelectScene;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem 场景属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowFPSToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem DelDataset_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetSunVisible_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripMenuItem SunTrajectorySetting_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewShedAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SightlineAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SkylineAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Profile_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClippingPlane_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShadowAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContourAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SlopeAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FloodAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem SetShadowType_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShadowAll_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShadowSelection_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NoShadow_ToolStripMenuItem;
        private System.Windows.Forms.Panel panelDiagram;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel m_panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel m_panel3;
        private System.Windows.Forms.Panel m_panel2;
        private System.Windows.Forms.Panel m_panel1;
        private System.Windows.Forms.Panel m_panel0;
        private System.Windows.Forms.Label m_labelTitle;
    }
}

