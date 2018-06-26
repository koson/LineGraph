using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgClipPlane : Form
    {
        private SceneControl m_sceneControl = null;
        private Action3D m_oldAction;
        private Layer3D m_layer3D = null;

        public DlgClipPlane()
        {
            InitializeComponent();
        }

        public void SetSceneControl(SceneControl sceneControl)
        {
            m_sceneControl = sceneControl;

            int count = m_sceneControl.Scene.Layers.Count;
            for (int i = 0; i < count; i++)
            {
                cb_layers.Items.Add(m_sceneControl.Scene.Layers[i].Name);
            }
            if (cb_layers.Items.Count > 0)
            {
                cb_layers.SelectedIndex = 0;
            }
        }

        //窗口加载事件
        private void DlgClipPlane_Load(object sender, EventArgs e)
        {
           // this.btn_start.Enabled = true;
            this.btn_clear.Enabled = false;
        }

        //选择图层
        private void cb_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            String layerName = this.cb_layers.SelectedItem as String;
            m_layer3D = m_sceneControl.Scene.Layers[layerName];
            if (m_layer3D == null)
            {
                MessageBox.Show("获取图层失败！");
            }
        }

        //窗口关闭事件
        private void DlgClipPlane_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RegisterEvents(false);
        }

        //定义裁剪面，开始分析
        private void btn_start_Click(object sender, EventArgs e)
        {
            m_oldAction = m_sceneControl.Action;

            m_sceneControl.Action = Action3D.CreatePolygon;
            this.RegisterEvents(false);
            this.RegisterEvents(true);

            this.btn_start.Enabled = false;
            this.btn_clear.Enabled = true;
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
                m_sceneControl.Scene.TrackingLayer.Clear();

                Geometry3D geometry = e.Geometry as Geometry3D;

                if (geometry is GeoLine3D)
                {
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
                    GeoStyle3D style3D = new GeoStyle3D();
                    style3D.LineColor = Color.Yellow;
                    style3D.AltitudeMode = AltitudeMode.Absolute;
                    geoRegion3D.Style3D = style3D;
                    m_sceneControl.Scene.TrackingLayer.Add(geoRegion3D, "region");
                }
            }
        }

        //鼠标右键事件
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreatePolygon)
            {
                GeoRegion3D region3D = e.Geometry as GeoRegion3D;
                if (region3D != null)
                {
                    Point3Ds point3Ds = region3D[0];
                    if (point3Ds.Count < 3)
                        return;
                    else
                    {
                        Point3D pt1 = point3Ds[0];
                        Point3D pt2 = point3Ds[1];
                        Point3D pt3 = point3Ds[2];
                        m_layer3D.SetCustomClipPlane(pt1, pt2, pt3);
                    }
                }
                m_sceneControl.Action = m_oldAction;
                m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }
      
        //清除分析
        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            m_layer3D.ClearCustomClipPlane();
            m_sceneControl.Scene.TrackingLayer.Clear();

            m_sceneControl.Action = Action3D.Pan;

            this.btn_start.Enabled = true;
            this.btn_clear.Enabled = false;

        }
        /// <summary>
        /// 设置添加到TrackingLayer的三维几何对象的风格
        /// </summary>
        /// <param name="geometry"></param>
        private void SetGeometry3DStyle(Geometry3D geometry)
        {
            try
            {
                GeoStyle3D style = new GeoStyle3D();
                style.AltitudeMode = AltitudeMode.Absolute;

                style.BottomAltitude = 2;

                // 点风格
                style.MarkerColor = Color.Crimson;
                style.MarkerSize = 8;
                //
                style.LineColor = Color.Red;
                style.LineWidth = 2;
                style.FillMode = FillMode3D.LineAndFill;
                style.FillForeColor = Color.FromArgb(80, Color.LightSeaGreen.R, Color.LightSeaGreen.G, Color.LightSeaGreen.B);
                geometry.Style3D = style;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
    }
}
