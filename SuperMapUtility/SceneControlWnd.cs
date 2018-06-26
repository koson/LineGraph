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
using SuperMap.Data;
using SuperMap.Realspace;

namespace LineGraph.SuperMapUtility
{
    public partial class SceneControlWnd : UserControl
    {
        private Workspace m_workspace;
        private DlgAttribute m_DlgAttribute = null;
        private LayersControl m_LayersControl = null;
        private DlgSetLayerStyle m_DlgSetLayerStyle = null;
        private DlgOSGBQuery m_DlgOSGBQuery = null;

        private SampleMeasureRun m_SampleMeasureRun = null;
        private SampleSymbolRun m_sampleSymbolRun = null;
        private SampleDesignerRun m_sampleDesignerRun = null;

        private System.Drawing.Drawing2D.GraphicsPath mousePath;
        private Symbol m_symbol;

        public SceneControlWnd(Workspace workspace,SceneControl scenecontrol)
        {
            m_workspace = workspace;
            m_sceneControl = scenecontrol;

            InitializeComponent();

            this.m_sceneControl.IsKeyboardNavigationEnabled = true;
            this.m_sceneControl.IsFPSVisible = false;
            m_sceneControl.Scene.Sun.IsVisible = false;

            m_SampleMeasureRun = new SampleMeasureRun(m_sceneControl);
            m_sampleDesignerRun = new SampleDesignerRun(m_workspace, m_sceneControl);

            //FlowLayoutPanel鼠标滚动事件注册
            flowLayoutPanelMarker.MouseWheel += new MouseEventHandler(flowLayoutPanelMarker_MouseWheel);
            flowLayoutPanelFill.MouseWheel += new MouseEventHandler(flowLayoutPanelFill_MouseWheel);
            mousePath = new System.Drawing.Drawing2D.GraphicsPath();

            //注册事件
            m_sceneControl.ObjectSelected += new ObjectSelectedEventHandler(m_sceneControl_ObjectSelected);

            m_toolStripButtonClearPoint.Enabled = false;
            m_toolStripButtonClearFill.Enabled = false;
        }

        public void SetRegionPoint()
        {
            m_sampleDesignerRun.SetRegionPoint();
        }

