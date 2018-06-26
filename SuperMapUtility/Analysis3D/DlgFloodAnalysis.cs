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
       public partial class DlgFloodAnalysis : Form
    {
        private SceneControl m_sceneControl = null;     
        private ContourMap m_contour = null;
        private Double m_minVisibleAltidute = 100;//水淹基础高度
        private Double m_maxVisibleAltidute = 2000;//水淹最高高度
        private Double m_waterInterval = 10;//水涨幅度
        private SuperMap.UI.Action3D m_oldAction;
        private Timer m_timer;
        private Panel m_panelDiagram;

        public DlgFloodAnalysis()
        {
            InitializeComponent();
        }

        public void Initialize(SceneControl sceneControl,Panel panel)
        {
            m_sceneControl = sceneControl;
            m_panelDiagram = panel;
            m_timer = new Timer();
            m_timer.Enabled = false;
        }

        //设置初始值
        private void DlgFloodAnalysis_Load(object sender, EventArgs e)
        {
            this.btn_Clear.Enabled = false;
            this.btn_StartAnalysis.Enabled = false;
            this.tb_minAltitude.Text = this.m_minVisibleAltidute.ToString();
            this.tb_maxAltitude.Text = this.m_maxVisibleAltidute.ToString();
        }
      
        //清除所有分析结果
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);

            if (m_timer != null)
            {
                m_timer.Enabled = false;
                m_timer.Stop();
            }
            if (m_contour != null)
            {
                m_contour.Clear();
                m_contour = null;
            }
            m_sceneControl.Scene.TrackingLayer.Clear();
            this.m_panelDiagram.Visible = false;
            this.btn_Clear.Enabled = false;
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
            m_sceneControl.Scene.TrackingLayer.Clear();
            if (m_sceneControl.Action == Action3D.CreateLine)
            {
                GeoLine3D geoline3d = e.Geometry as GeoLine3D;
                if (geoline3d.PartCount > 0)
                {
                    Rectangle2D rect = m_contour.CoverageArea;
                    Point3Ds pts = geoline3d[0];
                    rect.Left = pts[0].X;
                    rect.Top = pts[0].Y;
                    rect.Right = pts[1].X;
                    rect.Bottom = pts[1].Y;
                    m_contour.CoverageArea = rect;
                }
            }
        }

        //鼠标右键事件，结束分析操作
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreateLine)
            {
                m_sceneControl.Action = m_oldAction;
                this.RegisterEvents(false);
            }

        }

        //窗口关闭事件
        private void DlgFloodAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RegisterEvents(false);

            if (m_contour != null)
            {
                m_contour.Clear();
                m_contour.Dispose();
                m_contour = null;
            }
            if (m_timer != null)
            {
                m_timer.Stop();
                m_timer.Enabled = false;
            }

            m_sceneControl.Scene.TrackingLayer.Clear();
            m_panelDiagram.Visible = false;
        }

        //水面不断上涨
        private void timer_tick(Object sender, EventArgs e)
        { 
            if (m_contour == null)
                return;
            double maxAltitude = m_contour.MaxVisibleAltitude;
            if (maxAltitude < m_maxVisibleAltidute)
            {
                maxAltitude += m_waterInterval;
                m_contour.MaxVisibleAltitude = maxAltitude;
                m_sceneControl.Scene.Refresh();
            }                        
        }
     
        private void btn_DrawAnalystRange_Click(object sender, EventArgs e)
        {
            if (m_timer != null && m_timer.Enabled)
            {
                m_timer.Enabled = false;
                m_timer.Stop();
            }
            if (m_contour == null)
            {
                m_contour = new ContourMap(m_sceneControl.Scene);
                m_contour.DisplayStyle = ContourMap.DisplayMode.Face;
                m_contour.Opacity = 50;
                m_contour.BorderVisible = true;

                //设置等高线颜色表
                ColorDictionary colorDict = new ColorDictionary();
                colorDict[0] = Color.FromArgb(36, 65, 171);
                colorDict[100] = Color.FromArgb(80, 107, 191);
                colorDict[500] = Color.FromArgb(124, 149, 210);
                colorDict[800] = Color.FromArgb(168, 191, 230);
                colorDict[1200] = Color.FromArgb(212, 233, 250);

                m_contour.ColorDictTable = colorDict;
            }
            m_contour.MinVisibleAltitude = m_minVisibleAltidute;
            m_contour.MaxVisibleAltitude = m_minVisibleAltidute + 5;

            this.RegisterEvents(false);
            this.RegisterEvents(true);

            m_oldAction = m_sceneControl.Action;
            m_sceneControl.Action = SuperMap.UI.Action3D.CreateLine;

            m_contour.Build();
            m_contour.BorderColor = Color.Blue;

            this.btn_StartAnalysis.Enabled = true;
            this.btn_Clear.Enabled = true;
        }

        private void btn_StartAnalysis_Click(object sender, EventArgs e)
        {
            m_panelDiagram.Visible = true;

            m_timer.Enabled = true;
            m_timer.Interval = 100;
            m_timer.Tick -= new EventHandler(timer_tick);
            m_timer.Tick += new EventHandler(timer_tick);
            m_timer.Start();

            this.btn_StartAnalysis.Enabled = false;
            this.btn_Clear.Enabled = true;
        }

        private void tb_minAltitude_TextChanged(object sender, EventArgs e)
        {
            String str = this.tb_minAltitude.Text;
            if (str != "")
            {
                m_minVisibleAltidute = Convert.ToDouble(str);
            }
        }

        private void tb_maxAltitude_TextChanged(object sender, EventArgs e)
        {
            String str = this.tb_maxAltitude.Text;
            if (str != "")
            {
                m_maxVisibleAltidute = Convert.ToDouble(str);
            }
        }

        private void tb_Interval_TextChanged(object sender, EventArgs e)
        {
            String str = this.tb_Interval.Text;
            if (str != "")
            {
                m_waterInterval = Convert.ToDouble(str);
            }
        }
    }
}
