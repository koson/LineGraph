///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、 范例简介：示范三维分析功能,包括:可视域分析,视线分析,天际线分析,剖面线分析,裁剪面分析,阴影分析,等高线分析,坡度坡向分析,淹没分析
//2、示例数据：
//   安装目录\SampleData\Analysis3D
//3、关键类型/成员: 
//   Viewshed3D类
//   Sightline类
//   Skyline类
//   ContourMap类
//   SlopeMap类
//   Profile类
//   ShadowVisibilityQuery类
//   Layer3D.SetCustomClipPlane方法
//   Layer3D.ClearCustomClipPlane方法
//4、使用步骤：
//   (1)运行程序后，默认打开SampleData中指定数据
//   (2)点击菜单栏的各种分析按钮，执行分析相应的分析功能
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.UI;
using SuperMap.Data;
using SuperMap.Realspace;
using System.IO;

namespace SuperMap.SampleCode.Realspace
{
    public partial class FormMain : Form
    {
        SceneControl m_sceneControl = null;
        DlgViewShedAnalysis m_dlgViewShed = null;
        DlgContourMap m_dlgContourMap = null;
        DlgSlopeMap m_dlgSlopeMap = null;
        DlgSkyline m_dlgSkyline = null;
        DlgSightLine m_dlgSightline = null;
        bool m_bSceneSaved = false;
        bool m_bWksSaved = false;
        String m_FlattenKMLPath = String.Empty;
        Layer3DOSGBFile m_layerOSGB = null;
        DlgShadowAnalysis m_dlgShadowAnalysis = null;
        DlgProfileAnalysis m_dlgProfileAnalysis = null;
        Layer3D m_selectedLayer = null;
        DlgSunTrajectory m_dlgSunTrajectory = null;
        DlgFloodAnalysis m_dlgFloodAnalysis = null;
        DlgClipPlane m_dlgClipPlane = null;


        public FormMain()
        {
            InitializeComponent();

            this.CreateSceneControl();
        }

        //初始化工作
        private void Initialize()
        {
            //控件绑定工作空间
            this.workspaceControl.WorkspaceTree.Workspace = workspace;
            this.m_sceneControl.Scene.Workspace = workspace;
            this.layersControl.Scene = this.m_sceneControl.Scene;

            //右键菜单
            this.workspaceControl.WorkspaceTree.NodeContextMenuStrips[WorkspaceTreeNodeDataType.Dataset] = contextMenuStripDataset;
            this.layersControl.Layer3DsTree.NodeContextMenuStrips[Layer3DsTreeNodeDataType.Layer3D] = contextMenuStripLayer;

            this.layersControl.Layer3DsTree.SelectionChanged += new SelectionChangedEventHandler(Layer3DsTree_SelectionChanged);

            this.toolStripStatusLabel.Text = "状态栏";

            //开启全屏反走样
            SuperMap.Data.Environment.IsSceneAntialias = true;
            this.m_sceneControl.IsFPSVisible = false;
        }

