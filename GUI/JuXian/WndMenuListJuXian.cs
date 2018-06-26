using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineGraph.GUI
{
    public partial class WndMenuListJuXian : UserControl
    {
        public WndMenuListJuXian()
        {
            InitializeComponent();
        }

        public delegate void WorkSpaceCtrlEventHandler(object sender, EventArgs e);
        public event WorkSpaceCtrlEventHandler WorkSpaceCtrl;

        public delegate void LengthCtrlEventHandler(object sender, EventArgs e);
        public event LengthCtrlEventHandler LengthCtrl;

        public delegate void AreaCtrlEventHandler(object sender, EventArgs e);
        public event AreaCtrlEventHandler AreaCtrl;

        public delegate void HeightCtrlEventHandler(object sender, EventArgs e);
        public event HeightCtrlEventHandler HeightCtrl;

        public delegate void ClearResultCtrlEventHandler(object sender, EventArgs e);
        public event ClearResultCtrlEventHandler ClearResultCtrl;

        public delegate void layerStyleCtrlEventHandler(object sender, EventArgs e);
        public event layerStyleCtrlEventHandler LayerStyleCtrl;

        public delegate void PropertyCtrlEventHandler(object sender, EventArgs e);
        public event PropertyCtrlEventHandler PropertyCtrl;

        public delegate void SQLCtrlEventHandler(object sender, EventArgs e);
        public event SQLCtrlEventHandler SQLCtrl;

        public delegate void SensorCtrlEventHandler(object sender, EventArgs e);
        public event SensorCtrlEventHandler SensorCtrl;

        public delegate void WorkerCtrlEventHandler(object sender, EventArgs e);
        public event WorkerCtrlEventHandler WorkerCtrl;

        public delegate void VideoerCtrlEventHandler(object sender, EventArgs e);
        public event VideoerCtrlEventHandler VideoCtrl;

        public delegate void DesignerCtrlEventHandler(object sender, EventArgs e);
        public event DesignerCtrlEventHandler DesignerCtrl;

        public delegate void SensorInfoCtrlEventHandler(object sender, EventArgs e);
        public event SensorInfoCtrlEventHandler SensorInfoCtrl;

        public delegate void AddSceneCtrlEventHandler(object sender, EventArgs e);
        public event AddSceneCtrlEventHandler AddSceneCtrl;

        public delegate void SaveKmlCtrlEventHandler(object sender, EventArgs e);
        public event SaveKmlCtrlEventHandler SaveKmlCtrl;

        public delegate void RemoveLayerCtrlEventHandler(object sender, EventArgs e);
        public event RemoveLayerCtrlEventHandler RemoveLayer;

        public delegate void AddModelCtrlEventHandler(object sender, EventArgs e);
        public event AddModelCtrlEventHandler AddModelCtrl;

        public delegate void RemoveModelCtrlEventHandler(object sender, EventArgs e);
        public event RemoveModelCtrlEventHandler RemoveModelCtrl;

        public delegate void FlyToObjectCtrlEventHandler(object sender, EventArgs e);
        public event FlyToObjectCtrlEventHandler FlyToObjectCtrl;

        public delegate void Feature3DVisibleCtrlEventHandler(object sender, EventArgs e);
        public event Feature3DVisibleCtrlEventHandler Feature3DVisibleCtrl;

        public delegate void ModelSelectableCtrlEventHandler(object sender, EventArgs e);
        public event ModelSelectableCtrlEventHandler ModelSelectableCtrl;

        public delegate void ModelEditableCtrlEventHandler(object sender, EventArgs e);
        public event ModelEditableCtrlEventHandler ModelEditableCtrl;

        public delegate void DataCaptureCtrlEventHandle(object sender, EventArgs e);
        public event DataCaptureCtrlEventHandle DataCaptureCtrl;

        public delegate void UserCtrlEventHandle(object sender, EventArgs e);
        public event UserCtrlEventHandle UserCtrl;

        public delegate void GoodsCtrlEventHandle(object sender, EventArgs e);
        public event GoodsCtrlEventHandle GoodsCtrl;

        public delegate void FinanceCtrlEventHandle(object sender, EventArgs e);
        public event FinanceCtrlEventHandle FinanceCtrl;

        public delegate void ThreeDdesignerCtrlEventHandle(object sender, EventArgs e);
        public event ThreeDdesignerCtrlEventHandle ThreeDdesignerCtrl;

        public delegate void SymbolResourceCtrlEventHandle(object sender, EventArgs e);
        public event SymbolResourceCtrlEventHandle SymbolResourceCtrl;

        public delegate void QingXieSheYingCtrlEventHandle(object sender, EventArgs e);
        public event QingXieSheYingCtrlEventHandle QingXieSheYingCtrl;

        public delegate void COMDataCaptureCtrlEventHandle(object sender, EventArgs e);
        public event COMDataCaptureCtrlEventHandle COMDataCaptureCtrl;

        public delegate void DataAnalyzeCtrlEventHandle(object sender, EventArgs e);
        public event DataAnalyzeCtrlEventHandle DataAnalyzeCtrl;

        public delegate void CameraViewCtrlEventHandle(object sender, EventArgs e);
        public event CameraViewCtrlEventHandle CameraViewCtrl;

        public delegate void TreeStyleCtrlEventHandle(object sender, EventArgs e);
        public event TreeStyleCtrlEventHandle TreeStyleCtrl;

        public delegate void TreeProtectCtrlEventHandle(object sender, EventArgs e);
        public event TreeProtectCtrlEventHandle TreeProtectCtrl;

        public delegate void TreeManageCtrlEventHandle(object sender, EventArgs e);
        public event TreeManageCtrlEventHandle TreeManageCtrl;

        public delegate void GPSLocationCtrlEventHandle(object sender, EventArgs e);
        public event GPSLocationCtrlEventHandle GPSLocationCtrl;

        public delegate void ProjectSummaryCtrlEventHandle(object sender, EventArgs e);
        public event ProjectSummaryCtrlEventHandle ProjectSummaryCtrl;

        public delegate void MapCtrlEventHandle(object sender, EventArgs e);
        public event MapCtrlEventHandle MapCtrl;

        public delegate void FullAirCtrlEventHandle(object sender, EventArgs e);
        public event FullAirCtrlEventHandle FullAirCtrl;

        public delegate void BroadcastCtrlEventHandle(object sender, EventArgs e);
        public event BroadcastCtrlEventHandle BroadcastCtrl;

        public delegate void TreeSceneCtrlEventHandle(object sender, EventArgs e);
        public event TreeSceneCtrlEventHandle TreeSceneCtrl;

        private void MenuItem_DataCapture_Click(object sender, EventArgs e)
        {
            if (DataCaptureCtrl != null)
            {
                DataCaptureCtrl(sender, e);
            } 
        }


        private void MenuItem_SensorDevice_Click(object sender, EventArgs e)
        {
            if (SensorInfoCtrl != null)
            {
                SensorInfoCtrl(sender, e);
            }
        }

        private void MenuItem_AddKml_Click(object sender, EventArgs e)
        {
         
        }
        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (SaveKmlCtrl != null)
            {
                SaveKmlCtrl(sender, e);
            }
        }
        private void MenuItem_RemoveLayer_Click(object sender, EventArgs e)
        {
            if (RemoveLayer != null)
            {
                RemoveLayer(sender, e);
            }
        }
        private void MenuItem_AddModel_Click(object sender, EventArgs e)
        {
            if (AddModelCtrl != null)
            {
                AddModelCtrl(sender, e);
            }
        }
        private void MenuItem_RemoveObject_Click(object sender, EventArgs e)
        {
            if (RemoveModelCtrl != null)
            {
                RemoveModelCtrl(sender, e);
            }
        }
        private void MenuItem_FlyToObject_Click(object sender, EventArgs e)
        {
            if (FlyToObjectCtrl != null)
            {
                FlyToObjectCtrl(sender, e);
            }
        }
        private void MenuItem_Feature3DVisible_Click(object sender, EventArgs e)
        {
            if (Feature3DVisibleCtrl != null)
            {
                Feature3DVisibleCtrl(sender, e);
            }
        }
        private void MenuItem_Selectable_Click(object sender, EventArgs e)
        {
            if (ModelSelectableCtrl != null)
            {
                ModelSelectableCtrl(sender, e);
            }
        }
        private void MenuItem_Editable_Click(object sender, EventArgs e)
        {
            if (ModelEditableCtrl != null)
            {
                ModelEditableCtrl(sender, e);
            }
        }

        private void MenuItem_WorkSpaceCtrl_Click(object sender, EventArgs e)
        {
            if (WorkSpaceCtrl != null)
            {
                WorkSpaceCtrl(sender, e);
            }
        }

        private void MenuItem_Length_Click(object sender, EventArgs e)
        {
            if (LengthCtrl != null)
            {
                LengthCtrl(sender, e);
            }
        }

        private void MenuItem_Area_Click(object sender, EventArgs e)
        {
            if (AreaCtrl != null)
            {
                AreaCtrl(sender, e);
            }
        }

        private void MenuItem_Height_Click(object sender, EventArgs e)
        {
            if (HeightCtrl != null)
            {
                HeightCtrl(sender, e);
            }
        }

        private void MenuItem_ClearResult_Click(object sender, EventArgs e)
        {
            if (ClearResultCtrl != null)
            {
                ClearResultCtrl(sender, e);
            }
        }

        private void MenuItem_LayerStyle_Click(object sender, EventArgs e)
        {
            if (LayerStyleCtrl != null)
            {
                LayerStyleCtrl(sender, e);
            }
        }

        private void MenuItem_Property_Click(object sender, EventArgs e)
        {
            if (PropertyCtrl != null)
            {
                PropertyCtrl(sender, e);
            }
        }

        private void MenuItem_SQL_Click(object sender, EventArgs e)
        {
            if (SQLCtrl != null)
            {
                SQLCtrl(sender, e);
            }
        }

        //private void MenuItem_Buffer_Click(object sender, EventArgs e)
        //{
        //    if (LayerStyleCtrl != null)
        //    {
        //        LayerStyleCtrl(sender, e);
        //    }
        //}
        private void MenuItem_Sensor_Click(object sender, EventArgs e)
        {
            if (SensorCtrl != null)
            {
                SensorCtrl(sender, e);
            }
        }
        private void MenuItem_Worker_Click(object sender, EventArgs e)
        {
            if (WorkerCtrl != null)
            {
                WorkerCtrl(sender, e);
            }
        }
        private void MenuItem_Videoer_Click(object sender, EventArgs e)
        {
            if (VideoCtrl != null)
            {
                VideoCtrl(sender, e);
            }
        }

        private void MenuItem_Designer_Click(object sender, EventArgs e)
        {
            if (DesignerCtrl != null)
            {
                DesignerCtrl(sender, e);
            }
        }

        private void MenuItem_User_Click(object sender, EventArgs e)
        {
            if (UserCtrl != null)
            {
                UserCtrl(sender, e);
            }
        }

        private void MenuItem_Goods_Click(object sender, EventArgs e)
        {
            if (GoodsCtrl != null)
            {
                GoodsCtrl(sender, e);
            }
        }

        private void MenuItem_Finance_Click(object sender, EventArgs e)
        {
            if (FinanceCtrl != null)
            {
                FinanceCtrl(sender, e);
            }
        }

        private void MenuItem_3Ddesigner_Click(object sender, EventArgs e)
        {
            if (ThreeDdesignerCtrl != null)
            {
                ThreeDdesignerCtrl(sender, e);
            } 
        }

        private void MenuItem_SymbolResource_Click(object sender, EventArgs e)
        {
            if (SymbolResourceCtrl != null)
            {
                SymbolResourceCtrl(sender, e);
            }
        }

        private void MenuItem_倾斜摄影_Click(object sender, EventArgs e)
        {
            if (QingXieSheYingCtrl != null)
            {
                QingXieSheYingCtrl(sender, e);
            }
        }

  

        private void MenuItem_公园视频监控_Click(object sender, EventArgs e)
        {
            if (CameraViewCtrl != null)
            {
                CameraViewCtrl(sender, e);
            }
        }

        private void MenuItem_园林移动巡检_Click(object sender, EventArgs e)
        {
            if (GPSLocationCtrl != null)
            {
                GPSLocationCtrl(sender, e);
            }
        }

        private void MenuItem_树木管理_Click(object sender, EventArgs e)
        {
          
        }

        private void MenuItem_GPS定位_Click(object sender, EventArgs e)
        {
            if (GPSLocationCtrl != null)
            {
                GPSLocationCtrl(sender, e);
            }  
        }


        private void MenuItem_三维模型_Click(object sender, EventArgs e)
        {
            if (AddSceneCtrl != null)
            {
                AddSceneCtrl(sender, e);
            }
        }

        private void MenuItem_空中全景_Click(object sender, EventArgs e)
        {
            if (FullAirCtrl != null)
            {
                FullAirCtrl(sender, e);
            }
        }

        private void 林木选测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThreeDdesignerCtrl != null)
            {
                int index = 0;
                sender = index;
                ThreeDdesignerCtrl(sender, e);
            }
        }

        private void 土地耕种模拟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThreeDdesignerCtrl != null)
            {
                int index = 3;
                sender = index;
                ThreeDdesignerCtrl(sender, e);
            }
        }

        private void MenuItem_项目信息_Click(object sender, EventArgs e)
        {
            if (ProjectSummaryCtrl != null)
            {
                ProjectSummaryCtrl(sender, e);
            }
        }

        private void MenuItem_园林养护_Click(object sender, EventArgs e)
        {
            if (TreeProtectCtrl != null)
            {
                TreeProtectCtrl(sender, e);
            }
        }

        private void MenuItem_监测数据分析_Click(object sender, EventArgs e)
        {
            if (DataAnalyzeCtrl != null)
            {
                DataAnalyzeCtrl(sender, e);
            }
        }

        private void MenuItem_监测数据管理_Click(object sender, EventArgs e)
        {
            if (SensorCtrl != null)
            {
                SensorCtrl(sender, e);
            }
        }

        private void MenuItem_监测数据采集_Click(object sender, EventArgs e)
        {
            if (COMDataCaptureCtrl != null)
            {
                COMDataCaptureCtrl(sender, e);
            }
        }

        private void 二维管理场景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void MenuItem_行道树木监控_Click(object sender, EventArgs e)
        {
          
        }

        private void 树木移植监测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TreeManageCtrl != null)
            {
                TreeManageCtrl(sender, e);
            }
        }

        private void MenuItem_航空影像_Click(object sender, EventArgs e)
        {
            if (MapCtrl != null)
            {
                int index = 0;
                sender = index;
                MapCtrl(sender, e);
            }
        }

        private void 卫星影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapCtrl != null)
            {
                int index = 2;
                sender = index;
                MapCtrl(sender, e);
            }
        }

        private void 数字线划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapCtrl != null)
            {
                int index = 1;
                sender = index;
                MapCtrl(sender, e);
            }
        }

        private void 园林应急指挥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BroadcastCtrl != null)
            {
                BroadcastCtrl(sender, e);
            }
        }

        private void 实景模拟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TreeSceneCtrl != null)
            {
                TreeSceneCtrl(sender, e);
            }
        }

        public event EventHandler UserManagement;

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(UserManagement != null)
            {
                UserManagement(sender, e);
            }
        }

        private void WndMenuListJuXian_Load(object sender, EventArgs e)
        {

        }

        private void 名树名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TreeStyleCtrl != null)
            {
                TreeStyleCtrl(sender, e);
            } 
        }
    }
}
