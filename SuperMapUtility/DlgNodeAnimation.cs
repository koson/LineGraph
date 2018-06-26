///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、 范例简介：示范节点动画功能,
//2、示例数据：
//   安装目录\SampleData\NodeAnimation
//3、关键类型/成员: 
//   NodeAnimation类
//   NodeAnimation.SetTrack()方法
//   NodeAnimation.Length属性
//   NodeAnimation.PlayMode属性
//   NodeAnimation.IsEnabled属性
//////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.UI;
using SuperMap.Realspace;
using SuperMap.Data;
using System.IO;

namespace LineGraph.SuperMapUtility
{
    public partial class DlgNodeAnimation : Form
    {
        private SceneControl m_sceneControl = null;
        private LayersControl m_layersControl = null;
        private Layer3DKML m_layerKML = null;
        private GeoModel m_geoModel = null;
        private GeoLine3D m_geoLine3D = null;
        private double m_length = 10.0;
        private Boolean m_bIsLoop = false;
        private SuperMap.Data.NodeAnimation m_nodeAnimation = null;
        private Boolean m_bIsSaveTrack = true;
        private GeoStyle3D m_style3D = null;

        public DlgNodeAnimation()
        {
            InitializeComponent();
            this.cb_Track.Items.Add("绘制运动轨迹");
            this.btn_AddToKML.Enabled = false;
            this.tb_Length.Text = m_length.ToString();
        }

        public void Initialize(Layer3DKML layerKML, SceneControl sceneControl, LayersControl layersControl)
        {
            m_layerKML = layerKML;
            m_sceneControl = sceneControl;
            m_layersControl = layersControl;
            m_style3D = new GeoStyle3D();
            this.tb_LayerKml.Text = Path.GetFileName(m_layerKML.DataName);

            this.InitCombox(m_layerKML);       

            m_sceneControl.Tracked -= new Tracked3DEventHandler(m_sceneControl_Tracked);
            m_sceneControl.Tracked += new Tracked3DEventHandler(m_sceneControl_Tracked);

        }

        //获取KML图层下的模型和运动轨迹，初始化模型列表和轨迹列表
        private void InitCombox(Layer3DKML layerKML)
        {
            Feature3Ds features = layerKML.Features;
            if (features.Count > 0)
            {
                for (int i = 0; i < features.Count; i++)
                {
                    Feature3D feature = features[i] as Feature3D;
                    GeoPlacemark geoplacemark = feature.Geometry as GeoPlacemark;
                    if (geoplacemark != null)
                    {
                        Geometry3D geometry3D = geoplacemark.Geometry as Geometry3D;
                        if (geometry3D is GeoModel)
                        {
                            this.cb_Model.Items.Add(feature.Name);
                        }
                        else if (geometry3D is GeoLine3D)
                        {
                            this.cb_Track.Items.Add(feature.Name);
                        }
                    }
                }
            }
            if (this.cb_Model.Items.Count > 0)
            {
                this.cb_Model.SelectedIndex = 0;
            }
            if (this.cb_Track.Items.Count > 1)
            {
                this.cb_Track.SelectedIndex = 1;
            }
            else
            {
                this.cb_Track.SelectedIndex = 0;
            }
        }

        //指定模型，并设置其节点动画属性
        private void cb_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果之前的模型正在运动，则停止运动
            if (m_nodeAnimation != null && m_nodeAnimation.IsEnabled == true)
            {
                m_nodeAnimation.IsEnabled = false;
            }

            //获取当前模型，并设置节点动画
            String featureName = this.cb_Model.SelectedItem as String;

