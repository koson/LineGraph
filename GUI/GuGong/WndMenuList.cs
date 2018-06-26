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
    public partial class WndMenuList : UserControl
    {
        public WndMenuList()
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

        public delegate void AddKmlCtrlEventHandler(object sender, EventArgs e);
        public event AddKmlCtrlEventHandler AddKmlCtrl;

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

        public delegate void MapCtrlEventHandle(object sender, EventArgs e);
        public event MapCtrlEventHandle MapCtrl;

        public delegate void ProjectSummaryCtrlEventHandle(object sender, EventArgs e);
        public event ProjectSummaryCtrlEventHandle ProjectSummaryCtrl;

        public delegate void DeviceStyleHandle(object sender, EventArgs e);
        public event DeviceStyleHandle DeviceStyleCtrl;

        public delegate void DeviceCompanyHandle(object sender, EventArgs e);
        public event DeviceCompanyHandle DeviceCompanyCtrl;

        private void MenuItem_项目信息_Click(object sender, EventArgs e)
        {
            //ProjectSummary ps = new ProjectSummary();
            //ps.Show();
        }

        private void MenuItem_维修记录_Click(object sender, EventArgs e)
        {
            //HistoryRepairFrm hpfrm = new HistoryRepairFrm();
            //hpfrm.Show();
        }

        private void MenuItem_视频素材_Click(object sender, EventArgs e)
        {
            ////string[] types = new string[] { "avi", "map4" };
            ////DocsFrm df = new DocsFrm(types);
            ////df.Show();
            //Form19 form19 = new Form19();
            //form19.TopMost = true;
            //form19.ShowDialog();
        }


        private void MenuItem_监测区域_Click(object sender, EventArgs e)
        {
        }

        private void MenuItem_视频监控_Click(object sender, EventArgs e)
        {
            if (CameraViewCtrl != null)
            {
                CameraViewCtrl(sender, e);
            }
        }

        private void MenuItem_DataCapture_Click(object sender, EventArgs e)
        {
            if (DataCaptureCtrl != null)
            {
                DataCaptureCtrl(sender, e);
            } 
        }

        private void MenuItem_串口数据_Click(object sender, EventArgs e)
        {
            if (COMDataCaptureCtrl != null)
            {
                COMDataCaptureCtrl(sender, e);
            }
        }
        

        private void MenuItem_静力水准监测_Click(object sender, EventArgs e)
        {
            //Process process = new Process();
            ////  process.StartInfo.FileName = "E:/Program Files (x86)/LT/Logger V4/BGKLogger.exe"; //打开基康仪器传感器参数配置程序
            //process.StartInfo.FileName = "E:/Program Files (x86)/LT/Logger V4/AMT-Modbus V1.0.exe"; //打开基康仪器参数配置程序
            //process.Start();
        }

        private void MenuItem_动态监测_Click(object sender, EventArgs e)
        {
            //QingJiaoYi QingJiaoYi = new QingJiaoYi();
            //QingJiaoYi.TopMost = true;
            //QingJiaoYi.ShowDialog();
        }

        //private void 故宫项目动态监测曲线动态图ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //RealChart RealChart = new RealChart();
        //    //RealChart.TopMost = true;
        //    //RealChart.ShowDialog();
        //}

        private void MenuItem_AddKml_Click(object sender, EventArgs e)
        {
            if (AddKmlCtrl != null)
            {
                AddKmlCtrl(sender, e);
            }
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

        private void MenuItem_DataAnalyze_Click(object sender, EventArgs e)
        {
            if (DataAnalyzeCtrl != null)
            {
                DataAnalyzeCtrl(sender, e);
            }
        }

        private void MenuItem_监测设备信息库_Click(object sender, EventArgs e)
        {
            if (SensorInfoCtrl != null)
            {
                SensorInfoCtrl(sender, e);
            }
        }

        private void MenuItem_监测设备布设_Click(object sender, EventArgs e)
        {
            if (AddModelCtrl != null)
            {
                AddModelCtrl(sender, e);
            }
        }

        private void MenuItem_实时监测数据管理_Click(object sender, EventArgs e)
        {
            if (SensorCtrl != null)
            {
                SensorCtrl(sender, e);
            }
        }

        private void MenuItem_监测设备状态_Click(object sender, EventArgs e)
        {
            if (MapCtrl != null)
            {
                MapCtrl(sender, e);
            }
        }

        private void MenuItem_基本概况_Click(object sender, EventArgs e)
        {
            if (ProjectSummaryCtrl != null)
            {
                ProjectSummaryCtrl(sender, e);
            }
        }

        private void MenuItem_设备厂家_Click(object sender, EventArgs e)
        {
            if (DeviceCompanyCtrl != null)
            {
                DeviceCompanyCtrl(sender, e);
            }
        }

        private void MenuItem_设备类型_Click(object sender, EventArgs e)
        {
            if (DeviceStyleCtrl != null)
            {
                DeviceStyleCtrl(sender, e);
            }
        }
    }
}
