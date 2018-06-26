using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using SuperMap.Realspace.SpatialAnalyst;
using System.Diagnostics;

namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgSlopeMap : Form
    {
        private Workspace m_workspace = null;
        private SceneControl m_sceneControl = null;
        private SlopeMap.DisplayMode m_fillMode = SlopeMap.DisplayMode.Face_And_Arrow;
        private double m_opacity = 60.0;
        private double m_minVisibleSlope = 0;
        private double m_maxVisibleSlope = 90;
        private Boolean m_bShowBorer = true;
        private Color m_BorderColor = Color.Yellow;
        private SlopeMap m_slope = null;
        private bool m_bIsShowSlopInfo = false;
        private Point3D m_point3D = Point3D.Empty;
        private Point3D m_lastPoint3D = Point3D.Empty;
        private Timer m_timer = null;
        private GeoStyle3D m_style3D = null;

        public DlgSlopeMap()
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

        private void DlgSlopeMap_Load(object sender, EventArgs e)
        {
            this.cb_DisplayStyle.SelectedIndex = 2;
            this.tb_Opacity.Text = Convert.ToString(this.m_opacity);
            this.tb_minVisibleSlope.Text = Convert.ToString(m_minVisibleSlope);
            this.tb_maxVisibleSlope.Text = Convert.ToString(m_maxVisibleSlope);
            this.cb_IsShowSlopInfo.Checked = false;
            this.cb_IsShowBorder.Checked = m_bShowBorer;
            this.colorButton_Border.Color = m_BorderColor;
            this.btn_Clear.Enabled = false;
            this.btn_StopAnalysis.Enabled = false;
            m_style3D = new GeoStyle3D();
            m_style3D.FillForeColor = Color.Red;

            m_timer = new Timer();
            m_timer.Enabled = false;

            this.RegisterEvents(false);
        }

        //设置显示风格
        private void cb_DisplayStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_DisplayStyle.SelectedIndex;

            switch (index)
            {
                case 0:
                    m_fillMode = SlopeMap.DisplayMode.Face;
                    break;
                case 1:
                    m_fillMode = SlopeMap.DisplayMode.Arrow;
                    break;
                case 2:
                    m_fillMode = SlopeMap.DisplayMode.Face_And_Arrow;
                    break;
                default:
                    m_fillMode = SlopeMap.DisplayMode.Face_And_Arrow;
                    break;
            }

            if (m_slope != null)
            {
                m_slope.DisplayStyle = m_fillMode;
            }
        }

        //设置透明度
        private void tb_Opacity_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_Opacity.Text != "")
            {
                this.m_opacity = Convert.ToDouble(this.tb_Opacity.Text);

                if (m_slope != null)
                {
                    m_slope.Opacity = m_opacity;
                }
            }

        }

        //是否显示坡度信息
        private void cb_IsShowSlopInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (m_slope != null)
            {
                m_bIsShowSlopInfo = cb_IsShowSlopInfo.Checked;
                if (m_bIsShowSlopInfo)
                {

                    m_sceneControl.Action = Action3D.CreateRectangle;
                    m_sceneControl.Tracking -= new Tracking3DEventHandler(m_sceneControl_Tracking);
                    m_sceneControl.Tracking += new Tracking3DEventHandler(m_sceneControl_Tracking);
                    m_timer.Enabled = true;
                }
                else
                {
                    m_sceneControl.Tracking -= new Tracking3DEventHandler(m_sceneControl_Tracking);
                    m_timer.Enabled = false;
                    this.m_sceneControl.Scene.TrackingLayer.Clear();
                }
            }
        }

        //设置坡度坡向分析的最大坡度值
        private void tb_maxVisibleSlope_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_maxVisibleSlope.Text != "")
            {
                m_maxVisibleSlope = Convert.ToDouble(this.tb_maxVisibleSlope.Text);

                if (m_slope != null)
                {
                    m_slope.MaxVisibleSlope = m_maxVisibleSlope;
                }
            }
        }

        //设置坡度坡向分析的最小坡度值
        private void tb_minVisibleSlope_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_minVisibleSlope.Text != "")
            {
                m_minVisibleSlope = Convert.ToDouble(this.tb_minVisibleSlope.Text);

                if (m_slope != null)
                {
                    m_slope.MinVisibleSlope = m_minVisibleSlope;
                }
            }
        }


        //是否显示边框
        private void cb_IsShowBorder_CheckedChanged(object sender, EventArgs e)
        {
            m_bShowBorer = this.cb_IsShowBorder.Checked;
            this.colorButton_Border.Enabled = m_bShowBorer;

            if (m_slope != null)
            {
                m_slope.BorderVisible = m_bShowBorer;
            }
        }

        //设置边框颜色
        private void colorButton_Border_ColorChanged(object sender, EventArgs e)
        {
            m_BorderColor = this.colorButton_Border.Color;

            if (m_slope != null)
            {
                m_slope.BorderColor = m_BorderColor;
            }
        }

        //开始分析
        private void btn_StartAnalyst_Click(object sender, EventArgs e)
        {
            if (m_slope == null)
            {
                m_slope = CreateSlope();
            }
            this.btn_StartAnalyst.Enabled = false;
            this.btn_StopAnalysis.Enabled = true;
            this.btn_Clear.Enabled = true;
            this.cb_IsShowSlopInfo.Checked = false;

            this.RegisterEvents(false);
            this.RegisterEvents(true);
            m_sceneControl.Action = SuperMap.UI.Action3D.CreateRectangle;

        }

        private SlopeMap CreateSlope()
        {
            Rectangle2D rect = Rectangle2D.Empty;
            SlopeMap slope = new SlopeMap(m_sceneControl.Scene);
            slope.Opacity = m_opacity;
            slope.BorderVisible = m_bShowBorer;

            slope.DisplayStyle = m_fillMode;

            //设置坡度坡向调色板
            ColorDictionary colorDict = new ColorDictionary();
            colorDict[0] = Color.Blue;
            colorDict[10] = Color.Green;
            colorDict[30] = Color.Red;
            slope.ColorDictTable = colorDict;
            slope.MaxVisibleSlope = m_maxVisibleSlope;
            slope.MinVisibleSlope = m_minVisibleSlope;

            slope.Build();

            return slope;
        }
        /// <summary>
        /// 注册或注销m_sceneControl的事件
        /// </summary>
        /// <param name="register"></param>
        private void RegisterEvents(Boolean register)
        {
            if (register)
            {
                m_sceneControl.Tracking += new Tracking3DEventHandler(m_sceneControl_Tracking);
            }
            else
            {
                m_sceneControl.Tracking -= new Tracking3DEventHandler(m_sceneControl_Tracking);

            }
        }

        //鼠标移动事件
        void m_sceneControl_Tracking(object sender, Tracking3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreateRectangle)
            {
                if (!m_bIsShowSlopInfo)
                {
                    if (m_slope != null)
                    {
                        GeoRegion3D geoRegion3D = e.Geometry as GeoRegion3D;

                        if (geoRegion3D.PartCount > 0)
                        {
                            Rectangle2D rect = m_slope.CoverageArea;
                            rect = geoRegion3D.Bounds;
                            m_slope.CoverageArea = rect;
                        }
                    }
                }
                //显示坡度坡向信息
                else
                {
                    m_timer.Enabled = true;
                    m_timer.Interval = 2000;
                    m_timer.Tick -= new EventHandler(timer_tick);
                    m_timer.Tick += new EventHandler(timer_tick);
                    m_point3D = new Point3D(e.X, e.Y, e.Z);
                    m_timer.Start();
                }
            }
        }

        //鼠标在场景中停留两秒中显示坡度坡向信息
        private void timer_tick(Object sender, EventArgs e)
        {
            if (m_slope != null)
            {
                if (m_lastPoint3D != m_point3D)
                {
                    this.m_sceneControl.Scene.TrackingLayer.Clear();
                    double slopeValue = m_slope.GetSlopeValue(m_point3D);
                    double slopeDirection = m_slope.GetSlopeDirectionValue(m_point3D);

                    TextStyle textstyle = new TextStyle();
                    textstyle.IsSizeFixed = true;
                    textstyle.FontName = "微软雅黑";
                    textstyle.ForeColor = Color.Black;
                    textstyle.FontScale = 2;
                    textstyle.FontHeight = 3;

                    TextPart3D textPart3D = new TextPart3D();
                    textPart3D.Text = String.Format("Longitude: {0}\nLatitude:{1}\nAltitude: {2}\nSlopeValue: {3}\nSlopeDirection: {4}", m_point3D.X,m_point3D.Y,m_point3D.Z,slopeValue,slopeDirection);
                    textPart3D.AnchorPoint = m_point3D;
                    GeoText3D geoText3D = new GeoText3D(textPart3D);
                    geoText3D.TextStyle = textstyle;
                    GeoStyle3D style3D = new GeoStyle3D();
                    style3D.AltitudeMode = AltitudeMode.Absolute;
                    style3D.BottomAltitude = 10;
                    geoText3D.Style3D = style3D;
                    this.m_sceneControl.Scene.TrackingLayer.Add(geoText3D, "Text");


                    m_lastPoint3D = m_point3D;
                }
            }
        }

        //清除所有分析结果
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            if (m_slope != null)
            {
                m_slope.Clear();
                m_slope = null;
            }
            m_sceneControl.Action = Action3D.Pan;
            m_timer.Enabled = false;

            this.m_sceneControl.Scene.TrackingLayer.Clear();
            this.btn_StopAnalysis.Enabled = false;
            this.btn_StartAnalyst.Enabled = true;
            this.btn_Clear.Enabled = false;
        }

        //关闭窗口事件
        private void DlgSlopeMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RegisterEvents(false);
            if (m_slope != null)
            {
                m_slope.Clear();
                m_slope = null;
            }
            if (m_timer != null)
            {
                m_timer.Tick -= new EventHandler(timer_tick);
                m_timer.Stop();
                m_timer = null;
            }
            this.m_sceneControl.Scene.TrackingLayer.Clear();
            m_sceneControl.Action = Action3D.Pan;

        }

        //结束分析，修改Action
        private void btn_StopAnalysis_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan;

            this.btn_StartAnalyst.Enabled = true;
            this.btn_StopAnalysis.Enabled = false;
        }

    }
}
