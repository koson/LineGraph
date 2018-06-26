///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、 范例简介：示范三维天际线分析功能
//2、示例数据：
//   安装目录\SampleData\Analysis3D
//3、关键类型/成员: 
//  Skyline类
//  Skyline.Color属性
//  Skyline.ViewerPosition
//  Skyline.Direction
//  Skyline.Pitch
//  Skyline.Quality
//  Skyline.AddLimitBody(GeoRegion3D^ pLimitBodyRegion3D)
//  Skyline.RemoveLimitBody(System::Int32 index)
//  Skyline.RemoveAllLimitBodies
//  Skyline.GetLimitBodyCount
//  Skyline.Build()
//  Skyline.Clear()

//4、使用步骤：
//   (1)运行程序后，默认打开SampleData中指定数据，或手动打开需要分析的模型数据
//   (2)点击菜单栏的“天际线分析”，弹出属性设置对话框，
//   (3)点击“开始分析”按钮，开始分析，默认以当前相机为视点进行天际线分析
//   (4)天际线分析后，可以绘制限高区域，点击“绘制限高”按钮后可以进行多次绘制，点击“结束绘制限高”，结束绘制
//   (5)点击“清除限高”，进行清除绘制的限高区域
//   (6)点击“清除分析”，清除分析结果

//5、使用说明
//   (1)分析后，可以通过调整对话框中的参数调整分析区域
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using SuperMap.Realspace.SpatialAnalyst;


namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgSkyline : Form
    {
        private Workspace m_workspace = null;
        private SceneControl m_sceneControl = null;
        private Skyline m_skyline = null;
        private Color m_skylineColor = Color.FromArgb(255, 192, 0, 0);
        private Color m_limitColor = Color.FromArgb(255, 0, 255, 255);
        private double m_observerX = 0.0;
        private double m_observerY = 0.0;
        private double m_observerHeight = 40.0;
        private double m_direction = 0.0;
        private double m_pitch = 0.0;
        private AnalysisQuality m_quality = AnalysisQuality.Medium;
        private GeoStyle3D m_style3D = null;
        private Boolean m_bShowObserverPoint = true;
        private Skyline.DisplayMode m_displayMode = Skyline.DisplayMode.LINE;


        public DlgSkyline()
        {
            InitializeComponent();
        }

        public void setWorkspace(Workspace workspace)
        {
            m_workspace = workspace;
        }

        public void SetSceneControl(SceneControl sceneControl)
        {
            m_sceneControl = sceneControl;
        }


        private void DlgSkyline_Load(object sender, EventArgs e)
        {
            this.cb_TextureQuality.SelectedIndex = 1;
            this.colorButton.Color = m_skylineColor;
            this.gb_HeightLimit.Enabled = false;
            this.btn_ClearResult.Enabled = false;
            this.cb_DisplayMode.SelectedIndex = 0;
            this.btn_FlyToViewer.Enabled = false;

            m_style3D = new GeoStyle3D();
            this.RegisterEventsForHeightLimit(false);
        }

        //设置天际线观察点的X坐标
        private void numericUpDown_X_ValueChanged(object sender, EventArgs e)
        {
            m_observerX = Convert.ToDouble(this.numericUpDown_X.Value);

            if (m_skyline != null)
            {
                Point3D viewerPosition = m_skyline.ViewerPosition;
                viewerPosition.X = m_observerX;
                m_skyline.ViewerPosition = viewerPosition;
            }
        }

        //设置天际线观察点的Y坐标
        private void numericUpDown_Y_ValueChanged(object sender, EventArgs e)
        {
            m_observerY = Convert.ToDouble(this.numericUpDown_Y.Value);

            if (m_skyline != null)
            {
                Point3D viewerPosition = m_skyline.ViewerPosition;
                viewerPosition.Y = m_observerY;
                m_skyline.ViewerPosition = viewerPosition;
            }
        }

        //设置天际线观察点的高度
        private void numericUpDown_Height_ValueChanged(object sender, EventArgs e)
        {
            m_observerHeight = Convert.ToDouble(this.numericUpDown_Height.Value);

            if (m_skyline != null)
            {
                Point3D viewerPosition = m_skyline.ViewerPosition;
                viewerPosition.Z = m_observerHeight;
                m_skyline.ViewerPosition = viewerPosition;
            }
        }

        //设置天际线的方向角
        private void numeric_Direction_ValueChanged(object sender, EventArgs e)
        {
            m_direction = Convert.ToDouble(this.numeric_Direction.Value);

            if (m_skyline != null)
            {
                m_skyline.Direction = m_direction;
            }
        }

        //设置天际线的倾斜角
        private void numeric_Pitch_ValueChanged(object sender, EventArgs e)
        {
            m_pitch = Convert.ToDouble(this.numeric_Pitch.Value);

            if (m_skyline != null)
            {
                m_skyline.Pitch = m_pitch;
            }
        }

        //设置天际线颜色
        private void colorButton_ColorChanged(object sender, EventArgs e)
        {
            m_skylineColor = colorButton.Color;

            if (m_skyline != null)
            {
                m_skyline.Color = m_skylineColor;
            }
        }

        //设置天际线分析质量
        private void cb_TextureQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_TextureQuality.SelectedIndex;
            switch (index)
            {
                case 0:
                    m_quality = AnalysisQuality.High;
                    break;
                case 1:
                    m_quality = AnalysisQuality.Medium;
                    break;
                case 2:
                    m_quality = AnalysisQuality.High;
                    break;
                default:
                    m_quality = AnalysisQuality.Medium;
                    break;
            }
            if (m_skyline != null)
            {
                m_skyline.Quality = m_quality;
            }
        }

        //是否显示观察点
        private void cb_IsShowObserverPoint_CheckedChanged(object sender, EventArgs e)
        {
            m_bShowObserverPoint = this.cb_IsShowObserverPoint.Checked;
            if (m_skyline != null)
            {
                m_skyline.SetViewerVisible(m_bShowObserverPoint);
            }
        }

        //设置显示模式，0：显示线；1：显示面
        private void cb_DisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_DisplayMode.SelectedIndex;
            if (index == 0)
            {
                m_displayMode = Skyline.DisplayMode.LINE;
            }
            else if (index == 1)
            {
                m_displayMode = Skyline.DisplayMode.FACE;
            }

            if (m_skyline != null)
            {
                m_skyline.DisplayStyle = m_displayMode;
            }
        }
        //开始分析
        private void btn_Analyst_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = SuperMap.UI.Action3D.CreatePoint;
            if (m_skyline == null)
            {
                m_skyline = this.CreateSkyline();
            }

            Camera camera = m_sceneControl.Scene.FirstPersonCamera;
            m_skyline.ViewerPosition = new Point3D(camera.Longitude, camera.Latitude, camera.Altitude);
            m_skyline.Direction = camera.Heading;
            m_skyline.Pitch = camera.Tilt - 90;
            m_skyline.Color = m_skylineColor;
            m_skyline.SetViewerVisible(m_bShowObserverPoint);
            updateObserverPosition(m_skyline);

            this.RegisterEventsForSkyline(false);
            this.RegisterEventsForSkyline(true);

            this.btn_Analyst.Enabled = false;
            this.btn_ClearResult.Enabled = true;
            this.gb_HeightLimit.Enabled = true;
            this.btn_HeightLimit.Enabled = true;
            this.btn_DeleteLimit.Enabled = false;
            this.btn_StopDrawLimit.Enabled = false;
            this.btn_FlyToViewer.Enabled = true;
        }

        private Skyline CreateSkyline()
        {
            Skyline skyline = new Skyline(m_sceneControl.Scene);
            skyline.Quality = m_quality;
            skyline.DisplayStyle = m_displayMode;
            skyline.SetViewerVisible(m_bShowObserverPoint);
            skyline.Build();

            return skyline;
        }

        private void RegisterEventsForSkyline(Boolean register)
        {
            if (register)
            {
                m_sceneControl.Tracking += new Tracking3DEventHandler(m_sceneControl_Tracking);

                m_sceneControl.Tracked += new Tracked3DEventHandler(m_sceneControl_Tracked);
            }
            else
            {
                m_sceneControl.Tracking -= new Tracking3DEventHandler(m_sceneControl_Tracking);

                m_sceneControl.Tracked -= new Tracked3DEventHandler(m_sceneControl_Tracked);
            }
        }
        /// <summary>
        /// 为设置限高注册或注销m_sceneControl的事件
        /// </summary>
        /// <param name="register"></param>
        private void RegisterEventsForHeightLimit(Boolean register)
        {
            if (register)
            {
                m_sceneControl.Tracking += new Tracking3DEventHandler(m_sceneControl_Tracking);

                m_sceneControl.Tracked += new Tracked3DEventHandler(m_sceneControl_Tracked);
            }
            else
            {
                m_sceneControl.Tracking -= new Tracking3DEventHandler(m_sceneControl_Tracking);

                m_sceneControl.Tracked -= new Tracked3DEventHandler(m_sceneControl_Tracked);
            }
        }


        //鼠标移动事件
        void m_sceneControl_Tracking(object sender, Tracking3DEventArgs e)
        {
            m_sceneControl.Scene.TrackingLayer.Clear();
           
            if (m_sceneControl.Action == Action3D.CreatePolygon)
            {
                Geometry3D geometry = e.Geometry as Geometry3D;

                if (geometry is GeoLine3D)
                {
                    m_style3D.LineColor = m_limitColor;
                    geometry.Style3D = m_style3D;
                    m_sceneControl.Scene.TrackingLayer.Add(geometry, "line");
                    return;
                }
                else if (geometry is GeoRegion3D)
                {
                    GeoRegion3D geoRegion3D = geometry as GeoRegion3D;
                    if (geoRegion3D[0].Count < 3)
                    {
                        return;
                    }
                    m_style3D.FillForeColor = m_limitColor;
                    geoRegion3D.Style3D = m_style3D;

                    m_sceneControl.Scene.TrackingLayer.Add(geoRegion3D, "region");

                }
            }
        }
        //鼠标右键事件，结束分析操作
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreatePolygon)
            {
                GeoRegion3D region3D = e.Geometry as GeoRegion3D;
                if (region3D != null)
                {
                    m_style3D.FillForeColor = m_limitColor;
                    region3D.Style3D = m_style3D;
                    int i = m_skyline.AddLimitBody(region3D);
                }
            }
        }

        //更新天际线分析观察点
        private void updateObserverPosition(Skyline skyline)
        {
            this.numericUpDown_X.Value = Convert.ToDecimal(skyline.ViewerPosition.X);
            this.numericUpDown_Y.Value = Convert.ToDecimal(skyline.ViewerPosition.Y);
            this.numericUpDown_Height.Value = Convert.ToDecimal(skyline.ViewerPosition.Z);
            this.numeric_Direction.Value = Convert.ToDecimal(skyline.Direction);
            this.numeric_Pitch.Value = Convert.ToDecimal(skyline.Pitch);
        }

        //定位到视点
        private void btn_FlyToViewer_Click(object sender, EventArgs e)
        {
            if (m_skyline != null)
            {
                m_skyline.LocateToViewerPosition();
            }
        }

        //删除限高
        private void btn_DeleteLimit_Click(object sender, EventArgs e)
        {
            if (m_skyline != null)
            {
                m_skyline.RemoveAllLimitBodies();
            }
            this.RegisterEventsForHeightLimit(false);
            this.m_sceneControl.Scene.TrackingLayer.Clear();

            this.btn_HeightLimit.Enabled = true;
            this.btn_StopDrawLimit.Enabled = false;
            this.btn_DeleteLimit.Enabled = false;
        }

        //绘制限高多边形
        private void btn_HeightLimit_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = SuperMap.UI.Action3D.CreatePolygon;

            this.RegisterEventsForHeightLimit(false);
            this.RegisterEventsForHeightLimit(true);

            this.btn_HeightLimit.Enabled = false;
            this.btn_StopDrawLimit.Enabled = true;
            this.btn_DeleteLimit.Enabled = true;
        }


        //检查场景中是否存在天际线分析，如果有，移除
        private void clearSkylineAnalysis()
        {
            this.numeric_Direction.Value = 0; ;
            this.numeric_Pitch.Value = 0;
            this.numericUpDown_X.Value = 0;
            this.numericUpDown_Y.Value = 0;
            this.numericUpDown_Height.Value = 0;
            m_sceneControl.Scene.TrackingLayer.Clear();

            if (m_skyline != null)
            {
                m_skyline.Clear();
                m_skyline = null;
            }
        }

        //清除所有天际线分析
        private void btn_ClearResult_Click(object sender, EventArgs e)
        {
            //将已有天际线分析删除
            this.clearSkylineAnalysis();

            this.RegisterEventsForHeightLimit(false);

            this.gb_HeightLimit.Enabled = false;
            this.m_sceneControl.Scene.TrackingLayer.Clear();

            m_sceneControl.Action = Action3D.Pan;

            this.btn_Analyst.Enabled = true;
            this.btn_ClearResult.Enabled = false;
          
        }

        //窗体关闭事件
        private void DlgSkyline_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan;

            this.clearSkylineAnalysis();

            this.RegisterEventsForHeightLimit(false);
            this.m_sceneControl.Scene.TrackingLayer.Clear();
            m_style3D = null;
        }

        //停止绘制限高，修改Action
        private void btn_StopDrawLimit_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan;

            this.btn_HeightLimit.Enabled = true;
            this.btn_StopDrawLimit.Enabled = false;
            this.btn_DeleteLimit.Enabled = true;
        }

        //获取天际线
        private void btn_GetSkyline_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_skyline != null)
                {
                    GeoLine3D line3D = m_skyline.GetSkyline();

                    if (m_workspace.Datasources.Count == 0)
                    {
                        MessageBox.Show("请先打开一个数据源");
                        return;
                    }
                    Datasource datasource = m_workspace.Datasources[0];
                    Datasets datasets = datasource.Datasets;

                    String datasetName = "NewLine3D";
                    if (datasource.Datasets.Contains(datasetName))
                    {
                        datasource.Datasets.Delete(datasetName);
                    }
                    DatasetVectorInfo datasetInfo = new DatasetVectorInfo();
                    datasetInfo.Type = DatasetType.Line3D;
                    datasetInfo.Name = datasetName;
                    datasetInfo.EncodeType = EncodeType.None;

                    DatasetVector newDataset = datasource.Datasets.Create(datasetInfo);
                    if (newDataset == null)
                    {
                        MessageBox.Show("创建三维面数据集失败！");
                    }
                    if (m_sceneControl.Scene.Type == SceneType.Globe)
                    {
                        newDataset.PrjCoordSys = new PrjCoordSys(PrjCoordSysType.EarthLongitudeLatitude);

                    }
                    Recordset recordset = newDataset.GetRecordset(false, CursorType.Dynamic);
                    recordset.AddNew(line3D);
                    recordset.Update();
                    recordset.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }
           
        }

    }
}
