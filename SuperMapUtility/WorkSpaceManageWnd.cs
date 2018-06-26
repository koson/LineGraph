///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、范例简介：示范打开、创建、另存、删除文件型和数据库型工作空间
//2、示例数据：无        
//3、关键类型/成员: 
//      WorkspaceConnectionInfo 类型
//      Workspace.Open 方法
//      Workspace.Create 方法
//      Workspace.SavaAs 方法
//      Workspace.DeleteWorkspace 方法
//
//4、使用步骤：
//   (1)打开或创建工作空间，查看工作空间属性。
//   (2)另存当前工作空间。
//   (3)删除当前工作空间。
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SuperMap.UI;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.Mapping;


namespace LineGraph.SuperMapUtility
{
    public partial class WorkSpaceManageWnd : Form
    {
        public Workspace m_workspace;
        public SceneControl m_SceneControl;
        public MapControl m_MapControl;

        private SampleWorkSpaceRun m_sampleRun;
        private WorkspaceConnectionInfo m_connectionInfo;
        private Layer3DOSGBFile m_LayerOSGB;

        private static String m_filedName = "ModelId";
        private Layer3DDataset m_layer3DPoint;
        private Layer3DDataset m_layer3DRegion;
        private bool m_bAddedPointLayer = false;

        private int pointColor = 0;

        private LineGraph.SQLUtility.DeviceAddressWnd m_DeviceAddressWnd;

        private bool bSceneOpened = false;
       
