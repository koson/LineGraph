///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
//1、范例简介：示范如何将符号库中的符号取出、符号设置、符号预览等功能
//2、示例数据：安装路径\SampleData\City\Changchun.smwu； 
//3、关键类型/成员: 
//     Workspace.Open 方法
//     Resources.MarkerLibrary 属性
//     Resources.LineLibrary 属性
//     Resources.FillLibrary 属性
//     SymbolLibrary.RootGroup 属性
//     Symbol.Draw 方法
//     Symbol.ID 属性
//     Symbol.Name 属性
//     Geometry.Style 属性 
//
//4、使用步骤：
//   (1)点选一符号图标，查看右侧面板中符号的信息。
//   (2)修改符号的各个属性，查看符号的预览效果。
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Realspace;
using System.Threading.Tasks;

namespace LineGraph.SuperMapUtility
{
    public partial class SymbolResourceWnd : UserControl
    {
        private SampleSymbolRun m_sampleRun;
        private SuperMap.Data.Workspace m_workspace;
        private System.Drawing.Drawing2D.GraphicsPath mousePath;

        private GeoStyle m_pointStyle;
        private GeoStyle m_lineStyle;
        private GeoStyle m_fillStyle;

        private Symbol m_symbol;

        public delegate void SymbolMarkerEventHandler(object sender, EventArgs e);
        public event SymbolMarkerEventHandler SymbolMarkerCtrl;

        public delegate void SymbolFillEventHandler(object sender, EventArgs e);
        public event SymbolFillEventHandler SymbolFillCtrl;

