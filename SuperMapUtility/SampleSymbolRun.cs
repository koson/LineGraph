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
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Realspace;

namespace LineGraph.SuperMapUtility
{
    public class SampleSymbolRun
    {
        private Workspace m_workspace;

        private GeoPoint m_point;
        public GeoPoint Point
        {
            get { return m_point; }
        }
        private GeoLine m_line;
        public GeoLine Line
        {
            get { return m_line; }
        }
        private GeoRegion m_region;
        public GeoRegion Region
        {
            get { return m_region; }
        }

        private GeoStyle m_markerGeoStyle;
        public GeoStyle MarkerGeoStyle
        {
            get { return m_markerGeoStyle; }
            set { m_markerGeoStyle = value; }
        }

        private GeoStyle m_lineGeoStyle;
        public GeoStyle LineGeoStyle
        {
            get { return m_lineGeoStyle; }
            set { m_lineGeoStyle = value; }
        }

        private GeoStyle m_fillGeoStyle;
        public GeoStyle FillGeoStyle
        {
            get { return m_fillGeoStyle; }
            set { m_fillGeoStyle = value; }
        }

        private SymbolGroup m_symbolMarkerRootGroup;
        public SymbolGroup SymbolMarkerRootGroup
        {
            get { return m_symbolMarkerRootGroup; }

        }

        private SymbolGroup m_symbolLineRootGroup;
        public SymbolGroup SymbolLineRootGroup
        {
            get { return m_symbolLineRootGroup; }
        }

        private SymbolGroup m_symbolFillRootGroup;
        public SymbolGroup SymbolFillRootGroup
        {
            get { return m_symbolFillRootGroup; }
        }

        private SymbolGroup m_symbolTreeMarkerGroup;
        public SymbolGroup SymbolTreeMarkerGroup
        {
            get { return m_symbolTreeMarkerGroup; }
        }


        /// <summary>
        /// 根据workspace构造SampleRun对象
        /// </summary>
        public SampleSymbolRun(Workspace workspace)
        {
            try
            {
                m_workspace = workspace;

                Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 打开需要的工作空间文件及地图
        /// </summary>
        private void Initialize()
        {
            try
            {
                //初始化点线面
                m_point = new GeoPoint(25, 25);

                Point2Ds point2DsLine = new Point2Ds();
                point2DsLine.Add(new Point2D(5, 35));
                point2DsLine.Add(new Point2D(65, 35));
                m_line = new GeoLine(point2DsLine);

                Point2Ds point2DsRegion = new Point2Ds();
                point2DsRegion.Add(new Point2D(5, 5));
                point2DsRegion.Add(new Point2D(5, 69));
                point2DsRegion.Add(new Point2D(69, 69));
                point2DsRegion.Add(new Point2D(69, 5));
                m_region = new GeoRegion(point2DsRegion);
                //初始化点线面符号的风格
                m_markerGeoStyle = new GeoStyle();
                m_markerGeoStyle.LineColor = Color.Blue;
                m_markerGeoStyle.MarkerSize = new Size2D(12, 12);
                m_point.Style = m_markerGeoStyle;

                m_lineGeoStyle = new GeoStyle();
                m_lineGeoStyle.LineColor = Color.Blue;
                m_lineGeoStyle.LineWidth = 0.5;
                m_line.Style = m_lineGeoStyle;

                m_fillGeoStyle = new GeoStyle();
                m_fillGeoStyle.FillForeColor = Color.Blue;
                m_fillGeoStyle.FillBackOpaque = false;
                m_region.Style = m_fillGeoStyle;

                // 得到点线面的RootGroup
                Resources resources = m_workspace.Resources;
                SymbolLibrary symbolMarkerLibrary = resources.MarkerLibrary;
                m_symbolMarkerRootGroup = symbolMarkerLibrary.RootGroup;

                SetTreeGroup(m_symbolMarkerRootGroup);

                SymbolLibrary symbolLineLibrary = resources.LineLibrary;
                m_symbolLineRootGroup = symbolLineLibrary.RootGroup;

                SymbolLibrary symbolFillLibrary = resources.FillLibrary;
                m_symbolFillRootGroup = symbolFillLibrary.RootGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置TreeView的数据
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="rootGroup"></param>
        public void SetTreeView(TreeView treeView, SymbolGroup rootGroup)
        {
            try
            {
                TreeNode topNode = treeView.TopNode;
                topNode.Text = "根组";
                topNode.Tag = rootGroup;
                SetTreeNode(topNode, rootGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置TreeNode的数据
        /// </summary>
        /// <param name="node"></param>
        /// <param name="symbolGroup"></param>
        private void SetTreeNode(TreeNode node, SymbolGroup symbolGroup)
        {
            try
            {
                SymbolGroups groups = symbolGroup.ChildGroups;
                for (int i = 0; i < groups.Count; i++)
                {
                    SymbolGroup group = groups[i];
                    node.Nodes.Add(group.Name);
                    node.Nodes[i].Tag = group;
                    if (group != null)
                    {
                        SetTreeNode(node.Nodes[i], group);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetTreeGroup(SymbolGroup symbolGroup)
        {
            try
            {
                SymbolGroups groups = symbolGroup.ChildGroups;
                for (int i = 0; i < groups.Count; i++)
                {
                    SymbolGroup group = groups[i];
                    if(group.Name == "树木")
                    {
                        m_symbolTreeMarkerGroup = group;
                    }
                    //string str = group.Name;
                    if (group != null)
                    {
                        SetTreeGroup(group);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}