        public void ShowPointMarkerWnd()
        {
            try
            {
                if(m_sampleSymbolRun == null)
                {
                    m_sampleSymbolRun = new SampleSymbolRun(m_workspace);
                }
                
                //添加三维控件到窗体
                panel1.Controls.Add(flowLayoutPanelMarker);
                panel1.Controls.SetChildIndex(flowLayoutPanelMarker, 1);

                PaintSymbols(50, 50, m_sampleSymbolRun.Point, flowLayoutPanelMarker, m_sampleSymbolRun.SymbolTreeMarkerGroup);
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowFillWnd()
        {
            try
            {
                if (m_sampleSymbolRun == null)
                {
                    m_sampleSymbolRun = new SampleSymbolRun(m_workspace);   
                }

                //添加三维控件到窗体
                panel1.Controls.Add(flowLayoutPanelFill);
                panel1.Controls.SetChildIndex(flowLayoutPanelFill, 2);

                PaintSymbols(75, 75, m_sampleSymbolRun.Region, flowLayoutPanelFill, m_sampleSymbolRun.SymbolFillRootGroup);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            

            PaintSymbols(75, 75, m_sampleSymbolRun.Region, flowLayoutPanelFill, m_sampleSymbolRun.SymbolFillRootGroup);
        }

        public void ShowSceneWnd()
        {
            panel1.Controls.Remove(flowLayoutPanelMarker);
            panel1.Controls.Remove(flowLayoutPanelFill);
        }

 
        void m_sceneControl_ObjectSelected(object sender, ObjectSelectedEventArgs e)
        {
            //Recordset recordset = null;
            //Selection3D[] selection3d = null;
            try
            {
                //有对象选中
                if (e.Count > 0)
                {
                    m_sceneControl.Action = Action3D.Pan2;

                    //selection3d = m_sceneControl.Scene.FindSelection(true);
                    //recordset = selection3d[0].ToRecordset();

                    //GeoStyle3D style = new GeoStyle3D();
                    //style.FillForeColor = Color.Red;

                    //GeoPoint3D sourcepoint = recordset.GetGeometry() as GeoPoint3D;

                    //GeoRegion3D geoRegion3D = recordset.GetGeometry() as GeoRegion3D;

                    //m_sampleDesignerRun.SetRegionPoint(geoRegion3D);
                    //// 源点
                    //if (m_pointType == 0)
                    //{
                    //    m_layerNetNode.Selection.Style = style;

                    //    GeoPoint3D sourcepoint = recordset.GetGeometry() as GeoPoint3D;
                    //    m_sourcePoints.Add(sourcepoint.ID);
                    //    if (m_sourcePoints.Count > 1)
                    //    {
                    //        m_layerNetNode.Selection.AddRange(m_sourcePoints.ToArray());
                    //    }
                    //    else
                    //    {
                    //        m_layerNetNode.Selection.Add(m_sourcePoints[0]);
                    //    }

                    //    m_layerNetNode.Selection.UpdateData();
                    //}
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Property_Ctrl()
        {
            m_sceneControl.DoubleClick -= sceneControl_DoubleClick;
            m_sceneControl.DoubleClick += sceneControl_DoubleClick;
            m_sceneControl.Action = Action3D.Pan;
        }

        //场景双击事件
        private void sceneControl_DoubleClick(object sender, EventArgs e)
        {
            if (m_sceneControl.Scene != null)
            {
                Selection3D[] select3D = m_sceneControl.Scene.FindSelection(true);
                if (select3D.Count() <= 0)
                {
                    MessageBox.Show("请先设置矢量图层 vectorR@vector 的选择集风格为贴对象！");
                    return;
                }
                if (m_DlgAttribute == null || m_DlgAttribute.IsDisposed)
                {
                    m_DlgAttribute = new DlgAttribute();
                }
                try
                {
                    m_DlgAttribute.getAtt(select3D);
                    m_DlgAttribute.TopMost = true;
                    m_DlgAttribute.ShowInTaskbar = false;
                    if (m_DlgAttribute.Visible == false)
                    {
                        m_DlgAttribute.StartPosition = FormStartPosition.CenterScreen;
                        m_DlgAttribute.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    m_DlgAttribute.Dispose();
                }
            }
        }

        public void LayerStyle_Ctrl()
        {
            Layer3Ds layer3ds = this.m_sceneControl.Scene.Layers;
            if (layer3ds.Count <= 0)
                return;
            TreeNode treeNode = this.m_LayersControl.Layer3DsTree.SelectedNode;
            Layer3DsTreeNodeBase treeNodeBase = treeNode as Layer3DsTreeNodeBase;
            if (treeNodeBase == null)
            {
                MessageBox.Show("请先选择一矢量图层");
                return;
            }
            Layer3D layer3D = treeNodeBase.GetData() as Layer3D;
            if (layer3D == null)
            {
                return;
            }
            if (layer3D.Type == Layer3DType.Dataset || layer3D.Type == Layer3DType.VectorFile)
            {
                if (m_DlgSetLayerStyle == null || m_DlgSetLayerStyle.IsDisposed)
                {
                    m_DlgSetLayerStyle = new DlgSetLayerStyle();
                }

                m_DlgSetLayerStyle.Initialize(m_sceneControl, layer3D, false);
                m_DlgSetLayerStyle.StartPosition = FormStartPosition.CenterScreen;
                m_DlgSetLayerStyle.Show();
            }
        }

        public void SQL_Ctrl()
        {
            if (this.m_workspace.Datasources.Count == 0)
            {
                MessageBox.Show("请打开数据源！");
                return;
            }

            if (m_DlgOSGBQuery != null)
            {
                if (!m_DlgOSGBQuery.m_bCleared)
                {
                    m_DlgOSGBQuery.ClearResult();
                }
                m_DlgOSGBQuery.Dispose();
                m_DlgOSGBQuery = null;
            }
            m_DlgOSGBQuery = new DlgOSGBQuery();
            m_DlgOSGBQuery.SetValue(m_workspace, m_sceneControl);
            bool bFlag = m_DlgOSGBQuery.SetQueryType(OSGBQueryType.SQL);
            if (bFlag)
            {
                m_DlgOSGBQuery.StartPosition = FormStartPosition.CenterScreen;
                m_DlgOSGBQuery.Show();
            }
        }
        /// <summary>
        /// 开始距离量算
        /// </summary>
        public void BeginMeasureDistance()
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureDistance();
        }

        /// <summary>
        /// 开始依地距离量算
        /// </summary>
        public void BeginMeasureTerrainDistance()
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureTerrainDistance();
        }

        /// <summary>
        /// 开始水平距离量算
        /// </summary>
        public void BeginMeasureHorizontalDistance()
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureHorizontalDistance();
        }

        /// <summary>
        /// 开始面积量算
        /// </summary>
        public void BeginMeasureArea()
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureArea();
        }

        /// <summary>
        /// 开始高度量算
        /// </summary>
        public void BeginMeasureAltitude()
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureAltitude();
        }

        /// <summary>
        /// 开始依地面积量算
        /// </summary>
        public void BeginMeasureTerrainArea()
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureTerrainArea();
        }

        /// <summary>
        /// 清空量算结果
        /// </summary>
        public void ClearResult()
        {
            UserHelper.bMeasure = false;
            m_SampleMeasureRun.ClearResult();
        }



        /// <summary>
        /// 进行距离量算操所
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonMeasureDistance_Click(object sender, EventArgs e)
        {
            try
            {
                UserHelper.bMeasure = true;
                m_SampleMeasureRun.BeginMeasureDistance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 进行面积量算操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonMeasureArea_Click(object sender, EventArgs e)
        {
            try
            {
                UserHelper.bMeasure = true;
                m_SampleMeasureRun.BeginMeasureArea();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 进行高度量算操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonMeasureAltitude_Click(object sender, EventArgs e)
        {
            try
            {
                UserHelper.bMeasure = true;
                m_SampleMeasureRun.BeginMeasureAltitude();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 清空量算结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                UserHelper.bMeasure = false;
                m_SampleMeasureRun.ClearResult();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void m_toolStripButtonMeasureTerrainArea_Click(object sender, EventArgs e)
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureTerrainArea();
        }

        private void m_toolStripButtonMeasureTerrainDistance_Click(object sender, EventArgs e)
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureTerrainDistance();
        }

        private void m_toolStripButtonMeasureHorizotalDistance_Click(object sender, EventArgs e)
        {
            UserHelper.bMeasure = true;
            m_SampleMeasureRun.BeginMeasureHorizontalDistance();
        }

        private void toolStripButton_StopMeasure_Click(object sender, EventArgs e)
        {
            UserHelper.bMeasure = false;
            m_sceneControl.Action = Action3D.Pan;
        }

        /// <summary>
        /// flowLayoutPanelMarker的鼠标滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanelMarker_MouseWheel(Object sender, MouseEventArgs e)
        {
            try
            {
                if (flowLayoutPanelMarker.Focused)
                {
                    Int32 numberOfTextLinesToMove = Math.Abs(e.Delta * SystemInformation.MouseWheelScrollLines / 200) % 10;
                    Int32 numberOfPixelsToMove = numberOfTextLinesToMove * flowLayoutPanelMarker.Size.Height;
                    if (numberOfPixelsToMove != 0)
                    {
                        System.Drawing.Drawing2D.Matrix translateMatrix = new System.Drawing.Drawing2D.Matrix();
                        translateMatrix.Translate(0, numberOfPixelsToMove);
                        mousePath.Transform(translateMatrix);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 将SymbolGroup中的符号，通过大小和几何对象绘制到FlowLayoutPanel中
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="geometry"></param>
        /// <param name="panel"></param>
        /// <param name="symbolGroup"></param>
        private void PaintSymbols(Int32 width, Int32 height, Geometry geometry, FlowLayoutPanel flowLayoutPanel, SymbolGroup symbolGroup)
        {
            try
            {
                flowLayoutPanel.Controls.Clear();
                Int32 count = symbolGroup.Count;
                Int32 row = 1;
                // 循环得到符号并将符号添加到PictureBox，后将PictureBox添加到FlowLayoutPanel
                for (int i = 0; i < count; i++)
                {
                    Symbol symbol = symbolGroup[i];
                    // 初始化PictureBox对象
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(width, height);
                    pictureBox.Name = symbol.Name;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.Tag = symbol;
                    //绘制符号
                    DrawSymbol(symbol, geometry, width, height, pictureBox);
                    //注册PictureBox的点击事件
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    pictureBox.MouseLeave += new EventHandler(pictureBox_MouseLeave);
                    if (i % (flowLayoutPanel.Width / width) == 0)
                    {
                        row++;
                    }
                    flowLayoutPanel.Controls.Add(pictureBox);
                }

                flowLayoutPanel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 在Picture上绘制符号
        /// </summary>
        /// <param name="symbol"></param>
        public void DrawSymbol(Symbol symbol, Geometry geometry, Int32 width, Int32 height, PictureBox pictureBox)
        {
            try
            {
                Bitmap bitmap = new Bitmap(width, width);

                if (symbol.Type == SymbolType.Fill3D)
                {
                    symbol.Draw(bitmap, geometry);
                }
                else
                {
                    geometry.Style.MarkerSymbolID = symbol.ID;

                    Toolkit.Draw(geometry, m_workspace.Resources, Graphics.FromImage(bitmap));

                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// PictureBox的点击事件,分不同的面板，响应不同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(Object sender, EventArgs e)
        {
            try
            {
                PictureBox pictureBox = sender as PictureBox;
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
                m_symbol = pictureBox.Tag as Symbol;
                //不同的面板不同的响应
                if (pictureBox.Parent == flowLayoutPanelMarker)
                {
                    flowLayoutPanelMarker.Select();

                    SymbolMarker_Ctrl(m_symbol.ID);
                }

                if (pictureBox.Parent == flowLayoutPanelFill)
                {
                    flowLayoutPanelFill.Select();

                    SymbolFill_Ctrl(m_symbol.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// mouse Leave事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseLeave(Object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            picture.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// flowLayoutPanelFill的鼠标滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanelFill_MouseWheel(Object sender, MouseEventArgs e)
        {
            try
            {
                if (flowLayoutPanelFill.Focused)
                {
                    Int32 numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                    Int32 numberOfPixelsToMove = numberOfTextLinesToMove * flowLayoutPanelFill.Size.Height;
                    if (numberOfPixelsToMove != 0)
                    {
                        System.Drawing.Drawing2D.Matrix translateMatrix = new System.Drawing.Drawing2D.Matrix();
                        translateMatrix.Translate(0, numberOfPixelsToMove);
                        mousePath.Transform(translateMatrix);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SymbolMarker_Ctrl(int SelectedIndex)
        {
            Camera camera = m_sceneControl.Scene.Camera;
            m_sceneControl.Action = Action3D.Pan2;

            m_sceneControl.IsCursorCustomized = true;
            m_sceneControl.Cursor = System.Windows.Forms.Cursors.Cross;
            m_sampleDesignerRun.SettingPoint3D(SelectedIndex);

            m_toolStripButtonClearPoint.Enabled = true;

            UserHelper.bAddSymbolMark = true;
        }

        private void SymbolFill_Ctrl(int SelectedIndex)
        {
            m_sampleDesignerRun.SettingRegion3D(SelectedIndex, false);

            m_toolStripButtonClearFill.Enabled = true;

            UserHelper.bAddSymbolFill = true;
        }

        private void m_toolStripButtonClearPoint_Click(object sender, EventArgs e)
        {
            UserHelper.bAddSymbolMark = false;

            m_sceneControl.IsCursorCustomized = false;
            m_sceneControl.Action = Action3D.Pan;
            m_sampleDesignerRun.flag = true;
            m_sampleDesignerRun.isDraw = false;
            m_sceneControl.Focus();
            m_toolStripButtonClearPoint.Enabled = false;
            UserHelper.bAddSymbolMark = false;

        }

        private void m_toolStripButtonClearFill_Click(object sender, EventArgs e)
        {
            m_sceneControl.Action = Action3D.Pan2;

            m_sceneControl.IsCursorCustomized = false;
            m_sceneControl.Action = Action3D.Pan;
            m_sampleDesignerRun.flag = true;
            m_sampleDesignerRun.isDraw = false;
            m_sceneControl.Focus();

            m_toolStripButtonClearFill.Enabled = false;

            UserHelper.bAddSymbolFill = false;
        }
    }
}