        public WorkSpaceManageWnd()
        {
            try
            {
                InitializeComponent();

                m_workspace = new SuperMap.Data.Workspace();
                m_SceneControl = new SuperMap.UI.SceneControl();
                m_MapControl = new SuperMap.UI.MapControl();
                m_connectionInfo = new WorkspaceConnectionInfo();
                //实例化SampleRun
                m_sampleRun = new SampleWorkSpaceRun(m_workspace);
                m_sampleRun.OnCheck += new SampleWorkSpaceRun.CheckEventHandler(m_sampleRun_OnCheck);
                this.comboBoxCreateSDBVersion.SelectedIndexChanged += new EventHandler(comboBoxCreateSDBVersion_SelectedIndexChanged);
                this.comboBoxSaveSDBVersion.SelectedIndexChanged += new EventHandler(comboBoxSaveSDBVersion_SelectedIndexChanged);
                // 初始化控件

                comboBoxCreateSQLVersion.SelectedIndex = 0;
                comboBoxCreateOracleVersion.SelectedIndex = 0;
                comboBoxCreateSDBType.SelectedIndex = 0;
                comboBoxCreateSDBVersion.SelectedIndex = 0;
                comboBoxSaveSQLVersion.SelectedIndex = 0;
                comboBoxSaveOracleVersion.SelectedIndex = 0;
                comboBoxSaveSDBType.SelectedIndex = 0;
                comboBoxSaveSDBVersion.SelectedIndex = 0;

                this.m_SceneControl.Scene.Opened += new SceneOpenedEventHandler(Scene_Opened);
                this.m_SceneControl.MouseUp += new System.Windows.Forms.MouseEventHandler(SceneControl_MouseUp);

                m_DeviceAddressWnd = SQLUtility.DeviceAddressWnd.Create();
                m_DeviceAddressWnd.CameraDataAdjustHandler += new LineGraph.SQLUtility.DeviceAddressWnd.CameraDataAdjustEventHandler(CameraDataAdjust_Ctrl);
                m_DeviceAddressWnd.AddModelIDHandler += new LineGraph.SQLUtility.DeviceAddressWnd.AddModelIDEventHandler(AddModelID_Ctrl);
                m_DeviceAddressWnd.AddModelHandler += new LineGraph.SQLUtility.DeviceAddressWnd.AddModelEventHandler(AddModel_Ctrl);
                m_DeviceAddressWnd.DeleteModelHandler += new LineGraph.SQLUtility.DeviceAddressWnd.DeleteModelEventHandler(DeleteModel_Ctrl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CloseWorkSpace()
        {
            try
            {
                m_SceneControl.Dispose();
                m_MapControl.Dispose();
                m_workspace.Datasources.CloseAll();
                m_workspace.Close();
                m_workspace.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenWorkSpaceScene()
        {
            if (bSceneOpened) return;

            try
            {
                m_SceneControl.Scene.Close();

                if (m_workspace.Scenes.Count > 0)
                {
                    m_SceneControl.Scene.Workspace = m_workspace;
                    m_SceneControl.Action = Action3D.Pan;
                    m_SceneControl.Scene.Open(UserHelper.SceneLayerName);

                    m_SceneControl.Scene.Refresh();

                    bSceneOpened = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenWorkSpaceOSGB()
        {
            try
            {
                m_SceneControl.Scene.Close();

                if (m_workspace.Scenes.Count > 0)
                {
                    m_SceneControl.Scene.Workspace = m_workspace;
                    m_SceneControl.Action = Action3D.Pan;
                    m_SceneControl.Scene.Open(UserHelper.SceneLayerOSGBName);

                    m_SceneControl.Scene.Refresh();

                    bSceneOpened = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpensSceneSpace()
        {
            textBoxSDBPath.Text = UserHelper.WorkSpaceName;

            try
            {
                m_connectionInfo.Server = textBoxSDBPath.Text;
                m_connectionInfo.Type = this.GetType(System.IO.Path.GetExtension(textBoxSDBPath.Text).ToUpper().Replace(".", String.Empty));
                m_connectionInfo.Name = System.IO.Path.GetFileNameWithoutExtension(textBoxSDBPath.Text);
                m_connectionInfo.Password = textBoxSDBPassword.Text;

                m_SceneControl.Scene.Close();
                m_MapControl.Map.Close();
                m_workspace.Close();

                Boolean isSucceed = m_workspace.Open(m_connectionInfo);
                LoadDatasetResources();

                if (m_workspace.Scenes.Count > 0)
                {
                    m_SceneControl.Scene.Workspace = m_workspace;
                    m_SceneControl.Action = Action3D.Pan;
                    m_SceneControl.Scene.Open(UserHelper.SceneLayerName);

                    m_SceneControl.Scene.Refresh();
                }

                CreateDatasets();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenWorkSpaceMap(int index)
        {
            try
            {
                m_MapControl.Map.Close();

                if (m_workspace.Maps.Count > 0)
                {
                    m_MapControl.Map.Workspace = m_workspace;
                    if(index == 0)
                    {
                        m_MapControl.Map.Open(UserHelper.MapLayerName正射影像);
                    }
                    if (index == 1)
                    {
                        m_MapControl.Map.Open(UserHelper.MapLayerName线划图);
                    }
                    if (index == 2)
                    {
                        m_MapControl.Map.Open(UserHelper.MapLayerName卫星影像);
                    }

                    m_MapControl.Map.Zoom(0.5);
                    m_MapControl.Map.ViewEntire();

                    m_MapControl.Map.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenWorkSpace()
        {
            textBoxSDBPath.Text = UserHelper.WorkSpaceName;

            try
            {
                m_connectionInfo.Server = textBoxSDBPath.Text;
                m_connectionInfo.Type = this.GetType(System.IO.Path.GetExtension(textBoxSDBPath.Text).ToUpper().Replace(".", String.Empty));
                m_connectionInfo.Name = System.IO.Path.GetFileNameWithoutExtension(textBoxSDBPath.Text);
                m_connectionInfo.Password = textBoxSDBPassword.Text;

                m_SceneControl.Scene.Close();
                m_MapControl.Map.Close();
                m_workspace.Close();
 
                Boolean isSucceed = m_workspace.Open(m_connectionInfo);
                LoadDatasetResources();
                
                if (m_workspace.Maps.Count > 0)
                {
                    m_MapControl.Map.Workspace = m_workspace;
                    m_MapControl.Map.Open(UserHelper.MapLayerName);
                    m_MapControl.Map.Zoom(0.5);
                    m_MapControl.Map.ViewEntire();

                    m_MapControl.Map.Refresh();
                }

   
                if (m_workspace.Scenes.Count > 0)
                {
                    m_SceneControl.Scene.Workspace = m_workspace;
                    m_SceneControl.Action = Action3D.Pan;
                    m_SceneControl.Scene.Open(UserHelper.SceneLayerName);

                    m_SceneControl.Scene.Refresh();
                }

                CreateDatasets();
                m_DeviceAddressWnd.UpdateView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeviceAddressShow()
        {
            m_DeviceAddressWnd.SetSaveStatus(false);
            m_DeviceAddressWnd.ShowDialog();
        }

 
        public void CameraDataAdjust_Ctrl(object sender)
        {
            GeoPoint gp = sender as GeoPoint;
            Camera camera = new Camera(gp.X, gp.Y - 0.0002, 20);
            camera.Tilt = 80;
            m_SceneControl.Scene.FirstPersonCamera = camera;
            m_SceneControl.Scene.Refresh();
        }

        private string m_ModelId;
        private string m_ModelNOId;
        private void AddModelID_Ctrl(object sender)
        {
            List<string> lst = (List<string>)sender;
            m_ModelId = lst[0];
            m_ModelNOId = lst[1];
        }

        private void AddModel_Ctrl(object sender)
        {
            Point2Ds Point2Ds = (Point2Ds)sender;
            AddModel_Click(Point2Ds, m_ModelId, m_ModelNOId);
        }

        private void DeleteModel_Ctrl(object sender, EventArgs e)
        {
            m_ModelId = (string)sender;
            DeleteModel_Click(m_ModelId);
        }

        public void AddModel_Click(Point2Ds Point2Ds, string strID, string strNOID)
        {
            Point3D Point3D = new Point3D(Point2Ds[0].X, Point2Ds[0].Y, Point2Ds[1].X);
            AddModel_Click(Point3D, (int)Point2Ds[1].Y, strID, strNOID);
        }

        public void AddModel_Click(Point3D Point3D, int ModelIndex, string strID, string strNOID)
        {
            AddPointToDatasets(Point3D, ModelIndex, strID, strNOID);

            Datasource datasource = m_workspace.Datasources[0];
            DatasetVector pointDataset = datasource.Datasets["Point3D"] as DatasetVector;
            Recordset recordset = pointDataset.GetRecordset(false, CursorType.Dynamic);
           
            GeoPoint3D geopoint3D = new GeoPoint3D(Point3D);
            GeoStyle3D geoStyle = new GeoStyle3D();
            geoStyle.MarkerSymbolID = UserHelper.Marker3DSymbolID[ModelIndex];
            geoStyle.IsMarkerSizeFixed = false;
            geoStyle.MarkerSize = 1;
            geoStyle.Marker3DScaleX = 0.03;
            geoStyle.Marker3DScaleY = 0.03;
            geoStyle.Marker3DScaleZ = 0.08;
            geoStyle.IsMarker3D = true;
            geoStyle.AltitudeMode = AltitudeMode.RelativeToGround;
            geopoint3D.Style3D = geoStyle;

            recordset.MoveLast();
            recordset.AddNew(geopoint3D);
            recordset.SetFieldValue(m_filedName, strID);
            recordset.Update();
            recordset.Dispose();

            m_layer3DPoint.IsSelectable = false;
            m_layer3DPoint.UpdateData();
            m_SceneControl.Scene.Refresh();

            //AddKmlLayer();

            //GeoPlacemark geoPlacemark = new GeoPlacemark();
            //m_geoModel = new GeoModel();
            //m_geoModel.FromFile(UserHelper.sModelName[ModelIndex]);
            ////人物模型朝向前进方向，如果原始方向一致则不需要旋转。
            //m_geoModel.Style3D = m_style3D;
            //m_geoModel.RotationZ = 180;
            //m_geoModel.ScaleX = 0.3;
            //m_geoModel.ScaleY = 0.3;
            //m_geoModel.ScaleZ = 0.3;
            //m_geoModel.Position = new Point3D(Point3D.X, Point3D.Y, Point3D.Z);
            //geoPlacemark.Geometry = m_geoModel;
            //Feature3Ds feture3Ds = m_LayerKML.Features;
            //Feature3D feature = new Feature3D();
            //feature.Geometry = geoPlacemark;
            //feature.Description = strID;
            //feature.Name = feature.Description;
            //feture3Ds.Add(feature);
            //feture3Ds.ToKMLFile(m_LayerKML.DataName);
            //m_LayerKML.UpdateData();
        }

        private void AddPointToDatasets(Point3D Point3D, int ModelIndex, string strID, string strNOID)
        {
            CreateDatasets();
            try
            {
                Datasource datasource = m_workspace.Datasources[0];
                DatasetVector pointDataset = datasource.Datasets[UserHelper.sDeviceName[ModelIndex]] as DatasetVector;

                if (pointDataset != null)
                {
                    GeoPoint geoPoint = new GeoPoint(Point3D.X, Point3D.Y);
                    Recordset recordset = pointDataset.GetRecordset(false, CursorType.Dynamic);
                    recordset.MoveLast();
                    recordset.AddNew(geoPoint);
                    recordset.SetFieldValue(m_filedName, strID);
                    recordset.Update();
                    recordset.Close();
                    recordset.Dispose();
                }

                m_MapControl.Map.Refresh();

                DatasetVector textDataset = datasource.Datasets[UserHelper.sTextName] as DatasetVector;
                if (textDataset != null)
                {
                    Recordset textRecordset = textDataset.GetRecordset(false, CursorType.Dynamic);

                    TextPart part = new TextPart();
                    part.Text = strNOID;
                    Point2D point2D = new Point2D(Point3D.X, Point3D.Y);
                    part.AnchorPoint = point2D;
                    GeoText geoText = new GeoText(part);
                    geoText.TextStyle.ForeColor = Color.Green;
                    geoText.TextStyle.FontHeight = 8;
      
                    textRecordset.MoveLast();
                    textRecordset.AddNew(geoText);
                    textRecordset.Update();
                    textRecordset.Close();
                    textRecordset.Dispose();

                }

                m_MapControl.Map.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CreateDatasets()
        {
            if (m_bAddedPointLayer) return;
            try
            {
                //创建点数据集
                Datasource datasource = m_workspace.Datasources[0];

                PrjCoordSys crtPrjSys;
                //if (m_workspace.Maps.Count == 0)
                {
                    crtPrjSys = new PrjCoordSys();
                    crtPrjSys.Type = PrjCoordSysType.EarthLongitudeLatitude;
                }
                //else
                //{
                    //crtPrjSys = m_MapControl.Map.Layers[UserHelper.MapLayerName].Dataset.PrjCoordSys;
               // }

                for (int iDeviceIndex = 0; iDeviceIndex < UserHelper.nDeviceNum; iDeviceIndex++)
                {
                    datasource.Datasets.Delete(UserHelper.sDeviceName[iDeviceIndex]);
                    DatasetVectorInfo pointLayerInfo = new DatasetVectorInfo(UserHelper.sDeviceName[iDeviceIndex], DatasetType.Point);
                    DatasetVector pointDataset = datasource.Datasets.Create(pointLayerInfo);

                    // 添加使用的字段
                    FieldInfo fieldInfo = new FieldInfo();
                    fieldInfo.Type = FieldType.Char;
                    fieldInfo.Name = m_filedName;
                    pointDataset.FieldInfos.Add(fieldInfo);
                    pointDataset.PrjCoordSys = crtPrjSys;

                    //将点数据集加入到地图中
                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.SeaGreen;
                    setting.Style.MarkerSize = new Size2D(8,8);
                    setting.Style.MarkerSymbolID = UserHelper.MarkerSymbolID[iDeviceIndex];
                    m_MapControl.Map.Layers.Add(pointDataset, setting, true);
                    m_MapControl.Map.Refresh();
                }

                datasource.Datasets.Delete(UserHelper.sTextName);
                DatasetVectorInfo textLayerInfo = new DatasetVectorInfo(UserHelper.sTextName, DatasetType.Text);
                DatasetVector textDataset = datasource.Datasets.Create(textLayerInfo);
                textDataset.PrjCoordSys = crtPrjSys;
                m_MapControl.Map.Layers.Add(textDataset, true);
                m_MapControl.Map.Refresh();

                //定义新数据集
                {
                    datasource.Datasets.Delete("Point3D");
                    DatasetVectorInfo Datasetinfo = new DatasetVectorInfo();
                    Datasetinfo.Type = DatasetType.CAD;
                    Datasetinfo.Name = "Point3D";
                    DatasetVector datset = datasource.Datasets.Create(Datasetinfo);

                    FieldInfo fieldInfo = new FieldInfo();
                    fieldInfo.Type = FieldType.Char;
                    fieldInfo.Name = m_filedName;
                    datset.FieldInfos.Add(fieldInfo);
                    datset.PrjCoordSys = crtPrjSys;

                    DatasetVector datasetPoint3D = datasource.Datasets["Point3D"] as DatasetVector;

                    if (m_SceneControl.Scene.Layers.Contains("stylePoint3D"))
                    {
                        m_layer3DPoint = m_SceneControl.Scene.Layers["stylePoint3D"] as Layer3DDataset;
                    }
                    else
                    {
                        m_layer3DPoint = m_SceneControl.Scene.Layers.Add(datasetPoint3D, new Layer3DSettingVector(), true, "stylePoint3D");
                    }
                    m_SceneControl.Scene.Refresh();
                }

                // 新建数据集
                {
                    datasource.Datasets.Delete("Region3D");
                    DatasetVectorInfo Datasetinfo = new DatasetVectorInfo();
                    Datasetinfo.Type = DatasetType.Region3D;
                    Datasetinfo.Name = "Region3D";
                    DatasetVector datset = datasource.Datasets.Create(Datasetinfo);
                    datset.PrjCoordSys = crtPrjSys;

                    DatasetVector m_datasetRegion3D = datasource.Datasets["Region3D"] as DatasetVector;
                    if (m_SceneControl.Scene.Layers.Contains("styleRegion3D"))
                    {
                        m_layer3DRegion = m_SceneControl.Scene.Layers["styleRegion3D"] as Layer3DDataset;
                    }
                    else
                    {
                        m_layer3DRegion = m_SceneControl.Scene.Layers.Add(m_datasetRegion3D, new Layer3DSettingVector(), true, "styleRegion3D");
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            m_bAddedPointLayer = true;
        }

        public void DeleteModel_Click(string strID)
        {
            //if (m_LayerKML == null) return;
            //Feature3Ds features = m_LayerKML.Features;
            //Feature3D[] feature3Ds = features.FindFeature(strID, Feature3DSearchOption.AllFeatures);

            //if (feature3Ds.Length > 0)
            //{
            //    Feature3D feature3D = feature3Ds[0];
            //    m_LayerKML.Features.Remove(feature3D);
            //}

            Datasource datasource = m_workspace.Datasources[0];
            DatasetVector point3DDataset = datasource.Datasets["Point3D"] as DatasetVector;
            try
            {
                if (point3DDataset != null)
                {
                    Recordset recordSet = point3DDataset.Query(m_filedName + "='" + strID + "'", CursorType.Dynamic);
                    int recCount = recordSet.RecordCount;
                    if (recCount == 1)
                    {
                        recordSet.Delete();
                        recordSet.Update();
                        recordSet.Close();
                        recordSet.Dispose();
                    }
                    recordSet.Close();
                    recordSet.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            m_layer3DPoint.IsSelectable = false;
            m_layer3DPoint.UpdateData();
            m_SceneControl.Scene.Refresh();


            for (int ModelIndex = 0; ModelIndex < UserHelper.nDeviceNum; ModelIndex++)
            {
                DatasetVector pointDataset = datasource.Datasets[UserHelper.sDeviceName[ModelIndex]] as DatasetVector;
                Recordset recordSet = null;
                try
                {
                    if (pointDataset != null)
                    {
                        recordSet = pointDataset.Query(m_filedName + "='" + strID + "'", CursorType.Dynamic);
                        int recCount = recordSet.RecordCount;
                        if (recCount == 1)
                        {
                            recordSet.Delete();
                            recordSet.Update();
                            recordSet.Close();
                            recordSet.Dispose();
                            break;
                        }
                        recordSet.Close();
                        recordSet.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            m_MapControl.Map.Refresh();
        }

        public void UpdateMapView(string strID)
        {
            if (m_workspace.Datasources.Count <= 0) return;

            Datasource datasource = m_workspace.Datasources[0];
            for (int ModelIndex = 0; ModelIndex < UserHelper.nDeviceNum; ModelIndex++)
            {
                DatasetVector pointDataset = datasource.Datasets[UserHelper.sDeviceName[ModelIndex]] as DatasetVector;
                Recordset recordSet = null;
                try
                {
                    if (pointDataset != null)
                    {
                        recordSet = pointDataset.Query(m_filedName + "='" + strID + "'", CursorType.Dynamic);
                        int recCount = recordSet.RecordCount;
                        if (recCount == 1)
                        {
                            //if (pointColor >= 255)
                            //{
                            //    pointColor = 0;
                            //}

                            pointColor = pointColor == 120 ? 255 : 120;

                            GeoStyle style = new GeoStyle();
                            style.MarkerSize = new Size2D(8, 8);
                            style.LineColor = Color.FromArgb(0, 0, pointColor, 0);
                            //pointColor += 60;
                            GeoPoint point = recordSet.GetGeometry() as GeoPoint;
                            point.Style = style;

                            int index = m_MapControl.Map.TrackingLayer.IndexOf(strID);
                            if (index >= 0)
                            {
                                m_MapControl.Map.TrackingLayer.Remove(index);
                            }

                            m_MapControl.Map.TrackingLayer.Add(point, strID);

                            //recordSet.Edit();
                            //recordSet.Update();
                            //recordSet.Close();
                            //recordSet.Dispose();
                            break;
                        }
                        //recordSet.Close();
                        //recordSet.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            m_MapControl.Map.Refresh();
        }

        public void Layer3D_Click()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "打开三维缓存文件";
            openFileDialog.Filter = "所有支持的三维缓存文件（*.sci, *.scv, *.scp,*.sci3d, *.sct, *.sit,*.gci,*.scm）|*.sci;*.scv;*.scp;*.sci3d;*.sct;*.sit;*.gci;*.scm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                String extention = System.IO.Path.GetExtension(fileName);
                Layer3D layer3D = null;
                Layer3Ds layer3ds = this.m_SceneControl.Scene.Layers;

                switch (extention)
                {
                    case ".sci":
                    case ".sci3d":
                    case ".sit":
                    case ".gci":
                        {
                            layer3D = layer3ds.Add(fileName, Layer3DType.ImageFile, true);
                            layer3D.UpdateData();
                            this.m_SceneControl.Scene.Refresh();
                            this.m_SceneControl.Scene.EnsureVisible(layer3D.Bounds);
                            break;
                        }
                    case ".scv":
                        {
                            layer3D = layer3ds.Add(fileName, Layer3DType.VectorFile, true);
                            //layer3D.UpdateData();
                            this.m_SceneControl.Scene.Refresh();
                            this.m_SceneControl.Scene.EnsureVisible(layer3D.Bounds);

                            break;
                        }
                    case ".scp":
                        {
                            layer3D = layer3ds.Add(fileName, Layer3DType.OSGB, true);

                            if (layer3D != null)
                            {
                                m_LayerOSGB = layer3D as Layer3DOSGBFile;
                                this.m_SceneControl.Scene.EnsureVisible(m_LayerOSGB.Bounds);
                                this.m_SceneControl.Scene.Refresh();
                            }

                            break;
                        }
                    case ".sct":
                        {
                            TerrainLayer terrainlayer3D = this.m_SceneControl.Scene.TerrainLayers.Add(fileName, true);
                            this.m_SceneControl.Scene.Refresh();
                            this.m_SceneControl.Scene.EnsureVisible(terrainlayer3D.Bounds);

                            break;
                        }
                }
            }
        }

        void SceneControl_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (UserHelper.bMeasure || UserHelper.bAddSymbolMark || UserHelper.bAddSymbolFill) return;

                    m_SceneControl.InteractionMode = InteractionMode3D.Default;
                    m_SceneControl.Action = Action3D.Pan2;
                    m_SceneControl.IsCursorCustomized = true;
                    m_SceneControl.Cursor = System.Windows.Forms.Cursors.Cross;

                    Point3D point3D = new Point3D();
                    point3D = m_SceneControl.Scene.PixelToGlobe(e.Location, PixelToGlobeMode.TerrainAndModel);

                    m_DeviceAddressWnd.SetModelPoint(point3D);
                    m_DeviceAddressWnd.SetSaveStatus(true);

                    if (m_DeviceAddressWnd.ShowDialog() == DialogResult.OK)
                    {
                        if (!Double.IsNaN(point3D.X) && !Double.IsNaN(point3D.Y) && !Double.IsNaN(point3D.Z))
                        {
                            AddModel_Click(point3D, m_DeviceAddressWnd.nModelIndex, m_DeviceAddressWnd.strModelID, m_DeviceAddressWnd.strModelNOID);
                        }
                    }

                    m_SceneControl.Action = Action3D.Pan;
                    m_SceneControl.IsCursorCustomized = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Scene_Opened(object sender, EventArgs e)
        {
            Layer3Ds layers = this.m_SceneControl.Scene.Layers;
            for (int i = 0; i < layers.Count; i++)
            {
                Layer3D layer = layers[i];
                if (layer.Type == Layer3DType.OSGB)
                {
                    m_LayerOSGB = layer as Layer3DOSGBFile;
                }
            }
        }

        public Boolean OpenData()
        {
            LoadDatasetResources();
           
            OpenMapData();
            Scene Scene = this.m_SceneControl.Scene;
            Scene.Workspace = m_workspace;
            if (m_workspace.Scenes.Count == 0) return false;
            //bool bOpen = Scene.Open(UserHelper.SceneLayerName);
            bool bOpen = Scene.Open(this.m_workspace.Scenes[0]);

            if (!bOpen)
            {
                MessageBox.Show("打开场景失败！");
                return false;
            }

            m_SceneControl.Scene.Refresh();

            CreateDatasets();

            return true;
        }

        private Boolean OpenMapData()
        {
            if (m_workspace.Maps.Count == 0) return false;
            m_MapControl.Map.Workspace = m_workspace;
            //bool bOpen = m_MapControl.Map.Open(UserHelper.MapLayerName);
            bool bOpen = m_MapControl.Map.Open(this.m_workspace.Maps[0]);

            if (!bOpen)
            {
                MessageBox.Show("打开地图失败！");
                return false;
            }

            m_MapControl.Map.Refresh();
            return true;
        }

        private void LoadDatasetResources()
        {
            try
            {
                //导入三维符号库文件
                Resources resource = m_workspace.Resources;
                SymbolMarkerLibrary markerlibrary = resource.MarkerLibrary;
                markerlibrary.FromFile(@"..\..\Bin64\Ref\3DData\SymbolLibrary\Marker3DLibrary.sym");

                SymbolLineLibrary linelibrary = resource.LineLibrary;
                linelibrary.FromFile(@"..\..\Bin64\Ref\3DData\SymbolLibrary\Line3DLibrary.lsl");
               
                SymbolFillLibrary filllibrary = resource.FillLibrary;
                filllibrary.FromFile(@"..\..\Bin64\Ref\3DData\SymbolLibrary\Fill3DLibrary.bru");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSaveSDBVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (comboBoxSaveSDBVersion.SelectedIndex == 0)
                //{
                    comboBoxSaveSDBType.Items.Clear();
                    comboBoxSaveSDBType.Items.Add("SMWU");
                    comboBoxSaveSDBType.Items.Add("SXWU");
                //}
                //else
                //{
                //    comboBoxSaveSDBType.Items.Clear();
                //    comboBoxSaveSDBType.Items.Add("SMW");
                //    comboBoxSaveSDBType.Items.Add("SXW");
                //}

                comboBoxSaveSDBType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxCreateSDBVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (comboBoxCreateSDBVersion.SelectedIndex == 0)
                //{
                    comboBoxCreateSDBType.Items.Clear();
                    comboBoxCreateSDBType.Items.Add("SMWU");
                    comboBoxCreateSDBType.Items.Add("SXWU");
                //}
                //else
                //{
                //    comboBoxCreateSDBType.Items.Clear();
                //    comboBoxCreateSDBType.Items.Add("SMW");
                //    comboBoxCreateSDBType.Items.Add("SXW");
                //}

                comboBoxCreateSDBType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 做操作的同时设置界面
        /// </summary>
        /// <param name="args"></param>
        private void m_sampleRun_OnCheck(Boolean isInitialize)
        {
            try
            {
                if (isInitialize)
                {
                    tabControlSave.Enabled = false;
                    buttonDeleteOK.Enabled = false;
                    buttonDeleteCancel.Enabled = false;
                }
                else
                {
                    tabControlSave.Enabled = true;
                    buttonDeleteOK.Enabled = true;
                    buttonDeleteCancel.Enabled = true;

                    OpenData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 在窗体关闭时，需要释放相关的资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 浏览选择SDB文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenSDBFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDig = new OpenFileDialog();
                //openFileDig.Filter = "SMWU files (*.smwu)|*.smwu|SXW files (*.sxw)|*.sxw|SMW files (*.smw)|*.smw|SXWU files (*.sxwu)|*.sxwu";
                openFileDig.Filter = "所有支持的三维缓存文件（*.smwu, *.sxwu, *.sxw,*.smw）|*.smwu;*.sxwu;*.sxw;*.smw;";
                if (openFileDig.ShowDialog() == DialogResult.OK)
                {
                    textBoxSDBPath.Text = openFileDig.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 打开SDB工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSDBOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSDBPath.Text;
                m_connectionInfo.Type = this.GetType(System.IO.Path.GetExtension(textBoxSDBPath.Text).ToUpper().Replace(".", String.Empty));
                m_connectionInfo.Name = System.IO.Path.GetFileNameWithoutExtension(textBoxSDBPath.Text);
                m_connectionInfo.Password = textBoxSDBPassword.Text;

                m_SceneControl.Scene.Close();
                m_MapControl.Map.Close();

                richTextBoxOutput.Text += m_sampleRun.Open(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 打开Oracle工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOracleOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxOrcleServer.Text;
                m_connectionInfo.Database = textBoxOrcleDatabase.Text;
                m_connectionInfo.User = textBoxOracleUser.Text;
                m_connectionInfo.Password = textBoxOraclePassword.Text;
                m_connectionInfo.Name = textBoxOrcleName.Text;
                m_connectionInfo.Type = WorkspaceType.Oracle;

                m_SceneControl.Scene.Close();
                m_MapControl.Map.Close();

                richTextBoxOutput.Text += m_sampleRun.Open(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 打开SQL工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSQLOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSQLServer.Text;
                m_connectionInfo.Database = textBoxSQLDatabase.Text;
                m_connectionInfo.User = textBoxSQLUser.Text;
                m_connectionInfo.Password = textBoxSQLPassword.Text;
                m_connectionInfo.Name = textBoxSQLName.Text;
                m_connectionInfo.Driver = "SQL Server";
                m_connectionInfo.Type = WorkspaceType.SQL;

                m_SceneControl.Scene.Close();
                m_MapControl.Map.Close();

                richTextBoxOutput.Text += m_sampleRun.Open(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选择创建的SDB路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSDBFile_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDig = new FolderBrowserDialog();

                if (folderBrowserDig.ShowDialog() == DialogResult.OK)
                {
                    textBoxCreateSDBPath.Text = folderBrowserDig.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 创建SDB工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSDBOK_Click(object sender, EventArgs e)
        {
            try
            {
                String extension = comboBoxCreateSDBType.SelectedItem as String;

                m_connectionInfo.Version = this.GetVersion(comboBoxCreateSDBVersion.SelectedIndex);
                m_connectionInfo.Type = this.GetType(extension);
                m_connectionInfo.Server = System.IO.Path.Combine(textBoxCreateSDBPath.Text, textBoxCreateSDBName.Text + "." + extension);
                m_connectionInfo.Name = textBoxCreateSDBName.Text;
                m_connectionInfo.Password = textBoxCreateSDBPassword.Text;

                richTextBoxOutput.Text += m_sampleRun.Create(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 创建Oracle工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateOracleOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxCreateOracleServer.Text;
                m_connectionInfo.Database = textBoxCreateOracleDatabase.Text;
                m_connectionInfo.User = textBoxCreateOracleUser.Text;
                m_connectionInfo.Password = textBoxCreateOraclePassword.Text;
                m_connectionInfo.Name = textBoxCreateOracleName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxCreateOracleVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.Oracle;

                richTextBoxOutput.Text += m_sampleRun.Create(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 创建SQL工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSQLOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxCreateSQLServer.Text;
                m_connectionInfo.Database = textBoxCreateSQLDatabase.Text;
                m_connectionInfo.User = textBoxCreateSQLUser.Text;
                m_connectionInfo.Password = textBoxCreateSQLPassword.Text;
                m_connectionInfo.Name = textBoxCreateSQLName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxCreateSQLVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.SQL;
                m_connectionInfo.Driver = "SQL Server";

                richTextBoxOutput.Text += m_sampleRun.Create(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选择另存的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSDBOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDig = new FolderBrowserDialog();

                if (folderBrowserDig.ShowDialog() == DialogResult.OK)
                {
                    textBoxSaveSDBFilePath.Text = folderBrowserDig.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 另存SDB工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSDBOK_Click(object sender, EventArgs e)
        {
            try
            {
                String extension = comboBoxSaveSDBType.SelectedItem as String;

                m_connectionInfo.Version = GetVersion(comboBoxSaveSDBVersion.SelectedIndex);
                m_connectionInfo.Type = this.GetType(extension);
                m_connectionInfo.Server = System.IO.Path.Combine(textBoxSaveSDBFilePath.Text, textBoxSaveSDBName.Text + "." + extension);
                m_connectionInfo.Name = textBoxSaveSDBName.Text;
                m_connectionInfo.Password = textBoxSaveSDBPassword.Text;

                richTextBoxOutput.Text += m_sampleRun.SaveAs(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 另存Oracle工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveOracleOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSaveOracleServer.Text;
                m_connectionInfo.Database = textBoxSaveOracleDatabase.Text;
                m_connectionInfo.User = textBoxSaveOracleUser.Text;
                m_connectionInfo.Password = textBoxSaveOraclePassword.Text;
                m_connectionInfo.Name = textBoxSaveOracleName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxSaveOracleVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.Oracle;

                richTextBoxOutput.Text += m_sampleRun.SaveAs(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 另存SQL工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSQLOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSaveSQLServer.Text;
                m_connectionInfo.Database = textBoxSaveSQLDatabase.Text;
                m_connectionInfo.User = textBoxSaveSQLUser.Text;
                m_connectionInfo.Password = textBoxSaveSQLPassword.Text;
                m_connectionInfo.Name = textBoxSaveSQLName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxSaveSQLVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.SQL;
                m_connectionInfo.Driver = "SQL Server";

                richTextBoxOutput.Text += m_sampleRun.SaveAs(m_connectionInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 取消删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteCancel_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Text += "删除取消" + System.Environment.NewLine;
        }

        /// <summary>
        /// 删除当前工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteOK_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Text += m_sampleRun.Delete();
        }


        /// <summary>
        /// 获取选择的工作空间类型
        /// </summary>
        /// <param name="index">选中的索引号</param>
        /// <returns>对应的类型</returns>
        private WorkspaceType GetType(String type)
        {
            WorkspaceType result = WorkspaceType.Default;

            switch (type.ToUpper())
            {
                case "SMWU":
                    {
                        result = WorkspaceType.SMWU;
                    }
                    break;
                case "SXWU":
                    {
                        result = WorkspaceType.SXWU;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取选择的版本号
        /// </summary>
        /// <param name="selectIndex">选中的索引号</param>
        /// <returns>对应的版本号</returns>
        private WorkspaceVersion GetVersion(Int32 selectIndex)
        {
            WorkspaceVersion version = WorkspaceVersion.SFC50;
            switch (selectIndex)
            {
                case 0:
                    {
                        version = WorkspaceVersion.UGC60;
                    }
                    break;
                case 1:
                    {
                        version = WorkspaceVersion.UGC20;
                    }
                    break;
                case 2:
                    {
                        version = WorkspaceVersion.SFC60;
                    }
                    break;
                default:
                    break;
            }

            return version;
        }

    }
}

