///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、 范例简介：示范三维可视域分析功能
//2、示例数据：
//   安装目录\SampleData\Analysis3D
//3、关键类型/成员: 
//  Viewshed3D类
//  Viewshed3D.VisibleAreaColor属性
//  Viewshed3D.HiddenAreaColor
//  Viewshed3D.ViewerPosition
//  Viewshed3D.Direction
//  Viewshed3D.Pitch
//  Viewshed3D.HorizontalFov
//  Viewshed3D.VerticalFov
//  Viewshed3D.Distance
//  Viewshed3D.Quality
//  Viewshed3D.SetDistDirByPoint(Point3D value)
//  Viewshed3D.Build()
//  Viewshed3D.Clear()

//4、使用步骤：
//   (1)运行程序后，默认打开SampleData中指定数据，或手动打开需要分析的模型数据
//   (2)点击菜单栏的“可视域分析”，弹出属性设置对话框，
//   (3)点击“开始分析”按钮，开始分析，在场景中点一个点作为观察点，点第二个点确定分析目标区域，右键结束
//   (4)可以多次分析，按“结束分析”按钮结束分析
//   (5)点击“清除分析”，清除分析结果

//5、使用说明
//   分析后，可以通过调整对话框中的参数调整分析区域
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
    enum ColorScheme
    {
        Standand, //red/green
        Custom, //yellow/blue
        Random
    }
    public partial class DlgViewShedAnalysis : Form
    {
        Workspace m_workspace = null;
        SceneControl m_sceneControl = null;
        double m_viewDistance = 100.0;
        private double m_horizontalFOV = 90; //1~120 deg.
        private double m_vertialFOV = 60; //1~120 deg.
        private double m_direction = 0.0; //-360~360
        private double m_pitch = 0.0; //-90~90
        private AnalysisQuality m_quality = AnalysisQuality.Medium;
        private ColorScheme m_colorScheme = ColorScheme.Standand;
        private Viewshed3D m_viewshed3D = null;
        private List<Viewshed3D> m_viewshed3DList = null;
        private Color m_hintLineColor = Color.White;
        private bool m_bHasDone = true; //一次分析是否完成
        

        public DlgViewShedAnalysis()
        {
            InitializeComponent();
        }

        public void SetWorkspace(Workspace workspace)
        {
            m_workspace = workspace;
        }

        public void SetSceneControl(SceneControl sceneControl)
        {
            m_sceneControl = sceneControl;
        }

        private void DlgViewShedAnalysis_Load(object sender, EventArgs e)
        {
            this.cb_ColorScheme.SelectedIndex = 0;
            this.cb_Quality.SelectedIndex = 1;
            this.RegisterEvents(false);
            this.btn_Clear.Enabled = false;
            this.btn_StopAnalysis.Enabled = false;

            m_viewshed3DList = new List<Viewshed3D>();
        }

        //设置方向角
        private void numeric_Direction_ValueChanged(object sender, EventArgs e)
        {
            m_direction = Convert.ToDouble(this.numeric_Direction.Value);

            if (m_viewshed3D != null)
            {
                m_viewshed3D.Direction = m_direction;
            }
        }

        //设置倾斜角
        private void numeric_Pitch_ValueChanged(object sender, EventArgs e)
        {
            m_pitch = Convert.ToDouble(this.numeric_Pitch.Value);

            if (m_viewshed3D != null)
            {
                m_viewshed3D.Pitch = m_pitch;
            }
        }

        //设置可视距离
        private void numeric_Distance_ValueChanged(object sender, EventArgs e)
        {
            this.m_viewDistance = Convert.ToDouble(this.numeric_Distance.Value);

            if (m_viewshed3D != null)
            {
                m_viewshed3D.Distance = m_viewDistance;
            }
        }

        //设置水平视域
        private void numeric_HorizontalFOV_ValueChanged(object sender, EventArgs e)
        {
            this.m_horizontalFOV = Convert.ToDouble(this.numeric_HorizontalFOV.Value);

            if (m_viewshed3D != null)
            {
                m_viewshed3D.HorizontalFov = m_horizontalFOV;
            }
        }

        //设置垂直视域
        private void numeric_VerticalFOV_ValueChanged(object sender, EventArgs e)
        {
            this.m_vertialFOV = Convert.ToDouble(this.numeric_VerticalFOV.Value);

            if (m_viewshed3D != null)
            {
                m_viewshed3D.VerticalFov = m_vertialFOV;
            }
        }


        //设置观察点X坐标
        private void tb_ObserverX_TextChanged(object sender, EventArgs e)
        {
            if (m_viewshed3D != null)
            {
                Point3D point3d = m_viewshed3D.ViewerPosition;
                point3d.X = Convert.ToDouble(this.tb_ObserverX.Text);
                m_viewshed3D.ViewerPosition = point3d;
            }
        }

        //设置观察点Y坐标
        private void tb_ObserverY_TextChanged(object sender, EventArgs e)
        {
            Point3D point3d = m_viewshed3D.ViewerPosition;
            point3d.Y = Convert.ToDouble(this.tb_ObserverY.Text);
            m_viewshed3D.ViewerPosition = point3d;
        }

        //设置观察点高度值
        private void tb_ObserverHeight_TextChanged(object sender, EventArgs e)
        {
            Point3D point3d = m_viewshed3D.ViewerPosition;
            point3d.Z = Convert.ToDouble(this.tb_ObserverHeight.Text);
            m_viewshed3D.ViewerPosition = point3d;
        }
        /// <summary>
        /// 设置颜色 三种选择：0.标准(红/绿) 1.自定义(黄/蓝) 2. 随机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_ColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cb_ColorScheme.SelectedIndex;

            switch (index)
            {
                case 0:
                    m_colorScheme = ColorScheme.Standand;
                    if (m_viewshed3D != null)
                    {
                        m_viewshed3D.VisibleAreaColor = Color.Green;
                        m_viewshed3D.HiddenAreaColor = Color.Red;
                    }

                    break;
                case 1:
                    m_colorScheme = ColorScheme.Custom;
                    if (m_viewshed3D != null)
                    {
                        m_viewshed3D.VisibleAreaColor = Color.Yellow;
                        m_viewshed3D.HiddenAreaColor = Color.Blue;
                    }

                    break;
                case 2:
                    m_colorScheme = ColorScheme.Random;
                    if (m_viewshed3D != null)
                    {
                        Random rand = new Random();
                        m_viewshed3D.VisibleAreaColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                        m_viewshed3D.HiddenAreaColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                    }

                    break;
                default:
                    m_colorScheme = ColorScheme.Standand;
                    if (m_viewshed3D != null)
                    {
                        m_viewshed3D.VisibleAreaColor = Color.Green;
                        m_viewshed3D.HiddenAreaColor = Color.Red;
                    }

                    break;
            }
        }

        //设置可视域分析质量
        private void cb_Quality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_viewshed3D != null)
            {
                int index = this.cb_Quality.SelectedIndex;
                switch (index)
                {
                    case 0:
                        m_quality = AnalysisQuality.Low;
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
                m_viewshed3D.Quality = m_quality;
            }
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

        //点击“分析”按钮事件
        private void btn_Analyst_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);
            this.RegisterEvents(true);

            m_sceneControl.Action = SuperMap.UI.Action3D.CreateLine;

            this.btn_Analyst.Enabled = false;
            this.btn_StopAnalysis.Enabled = true;
            this.btn_Clear.Enabled = true;
            this.m_bHasDone = true;
        }

        private Viewshed3D CreateViewShed3D()
        {
            //新建ViewShed对象
            Viewshed3D viewShed = new Viewshed3D(m_sceneControl.Scene);

            this.updateParam(viewShed, true);

            if (m_colorScheme == ColorScheme.Standand)
            {
                viewShed.VisibleAreaColor = Color.Green;
                viewShed.HiddenAreaColor = Color.Red;
            }
            else if (m_colorScheme == ColorScheme.Custom)
            {
                viewShed.VisibleAreaColor = Color.Yellow;
                viewShed.HiddenAreaColor = Color.Blue;
            }
            else if (m_colorScheme == ColorScheme.Random)
            {
                Random rand = new Random();
                viewShed.VisibleAreaColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                viewShed.HiddenAreaColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
            }

            viewShed.HintLineColor = m_hintLineColor;
            m_viewshed3DList.Add(viewShed);
            viewShed.Build();

            return viewShed;
        }

        void m_sceneControl_Tracking(object sender, Tracking3DEventArgs e)
        {
            if (m_sceneControl.Action == Action3D.CreateLine)
            {
                if (m_bHasDone)
                {
                    m_viewshed3D = CreateViewShed3D();
                    m_bHasDone = false;
                }
                if (m_viewshed3D != null)
                {
                    GeoLine3D geoline3d = e.Geometry as GeoLine3D;
                    if (geoline3d.PartCount > 0)
                    {
                        Point3Ds pts = geoline3d[0];

                        m_viewshed3D.ViewerPosition = pts[0];
                        updateObserverPosition(m_viewshed3D);

                        m_viewshed3D.SetDistDirByPoint(pts[1]);
                        updateParam(m_viewshed3D, false);
                    }
                }
            }
        }

        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            m_bHasDone = true;
        }

        //更新观察点坐标
        void updateObserverPosition(Viewshed3D viewshed)
        {
            this.tb_ObserverX.Text = Convert.ToString(viewshed.ViewerPosition.X);
            this.tb_ObserverY.Text = Convert.ToString(viewshed.ViewerPosition.Y);
            this.tb_ObserverHeight.Text = Convert.ToString(viewshed.ViewerPosition.Z);
        }

        /// <summary>
        /// 数据更新， bFlag = false时，用ViewShed对象的属性值更新界面参数
        /// bFlag = true时，用界面参数值更新ViewShed对象的属性值
        /// </summary>
        /// <param name="viewshed3D"></param>
        /// <param name="bFlag"></param>
        void updateParam(Viewshed3D viewshed3D,bool bFlag)
        {
            if (bFlag == false)
            {
                this.numeric_Distance.Value = Convert.ToDecimal(viewshed3D.Distance);
                this.numeric_Direction.Value = Convert.ToDecimal(viewshed3D.Direction);
                this.numeric_HorizontalFOV.Value = Convert.ToDecimal(viewshed3D.HorizontalFov);
                this.numeric_VerticalFOV.Value = Convert.ToDecimal(viewshed3D.VerticalFov);
                this.numeric_Pitch.Value = Convert.ToDecimal(viewshed3D.Pitch);
            }
            else
            {
                viewshed3D.Distance = Convert.ToDouble(this.numeric_Distance.Value);
                viewshed3D.Direction = Convert.ToDouble(this.numeric_Direction.Value);
                viewshed3D.HorizontalFov = Convert.ToDouble(this.numeric_HorizontalFOV.Value);
                viewshed3D.VerticalFov = Convert.ToDouble(this.numeric_VerticalFOV.Value);
                viewshed3D.Pitch = Convert.ToDouble(this.numeric_Pitch.Value);
            }
        }

        //清除所有可视域分析
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.RegisterEvents(false);

            int nCount = m_viewshed3DList.Count();
            int i = 0;
            for (i = 0; i < nCount; i++)
            {
                Viewshed3D viewShed = m_viewshed3DList[i];
                viewShed.Clear();
            }
            m_viewshed3DList.Clear();

            if (m_viewshed3D != null)
            {
                m_viewshed3D = null;
            }

            m_sceneControl.Action = Action3D.Pan;

            this.btn_Analyst.Enabled = true;
            this.btn_StopAnalysis.Enabled = false;
            this.btn_Clear.Enabled = false ;
        }

        //窗体关闭事件
        private void DlgViewShedAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RegisterEvents(false);

            int nCount = m_viewshed3DList.Count();
            int i = 0;
            for (i = 0; i < nCount; i++)
            {
                Viewshed3D viewShed = m_viewshed3DList[i];
                viewShed.Clear();
            }
            m_viewshed3DList.Clear();

            if (m_viewshed3D != null)
            {
                m_viewshed3D = null;
            }
            m_sceneControl.Action = Action3D.Pan;
        }

        //修改可视域分析提示线颜色
        private void colorButton_ColorChanged(object sender, EventArgs e)
        {
            m_hintLineColor = this.colorButton.Color;

            if (m_viewshed3D != null)
            {
                m_viewshed3D.HintLineColor = m_hintLineColor;
            }
        }

        //结束分析，修改Action
        private void btn_StopAnalysis_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan;

            this.btn_Analyst.Enabled = true;
            this.btn_StopAnalysis.Enabled = false;
            this.btn_Clear.Enabled = true;
        }
    }
}