        public SymbolResourceWnd(Workspace workspace)
        {
            try
            {
                InitializeComponent();

                this.m_workspace = workspace;

                //实例化SampleRun
                m_sampleRun = new SampleSymbolRun(m_workspace);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// 在主窗体加载时，初始化SampleRun类型，来完成功能的展现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Anchor = AnchorStyles.Right;

                panelMarkerSetting.Enabled = false;
                panelLine.Enabled = false;
                panelFill.Enabled = false;


                //FlowLayoutPanel鼠标滚动事件注册
                flowLayoutPanelMarker.MouseWheel += new MouseEventHandler(flowLayoutPanelMarker_MouseWheel);
                flowLayoutPanelLine.MouseWheel += new MouseEventHandler(flowLayoutPanelLine_MouseWheel);
                flowLayoutPanelFill.MouseWheel += new MouseEventHandler(flowLayoutPanelFill_MouseWheel);


                //设置TreeView的数据
                treeViewLine.TopNode = treeViewLine.Nodes[0];
                treeViewFill.TopNode = treeViewFill.Nodes[0];
                m_sampleRun.SetTreeView(treeViewMarker, m_sampleRun.SymbolMarkerRootGroup);
                m_sampleRun.SetTreeView(treeViewLine, m_sampleRun.SymbolLineRootGroup);
                m_sampleRun.SetTreeView(treeViewFill, m_sampleRun.SymbolFillRootGroup);

                //设置符号列表的数据
                PaintSymbols(50, 50, m_sampleRun.Point, flowLayoutPanelMarker, m_sampleRun.SymbolMarkerRootGroup);
                PaintSymbols(75, 75, m_sampleRun.Line, flowLayoutPanelLine, m_sampleRun.SymbolLineRootGroup);
                PaintSymbols(75, 75, m_sampleRun.Region, flowLayoutPanelFill, m_sampleRun.SymbolFillRootGroup);
                //初始化预览的点线面符号风格
                m_pointStyle = m_sampleRun.MarkerGeoStyle;
                m_lineStyle = m_sampleRun.LineGeoStyle;
                m_fillStyle = m_sampleRun.FillGeoStyle;
                //ComboBox控件的初始化
                for (Int32 i = 0; i < 361; i++)
                {
                    comboBoxMarkerAngle.Items.Add(i);
                }

                for (Int32 i = 1; i < (pictureBoxMarker.Size.Width * pictureBoxMarker.Size.Height) / 40; i++)
                {
                    comboBoxMarkerSize.Items.Add(i);
                }

                comboBoxLineWith.Items.Add(0.5);
                for (Int32 i = 1; i < pictureBoxLine.Size.Height / 4; i++)
                {
                    comboBoxLineWith.Items.Add(i);
                }


                comboBoxFillGradientMode.Items.Add(FillGradientMode.None);
                comboBoxFillGradientMode.Items.Add(FillGradientMode.Linear);
                comboBoxFillGradientMode.Items.Add(FillGradientMode.Conical);
                comboBoxFillGradientMode.Items.Add(FillGradientMode.Square);
                comboBoxFillGradientMode.Items.Add(FillGradientMode.Radial);

                for (Int32 i = 0; i < 361; i++)
                {
                    comboBoxFillGradientAngle.Items.Add(i);
                }

                for (Int32 i = 0; i < 101; i++)
                {
                    comboBoxFillGradientOffsetRatioX.Items.Add(i);
                }

                for (Int32 i = 0; i < 101; i++)
                {
                    comboBoxFillGradientOffsetRatioY.Items.Add(i);
                }

                mousePath = new System.Drawing.Drawing2D.GraphicsPath();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        /// flowLayoutPanelLine的鼠标滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanelLine_MouseWheel(Object sender, MouseEventArgs e)
        {
            try
            {
                if (flowLayoutPanelLine.Focused)
                {
                    Int32 numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                    Int32 numberOfPixelsToMove = numberOfTextLinesToMove * flowLayoutPanelLine.Size.Height;
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
                    panelMarkerSetting.Enabled = true;

                    textBoxMarkerID.Text = m_symbol.ID.ToString();
                    textBoxMarkerName.Text = m_symbol.Name;
                    //绘制预览符号
                    GeoPoint point = new GeoPoint(pictureBoxMarker.Size.Width / 2, pictureBoxMarker.Size.Height / 2);
                    point.Style = m_pointStyle;
                    pictureBoxMarker.Tag = point;
                    DrawSymbol(m_symbol, point, pictureBoxMarker.Size.Width, pictureBoxMarker.Size.Height, pictureBoxMarker);

                    comboBoxMarkerAngle.SelectedIndex = Convert.ToInt32(point.Style.MarkerAngle);
                    buttonMarkerColor.BackColor = point.Style.LineColor;
                    comboBoxMarkerSize.SelectedIndex = Convert.ToInt32(((point.Style.MarkerSize.Width * point.Style.MarkerSize.Height) / 10));

                    if(SymbolMarkerCtrl != null)
                    {
                        sender = m_symbol.ID;
                        SymbolMarkerCtrl(sender, e);
                    }
                }

                if (pictureBox.Parent == flowLayoutPanelLine)
                {
                    flowLayoutPanelLine.Select();
                    panelLine.Enabled = true;

                    textBoxLineID.Text = m_symbol.ID.ToString();
                    textBoxLineName.Text = m_symbol.Name;
                    //绘制预览线型
                    Point2Ds point2Ds = new Point2Ds();
                    point2Ds.Add(new Point2D(5, pictureBoxLine.Size.Height / 2));
                    point2Ds.Add(new Point2D(pictureBoxLine.Size.Width - 5, pictureBoxLine.Size.Height / 2));
                    GeoLine line = new GeoLine(point2Ds);
                    line.Style = m_lineStyle;
                    pictureBoxLine.Tag = line;
                    DrawSymbol(m_symbol, line, pictureBoxLine.Size.Width, pictureBoxLine.Size.Height, pictureBoxLine);

                    buttonLineColor.BackColor = line.Style.LineColor;
                    if (line.Style.LineWidth == 0.5)
                    {
                        comboBoxLineWith.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxLineWith.SelectedItem = Convert.ToInt32(line.Style.LineWidth);
                    }
                }


                if (pictureBox.Parent == flowLayoutPanelFill)
                {
                    flowLayoutPanelFill.Select();

                    panelFill.Enabled = true;

                    textBoxFillID.Text = m_symbol.ID.ToString();
                    textBoxFillName.Text = m_symbol.Name;
                    //绘制预览填充符号
                    Point2Ds point2Ds = new Point2Ds();
                    point2Ds.Add(new Point2D(10, 20));
                    point2Ds.Add(new Point2D(10, pictureBoxFill.Size.Height - 20));
                    point2Ds.Add(new Point2D(pictureBoxFill.Size.Width - 10, pictureBoxFill.Size.Height - 20));
                    point2Ds.Add(new Point2D(pictureBoxFill.Size.Width - 10, 20));
                    GeoRegion region = new GeoRegion(point2Ds);
                    region.Style = m_fillStyle;
                    pictureBoxFill.Tag = region;
                    DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);

                    buttonFillForeColor.BackColor = region.Style.FillForeColor;
                    checkBoxFillBackOpaque.Checked = !region.Style.FillBackOpaque;
                    buttonFillBackColor.BackColor = checkBoxFillBackOpaque.Checked ? Color.FromKnownColor(KnownColor.Control) : m_fillStyle.FillBackColor;

                    comboBoxFillGradientMode.SelectedItem = region.Style.FillGradientMode;
                    comboBoxFillGradientAngle.SelectedIndex = Convert.ToInt32(region.Style.FillGradientAngle);

                    comboBoxFillGradientOffsetRatioX.SelectedIndex = region.Style.FillGradientOffsetRatioX;
                    comboBoxFillGradientOffsetRatioY.SelectedIndex = region.Style.FillGradientOffsetRatioY;

                    
                     if (SymbolFillCtrl != null)
                    {
                        sender = m_symbol.ID;
                        SymbolFillCtrl(sender, e);
                    }
                }
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
        /// 在窗体关闭时，需要释放相关的资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        //................符号面板控件的事件响应.....................//

        /// <summary>
        /// 符号树的节点点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewMarkerBrowse_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SymbolGroup group = e.Node.Tag as SymbolGroup;
            PaintSymbols(50, 50, m_sampleRun.Point, flowLayoutPanelMarker, group);
        }

        /// <summary>
        /// 符号颜色按钮的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMarkerColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    GeoPoint point = pictureBoxMarker.Tag as GeoPoint;
                    point.Style.LineColor = colorDialog1.Color;
                    buttonMarkerColor.BackColor = colorDialog1.Color;

                    DrawSymbol(m_symbol, point, pictureBoxMarker.Size.Width, pictureBoxMarker.Size.Height, pictureBoxMarker);
                    m_pointStyle.LineColor = point.Style.LineColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 符号角度改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMarkerAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GeoPoint point = pictureBoxMarker.Tag as GeoPoint;
                point.Style.MarkerAngle = comboBoxMarkerAngle.SelectedIndex;
                DrawSymbol(m_symbol, point, pictureBoxMarker.Size.Width, pictureBoxMarker.Size.Height, pictureBoxMarker);
                m_pointStyle.MarkerAngle = point.Style.MarkerAngle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 符号大小改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMarkerSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Double n = m_sampleRun.MarkerGeoStyle.MarkerSize.Width / m_sampleRun.MarkerGeoStyle.MarkerSize.Height;
                Double size = comboBoxMarkerSize.SelectedIndex + 1;
                Size2D size2D = new Size2D(Math.Sqrt(size * 10 / n) * n, Math.Sqrt(size * 10 / n));

                GeoPoint point = pictureBoxMarker.Tag as GeoPoint;
                point.Style.MarkerSize = size2D;
                DrawSymbol(m_symbol, point, pictureBoxMarker.Size.Width, pictureBoxMarker.Size.Height, pictureBoxMarker);
                m_pointStyle.MarkerSize = point.Style.MarkerSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //...................线型面板控件的事件响应........................//

        /// <summary>
        /// 线型树的节点点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewLine_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SymbolGroup group = e.Node.Tag as SymbolGroup;
            PaintSymbols(75, 75, m_sampleRun.Line, flowLayoutPanelLine, group);
        }
        /// <summary>
        /// 线型宽度改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLineWith_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GeoLine line = pictureBoxLine.Tag as GeoLine;
                if (comboBoxLineWith.SelectedIndex == 0)
                {
                    line.Style.LineWidth = 0.5;
                }
                else
                {
                    line.Style.LineWidth = comboBoxLineWith.SelectedIndex;
                }
                DrawSymbol(m_symbol, line, pictureBoxLine.Size.Width, pictureBoxLine.Size.Height, pictureBoxLine);
                m_lineStyle.LineWidth = line.Style.LineWidth;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 线型颜色改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog2.ShowDialog() == DialogResult.OK)
                {
                    GeoLine line = pictureBoxLine.Tag as GeoLine;
                    line.Style.LineColor = colorDialog2.Color;
                    buttonLineColor.BackColor = colorDialog2.Color;
                    DrawSymbol(m_symbol, line, pictureBoxLine.Size.Width, pictureBoxLine.Size.Height, pictureBoxLine);
                    m_lineStyle.LineColor = line.Style.LineColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //....................填充面板控件的事件响应.....................//

        /// <summary>
        /// 填充符号树的节点点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFill_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                SymbolGroup group = e.Node.Tag as SymbolGroup;
                PaintSymbols(75, 75, m_sampleRun.Region, flowLayoutPanelFill, m_sampleRun.SymbolFillRootGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 填充前景色按钮的事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFillForeColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog3.ShowDialog() == DialogResult.OK)
                {
                    GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                    region.Style.FillForeColor = colorDialog3.Color;
                    buttonFillForeColor.BackColor = colorDialog3.Color;
                    DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                    m_fillStyle.FillForeColor = region.Style.FillForeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 填充背景色按钮的事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFillBackColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog4.ShowDialog() == DialogResult.OK)
                {
                    GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                    region.Style.FillBackColor = colorDialog4.Color;
                    buttonFillBackColor.BackColor = colorDialog4.Color;
                    DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                    m_fillStyle.FillBackColor = region.Style.FillBackColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 填充背景色CheckBox的勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFillBackOpaque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                buttonFillBackColor.Enabled = !checkBoxFillBackOpaque.Checked;

                Color backColor = checkBoxFillBackOpaque.Checked ? Color.FromKnownColor(KnownColor.Control) : m_fillStyle.FillBackColor;
                buttonFillBackColor.BackColor = backColor;

                GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                region.Style.FillBackOpaque = !checkBoxFillBackOpaque.Checked;
                DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                m_fillStyle.FillBackOpaque = region.Style.FillBackOpaque;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 渐变模式改变的事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFillGradientMode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                String text = comboBoxFillGradientMode.Text;

                if (text == "None")
                {
                    region.Style.FillGradientMode = FillGradientMode.None;
                    comboBoxFillGradientAngle.Enabled = false;
                    comboBoxFillGradientOffsetRatioX.Enabled = false;
                    comboBoxFillGradientOffsetRatioY.Enabled = false;
                    checkBoxFillBackOpaque.Enabled = true;
                }
                if (text == "Linear")
                {
                    region.Style.FillGradientMode = FillGradientMode.Linear;
                    comboBoxFillGradientAngle.Enabled = true;
                    comboBoxFillGradientOffsetRatioX.Enabled = true;
                    comboBoxFillGradientOffsetRatioY.Enabled = false;
                    checkBoxFillBackOpaque.Enabled = false;
                }
                if (text == "Conical")
                {
                    region.Style.FillGradientMode = FillGradientMode.Conical;
                    comboBoxFillGradientAngle.Enabled = true;
                    comboBoxFillGradientOffsetRatioX.Enabled = true;
                    comboBoxFillGradientOffsetRatioY.Enabled = true;
                    checkBoxFillBackOpaque.Enabled = false;
                }
                if (text == "Radial")
                {
                    region.Style.FillGradientMode = FillGradientMode.Radial;
                    comboBoxFillGradientAngle.Enabled = true;
                    comboBoxFillGradientOffsetRatioX.Enabled = true;
                    comboBoxFillGradientOffsetRatioY.Enabled = true;
                    checkBoxFillBackOpaque.Enabled = false;
                }
                if (text == "Square")
                {
                    region.Style.FillGradientMode = FillGradientMode.Square;
                    comboBoxFillGradientAngle.Enabled = true;
                    comboBoxFillGradientOffsetRatioX.Enabled = true;
                    comboBoxFillGradientOffsetRatioY.Enabled = true;
                    checkBoxFillBackOpaque.Enabled = false;
                }
                DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                m_fillStyle.FillGradientMode = region.Style.FillGradientMode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 渐变角度改变的事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFillGradientAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                region.Style.FillGradientAngle = comboBoxFillGradientAngle.SelectedIndex;
                DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                m_fillStyle.FillGradientAngle = region.Style.FillGradientAngle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 水平偏移量改变的事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFillGradientOffsetRatioX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                region.Style.FillGradientOffsetRatioX = comboBoxFillGradientOffsetRatioX.SelectedIndex;
                DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                m_fillStyle.FillGradientOffsetRatioX = region.Style.FillGradientOffsetRatioX;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 垂直偏移量改变的事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFillGradientOffsetRatioY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GeoRegion region = pictureBoxFill.Tag as GeoRegion;
                region.Style.FillGradientOffsetRatioY = comboBoxFillGradientOffsetRatioY.SelectedIndex;
                DrawSymbol(m_symbol, region, pictureBoxFill.Size.Width - 20, pictureBoxFill.Size.Height - 40, pictureBoxFill);
                m_fillStyle.FillGradientOffsetRatioY = region.Style.FillGradientOffsetRatioY;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

