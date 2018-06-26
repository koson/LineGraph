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

namespace LineGraph.SuperMapUtility
{
    public partial class DlgSetLayerStyle : Form
    {
        private SceneControl m_sceneControl = null;
        private Layer3D m_layer3D = null;
        private GeoStyle3D m_style3D = null;
        private bool m_bSelection = false; //用于标记是设置图层风格还是选择集风格，false：设置图层风格；true：设置选择集风格

        
        public DlgSetLayerStyle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sceneControl"></param>
        /// <param name="layer3D"></param>
        /// <param name="isSelection"></param>
        public void Initialize(SceneControl sceneControl, Layer3D layer3D, bool isSelection)
        {
            m_sceneControl = sceneControl;
            m_layer3D = layer3D;
            m_bSelection = isSelection;

            this.cb_AltitudeMode.Items.Clear();

            //初始化高度模式列表
            if (m_bSelection)
            {
                this.cb_AltitudeMode.Items.Add("贴地");
                this.cb_AltitudeMode.Items.Add("贴对象");
            }
            else
            {
                this.cb_AltitudeMode.Items.Add("贴地");
                this.cb_AltitudeMode.Items.Add("贴对象");
                this.cb_AltitudeMode.Items.Add("相对地面");
                this.cb_AltitudeMode.Items.Add("绝对高度");
                this.cb_AltitudeMode.Items.Add("相对地下");

            }

            //初始化m_style3D
            if (m_bSelection)
            {
                m_style3D = m_layer3D.Selection.Style;
            }
            else
            {
                if (m_layer3D.Type == Layer3DType.Dataset)
                {
                    Layer3DDataset layer3DDataset = m_layer3D as Layer3DDataset;
                    Layer3DSettingVector layerSetting = layer3DDataset.AdditionalSetting as Layer3DSettingVector;
                    m_style3D = layerSetting.Style;
                }
                else if (m_layer3D.Type == Layer3DType.VectorFile)
                {
                    Layer3DVectorFile layer3DFile = m_layer3D as Layer3DVectorFile;
                    Layer3DSettingVector layerSetting = layer3DFile.AdditionalSetting as Layer3DSettingVector;
                    m_style3D = layerSetting.Style;
                }
            }

            this.UpdateData();
        }

        //用数据初始化界面
        private void UpdateData()
        {
            if (m_style3D == null)
                return;


            if (m_style3D.AltitudeMode == AltitudeMode.ClampToGround)
            {
                this.cb_AltitudeMode.SelectedIndex = 0;
            }
            else if (m_style3D.AltitudeMode == AltitudeMode.ClampToObject)
            {
                this.cb_AltitudeMode.SelectedIndex = 1;
            }
            else if (m_style3D.AltitudeMode == AltitudeMode.RelativeToGround)
            {
                this.cb_AltitudeMode.SelectedIndex = 2;
                this.tb_BottomAltitude.Text = m_style3D.BottomAltitude.ToString();
            }
            else if (m_style3D.AltitudeMode == AltitudeMode.Absolute)
            {
                this.cb_AltitudeMode.SelectedIndex = 3;
                this.tb_BottomAltitude.Text = m_style3D.BottomAltitude.ToString();
            }
            else if (m_style3D.AltitudeMode == AltitudeMode.RelativeToUnderground)
            {
                this.cb_AltitudeMode.SelectedIndex = 4;
                this.tb_BottomAltitude.Text = m_style3D.BottomAltitude.ToString();
            }
            this.colorButton.Color = this.m_style3D.FillForeColor;
            this.numericUpDown.Value = 100 - Convert.ToInt16(this.m_style3D.FillForeColor.A * 100 / 255);
        }
        /// <summary>
        /// 设置高度模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AltitudeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_style3D == null)
                return;

            String str = this.cb_AltitudeMode.SelectedItem.ToString();

            switch (str)
            {
                case "贴地":
                    m_style3D.AltitudeMode = AltitudeMode.ClampToGround;
                    this.tb_BottomAltitude.Enabled = false;
                    break;
                case "相对地面":
                    m_style3D.AltitudeMode = AltitudeMode.RelativeToGround;
                    this.tb_BottomAltitude.Enabled = true;
                    break;
                case "绝对高度":
                    m_style3D.AltitudeMode = AltitudeMode.Absolute;
                    this.tb_BottomAltitude.Enabled = true;
                    break;
                case "相对地下":
                    m_style3D.AltitudeMode = AltitudeMode.RelativeToUnderground;
                    this.tb_BottomAltitude.Enabled = true;
                    break;
                case "贴对象":
                    m_style3D.AltitudeMode = AltitudeMode.ClampToObject;
                    this.tb_BottomAltitude.Enabled = false;
                    break;
                default:
                    m_style3D.AltitudeMode = AltitudeMode.ClampToGround;
                    this.tb_BottomAltitude.Enabled = false;
                    break;
            }
            this.RefreshStyle();
        }

        //修改底部高程
        private void tb_BottomAltitude_TextChanged(object sender, EventArgs e)
        {
            if (m_style3D == null)
                return;

            String value = this.tb_BottomAltitude.Text;
            m_style3D.BottomAltitude = Convert.ToDouble(value);

            this.RefreshStyle();
        }

        //修改前景色
        private void colorButton_ColorChanged(object sender, EventArgs e)
        {
            if (m_style3D == null)
                return;

            int alpha = m_style3D.FillForeColor.A;
            Color newColor = this.colorButton.Color;
            m_style3D.FillForeColor = Color.FromArgb(alpha, newColor);

            this.RefreshStyle();
        }

        //修改透明度
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (m_style3D == null)
                return;

            Double value = Convert.ToDouble(numericUpDown.Value);
            Color color = m_style3D.FillForeColor;
            int alpha = Convert.ToInt16(255 - 255 * value / 100);
            m_style3D.FillForeColor = Color.FromArgb(alpha, color);

            this.RefreshStyle();
        }

        //刷新风格
        private void RefreshStyle()
        {
            if (m_layer3D == null)
                return;

            if (m_bSelection)
            {
                m_layer3D.Selection.Style = m_style3D;
                m_layer3D.Selection.UpdateData();
            }
            else
            {
                if (m_layer3D.Type == Layer3DType.Dataset)
                {
                    Layer3DDataset layer3DDataset = m_layer3D as Layer3DDataset;
                    //layer3DDataset.IsEditable = true;
                    Layer3DSettingVector layerSetting = layer3DDataset.AdditionalSetting as Layer3DSettingVector;
                    layerSetting.Style = m_style3D;
                    layer3DDataset.AdditionalSetting = layerSetting;
                    layer3DDataset.UpdateData();

                }
                else if (m_layer3D.Type == Layer3DType.VectorFile)
                {
                    Layer3DVectorFile layer3DFile = m_layer3D as Layer3DVectorFile;
                    Layer3DSettingVector layerSetting = layer3DFile.AdditionalSetting as Layer3DSettingVector;
                    layerSetting.Style = m_style3D;
                    layer3DFile.AdditionalSetting = layerSetting;
                    layer3DFile.UpdateData();
                }
                this.m_sceneControl.Scene.Refresh();
            }
        }
    }
}