            Feature3Ds features = m_layerKML.Features;
            Feature3D[] feature3Ds = features.FindFeature(featureName,Feature3DSearchOption.AllFeatures);
            if (feature3Ds.Length > 0)
            {
                Feature3D feature3D = feature3Ds[0];
                GeoPlacemark geoPlacemark = feature3D.Geometry as GeoPlacemark;
                m_geoModel = geoPlacemark.Geometry as GeoModel;
                if (m_geoModel != null)
                {
                    m_nodeAnimation = m_geoModel.NodeAnimation;
                    //位置变更事件
                    m_nodeAnimation.TimePositionChanged -= new TimePositionChangedEventHandler(m_nodeAnimationTimePositionChanged);
                    m_nodeAnimation.TimePositionChanged += new TimePositionChangedEventHandler(m_nodeAnimationTimePositionChanged);

                    if (m_geoLine3D != null && m_geoLine3D.PartCount > 0)
                    {
                        m_nodeAnimation.SetTrack(m_geoLine3D);
                        m_nodeAnimation.TimePostition = 0;
                    }
                }
            }
        }


        //如果kml中已经保存运动轨迹，可以选择已保存好的运动轨迹
        private void cb_Track_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Track.SelectedIndex == 0)
            {
                return;
            }
            this.m_sceneControl.Scene.TrackingLayer.Clear();

            String trackName = this.cb_Track.SelectedItem as String;
            Feature3Ds features = m_layerKML.Features;
            Feature3D[] feature3Ds = features.FindFeature(trackName, Feature3DSearchOption.AllFeatures);
            if (feature3Ds.Length > 0)
            {
                Feature3D feature3D = feature3Ds[0];
                GeoPlacemark geoPlacemark = feature3D.Geometry as GeoPlacemark;
                 m_geoLine3D = geoPlacemark.Geometry as GeoLine3D;
                 if (m_geoLine3D != null && m_geoLine3D.PartCount > 0)
                {
                    if (m_nodeAnimation != null)
                    {
                        m_nodeAnimation.SetTrack(m_geoLine3D);
                        m_nodeAnimation.TimePostition = 0;
                    }
                    this.btn_AddToKML.Enabled = false;
               }
            }
        }

        //绘制运动轨迹
        private void btn_DrawTrack_Click(object sender, EventArgs e)
        {
            this.cb_Track.SelectedIndex = 0;
            m_sceneControl.Scene.TrackingLayer.Clear();
            m_sceneControl.Action = Action3D.CreatePolyline;
        }
        

        //鼠标右键事件，结束绘制操作 
        void m_sceneControl_Tracked(object sender, Tracked3DEventArgs e)
        {
            int a = 0;
            if (m_sceneControl.Action == Action3D.CreatePolyline)
            {
                GeoLine3D line3D = e.Geometry as GeoLine3D;
                m_geoLine3D = line3D;

                m_style3D.LineColor = Color.Yellow;
                m_style3D.LineWidth = 1;
                m_style3D.AltitudeMode = AltitudeMode.Absolute;
                m_geoLine3D.Style3D = m_style3D;
                m_sceneControl.Scene.TrackingLayer.Add(m_geoLine3D, "track" + (++a));

                m_nodeAnimation.SetTrack(m_geoLine3D);
                m_nodeAnimation.Length = m_length;
                m_nodeAnimation.TimePostition = 0;
                m_sceneControl.Action = Action3D.Pan;

                this.btn_AddToKML.Enabled = true;
            }
        }

        //设置运动时长
        private void tb_Length_TextChanged(object sender, EventArgs e)
        {
            String str = this.tb_Length.Text;
            if (str != "")
            {
                m_length = Convert.ToDouble(str);
                this.trackBar.Maximum = Convert.ToInt16(m_length);


                if (m_nodeAnimation != null)
                {
                    m_nodeAnimation.Length = m_length;
                    m_nodeAnimation.TimePostition = 0;
                }
            }
        }

        //设置是否循环运动
        private void cb_PlayMode_CheckedChanged(object sender, EventArgs e)
        {
            m_bIsLoop = this.cb_PlayMode.Checked;

            if (m_nodeAnimation != null)
            {
                if (m_bIsLoop)
                {
                    m_nodeAnimation.PlayMode = PlayMode.Loop;
                }
                else
                {
                    m_nodeAnimation.PlayMode = PlayMode.Once;
                }
            }
        }

        //开始运动
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (m_nodeAnimation == null)
            {
                MessageBox.Show("获取模型动画失败！");
                return;
            }

            if (m_geoLine3D == null || m_geoLine3D.PartCount == 0)
            {
                MessageBox.Show("请先绘制运动轨迹！");
                return;
            }

            m_nodeAnimation.IsEnabled = true;

            if (m_bIsLoop)
            {
                m_nodeAnimation.PlayMode = PlayMode.Loop;
            }
            else
            {
                m_nodeAnimation.PlayMode = PlayMode.Once;
            }

            if (m_nodeAnimation.PlayMode == PlayMode.Once && m_nodeAnimation.TimePostition == m_nodeAnimation.Length)
            {
                m_nodeAnimation.TimePostition = 0;
            }
          
        }

        //运动过程中实时获取节点动画的时间位置
        private void m_nodeAnimationTimePositionChanged(object sender, TimePositionChangedEventArgs e)
        {
            double timePos = e.TimePosition;
            this.label_TimePosition.Text = String.Format("{0}", Math.Round(Convert.ToDecimal(timePos), 2));
            trackBar.Value = Convert.ToInt16(timePos);
            if (m_nodeAnimation.PlayMode == PlayMode.Once && timePos == m_nodeAnimation.Length)
            {
                m_nodeAnimation.IsEnabled = false;
                m_nodeAnimation.TimePostition = 0.05;
            }
        }

        //停止运动
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            m_nodeAnimation.IsEnabled = false;
        }

        //保存节点动画
        private void btn_AddToKML_Click(object sender, EventArgs e)
        {
            if (m_bIsSaveTrack)
            {
                Feature3Ds features = m_layerKML.Features;
                int nCount = this.cb_Track.Items.Count - 1;
                Feature3D feature3D = new Feature3D();
                GeoPlacemark geoPlacemark = new GeoPlacemark();
                m_style3D.LineColor = Color.Green;
                m_style3D.AltitudeMode = AltitudeMode.RelativeToGround;
                m_style3D.BottomAltitude = 0.5;
                m_geoLine3D.Style3D = m_style3D;
                geoPlacemark.Geometry = m_geoLine3D;
                feature3D.Geometry = geoPlacemark;
                feature3D.Description = "track" + nCount;
                feature3D.Name = feature3D.Description;
                features.Add(feature3D);

                //刷新图层树
                Layer3DsTreeNodeBase node = this.m_layersControl.Layer3DsTree.FindNode(m_layerKML);
                this.m_layersControl.Layer3DsTree.RefreshNode(node);
                node.Expand();

                //将新保存的运动轨迹添加的轨迹列表中
                if (!this.cb_Track.Items.Contains(feature3D.Name))
                {
                    this.cb_Track.Items.Add(feature3D.Name);
                    this.cb_Track.SelectedItem = feature3D.Name;
                }

                ////保存kml
                //String kmlPath = m_layerKML.DataName;
                //m_layerKML.Features.ToKMLFile(kmlPath);
            }


            this.m_sceneControl.Scene.TrackingLayer.Clear();
            this.btn_AddToKML.Enabled = false;
        }

        //关闭对话框
        private void DlgNodeAnimation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cb_Model.Items.Clear();
            this.m_sceneControl.Scene.TrackingLayer.Clear();
            m_nodeAnimation.TimePositionChanged -= new TimePositionChangedEventHandler(m_nodeAnimationTimePositionChanged);
            m_sceneControl.Tracked -= new Tracked3DEventHandler(m_sceneControl_Tracked);
            m_nodeAnimation.IsEnabled = false;

            m_geoLine3D = null;
            m_style3D = null;
            m_nodeAnimation = null;
            m_geoModel = null;
            this.btn_AddToKML.Enabled = false;
        }

        //是否保存运动轨迹
        private void cb_IsSaveTrack_CheckedChanged(object sender, EventArgs e)
        {
            m_bIsSaveTrack = this.cb_IsSaveTrack.Checked;
        }

        //设置动画的时间位置
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (m_nodeAnimation.IsEnabled == false)
            {
                int value = this.trackBar.Value;
                m_nodeAnimation.TimePostition = Convert.ToDouble(value);
            }
        }
    }
}
