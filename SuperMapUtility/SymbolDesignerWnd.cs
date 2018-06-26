///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、范例简介：示范三维符号（三维模型符号、线符号和水面填充符号）在场景中的显示与操作。
//2、示例数据：
//安装目录\SampleData\Symbol3DDisplay\Symbol3DDisplay.smwu
//安装目录\SampleData\Symbol3DDisplay\Model\Subway.kml
//安装目录\SampleData\Symbol3DDisplay\flyground.fpf
//安装目录\SampleData\SymbolLibrary\FillLibrary3D.bru
//安装目录\SampleData\SymbolLibrary\LineLibrary3D.lsl
//安装目录\SampleData\SymbolLibrary\MarkerLibrary3D.sym
//3、关键类型/成员: 
//      Workspace.Resources 属性
//      Resources.MarkerLibrary 属性
//      Resources.LineLibrary 属性
//      Resources.FillLibrary 属性
//      SymbolMarkerLibrary.FromFile 方法
//      SymbolLineLibrary.FromFile 方法
//      SymbolFillLibrary.FromFile 方法
//      SceneControl.Scene 属性
//      SceneControl.Tracked 事件
//      SceneControl.MouseClick 事件
//      Scene.Underground 属性  
//      Scene.PixelToGlobe 方法   
//      DatasetVector.GetRecordset 方法
//      Recordset.AddNew 方法
//      Recordset.Update 方法
//      GeoStyle3D.AltitudeMode 属性
//      GeoStyle3D.BottomAltitude 属性
//      GeoStyle3D.MarkerSymbolID 属性
//      GeoStyle3D.IsMarkerSizeFixed 属性 
//      GeoStyle3D.MarkerSize 属性
//      GeoStyle3D.Marker3DScaleX 属性 
//      GeoStyle3D.Marker3DScaleY 属性
//      GeoStyle3D.Marker3DScaleZ 属性 
//      GeoStyle3D.LineSymbolID 属性
//      GeoStyle3D.LineWidth 属性 
//      GeoStyle3D.FillSymbolID 属性
//      GeoPoint3D.Style3D 属性
//      GeoLine3D.Style3D 属性
//      GeoRegion3D.Style3D 属性   
//4、使用步骤：
//   (1)在符号交互去，选择点符号类型，在场景中绘制点；
//   (2)选择线符号类型，在场景中绘制线；
//   (3)选择水面符号类型，在场景中绘制面；
//   (4)结束绘制操作后，将鼠标状态切换到漫游状态；
//   (5)在符号展示区选择北京地铁线，观看该线数据的动态飞行的效果；
//   (6)在场景中选择一条线数据，可执行沿所绘制线飞行的操作。
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;

namespace LineGraph.SuperMapUtility
{
    public partial class SymbolDesignerWnd : Form
    {
       
        private SceneControl m_sceneContorl;
        private SampleDesignerRun m_sampleRun;
        private Geometry3D geometry;

        public SymbolDesignerWnd(Workspace workspace,SceneControl sceneControl)
        {
            m_workspace = workspace;
            m_sceneContorl = sceneControl;

            InitializeComponent();

            m_SymbolResourceWnd.SymbolMarkerCtrl += new SymbolResourceWnd.SymbolMarkerEventHandler(SymbolMarker_Ctrl);
            m_SymbolResourceWnd.SymbolFillCtrl += new SymbolResourceWnd.SymbolFillEventHandler(SymbolFill_Ctrl);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                m_sceneContorl.InteractionMode = InteractionMode3D.Default;
                m_sceneContorl.Action = Action3D.Pan2;

                //实例化SampleRun
                m_sampleRun = new SampleDesignerRun(m_workspace,m_sceneContorl);

                //注册事件
                //m_sceneContorl.ObjectSelected += new ObjectSelectedEventHandler(m_sceneControl_ObjectSelected);
                //m_sampleRun.flyManager.StopArrived += new StopArrivedEventHandler(flyManager_StopArrived);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 使当前被选中对象所在的图层为当前图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>     
        private void m_sceneControl_ObjectSelected(object sender, ObjectSelectedEventArgs e)
        {
            try
            {
                if (e.Count > 0)
                {
                    Selection3D[] selection = m_sceneContorl.Scene.FindSelection(true);
                    Recordset recordeset = selection[0].ToRecordset();
                    geometry = recordeset.GetGeometry() as Geometry3D;
                    if (geometry.Type == GeometryType.GeoLine3D)
                    {
                        //ButtonFlyLine.Enabled = true;
                    }
                    else
                    {
                        //ButtonFlyLineStop.Enabled = false;
                        //ButtonFlyLine.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormMain_Closing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //e.Cancel = true;
        }

        private void SymbolMarker_Ctrl(object sender, EventArgs e)
        {
            int SelectedIndex = (int)sender;

            Camera camera = m_sceneContorl.Scene.Camera;
            m_sceneContorl.Action = Action3D.Pan2;

            m_sceneContorl.IsCursorCustomized = true;
            m_sceneContorl.Cursor = System.Windows.Forms.Cursors.Cross;
            m_sampleRun.SettingPoint3D(SelectedIndex);
           // m_sampleRun.SettingRegion3D(0, true);
            m_buttonClearPoint3D.Enabled = true;

            UserHelper.bAddSymbolMark = true;
        }


        private void m_ButtonClearPoint_Click(object sender, EventArgs e)
        {
            m_ButtonPan_Click(sender, e);
            m_sceneContorl.Focus();
            m_buttonClearPoint3D.Enabled = false;

            UserHelper.bAddSymbolMark = false;

        }


        private void SymbolFill_Ctrl(object sender, EventArgs e)
        {
            int SelectedIndex = (int)sender;

            //ButtonFlyLine.Enabled = false;
            m_sampleRun.SettingRegion3D(SelectedIndex,false);
            m_buttonClearRegion3D.Enabled = true;

            UserHelper.bAddSymbolFill = true;
            
        }

        private void m_buttonClearRegion3D_Click(object sender, EventArgs e)
        {
            m_sceneContorl.Action = Action3D.Pan2;

            m_ButtonPan_Click(sender, e);
            m_sceneContorl.Focus();
            //ButtonFlyLine.Enabled = false;
            m_buttonClearRegion3D.Enabled = false;

            UserHelper.bAddSymbolFill = false;
        }

        /// <summary>
        /// 当飞行结束后触发事件,显示鸟巢，删除地下有关图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void flyManager_StopArrived(object sender, StopArrivedEventArgs e)
        {
            try
            {
                if (e.RouteStop.Name.Equals("地铁上方1"))
                {
                    //ButtonFlyUndergroud.Text = "地铁八号线动态飞行展示";
                    //m_sampleRun.FlyUndergroudStop();
                    return;
                }

                if (e.RouteStop.Name.Equals(m_sampleRun.routestopName))
                {
                    //m_FlyLineStop_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void m_ButtonPan_Click(object sender, EventArgs e)
        {
            m_sceneContorl.IsCursorCustomized = false;
            m_sceneContorl.Action = Action3D.Pan;
            m_sampleRun.flag = true;
            m_sampleRun.isDraw = false;
        }
    }
} 