        //创建m_sceneControl
        private void CreateSceneControl()
        {
            //////////////////////////////////////////////////////////////////////////////
            if (m_sceneControl == null || m_sceneControl.IsDisposed)
            {
                m_sceneControl = new SuperMap.UI.SceneControl();

                m_sceneControl.Action = SuperMap.UI.Action3D.Pan;
                m_sceneControl.BackColor = System.Drawing.Color.White;
                m_sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
                m_sceneControl.InteractionMode = SuperMap.UI.InteractionMode3D.Default;
                m_sceneControl.IsAlwaysUpdate = false;
                m_sceneControl.IsCursorCustomized = false;
                m_sceneControl.IsFPSVisible = true;
                m_sceneControl.IsKeyboardNavigationEnabled = false;
                m_sceneControl.IsMouseNavigationEnabled = true;
                m_sceneControl.IsStatusBarVisible = true;
                m_sceneControl.IsWaitCursorEnabled = false;
                m_sceneControl.Location = new System.Drawing.Point(3, 3);
                m_sceneControl.Margin = new System.Windows.Forms.Padding(0);
                m_sceneControl.Name = "m_sceneControl";
                m_sceneControl.Size = new System.Drawing.Size(475, 356);
                m_sceneControl.TabIndex = 0;

                this.tabPage2.Controls.Add(m_sceneControl);
                m_sceneControl.Scene.Workspace = workspace;

                this.Initialize();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.tabControl.SelectedIndex = 1;

            this.OpenData();
        }

        //初始时默认打开指定数据
        private Boolean OpenData()
        {
            String wksPath = @"../../SampleData/Analysis3D/Analysis3D.sxwu";
            WorkspaceConnectionInfo connInfo = new WorkspaceConnectionInfo(wksPath);

            bool bOpen = workspace.Open(connInfo);
            if (!bOpen)
            {
                MessageBox.Show("打开工作空间失败！");
                return false;
            }

            Scene scene = this.m_sceneControl.Scene;
            scene.Workspace = workspace;
            bOpen = scene.Open("Model");
            if (!bOpen)
            {
                MessageBox.Show("打开场景失败！");
                return false;
            }
            this.m_bWksSaved = false;

            return true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_dlgShadowAnalysis != null)
            {
                m_dlgShadowAnalysis.Dispose();
                m_dlgShadowAnalysis = null;
            }
            if (m_dlgSightline != null)
            {
                m_dlgSightline.Dispose();
                m_dlgSightline = null;
            }
            if (m_dlgSkyline != null)
            {
                m_dlgSkyline.Dispose();
                m_dlgSkyline = null;
            }
            if (m_dlgProfileAnalysis != null)
            {
                m_dlgProfileAnalysis.Dispose();
                m_dlgProfileAnalysis = null;
            }

            if (m_dlgSunTrajectory != null)
            {
                m_dlgSunTrajectory.Dispose();
                m_dlgSunTrajectory = null;
            }
            if (m_dlgFloodAnalysis != null)
            {
                m_dlgFloodAnalysis.Dispose();
                m_dlgFloodAnalysis = null;
            }

            if (m_dlgClipPlane != null)
            {
                m_dlgClipPlane.Dispose();
                m_dlgClipPlane = null;
            }

            if (m_dlgContourMap != null)
            {
                m_dlgContourMap.Dispose();
                m_dlgContourMap = null;
            }

            if (m_dlgSlopeMap != null)
            {
                m_dlgSlopeMap.Dispose();
                m_dlgSlopeMap = null;
            }
            this.m_sceneControl.Scene.Close();
            this.workspace.Datasources.CloseAll();
            m_sceneControl.Dispose();
        }
        //////////////////////////////////////////////////////////////////////////////////////

     

      
        //图层选择事件
        void Layer3DsTree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (m_sceneControl.Scene.Layers.Count <= 0)
                return;
            TreeNode[] treeNodes = e.SelectedNodes;
            if (treeNodes.Length <= 0)
                return;
            TreeNode treeNode = treeNodes[0];
            Layer3DsTreeNodeBase treeNodeBase = treeNode as Layer3DsTreeNodeBase;
            m_selectedLayer = treeNodeBase.GetData() as Layer3D;
            if (m_selectedLayer == null)
                return;
            if (m_selectedLayer.Type == Layer3DType.Dataset || m_selectedLayer.Type == Layer3DType.VectorFile)
            {
                if (m_selectedLayer.ShadowType == ShadowType.SELECTION)
                {
                    this.ShadowSelection_ToolStripMenuItem.Checked = true;
                    this.ShadowAll_ToolStripMenuItem.Checked = false;
                    this.NoShadow_ToolStripMenuItem.Checked = false;
                }
                else if (m_selectedLayer.ShadowType == ShadowType.ALL)
                {
                    this.ShadowAll_ToolStripMenuItem.Checked = true;
                    this.ShadowSelection_ToolStripMenuItem.Checked = false;
                    this.NoShadow_ToolStripMenuItem.Checked = false;
                }
                else if (m_selectedLayer.ShadowType == ShadowType.NONE)
                {
                    this.NoShadow_ToolStripMenuItem.Checked = true;
                    this.ShadowAll_ToolStripMenuItem.Checked = false;
                    this.ShadowSelection_ToolStripMenuItem.Checked = false;
                }
            }

        }


