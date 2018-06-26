using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using SuperMap.Realspace;
using SuperMap.Data;
using SuperMap.Realspace.SpatialAnalyst;
using SuperMap.UI;

namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgShadowAnalysis : Form
    {
        private ShadowType m_shadowType = ShadowType.ALL;
        private double m_minAltitude = 1;
        private double m_maxAltitude = 10;
        private double m_spacing = 5;
        private TimeSpan m_baseUtcOffset;
        private DateTime m_startTime = Convert.ToDateTime("9 AM");
        private DateTime m_endTime = Convert.ToDateTime("4 PM");
        private TimeSpan m_timeInterval = TimeSpan.FromMinutes(10);
        private ReadOnlyCollection<TimeZoneInfo> m_TimeZones;
        private ShadowVisibilityQuery m_shadowQuery = null;
        private SceneControl m_sceneControl = null;
        private Boolean m_bAnalyisSucess = false;
        private Selection3D m_selection = null;
        private GeoStyle3D m_style3D = null;
        private Action3D m_oldAction;

        public DlgShadowAnalysis()
        {
            InitializeComponent();
        }

        private void DlgShadowAnalysis_Load(object sender, EventArgs e)
        {
            this.cb_ShadowType.SelectedIndex = 0;
            this.cb_StartTime.SelectedIndex = 3;
            this.cb_EndTime.SelectedIndex = 10;
            this.cb_TimeInterval.SelectedIndex = 2;
            this.tb_MaxAltitude.Text = m_maxAltitude.ToString();
            this.tb_MinAltitude.Text = m_minAltitude.ToString();
            this.tb_spacing.Text = m_spacing.ToString();
            this.cb_GetShadowRatio.Enabled = false;
            this.label_shadowRatio.Enabled = false;
            this.btn_StartAnalysis.Enabled = true;
            this.btn_Apply.Enabled = false;
            this.btn_ClearResult.Enabled = false;

            InitializeTimeZoneComboBox();
        }

        //初始化
        public void Initalize(SceneControl sceneControl)
        {
            m_sceneControl = sceneControl;

            m_style3D = new GeoStyle3D();
        }

        //初始化时区下拉框
        void InitializeTimeZoneComboBox()
        {
            if (cb_TimeZone.Items.Count > 0)
                cb_TimeZone.Items.Clear();

            m_TimeZones = TimeZoneInfo.GetSystemTimeZones();
            for (int i = 0; i < m_TimeZones.Count; i++)
            {
                TimeZoneInfo zone = m_TimeZones[i];
                cb_TimeZone.Items.Add(zone.DisplayName);
            }
            int index = m_TimeZones.IndexOf(TimeZoneInfo.Local);
            cb_TimeZone.SelectedIndex = index;
        }

        //设置阴影分析范围
        private void cb_ShadowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_ShadowType.SelectedIndex;

            if (index == 0)
            {
                m_shadowType = ShadowType.ALL;
                m_selection = null;
            }
            else if (index == 1)
            {
                m_shadowType = ShadowType.SELECTION;
            }
            else if (index == 2)
            {
                m_shadowType = ShadowType.NONE;
                m_selection = null;
            }

            Layer3Ds layers = m_sceneControl.Scene.Layers;

            //设置阴影类型
            for (int i = 0; i < layers.Count; i++)
            {
                Layer3D layer = layers[i];
                layer.ShadowType = m_shadowType;
            }

        }

        //设置最大高度
        private void tb_MaxAltitude_TextChanged(object sender, EventArgs e)
        {
            if (tb_MaxAltitude.Text != "")
            {
                m_maxAltitude = Convert.ToDouble(tb_MaxAltitude.Text);

                if (m_shadowQuery != null && m_shadowQuery.QueryRegion != null)
                {
                    Geometry3D geometry3D = m_shadowQuery.QueryRegion;
                    m_style3D.BottomAltitude = m_minAltitude;
                    m_style3D.ExtendedHeight = m_maxAltitude - m_minAltitude;
                    geometry3D.Style3D = m_style3D;
                    m_shadowQuery.QueryRegion = geometry3D;
                }
                this.btn_Apply.Enabled = true;
            }
        }

        //设置最小高度
        private void tb_MinAltitude_TextChanged(object sender, EventArgs e)
        {
            if (tb_MinAltitude.Text != "")
            {
                m_minAltitude = Convert.ToDouble(tb_MinAltitude.Text);

                if (m_shadowQuery != null && m_shadowQuery.QueryRegion != null)
                {
                    Geometry3D geometry3D = m_shadowQuery.QueryRegion;
                    m_style3D.BottomAltitude = m_minAltitude;
                    m_style3D.ExtendedHeight = m_maxAltitude - m_minAltitude;
                    geometry3D.Style3D = m_style3D;
                    m_shadowQuery.QueryRegion = geometry3D;
                }
                this.btn_Apply.Enabled = true;
            }
        }

        //设置间距
        private void tb_spacing_TextChanged(object sender, EventArgs e)
        {
            if (tb_spacing.Text != "")
            {
                m_spacing = Convert.ToDouble(tb_spacing.Text);

                if (m_shadowQuery != null)
                {
                    m_shadowQuery.Spacing = m_spacing;
                }
                this.btn_Apply.Enabled = true;
            }
        }

        //设置时区偏移
        private void cb_TimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_TimeZone.SelectedIndex;

            TimeZoneInfo selectedTimeZoneInfo = m_TimeZones[index];

            m_baseUtcOffset = selectedTimeZoneInfo.BaseUtcOffset;

            if (m_shadowQuery != null)
            {
                m_shadowQuery.BaseUtcOffset = m_baseUtcOffset;
                this.btn_Apply.Enabled = true;
            }
        }

        //设置开始时间
        private void cb_StartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            String startTime = this.cb_StartTime.SelectedItem.ToString();

            m_startTime = Convert.ToDateTime(startTime);

            if (m_shadowQuery != null)
            {
                m_shadowQuery.StartTime = m_startTime;
                this.btn_Apply.Enabled = true;
            }
        }

        //设置结束时间
        private void cb_EndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            String endTime = this.cb_EndTime.SelectedItem.ToString();

            m_endTime = Convert.ToDateTime(endTime);

            if (m_shadowQuery != null)
            {
                m_shadowQuery.EndTime = m_endTime;
                this.btn_Apply.Enabled = true;
            }
        }

        //设置时间间隔
        private void cb_TimeInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            int minutes = Convert.ToInt16(this.cb_TimeInterval.SelectedItem.ToString());
            m_timeInterval = TimeSpan.FromMinutes(minutes);

            if (m_shadowQuery != null)
            {
                m_shadowQuery.TimeInterval = m_timeInterval;
                this.btn_Apply.Enabled = true;
            }
        }

        //绘制区域并开始分析
        private void btn_StartAnalysis_Click(object sender, EventArgs e)
        {
            if (m_shadowType == ShadowType.SELECTION)
            {
                //目前只允许一次选择一个图层中的对象
                Layer3Ds layers = m_sceneControl.Scene.Layers;
                for (int i = 0; i < layers.Count; i++)
                {
                    Layer3D layer = layers[i];
                    Selection3D seletion3D = layer.Selection;
                    if (seletion3D != null)
                    {
                        m_selection = seletion3D;
                        break;
                    }
                }
                if (m_selection == null)
                {
                    MessageBox.Show("请先选择要产生阴影的对象！");
                    return;
                }
            }
           
            this.RegisterEvents(false);
            this.RegisterEvents(true);

            m_oldAction = m_sceneControl.Action;
            m_sceneControl.Action = Action3D.CreatePolygon;

            if (m_shadowQuery == null)
            {
                m_shadowQuery = this.CreateShadowVisibilityQuery();
            }

            this.btn_StartAnalysis.Enabled = false;
            this.btn_ClearResult.Enabled = true;
        }

        private ShadowVisibilityQuery CreateShadowVisibilityQuery()
        {
            ShadowVisibilityQuery shadowQuery = new ShadowVisibilityQuery(m_sceneControl.Scene);
            shadowQuery.BaseUtcOffset = m_baseUtcOffset;
            shadowQuery.Spacing = m_spacing;
            shadowQuery.StartTime = m_startTime;
            shadowQuery.EndTime = m_endTime;
            shadowQuery.TimeInterval = m_timeInterval;

            //设置颜色表
            ColorDictionary colorDict = new ColorDictionary();
            colorDict[0] = Color.Blue;
            colorDict[30] = Color.Green;
            colorDict[60] = Color.Orange;
            colorDict[100] = Color.Red;
            shadowQuery.ColorDictTable = colorDict;

            return shadowQuery;

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
            if (m_sceneControl.Action == Action3D.CreatePolygon)
            {
                //m_sceneControl.Scene.TrackingLayer.Clear();

                //Geometry3D geometry = e.Geometry as Geometry3D;

                //if (geometry is GeoLine3D)
                //{
                //    m_sceneControl.Scene.TrackingLayer.Add(geometry, "line");
                //    return;
                //}
                //else if (geometry is GeoRegion3D)
                //{
                //    GeoRegion3D geoRegion3D = geometry as GeoRegion3D;

                //    if (geoRegion3D[0].Count < 3)
                //    {
                //        return;
                //    }
                //    GeoStyle3D style3D = new GeoStyle3D();
                //    style3D.FillMode = FillMode3D.Line;
                //    style3D.LineColor = Color.Yellow;
                //    style3D.AltitudeMode = AltitudeMode.Absolute;
                //    geoRegion3D.Style3D = style3D;
                //    m_sceneControl.Scene.TrackingLayer.Add(geoRegion3D, "region");
                //}
            }
        }

        //鼠标右键事件
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreatePolygon)
            {
                Geometry3D geometry3D = e.Geometry;
                if (geometry3D != null)
                {
                    m_style3D.BottomAltitude = m_minAltitude;
                    m_style3D.ExtendedHeight = m_maxAltitude - m_minAltitude;
                    geometry3D.Style3D = m_style3D;

                    m_shadowQuery.QueryRegion = geometry3D;

                    m_bAnalyisSucess = m_shadowQuery.Build();
                    if (m_bAnalyisSucess)
                    {
                        this.cb_GetShadowRatio.Enabled = true;
                        this.label_shadowRatio.Enabled = true;
                    }
                }
                m_sceneControl.Action = m_oldAction;
            }
        }

        //清除所有分析结果
        private void btn_ClearResult_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            if (m_shadowQuery != null)
            {
                m_shadowQuery.Clear();
                m_shadowQuery = null;
            }
            m_bAnalyisSucess = false;

            this.cb_GetShadowRatio.Enabled = false;
            this.label_shadowRatio.Text = "当前点的阴影率为：***";
            this.label_shadowRatio.Enabled = false;
            m_sceneControl.Scene.TrackingLayer.Clear();

            this.btn_StartAnalysis.Enabled = true;
            this.btn_ClearResult.Enabled = false;

        }

        //获取所选择点的阴影率
        private void cb_GetShadowRatio_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = this.cb_GetShadowRatio.Checked;
            if (bChecked)
            {
                this.label_shadowRatio.Enabled = true;
                m_sceneControl.MouseUp -= new MouseEventHandler(m_sceneControl_MouseUp);
                m_sceneControl.MouseUp += new MouseEventHandler(m_sceneControl_MouseUp);
            }
            else
            {
                this.label_shadowRatio.Text = "当前点的阴影率为：***";
                this.label_shadowRatio.Enabled = false;
                m_sceneControl.MouseUp -= new MouseEventHandler(m_sceneControl_MouseUp);
                this.m_sceneControl.Scene.TrackingLayer.Clear();

            }
        }

        //鼠标选择对象事件
        void m_sceneControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bAnalyisSucess == true)
            {
                this.m_sceneControl.Scene.TrackingLayer.Clear();

                if (m_shadowQuery != null && e.Button == MouseButtons.Left)
                {
                    Point point = new Point(e.X, e.Y);

                    double shadowRatio = m_shadowQuery.GetShadowRatio(point);

                    if (shadowRatio != -1)
                    {
                        this.label_shadowRatio.Text = String.Format("当前点的阴影率为：{0}%", shadowRatio * 100);


                        TextStyle textstyle = new TextStyle();
                        textstyle.IsSizeFixed = true;
                        textstyle.FontName = "微软雅黑";
                        textstyle.ForeColor = Color.Red;
                        textstyle.FontScale = 2;
                        textstyle.FontHeight = 2;

                        Point3D point3D = m_sceneControl.Scene.PixelToGlobe(e.Location);
                        TextPart3D textPart3D = new TextPart3D();
                        textPart3D.Text = String.Format("阴影率：{0}%", shadowRatio * 100);
                        textPart3D.AnchorPoint = point3D;
                        GeoText3D geoText3D = new GeoText3D(textPart3D);
                        geoText3D.TextStyle = textstyle;
                        this.m_sceneControl.Scene.TrackingLayer.Add(geoText3D, "Text");
                    }
                    else
                    {
                        this.label_shadowRatio.Text = "当前点的阴影率为：***";
                    }

                }
            }

        }

        private void DlgShadowAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RegisterEvents(false);
            if (m_shadowQuery != null)
            {
                m_shadowQuery.Clear();
                m_shadowQuery = null;
            }
            m_bAnalyisSucess = false;
            this.cb_GetShadowRatio.Enabled = false;
            this.label_shadowRatio.Text = "当前点的阴影率为：***";
            this.label_shadowRatio.Enabled = false;
            m_sceneControl.Scene.TrackingLayer.Clear();
        }

        //修改参数后，更新当前分析结果
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (m_shadowQuery != null)
            {
                m_shadowQuery.Build();
            }
            this.btn_Apply.Enabled = false;
        }
    }
}
