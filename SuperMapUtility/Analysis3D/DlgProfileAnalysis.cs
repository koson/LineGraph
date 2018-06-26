///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、 范例简介：示范三维剖面线分析功能
//2、示例数据：
//   安装目录\SampleData\Analysis3D
//3、关键类型/成员: 
//  Profile类
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using SuperMap.Realspace.SpatialAnalyst;

namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgProfileAnalysis : Form
    {
        private Workspace m_workspace = null;
        private SceneControl m_sceneControl = null;
        private Profile m_profile = null;
        private bool m_bHasDrawn = false; //是否绘制完成
        private Bitmap m_bitmap = null;
        private bool m_bShownPicture = false;
        private Point3Ds m_point3Ds = null;
        private Timer m_timer = null;
        private SuperMap.UI.Action3D m_oldAction;
        

        public DlgProfileAnalysis()
        {
            InitializeComponent();
        }

        public void Initialize(Workspace workspace, SceneControl sceneControl)
        {
            m_workspace = workspace;
            m_sceneControl = sceneControl;
        }

        private void DlgProfileAnalysis_Load(object sender, EventArgs e)
        {
            m_point3Ds = new Point3Ds();

            m_timer = new Timer();
            m_timer.Enabled = false;

            this.ClearResult_ToolStripMenuItem.Enabled = false;
        }

        //开始分析
        private void StartAnalysis_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_oldAction = m_sceneControl.Action;
            this.m_sceneControl.Action = Action3D.CreateLine;
            if (m_profile == null)
            {
                m_profile = new Profile(m_sceneControl.Scene);
            }


            this.RegisterEvents(false);
            this.RegisterEvents(true);

            m_profile.Build();

            this.StartAnalysis_ToolStripMenuItem.Enabled = false;
            this.ClearResult_ToolStripMenuItem.Enabled = true;
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
            //m_sceneControl.Scene.TrackingLayer.Clear();
            //if (m_sceneControl.Action == Action3D.CreateLine)
            //{
            //    GeoLine3D geoline3d = e.Geometry as GeoLine3D;
            //    if (geoline3d.PartCount > 0)
            //    {
            //        SetGeometry3DStyle(geoline3d);
            //        m_sceneControl.Scene.TrackingLayer.Add(geoline3d, "Analysis");
            //    }
            //}
        }
        //鼠标右键事件，结束分析操作
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreateLine)
            {
                GeoLine3D geoline3d = e.Geometry as GeoLine3D;
                if (geoline3d != null && geoline3d.PartCount > 0)
                {
                    Point3Ds pts = geoline3d[0];
                    m_profile.StartPoint = pts[0];
                    m_profile.EndPoint = pts[1];
                    outPutPic();
                }
                m_sceneControl.Action = m_oldAction;
                m_bHasDrawn = true;
            }

        }

        //输出剖面线图片
        private void outPutPic()
        {
            // 输出图片
            m_bitmap = m_profile.OutputProfileToBitMap();
            if (m_bitmap != null)
            {
                this.AutoSize = true;
                // 绘制标尺线
                int x1 = this.m_bitmap.Width;
                int y1 = this.m_bitmap.Height;
                Point p1 = new Point(0, 0);
                Point p2 = new Point(x1, y1);
                this.pictureBox.Image = DrawLineInPicture(m_bitmap, p1, p2, Color.DarkSlateGray, 1, DashStyle.Solid);
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Refresh();
                m_bShownPicture = true;
                
            }
        }

        // 在剖面图上画标尺线，bmp剖面图，p1左上角点(0,0)，p2右下角点(width,height)
        public Bitmap DrawLineInPicture(Bitmap bmp, Point p1, Point p2, Color linecolor, int linewidth, DashStyle ds)
        {
            if (p1.X == p2.X && p1.Y == p2.Y) 
                return bmp;

            Point3D leftTopPoint = m_profile.GetLeftTopPosition();
            Double height = m_profile.ExtendHeight;

            Graphics graphics = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(linecolor);
            Pen pen = new Pen(brush, linewidth);
            pen.DashStyle = ds;
            float x1 = p1.X;
            float y1 = p1.Y;
            float x2 = p2.X;
            float y2 = p2.Y;
            Point location;
            for (int i = 6; i > 0; i--)
            {
                PointF pp1 = new PointF(x1, y2 * i / 6);
                PointF pp2 = new PointF(x2, y2 * i / 6);
                location = new Point((int)x2 / 2, (int)y2 * i / 6 - 2);
                double Alt = leftTopPoint.Z - height * i / 6;
                Alt = Math.Round(Alt, 5);

                graphics.DrawLine(pen, pp1, pp2);

                Label lal_top = new Label();
                this.pictureBox.Controls.Add(lal_top);
                lal_top.AutoSize = true;
                lal_top.BackColor = Color.Black;
                lal_top.ForeColor = Color.White;
                lal_top.Text = "高程是：" + Alt.ToString() + "米";
                lal_top.Location = location;

            }
            graphics.Dispose();
            return bmp;
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

                // 点风格
                style.MarkerColor = Color.Crimson;
                style.MarkerSize = 8;
                // 线风格
                style.LineColor = Color.Red;
                style.LineWidth = 2;
                style.FillMode = FillMode3D.LineAndFill;
                style.FillForeColor = Color.FromArgb(80, Color.LightSeaGreen.R, Color.LightSeaGreen.G, Color.LightSeaGreen.B);
                geometry.Style3D = style;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        //清除分析结果
        private void ClearResult_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox.Image = null;
            this.pictureBox.Controls.Clear();

            m_sceneControl.Scene.TrackingLayer.Clear();

            if (m_profile != null)
            {
                m_profile.Clear();
                m_profile.Dispose();
                m_profile = null;
            }
            if (m_bitmap != null)
            {
                m_bitmap = null;
            }

            this.RegisterEvents(false);

            m_bHasDrawn = false;
            m_bShownPicture = false;

            m_timer.Stop();
            m_timer.Enabled = false;

            this.WindowState = FormWindowState.Normal;
            this.StartAnalysis_ToolStripMenuItem.Enabled = true;
            this.ClearResult_ToolStripMenuItem.Enabled = false;
        }

        //关闭窗体
        private void DlgProfileAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.pictureBox.Image = null;
            this.pictureBox.Controls.Clear();

            m_sceneControl.Scene.TrackingLayer.Clear();

            if (m_profile != null)
            {
                m_profile.Clear();
                m_profile.Dispose();
                m_profile = null;
            }
            if (m_point3Ds != null)
            {
                m_point3Ds.Clear();
                m_point3Ds = null;
            }
            if (m_bitmap != null)
            {
                m_bitmap = null;
            }

            this.RegisterEvents(false);

            m_bHasDrawn = false;
            m_bShownPicture = false;

            m_timer.Stop();
            m_timer.Enabled = false;
        }

        // 鼠标移动返回经纬度
        private Point pt;
        private Point3D pt3D;

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_profile == null || m_bHasDrawn == false)
                return;
            m_timer.Enabled = true;
            m_timer.Interval = 1000;
            m_timer.Tick -= new EventHandler(timer_tick);
            m_timer.Tick += new EventHandler(timer_tick);
            if (e.X < m_bitmap.Width && e.Y < m_bitmap.Height)
            {
                Color pixelColor = m_bitmap.GetPixel(e.X, e.Y);
                if (pixelColor.Name != "ff2f4f4f")
                {
                    pt = new Point(e.X, e.Y);
                    m_timer.Start();
                }
                else
                {
                    this.toolTip1.RemoveAll();
                    m_timer.Stop();
                    m_timer.Enabled = false;
                }
            }
        }

        // 鼠标在场景中停留两秒中显示信息
        private void timer_tick(Object sender, EventArgs e)
        {

            if (m_bShownPicture && m_profile != null)
            {

                pt3D = new Point3D();
                pt3D = m_profile.MeasurePoint3D(pt);
                double Lon = pt3D.X;
                Lon = Math.Round(Lon, 5);
                double Lat = pt3D.Y;
                Lat = Math.Round(Lat, 5);
                double Alt = pt3D.Z;
                Alt = Math.Round(Alt, 5);
                this.toolTip1.Show("Lon:" + Lon + "  Lat:" + Lat + " Alt:" + Alt, this, pt);
            }
        }

        // 鼠标左键点击画线，返回距离
        private bool m_bHasDrawn1 = false; // 是否绘制完成
        private bool m_bStartDraw1 = false; // 是否开始绘制
        private Point line_p1;
        private Point line_p2;
        Vector3d start;
        Vector3d end;
        private Label lal_dis = new Label();

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point3D p3d1;
            Point3D p3d2;

            if (m_profile == null || m_bitmap == null || m_bHasDrawn == false)
                return;
            Pen pen = new Pen(Color.Green, 2);
            pen.SetLineCap(LineCap.Triangle, LineCap.Triangle, DashCap.Triangle);
            pen.StartCap = LineCap.Triangle;
            pen.EndCap=LineCap.Triangle;
            Graphics g = pictureBox.CreateGraphics();

            if (e.Button == MouseButtons.Left)
            {
                // 只有鼠标点击在物体上时才返回点
                Color pixelColor = this.m_bitmap.GetPixel(e.X, e.Y);
                if (!m_bHasDrawn1 && pixelColor.Name != "ff2f4f4f")
                {
                    if (!m_bStartDraw1)
                    {
                        if (lal_dis.Text != null && lal_dis.Text != "")
                        {
                            lal_dis.Text = "";
                            this.pictureBox.Controls.Remove(lal_dis);

                        }
                        pictureBox.Refresh();
                        line_p1 = new Point(e.X, e.Y);
                        p3d1 = m_profile.MeasurePoint3D(line_p1);
                        // 转为球面坐标
                        
                        start = SphericalToCartesian(p3d1.X * DTOR, p3d1.Y * DTOR, p3d1.Z + EarthRadius);
                        m_bStartDraw1 = true;
                        g.FillEllipse(Brushes.Red, e.X, e.Y, 5, 5);

                    }
                    else
                    {
                        line_p2 = new Point(e.X, e.Y);
                        g.FillEllipse(Brushes.Red, e.X, e.Y, 5, 5);
                        p3d2 = m_profile.MeasurePoint3D(line_p2);
                        // 转为球面坐标，计算距离
                        end = SphericalToCartesian(p3d2.X * DTOR, p3d2.Y * DTOR, p3d2.Z + EarthRadius);
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawLine(pen, line_p1, line_p2);

                        Vector3d VecX = new Vector3d(end.x - start.x, end.y - start.y, end.z - start.z);
                        double distence = VecX.Length();//米
                        m_bHasDrawn1 = false;
                        m_bStartDraw1 = false;

                        lal_dis.AutoSize = true;
                        lal_dis.BackColor = Color.Transparent;
                        lal_dis.ForeColor = Color.White;
                        lal_dis.Text = "距离是：" + Math.Round(distence, 3).ToString() + "米";
                        lal_dis.Location = line_p2;
                        this.pictureBox.Controls.Add(lal_dis);
                        
                        g.Dispose();
                    }
                }
            }
         }

             /// <summary>
        /// 将球面坐标转换成笛卡尔坐标
        /// </summary>
        ///  
        private static Double EarthRadius = 6378137;      
        double DTOR = 0.0174532925199432957692369077;

        public Vector3d SphericalToCartesian(double dLongitude, double dLatitude, double dRadius)
        {
            double dRadCosLat = dRadius * (double)Math.Cos(dLatitude);
            return new Vector3d((double)(dRadCosLat * Math.Sin(dLongitude)),
                (double)(dRadius * Math.Sin(dLatitude)),
                (double)(dRadCosLat * Math.Cos(dLongitude)));
        }
       
        public class Vector3d
        {
            public double x;
            public double y;
            public double z;

            public Vector3d() { }
            public Vector3d(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            /// <summary>
            /// 场景中某一点与坐标原点的距离
            /// </summary>
            public double Length()
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (m_bitmap != null)
            {
                e.Graphics.DrawImage(m_bitmap, 0, 0);
            }
        }
              
    }
}