        //加载缓存
        private void AddCache_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Title = "打开三维缓存文件";
            this.openFileDialog.Filter = "所有支持的三维缓存文件（*.sci, *.scv, *.scp,*.sci3d, *.sct, *.sit,*.gci,*.scm）|*.sci;*.scv;*.scp;*.sci3d;*.sct;*.sit;*.gci;*.scm";
            this.openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = this.openFileDialog.FileName;
                String extention = System.IO.Path.GetExtension(fileName);
                Layer3D layer3D = null;
                Layer3Ds layer3ds = this.m_sceneControl.Scene.Layers;

                switch (extention)
                {
                    case ".sci":
                    case ".sci3d":
                    case ".sit":
                    case ".gci":
                        {
                            layer3D = layer3ds.Add(fileName, Layer3DType.ImageFile, true);
                            layer3D.UpdateData();
                            this.m_sceneControl.Scene.Refresh();
                            this.m_sceneControl.Scene.EnsureVisible(layer3D.Bounds);
                            break;
                        }
                    case ".scv":
                        {
                            layer3D = layer3ds.Add(fileName, Layer3DType.VectorFile, true);
                            //layer3D.UpdateData();
                            this.m_sceneControl.Scene.Refresh();
                            this.m_sceneControl.Scene.EnsureVisible(layer3D.Bounds);

                            break;
                        }
                    case ".scp":
                        {
                            layer3D = layer3ds.Add(fileName, Layer3DType.OSGB, true);
                            this.m_sceneControl.Scene.Refresh();
                            //this.m_sceneControl.Scene.EnsureVisible(layer3D.Bounds);
                            if (layer3D != null)
                            {
                                m_layerOSGB = layer3D as Layer3DOSGBFile;
                            }
                            break;
                        }
                    case ".sct":
                        {
                            TerrainLayer terrainlayer3D = this.m_sceneControl.Scene.TerrainLayers.Add(fileName, true);
                            this.m_sceneControl.Scene.Refresh();
                            this.m_sceneControl.Scene.EnsureVisible(terrainlayer3D.Bounds);

                            break;
                        }
                }
            }
        }

        //将数据集添加到场景中
        private void AddToSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceTreeNodeBase node = this.workspaceControl.WorkspaceTree.SelectedNode as WorkspaceTreeNodeBase;
            Dataset dataset = node.GetData() as Dataset;
            Layer3D layer3D = null;
            TerrainLayer terrainLayer = null;
            String layerName = dataset.Name + "@" + dataset.Datasource.Alias;

            switch (node.NodeType)
            {
                case WorkspaceTreeNodeDataType.DatasetVector:
                    {
                        Random random = new Random(Guid.NewGuid().GetHashCode());

                        DatasetVector datasetVector = dataset as DatasetVector;
                        Layer3DSettingVector settingVector = new Layer3DSettingVector();
                        GeoStyle3D style = new GeoStyle3D(); 
                        style.FillMode = FillMode3D.LineAndFill;
                        style.MarkerColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));//Color.Red;
                        style.LineColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));//Color.SaddleBrown;
                        style.FillForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));//Color.SkyBlue;
                        if (datasetVector.Type == DatasetType.Line3D)
                        {
                            style.AltitudeMode = AltitudeMode.Absolute;
                            style.LineWidth = 4;
                        }
                        settingVector.Style = style;
                        layer3D = this.m_sceneControl.Scene.Layers.Add(datasetVector, settingVector, true, layerName);
                        break;
                    }
                case WorkspaceTreeNodeDataType.DatasetGrid:
                    {
                        DatasetGrid datasetGrid = dataset as DatasetGrid;
                        terrainLayer = this.m_sceneControl.Scene.TerrainLayers.Add(datasetGrid, true);
                        break;
                    }
                case WorkspaceTreeNodeDataType.DatasetImage:
                    {
                        DatasetImage datasetImage = dataset as DatasetImage;
                        Layer3DSettingImage settingImage = new Layer3DSettingImage();
                        layer3D = this.m_sceneControl.Scene.Layers.Add(datasetImage, settingImage, true, layerName);
                        break;
                    }
            }
            //if (layer3D != null)
            //{
            //    this.m_sceneControl.Scene.EnsureVisible(layer3D.Bounds);
            //}
            //if (terrainLayer != null)
            //{
            //    this.m_sceneControl.Scene.EnsureVisible(terrainLayer.Bounds);
            //}
            this.m_sceneControl.Scene.Refresh();
        }

        private void FlyToLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer3DsTreeNodeBase node = this.layersControl.Layer3DsTree.SelectedNode as Layer3DsTreeNodeBase;
            Layer3D layer = node.GetData() as Layer3D;
            this.m_sceneControl.Scene.EnsureVisible(layer.Bounds);
        }

        private void VisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer3DsTreeNodeBase node = this.layersControl.Layer3DsTree.SelectedNode as Layer3DsTreeNodeBase;
            Layer3D layer = node.GetData() as Layer3D;
            layer.IsVisible = !(layer.IsVisible);
            this.layersControl.Refresh();
        }

        private void SelectableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer3DsTreeNodeBase node = this.layersControl.Layer3DsTree.SelectedNode as Layer3DsTreeNodeBase;
            Layer3D layer = node.GetData() as Layer3D;
            layer.IsSelectable = !(layer.IsSelectable);
            this.layersControl.Refresh();
        }

        private void EditableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer3DsTreeNodeBase node = this.layersControl.Layer3DsTree.SelectedNode as Layer3DsTreeNodeBase;
            Layer3D layer = node.GetData() as Layer3D;
            layer.IsEditable = !(layer.IsEditable);
            this.layersControl.Refresh();
        }

        //移除图层
        private void RemoveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer3DsTreeNodeBase node = this.layersControl.Layer3DsTree.SelectedNode as Layer3DsTreeNodeBase;
            Layer3D layer = node.GetData() as Layer3D;
            if (layer.Type == Layer3DType.KML && layer.Name.Contains("Flatten"))
            {
                if (m_layerOSGB != null)
                {
                    m_layerOSGB.ClearFlattenRegions();
                }
            }
            this.m_sceneControl.Scene.Layers.Remove(layer.Name);
        }

        //刷新场景
        private void btn_RefreshScene_Click(object sender, EventArgs e)
        {
            Layer3Ds layers = this.m_sceneControl.Scene.Layers;
            for (int i = 0; i < layers.Count; i++)
            {
                Layer3D layer = layers[i];
                layer.UpdateData();
            }
                this.m_sceneControl.Scene.Refresh();
        }

        /// <summary>
        /// ///////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectScene_Click(object sender, EventArgs e)
        {
            this.m_sceneControl.Action = Action3D.Select;
        }

        private void btn_PanScene_Click(object sender, EventArgs e)
        {
            this.m_sceneControl.Action = Action3D.Pan;
        }

        private void btn_Pan2Scene_Click(object sender, EventArgs e)
        {
            this.m_sceneControl.Action = Action3D.Pan2;
        }

        private void btn_EntireScene_Click(object sender, EventArgs e)
        {
            this.m_sceneControl.Scene.ViewEntire();
        }
        private void ShowFPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_sceneControl.IsFPSVisible = !this.m_sceneControl.IsFPSVisible;
            this.ShowFPSToolStripMenuItem.Checked = !this.ShowFPSToolStripMenuItem.Checked;
        }

        //删除数据集
        private void DelDataset_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceTreeNodeBase node = this.workspaceControl.WorkspaceTree.SelectedNode as WorkspaceTreeNodeBase;
            Dataset dataset = node.GetData() as Dataset;

            //如果该图层在场景中打开，移除图层
            Layer3Ds layers = this.m_sceneControl.Scene.Layers;
            int nLayer = layers.Count;
            for (int i = 0; i < nLayer; i++)
            {
                Layer3D layer = layers[i];
                if (layer.Caption.Contains(dataset.Name))
                {
                    layers.Remove(layer.Name);
                    nLayer--;
                    i--;
                }
            }
            Datasource datsource = dataset.Datasource;
            bool ret = datsource.Datasets.Delete(dataset.Name);
            datsource.Refresh();
        }

        //设置是否开启太阳
        private void SetSunVisible_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_sceneControl.Scene.Sun.IsVisible = !this.m_sceneControl.Scene.Sun.IsVisible;
            this.SetSunVisible_ToolStripMenuItem.Checked = !this.SetSunVisible_ToolStripMenuItem.Checked;
        }

        //设置太阳轨迹
        private void SunTrajectorySetting_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_dlgSunTrajectory == null || m_dlgSunTrajectory.IsDisposed)
            {
                m_dlgSunTrajectory = new DlgSunTrajectory();
            }
            m_dlgSunTrajectory.Initialize(m_sceneControl);
            m_dlgSunTrajectory.Show();
        }

        //可视域分析
        private void ViewShedAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_sceneControl.Scene.Name != "Model")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("Model");
            }
            if (m_dlgViewShed == null || m_dlgViewShed.IsDisposed)
            {
                m_dlgViewShed = new DlgViewShedAnalysis();
            }
            m_dlgViewShed.SetWorkspace(workspace);
            m_dlgViewShed.SetSceneControl(m_sceneControl);
            m_dlgViewShed.Show();

            //刷新场景，保证数据更新出来
            m_sceneControl.Scene.Refresh();
        }

        //视线分析
        private void SightlineAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "Model")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("Model");
            }
            if (m_dlgSightline == null || m_dlgSightline.IsDisposed)
            {
                m_dlgSightline = new DlgSightLine();
            }
            m_dlgSightline.setWorkspace(workspace);
            m_dlgSightline.SetSceneControl(this.m_sceneControl);
            m_dlgSightline.Show();
            m_sceneControl.Scene.Refresh();
        }

        //天际线分析
        private void SkylineAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "Model")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("Model");
            }
            if (m_dlgSkyline == null || m_dlgSkyline.IsDisposed)
            {
                m_dlgSkyline = new DlgSkyline();
            }
            m_dlgSkyline.setWorkspace(workspace);
            m_dlgSkyline.SetSceneControl(this.m_sceneControl);
            m_dlgSkyline.Show();


            //刷新场景，保证数据更新出来
            m_sceneControl.Scene.Refresh();
        }

        //裁剪面分析
        private void ClippingPlane_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "Model")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("Model");
            }
            if (m_dlgClipPlane == null || m_dlgClipPlane.IsDisposed)
            {
                m_dlgClipPlane = new DlgClipPlane();
            }
            m_dlgClipPlane.SetSceneControl(m_sceneControl);
            m_dlgClipPlane.Show();


            //刷新场景，保证数据更新出来
            m_sceneControl.Scene.Refresh();
        }

        //剖面线分析
        private void Profile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "Model")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("Model");
            }
            if (m_dlgProfileAnalysis == null || m_dlgProfileAnalysis.IsDisposed)
            {
                m_dlgProfileAnalysis = new DlgProfileAnalysis();
            }

            m_dlgProfileAnalysis.Initialize(workspace, m_sceneControl);
            m_dlgProfileAnalysis.Show();

            //刷新场景，保证数据更新出来
            m_sceneControl.Scene.Refresh();
        }

        //阴影分析
        private void ShadowAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "Model")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("Model");
            }
            if (m_dlgShadowAnalysis == null || m_dlgShadowAnalysis.IsDisposed)
            {
                m_dlgShadowAnalysis = new DlgShadowAnalysis();
            }

            m_dlgShadowAnalysis.Initalize(m_sceneControl);
            m_dlgShadowAnalysis.Show();

            //刷新场景，保证数据更新出来
            m_sceneControl.Scene.Refresh();
        }

        //等高线分析
        private void ContourAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "BeiJingDem")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("BeiJingDem");
            }
            if (m_dlgContourMap == null || m_dlgContourMap.IsDisposed)
            {
                m_dlgContourMap = new DlgContourMap();
            }
            m_dlgContourMap.setWorkspace(workspace);
            m_dlgContourMap.SetSceneControl(this.m_sceneControl);
            m_dlgContourMap.Show();

            //刷新场景，保证数据更新出来
            m_sceneControl.Scene.Refresh();
        }

        //坡度坡向分析
        private void SlopeAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "BeiJingDem")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("BeiJingDem");
            }
            if (m_dlgSlopeMap == null || m_dlgSlopeMap.IsDisposed)
            {
                m_dlgSlopeMap = new DlgSlopeMap();
            }
            m_dlgSlopeMap.setWorkspace(workspace);
            m_dlgSlopeMap.SetSceneControl(this.m_sceneControl);
            m_dlgSlopeMap.Show();

            m_sceneControl.Scene.Refresh();

        }

        //淹没分析
        private void FloodAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 设定图例中不同水深的颜色，并设置图例初始状态为不显示
            m_panel0.BackColor = Color.FromArgb(36, 65, 171);
            m_panel1.BackColor = Color.FromArgb(80, 107, 191);
            m_panel2.BackColor = Color.FromArgb(124, 149, 210);
            m_panel3.BackColor = Color.FromArgb(168, 191, 230);
            m_panel4.BackColor = Color.FromArgb(212, 233, 250);//Color.FromArgb(247, 231, 197);

            this.panelDiagram.Visible = false;

            if (m_sceneControl.Scene.Name != "BeiJingDem")
            {
                m_sceneControl.Scene.Layers.Clear();
                m_sceneControl.Scene.TerrainLayers.Clear();
                m_sceneControl.Scene.Open("BeiJingDem");
            }
            if (m_dlgFloodAnalysis == null || m_dlgFloodAnalysis.IsDisposed)
            {
                m_dlgFloodAnalysis = new DlgFloodAnalysis();
            }
            m_dlgFloodAnalysis.Initialize(m_sceneControl,this.panelDiagram);
            m_dlgFloodAnalysis.Show();

            m_sceneControl.Scene.Refresh();
        }

        private void SetShadowType_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //设置所选择的图层的阴影类型为All，即所有对象产生阴影
        private void ShadowAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer == null)
            {
                MessageBox.Show("请先选择一个图层!");
                return;
            }

            m_selectedLayer.ShadowType = ShadowType.ALL;

            this.ShadowSelection_ToolStripMenuItem.Checked = false;
            this.NoShadow_ToolStripMenuItem.Checked = false;
        }

        //设置所选择的图层的阴影类型为Selection，即选中对象产生阴影
        private void ShadowSeletion_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer == null)
            {
                MessageBox.Show("请先选择一个图层!");
                return;
            }
            m_selectedLayer.ShadowType = ShadowType.SELECTION;

            this.ShadowAll_ToolStripMenuItem.Checked = false;
            this.NoShadow_ToolStripMenuItem.Checked = false;
        }

        //设置所选择的图层的阴影类型为None，即不开启阴影
        private void NoShadow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_selectedLayer == null)
            {
                MessageBox.Show("请先选择一个图层!");
                return;
            }

            m_selectedLayer.ShadowType = ShadowType.NONE;
            this.ShadowAll_ToolStripMenuItem.Checked = false;
            this.ShadowSelection_ToolStripMenuItem.Checked = false;
        }
    }
}
