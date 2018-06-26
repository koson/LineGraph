///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、 范例简介：示范三维视线分析功能
//2、示例数据：
//   安装目录\SampleData\Analysis3D
//3、关键类型/成员: 
//  Sightline类
//  Sightline.ViewerPosition属性
//  Sightline.AddTargetPoint(Point3D value)
//  Sightline.GetTargetPoint(System::Int32 index)
//  Sightline.SetTargetPoint(System::Int32 index, Point3D value)
//  Sightline.RemoveTargetPoint(System::Int32 index)
//  Sightline.GetTargetPointCount
//  Sightline.Build()
//  Sightline.Clear()

//4、使用步骤：
//   (1)运行程序后，默认打开SampleData中指定数据，或手动打开需要分析的模型数据
//   (2)点击菜单栏的“视线分析”，弹出属性设置对话框，
//   (3)点击“开始分析”按钮，开始分析，在场景中点一个点作为观察点，然后点多个点作为目标点，右键结束
//   (4)可以多次分析，按“结束分析”按钮结束分析
//   (5)点击“清除分析”，清除分析结果

//5、使用说明
//   (1)分析后，可以通过调整对话框中的参数调整分析区域
//   (2)分析结果线间夹角不能大于120度，大于120度后分析结果线为灰色。
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
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using SuperMap.Realspace.SpatialAnalyst;
using System.Diagnostics;

namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgSightLine : Form
    {
        private Workspace m_workspace = null;
        private SceneControl m_sceneControl = null;
        private List<Point3D> m_endPoints = new List<Point3D>();
        private Sightline m_sightLine = null;
        private ColorScheme m_colorScheme = ColorScheme.Standand;
        private GeoStyle3D m_style3D = null;

        public DlgSightLine()
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

        private void DlgSightLine_Load(object sender, EventArgs e)
        {
            this.btn_Analyst.Enabled = true;
            this.btn_Clear.Enabled = false;
            this.btn_StopAnalysis.Enabled = false;
            this.cb_ColorScheme.SelectedIndex = 0;

            this.cb_TargetPtsIndex.Items.Clear();
            this.RegisterEvents(false);

            m_style3D = new GeoStyle3D();
        }


        //开始分析
        private void btn_Analyst_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            this.RegisterEvents(true);

            m_sceneControl.Action = SuperMap.UI.Action3D.CreatePolyline;

            if (m_sightLine == null)
            {
                m_sightLine = this.CreateSightline();
            }

            this.btn_Analyst.Enabled = false;
            this.btn_Clear.Enabled = true;
            this.btn_StopAnalysis.Enabled = true;
        }

        private Sightline CreateSightline()
        {
            Sightline sightline = new Sightline(m_sceneControl.Scene);

            this.cb_TargetPtsIndex.Items.Clear();
            sightline.Build();

            return sightline;
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

        void m_sceneControl_Tracking(object sender, Tracking3DEventArgs e)
        {
            this.m_sceneControl.Scene.TrackingLayer.Clear();

            if (m_sceneControl.Action == Action3D.CreatePolyline)
            {
                if (m_sightLine != null)
                {
                    GeoLine3D geoline3d = e.Geometry as GeoLine3D;
                    if (geoline3d != null && geoline3d.PartCount > 0)
                    {
                        Point3Ds pts = geoline3d[0];
                        m_sightLine.ViewerPosition = pts[0];
                        updateObservePosition(pts[0]);
                        m_sightLine.RemoveAllTargetPoints();
                        for (int i = 1; i < pts.Count; ++i)
                        {
                            m_sightLine.AddTargetPoint(pts[i]);
                        }
                    }
                }
            }
        }

        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            this.cb_TargetPtsIndex.Items.Clear();

            if (m_sceneControl.Action == Action3D.CreatePolyline)
            {
                GeoLine3D geoline3d = e.Geometry as GeoLine3D;
                if (geoline3d != null && geoline3d.PartCount > 0)
                {
                    Point3Ds pts = geoline3d[0];
                    m_sightLine.ViewerPosition = pts[0];
                    updateObservePosition(pts[0]);
                    m_sightLine.RemoveAllTargetPoints();
                    for (int i = 1; i < pts.Count; ++i)
                    {
                        m_sightLine.AddTargetPoint(pts[i]);
                        this.cb_TargetPtsIndex.Items.Add(i-1);
                    }
                }
            }
            if (this.cb_TargetPtsIndex.Items.Count > 0)
            {
                this.cb_TargetPtsIndex.SelectedIndex = 0;
            }

        }

        
        //将观察点坐标显示在界面上
        void updateObservePosition(Point3D position)
        {
            this.tb_ObserverX.Text = String.Format("{0}", Math.Round(position.X, 8));
            this.tb_ObserverY.Text = String.Format("{0}", Math.Round(position.Y, 8));
            this.tb_ObserverHeight.Text = String.Format("{0}", Math.Round(position.Z, 8));
        }

        //选择目标点，显示目标点坐标
        private void cb_TargetPtsIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_TargetPtsIndex.SelectedIndex;

            if (m_sightLine != null)
            {
                this.tb_TargetX.Text = String.Format("{0}",m_sightLine.GetTargetPoint(index).X);
                this.tb_TargetY.Text = String.Format("{0}", m_sightLine.GetTargetPoint(index).Y);
                this.tb_TargetHeight.Text = String.Format("{0}", m_sightLine.GetTargetPoint(index).Z);
            }
        }

        //设置观察点的x坐标
        private void tb_ObserverX_TextChanged(object sender, EventArgs e)
        {
            if(m_sightLine != null)
            {
                Point3D point3d = m_sightLine.ViewerPosition;
                point3d.X = Convert.ToDouble(this.tb_ObserverX.Text);
                m_sightLine.ViewerPosition = point3d;

                this.m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }

        //设置观察点的Y坐标
        private void tb_ObserverY_TextChanged(object sender, EventArgs e)
        {
            if (m_sightLine != null)
            {
                Point3D point3d = m_sightLine.ViewerPosition;
                point3d.Y = Convert.ToDouble(this.tb_ObserverY.Text);
                m_sightLine.ViewerPosition = point3d;

                this.m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }

        //设置观察点的高度值
        private void tb_ObserverHeight_TextChanged(object sender, EventArgs e)
        {
            if (m_sightLine != null)
            {
                Point3D point3d = m_sightLine.ViewerPosition;
                point3d.Z = Convert.ToDouble(this.tb_ObserverHeight.Text);
                m_sightLine.ViewerPosition = point3d;

                this.m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }

        //设置目标点的X坐标
        private void tb_TargetX_TextChanged(object sender, EventArgs e)
        {
            int index = this.cb_TargetPtsIndex.SelectedIndex;
            if (index >= 0 && m_sightLine != null)
            {
                Point3D point3d = m_sightLine.GetTargetPoint(index);
                point3d.X = Convert.ToDouble(this.tb_TargetX.Text);
                m_sightLine.SetTargetPoint(index, point3d);

                this.m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }

        //设置目标点的Y坐标
        private void tb_TargetY_TextChanged(object sender, EventArgs e)
        {
            int index = this.cb_TargetPtsIndex.SelectedIndex;
            if (index >= 0 && m_sightLine != null)
            {
                Point3D point3d = m_sightLine.GetTargetPoint(index);
                point3d.Y = Convert.ToDouble(this.tb_TargetY.Text);
                m_sightLine.SetTargetPoint(index, point3d);

                this.m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }

        //设置目标点的高度
        private void tb_TargetHeight_TextChanged(object sender, EventArgs e)
        {
            int index = this.cb_TargetPtsIndex.SelectedIndex;
            if (index >= 0 && m_sightLine != null)
            {
                Point3D point3d = m_sightLine.GetTargetPoint(index);
                point3d.Z = Convert.ToDouble(this.tb_TargetHeight.Text);
                m_sightLine.SetTargetPoint(index, point3d);

                this.m_sceneControl.Scene.TrackingLayer.Clear();
            }
        }

        //设置视线颜色，可见区域颜色/不可见区域颜色
        private void cb_ColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_ColorScheme.SelectedIndex;

            switch (index)
            {
                case 0:
                    m_colorScheme = ColorScheme.Standand;
                    if (m_sightLine != null)
                    {
                        m_sightLine.VisibleColor = Color.FromArgb(108, 231, 27);
                        m_sightLine.HiddenColor = Color.FromArgb(244, 52, 4);
                    }

                    break;
                case 1:
                    m_colorScheme = ColorScheme.Custom;
                    if (m_sightLine != null)
                    {
                        m_sightLine.VisibleColor = Color.Yellow;
                        m_sightLine.HiddenColor = Color.Blue;
                    }

                    break;
                case 2:
                    m_colorScheme = ColorScheme.Random;
                    if (m_sightLine != null)
                    {
                        Random rand = new Random();
                        m_sightLine.VisibleColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                        m_sightLine.HiddenColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                    }

                    break;
                default:
                    m_colorScheme = ColorScheme.Standand;
                    if (m_sightLine != null)
                    {
                        m_sightLine.VisibleColor = Color.Green;
                        m_sightLine.HiddenColor = Color.Red;
                    }

                    break;
            }
        }

        //清除所有分析结果
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (m_sightLine != null)
            {
                m_sightLine.Clear();
                m_sightLine = null;
            }
            this.m_sceneControl.Scene.TrackingLayer.Clear();
            this.cb_TargetPtsIndex.Items.Clear();
            this.cb_TargetPtsIndex.SelectedIndex = -1;
            this.tb_ObserverX.Text = "0.0";
            this.tb_ObserverY.Text = "0.0";
            this.tb_ObserverHeight.Text = "0.0";
            this.tb_TargetX.Text = "";
            this.tb_TargetY.Text = "";
            this.tb_TargetHeight.Text = "";
            this.RegisterEvents(false);

            m_sceneControl.Action = Action3D.Pan;

            this.btn_Analyst.Enabled = true;
            this.btn_Clear.Enabled = false;
            this.btn_StopAnalysis.Enabled = false;
        }

        //窗体关闭事件
        private void DlgSightLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_sceneControl.Scene.TrackingLayer.Clear();
            if (m_sightLine != null)
            {
                m_sightLine.Clear();
                m_sightLine = null;
            }
            this.RegisterEvents(false);
            m_sceneControl.Action = Action3D.Pan;
        }

        //结束分析，修改Action
        private void btn_StopAnalysis_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan;

            this.btn_Analyst.Enabled = true;
            this.btn_Clear.Enabled = true;
            this.btn_StopAnalysis.Enabled = false;
        }

        //获取障碍点
        private void btn_GetBarrierPoint_Click(object sender, EventArgs e)
        {
            if(m_sightLine != null)
            {
                int nCount = m_sightLine.GetTargetPointCount();
                for (int i = 0; i < nCount; i++)
                {
                    Sightline.SightlineResult result = m_sightLine.GetSightlineResult(i);
                    //if (!result.Visible)
                    //{
                    Point3D pt3D = result.BarrierPoint;
                    GeoPoint3D geoPoint3D = new GeoPoint3D(pt3D);
                    m_style3D.AltitudeMode = AltitudeMode.Absolute;
                    m_style3D.MarkerSize = 10;
                    m_style3D.MarkerFile = @"../../SampleData/Analysis3D/BarrierPoint3D.png";
                    m_style3D.MarkerAnchorPoint = new Point2D(0.5, 0.5);
                    geoPoint3D.Style3D = m_style3D;
                    String tag = "TargetPoint" + i;
                    int id = m_sceneControl.Scene.TrackingLayer.IndexOf(tag);
                    if (id < 0)
                    {
                        m_sceneControl.Scene.TrackingLayer.Add(geoPoint3D, tag);
                    }
                    else
                    {
                        m_sceneControl.Scene.TrackingLayer.Set(id, geoPoint3D);
                    }

                    //    Boolean isVisible = result.Visible;

                    //    TextStyle style = new TextStyle();
                    //    style.IsSizeFixed = true;
                    //    style.FontName = "隶书";
                    //    style.ForeColor = Color.Red;
                    //    style.FontScale = 2;

                    //    String str;
                    //    if (isVisible)
                    //    {
                    //        str = "可通视";
                    //    }
                    //    else
                    //    {
                    //        str = "不可通视";
                    //    }
                    //    GeoText3D text = new GeoText3D(new TextPart3D(str, m_sightLine.GetTargetPoint(i)), style);

                    //    //this.m_sceneControl.Scene.TrackingLayer.Add(text, "test" + i);
                    ////}

                    //}
                }

            }
        }


    }
}
