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
using SuperMap.UI;
using SuperMap.Mapping;

namespace LineGraph.SuperMapUtility
{
    public partial class MapControlWnd : UserControl
    {
        private Workspace m_workspace;

        private Point2Ds pts = null;
        private GeoLine trackLine;

        int nPos = 0;
        private GeoStyle pStyle;
        private Size2D size;

        public delegate void WndDataViewerEventHandler(object sender, EventArgs e);
        public event WndDataViewerEventHandler WndDataViewer;

        public delegate void CameraDataAdjustEventHandler(object sender);
        public event CameraDataAdjustEventHandler CameraDataAdjustHandler;

        public MapControlWnd(Workspace workspace, MapControl mapcontrol)
        {
            m_workspace = workspace;
            m_MapControl = mapcontrol;

            InitializeComponent();

            // 调整mapControl的状态
            m_MapControl.Action = SuperMap.UI.Action.Pan;
          
            m_MapControl.MouseDown += new MouseEventHandler(map_MouseDown);
            m_MapControl.GeometrySelected += new SuperMap.UI.GeometrySelectedEventHandler(m_mapControl_GeometrySelected);
            //m_MapControl.Paint += new PaintEventHandler(m_mapControl_Paint);
            //m_MapControl.Click += new EventHandler(map_Click);

            pStyle = new GeoStyle();
            pStyle.LineColor = System.Drawing.Color.Red;
            pStyle.LineWidth = 2;

            //设置跟踪层图标大小
            size = new Size2D();
            size.Height = 10;
            size.Width = 10;
        }

        //鼠标触发事件用来控制 鼠标左键表示移动，鼠标右键表示选择，来控制CAD二维故宫图
        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    if (m_MapControl.Map.FindSelection(true).Length == 0)
                    {
                        m_MapControl.Action = SuperMap.UI.Action.Pan;//移动
                    }
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    m_MapControl.Action = SuperMap.UI.Action.Select;//选择
                    //  m_MapControl.Action = SuperMap.UI.Action.SelectCircle;
                    break;
                default:
                    break;
            }
        }

        // 对象选择事件
        private void m_mapControl_GeometrySelected(object sender, SuperMap.UI.GeometrySelectedEventArgs e)
        {
            try
            {
                Recordset recordset = GetSelectedRecordset(false);
                GeoPoint gp = recordset.GetGeometry() as GeoPoint;
                sender = gp;
                if (CameraDataAdjustHandler != null)
                {
                    CameraDataAdjustHandler(sender);
                }

                if (WndDataViewer != null)
                {
                    WndDataViewer(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 获取选中的记录集
        /// </summary>
        public Recordset GetSelectedRecordset(Boolean isAllRecord)
        {
            Recordset recordset = null;

            try
            {
                if (isAllRecord)
                {
                    //recordset = m_dataset.GetRecordset(false, CursorType.Static);
                }
                else
                {
                    Selection[] selection = m_MapControl.Map.FindSelection(true);
                    //判断选择集是否为空
                    if (selection != null && selection.Length != 0)
                    {
                        recordset = selection[0].ToRecordset();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return recordset;

        }

        /// 没有选择对象的时候表格清空
        private void m_mapControl_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (m_MapControl.Map.Layers[0].Selection.Count < 1)
                {
                    //dataGridView.Columns.Clear();
                    //dataGridView.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void map_Click(object sender, EventArgs e)
        {
        }

        private void ImportExeclData(DataTable table)
        {
            pts = new Point2Ds();
            Point2D pnt = new Point2D();
            for (int p = 0; p < table.Rows.Count; p++)
            {
                pnt.X = Convert.ToDouble(table.Rows[p][0].ToString());
                pnt.Y = Convert.ToDouble(table.Rows[p][1].ToString());
                pts.Add(pnt);
            }
            trackLine = new GeoLine();
            trackLine.AddPart(pts);
            trackLine.Style = pStyle;

            //添加轨迹路线
            m_MapControl.Map.TrackingLayer.Add(trackLine, "GPSTrack");
            m_MapControl.Map.EnsureVisible(trackLine);
            m_MapControl.Map.Zoom(0.7);
            m_MapControl.Map.Refresh();
        }

        void t_Tick(object sender, EventArgs e)
        {
            GeoPoint trackP = new GeoPoint();
            if (bplay == true && nPos < pts.Count)
            {
                trackP.X = pts[nPos].X;
                trackP.Y = pts[nPos].Y;

                //等于0说明临时图层上还没有添加过这个对象
                if (nPos > 0)
                {
                    m_MapControl.Map.TrackingLayer.Remove(1);
                }
                if (nPos + 1 < pts.Count && pts[nPos].X < pts[nPos + 1].X)
                {
                    //车头朝右的车
                    pStyle.MarkerSymbolID = 54424;
                }
                else
                {
                    //车头朝左的车
                    pStyle.MarkerSymbolID = 54423;
                }
                pStyle.MarkerSize = size;
                trackP.Style = pStyle;
                m_MapControl.Map.TrackingLayer.Add(trackP, "GPSPoint");
                nPos++;
            }
            else
            {
                nPos = 0;
                m_MapControl.Map.TrackingLayer.Remove(1);
            }
            m_MapControl.Map.RefreshTrackingLayer();
        }

        public void t_Run()
        {
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(t_Tick);
                timer.Interval = 200;
            }

            bplay = true;
            timer.Enabled = true;
        }

        public void t_Stop()
        {
            //标记设置成停止
            timer.Enabled = false;
            bplay = false;
        }
    }
}
