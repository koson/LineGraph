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
    enum CoverageArea
    {
        Rectangle,
        EntireTerrain
    }

    public partial class DlgContourMap : Form
    {
        private Workspace m_workspace = null;
        private SceneControl m_sceneControl = null;
        private ContourMap.DisplayMode m_fillMode = ContourMap.DisplayMode.Face_And_Line;
        private Color m_contourLineColor = Color.Black;
        private double m_countourLineInterval = 100.0;
        private double m_opacity = 60.0;
        private double m_minVisibleAlt = 0;
        private double m_maxVisibleAlt = 9000;
        private Boolean m_bShowBorer = true;
        private Color m_BorderColor = Color.Yellow;
        private ContourMap m_contour = null;
        

        public DlgContourMap()
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

        //设置初始值
        private void DlgContourMap_Load(object sender, EventArgs e)
        {
            this.cb_DisplayStyle.SelectedIndex = 2;
            this.colorButton.Color = m_contourLineColor;
            this.tb_LineInterval.Text = Convert.ToString(m_countourLineInterval);
            this.tb_Opacity.Text = Convert.ToString(m_opacity);
            this.cb_IsShowBorder.Checked = m_bShowBorer;
            this.colorButton_Border.Color = m_BorderColor;
            this.tb_minVisibleAltitude.Text = Convert.ToString(m_minVisibleAlt);
            this.tb_maxVisibleAltitude.Text = Convert.ToString(m_maxVisibleAlt);
            this.btn_StartAnalyst.Enabled = true;
            this.btn_StopAnalysis.Enabled = false;
            this.btn_Clear.Enabled = false;
            this.RegisterEvents(false);
        }
        /// <summary>
        /// 设置等高线的显示模式 0:纹理填充 1:等高线 2:纹理填充和等高线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_DisplayStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_DisplayStyle.SelectedIndex;

            switch (index)
            {
                case 0:
                    m_fillMode = ContourMap.DisplayMode.Face;
                    break;
                case 1:
                    m_fillMode = ContourMap.DisplayMode.Line;
                    break;
                case 2:
                    m_fillMode = ContourMap.DisplayMode.Face_And_Line;
                    break;
            }

            if (m_contour != null)
            {
                m_contour.DisplayStyle = m_fillMode;
            }
        }

        //设置等高线间隔
        private void tb_LineInterval_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_LineInterval.Text != null)
            {
                m_countourLineInterval = Convert.ToDouble(this.tb_LineInterval.Text);
                if (m_contour != null)
                {
                    m_contour.Interval = m_countourLineInterval;
                }
            }
        }

        //设置填充调色板
        private void tb_Opacity_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_Opacity.Text != "")
            {
                this.m_opacity = (Convert.ToDouble(this.tb_Opacity.Text));
                if (m_contour != null)
                {
                    m_contour.Opacity = m_opacity;
                }
            }
        }

        private void colorButton_ColorChanged(object sender, EventArgs e)
        {
            m_contourLineColor = colorButton.Color;

            if (m_contour != null)
            {
                m_contour.LineColor = m_contourLineColor;
            }
        }

        //设置等高线分析的最小高度值
        private void tb_minVisibleAltitude_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_minVisibleAltitude.Text != "")
            {
                m_minVisibleAlt = Convert.ToDouble(this.tb_minVisibleAltitude.Text);

                if (m_contour != null)
                {
                    m_contour.MinVisibleAltitude = m_minVisibleAlt;
                }
            }
        }

        //设置等高线分析的最大高度值
        private void tb_maxVisibleAltitude_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_maxVisibleAltitude.Text != "")
            {
                m_maxVisibleAlt = Convert.ToDouble(this.tb_maxVisibleAltitude.Text);

                if (m_contour != null)
                {
                    m_contour.MaxVisibleAltitude = m_maxVisibleAlt;
                }
            }
        }


        //是否显示边框
        private void cb_IsShowBorder_CheckedChanged(object sender, EventArgs e)
        {
            m_bShowBorer = this.cb_IsShowBorder.Checked;
            this.colorButton_Border.Enabled = m_bShowBorer;

            if (m_contour != null)
            {
                m_contour.BorderVisible = m_bShowBorer;
            }
        }

        //设置边框颜色
        private void colorButton_Border_ColorChanged(object sender, EventArgs e)
        {
            m_BorderColor = this.colorButton_Border.Color;

            if (m_contour != null)
            {
                m_contour.BorderColor = m_BorderColor;
            }
        }
          /// <summary>
        /// 获取绘制到场景跟踪图层上的站点的样式
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        private GeoStyle3D GetPointGeoStyle3D(Double z)
        {
            GeoStyle3D geoStyle3D = new GeoStyle3D();

            geoStyle3D.AltitudeMode = AltitudeMode.Absolute;
            geoStyle3D.BottomAltitude = 5;
            geoStyle3D.MarkerColor = System.Drawing.Color.FromArgb(255, 255, 255, 0);
            geoStyle3D.MarkerSize = 1;
            geoStyle3D.ExtendedHeight = z;

            return geoStyle3D;
        }

        //开始分析
        private void btn_StartAnalyst_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            this.RegisterEvents(true);

            m_sceneControl.Action = SuperMap.UI.Action3D.CreateRectangle;

            if (m_contour == null)
            {
                m_contour = CreateContourMap();
            }

            this.btn_StartAnalyst.Enabled = false;
            this.btn_StopAnalysis.Enabled = true;
            this.btn_Clear.Enabled = true;
        }

        //清除所有分析结果
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            if (m_contour != null)
            {
                m_contour.Clear();
                m_contour = null;
            }
            m_sceneControl.Action = Action3D.Pan;

            this.btn_StartAnalyst.Enabled = true;
            this.btn_Clear.Enabled = false;
            this.btn_StopAnalysis.Enabled = false;

        }

        private ContourMap CreateContourMap()
        {
            ContourMap contour = new ContourMap(m_sceneControl.Scene);
            contour.Interval = m_countourLineInterval;
            contour.Opacity = m_opacity;
            contour.LineColor = m_contourLineColor;
            contour.BorderVisible = m_bShowBorer;
            contour.BorderColor = m_BorderColor;

            //设置等高线颜色表
            ColorDictionary colorDict = new ColorDictionary();
            ///////////////////////////////////////////////////////////////
            ///////北京地形////////////////////////
            colorDict[0] = Color.Blue;
            colorDict[800] = Color.Green;
            colorDict[1500] = Color.Red;

            contour.ColorDictTable = colorDict;

            contour.MaxVisibleAltitude = m_maxVisibleAlt;
            contour.MinVisibleAltitude = m_minVisibleAlt;

            contour.DisplayStyle = m_fillMode;
            contour.Build();
            return contour;

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
            if (m_sceneControl.Action == Action3D.CreateRectangle)
            {
                if (m_contour != null)
                {
                    GeoRegion3D geoRegion3D = e.Geometry as GeoRegion3D;

                    if (geoRegion3D.PartCount > 0)
                    {
                        Rectangle2D rect = m_contour.CoverageArea;
                        rect = geoRegion3D.Bounds;
                        m_contour.CoverageArea = rect;
                    }
                }
            }
        }

        //鼠标右键事件，结束分析操作
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            //Rectangle2D rect = m_contour.CoverageArea;
            //Console.WriteLine(rect.ToString());
        }

        //窗口关闭事件
        private void DlgContourMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RegisterEvents(false);
            if (m_contour != null)
            {
                m_contour.Clear();
                m_contour = null;
            }
            m_sceneControl.Action = Action3D.Pan;
        }

        //停止分析，修改Action
        private void btn_StopAnalysis_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan;

            this.btn_StartAnalyst.Enabled = true;
            this.btn_StopAnalysis.Enabled = false;
        }

    }
}
