using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LineGraph.SuperMapUtility;
using SuperMap.Data;
using SuperMap.Realspace;
using SuperMap.UI;
using SuperMap.Mapping;
using LineGraph.Data;
//using LineGraph.Designer;
using System.Diagnostics;
using System.Management;
using System.IO;


namespace LineGraph
{
    public partial class MainFormG: Form
    {
        //private GUI.SensorWnd m_SensorWnd = null;
        private LineGraph.Data.ExcelData m_ExcelData = null;

        private LineGraph.SQLUtility.DeviceInfoWnd m_DeviceInfoWnd = null;
        private LineGraph.SQLUtility.DeviceStyleWnd m_DeviceStyleWnd = null;
        private LineGraph.SQLUtility.DeviceCompanyWnd m_DeviceCompanyWnd = null;
        
        private LineGraph.SQLUtility.User_Management m_UserManagement = null;
        private LineGraph.SQLUtility.Goods_Management m_GoodManagement = null;
        //private LineGraph.SQLUtility.Finance_Management m_FinanceManagement = null;
        private LineGraph.SQLUtility.CameraViewWnd m_CameraViewWnd = null;

        //private LineGraph.SuperMapUtility.SymbolDesignerWnd m_ThreeDesignerWnd = null;

        private bool m_bMapShow = false;
        private bool m_bSensorShow = false;

        public MainFormG()
        {
            InitializeComponent();

            WndMenuList.WorkSpaceCtrl += new GUI.WndMenuList.WorkSpaceCtrlEventHandler(WorkSpace_Ctrl);
            WndMenuList.LengthCtrl += new GUI.WndMenuList.LengthCtrlEventHandler(Length_Ctrl);
            WndMenuList.AreaCtrl += new GUI.WndMenuList.AreaCtrlEventHandler(Area_Ctrl);
            WndMenuList.HeightCtrl += new GUI.WndMenuList.HeightCtrlEventHandler(Height_Ctrl);
            WndMenuList.ClearResultCtrl += new GUI.WndMenuList.ClearResultCtrlEventHandler(ClearResult_Ctrl);
            WndMenuList.SensorInfoCtrl += new GUI.WndMenuList.SensorInfoCtrlEventHandler(SensorInfo_Ctrl);
            WndMenuList.AddModelCtrl += new GUI.WndMenuList.AddModelCtrlEventHandler(AddModelImage_Ctrl);
            WndMenuList.DataCaptureCtrl += new GUI.WndMenuList.DataCaptureCtrlEventHandle(DataCapture_Ctrl);
            WndMenuList.LayerStyleCtrl += new GUI.WndMenuList.layerStyleCtrlEventHandler(LayerStyle_Ctrl);
            WndMenuList.SQLCtrl += new GUI.WndMenuList.SQLCtrlEventHandler(SQL_Ctrl);
            WndMenuList.PropertyCtrl += new GUI.WndMenuList.PropertyCtrlEventHandler(Property_Ctrl);
            WndMenuList.SensorCtrl += new GUI.WndMenuList.SensorCtrlEventHandler(Sensor_Ctrl);
            WndMenuList.WorkerCtrl += new GUI.WndMenuList.WorkerCtrlEventHandler(Worker_Ctrl);
            WndMenuList.AddKmlCtrl += new GUI.WndMenuList.AddKmlCtrlEventHandler(AddKml_Ctrl) ;
            WndMenuList.SaveKmlCtrl += new GUI.WndMenuList.SaveKmlCtrlEventHandler(SaveKml_Ctrl) ;
            WndMenuList.RemoveLayer += new GUI.WndMenuList.RemoveLayerCtrlEventHandler(Remove_Layer) ;
            WndMenuList.RemoveModelCtrl += new GUI.WndMenuList.RemoveModelCtrlEventHandler(RemoveModel_Ctrl) ;
            WndMenuList.FlyToObjectCtrl += new GUI.WndMenuList.FlyToObjectCtrlEventHandler(FlyToObject_Ctrl);
            WndMenuList.Feature3DVisibleCtrl += new GUI.WndMenuList.Feature3DVisibleCtrlEventHandler(Feature3DVisible_Ctrl);
            WndMenuList.ModelSelectableCtrl += new GUI.WndMenuList.ModelSelectableCtrlEventHandler(ModelSelectable_Ctrl);
            WndMenuList.ModelEditableCtrl += new GUI.WndMenuList.ModelEditableCtrlEventHandler(ModelEditable_Ctrl);
            WndMenuList.UserCtrl += new GUI.WndMenuList.UserCtrlEventHandle(User_Ctrl);
            WndMenuList.GoodsCtrl += new GUI.WndMenuList.GoodsCtrlEventHandle(Goods_Ctrl);
            WndMenuList.FinanceCtrl += new GUI.WndMenuList.FinanceCtrlEventHandle(Finance_Ctrl);
            WndMenuList.ThreeDdesignerCtrl += new GUI.WndMenuList.ThreeDdesignerCtrlEventHandle(ThreeDesigner_Ctrl);
            WndMenuList.SymbolResourceCtrl += new GUI.WndMenuList.SymbolResourceCtrlEventHandle(SymbolResource_Ctrl);
            WndMenuList.COMDataCaptureCtrl += new GUI.WndMenuList.COMDataCaptureCtrlEventHandle(COMDataCapture_Ctrl);
            WndMenuList.DataAnalyzeCtrl += new GUI.WndMenuList.DataAnalyzeCtrlEventHandle(DataAnalyze_Ctrl);
            WndMenuList.CameraViewCtrl += new GUI.WndMenuList.CameraViewCtrlEventHandle(CameraView_Ctrl);
            //WndMenuList.AddSceneCtrl += new GUI.WndMenuList.AddSceneCtrlEventHandler(AddScene_Ctrl);
            WndMenuList.MapCtrl += new GUI.WndMenuList.MapCtrlEventHandle(Map_Ctrl);
            WndMenuList.ProjectSummaryCtrl += new GUI.WndMenuList.ProjectSummaryCtrlEventHandle(ProjectSummary_Ctrl);
            WndMenuList.DeviceStyleCtrl += new GUI.WndMenuList.DeviceStyleHandle(DeviceStyle_Ctrl);
            WndMenuList.DeviceCompanyCtrl += new GUI.WndMenuList.DeviceCompanyHandle(DeviceCompany_Ctrl);

            m_MapControlWnd.WndDataViewer += new LineGraph.SuperMapUtility.MapControlWnd.WndDataViewerEventHandler(WndDataViewer_Ctrl);
            m_MapControlWnd.CameraDataAdjustHandler += new LineGraph.SuperMapUtility.MapControlWnd.CameraDataAdjustEventHandler(m_WorkSpaceCtrl.CameraDataAdjust_Ctrl);
            m_DataCaptureWnd.m_DataReceiverWnd.MapDataColorAdjustHandler += new LineGraph.DataReceiver.DataReceiverWnd.MapDataColorAdjustEventHandler(MapDataColor_Ctrl);

            SuperMap.Data.Environment.IsSceneAntialias = true;
            //m_WorkSpaceCtrl.OpenWorkSpace();
        }

        private void Wnd_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Screen_Show(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ProjectSummary_Ctrl(object sender, EventArgs e)
        {
            string FileName = @"..\..\Bin64\Debug\cubepdf-viewer.exe";

            Process[] myprocess = Process.GetProcessesByName(FileName);
            if (myprocess.Length > 0)
            {
                myprocess[0].CloseMainWindow();
                myprocess[0].Close();
            }
            else
            {
                Process.Start(FileName);
            }
        }

        private void DeviceStyle_Ctrl(object sender, EventArgs e)
        {
            if (m_DeviceStyleWnd == null || m_DeviceStyleWnd.IsDisposed)
            {
                m_DeviceStyleWnd = new SQLUtility.DeviceStyleWnd();
            }
            try
            {
                m_DeviceStyleWnd.StartPosition = FormStartPosition.CenterScreen;
                m_DeviceStyleWnd.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_DeviceStyleWnd.Dispose();
            }
        }

        private void DeviceCompany_Ctrl(object sender, EventArgs e)
        {
            if (m_DeviceCompanyWnd == null || m_DeviceCompanyWnd.IsDisposed)
            {
                m_DeviceCompanyWnd = new SQLUtility.DeviceCompanyWnd();
            }
            try
            {
                m_DeviceCompanyWnd.StartPosition = FormStartPosition.CenterScreen;
                m_DeviceCompanyWnd.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_DeviceCompanyWnd.Dispose();
            }
        }

        private void WorkSpace_Ctrl(object sender, EventArgs e)
        {
            m_WorkSpaceCtrl.ShowDialog();
        }

        private void Length_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.BeginMeasureDistance();  
        }

        private void Area_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.BeginMeasureArea(); 
        }

        private void Height_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.BeginMeasureAltitude();
        }

        private void ClearResult_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.ClearResult();
        }

        private void LayerStyle_Ctrl(object sender, EventArgs e)
        {
           m_SceneControlWnd.LayerStyle_Ctrl();
        }

        private void Property_Ctrl(object sender, EventArgs e)
        {
           m_SceneControlWnd.Property_Ctrl();
        }

        private void SQL_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.SQL_Ctrl();
        }

        private void Sensor_Ctrl(object sender, EventArgs e)
        {
            //if (m_SensorWnd == null || m_SensorWnd.IsDisposed)
            //{
            //    m_SensorWnd = new GUI.SensorWnd();
            //}
            //try
            //{
            //    m_SensorWnd.StartPosition = FormStartPosition.CenterScreen;
            //    m_SensorWnd.Show();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    m_SensorWnd.Dispose();
            //}

            if (!m_bSensorShow)
            {
                this.splitContainer.Panel2.Controls.Add(this.m_DataCaptureWnd.m_DataReceiverWnd);
                this.splitContainer.Panel2.Controls.SetChildIndex(this.m_DataCaptureWnd.m_DataReceiverWnd, 1);
                m_bSensorShow = true;
            }
            else
            {
                this.splitContainer.Panel2.Controls.Remove(this.m_DataCaptureWnd.m_DataReceiverWnd);
                m_bSensorShow = false;
            } 
        }

        private void AddScene_Ctrl(object sender, EventArgs e)
        {
            this.splitContainer.Panel2.Controls.Remove(this.m_DataCaptureWnd.m_DataReceiverWnd);
            this.splitContainer.Panel2.Controls.Remove(this.m_MapControlWnd);

            m_SceneControlWnd.ShowSceneWnd();

            m_WorkSpaceCtrl.OpenWorkSpaceScene();
        }

        private void Map_Ctrl(object sender, EventArgs e)
        {
            if(!m_bMapShow)
            {
                this.splitContainer.Panel2.Controls.Add(this.m_MapControlWnd);
                this.splitContainer.Panel2.Controls.SetChildIndex(m_MapControlWnd, 2);
                m_bMapShow = true;
            }
            else
            {
                this.splitContainer.Panel2.Controls.Remove(this.m_MapControlWnd);
                m_bMapShow = false;
            } 
        }


        private void ThreeDesigner_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.ShowPointMarkerWnd();
        }

        private void Worker_Ctrl(object sender, EventArgs e)
        {
            if (m_ExcelData == null)
            {
                m_ExcelData = new ExcelData();
            }

            m_ExcelData.RunExcelData();
        }

        private void WndDataViewer_Ctrl(object sender, EventArgs e)
        {
            
        }

        private string m_ModelId;
        private string m_ModelNOId;
        private void AddModelID_Ctrl(object sender, EventArgs e)
        {
            List<string> lst = (List<string>)sender;
            m_ModelId = lst[0];
            m_ModelNOId = lst[1];
        }
        private void AddModel_Ctrl(object sender, EventArgs e)
        {
            Point2Ds Point2Ds = (Point2Ds)sender;
            m_WorkSpaceCtrl.AddModel_Click(Point2Ds, m_ModelId, m_ModelNOId);
        }

        private void DeleteModel_Ctrl(object sender, EventArgs e)
        {
            m_ModelId = (string)sender;
            m_WorkSpaceCtrl.DeleteModel_Click(m_ModelId);
        }

        private void MapDataColor_Ctrl(object sender)
        {
            m_WorkSpaceCtrl.UpdateMapView((string)sender);
        }

        private void SensorInfo_Ctrl(object sender, EventArgs e)
        {
            if (m_DeviceInfoWnd == null || m_DeviceInfoWnd.IsDisposed)
            {
                m_DeviceInfoWnd = new SQLUtility.DeviceInfoWnd();
            }
            try
            {
                m_DeviceInfoWnd.StartPosition = FormStartPosition.CenterScreen;
                m_DeviceInfoWnd.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_DeviceInfoWnd.Dispose();
            }
        }

        private void AddModelImage_Ctrl(object sender, EventArgs e)
        {
            m_WorkSpaceCtrl.DeviceAddressShow();
        }

        private void DataCapture_Ctrl(object sender, EventArgs e)
        {
            m_DataCaptureWnd.Show();

            //if (m_DtuClientSim == null || m_DtuClientSim.IsDisposed)
            //{
            //    m_DtuClientSim = new DataReceiver.DTUFrmMain();
            //}
            //try
            //{
            //    m_DtuClientSim.StartPosition = FormStartPosition.CenterScreen;
            //    m_DtuClientSim.Show();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    m_DtuClientSim.Dispose();
            //}
        }

        private void AddKml_Ctrl(object sender, EventArgs e)
        {

        }
        private void SaveKml_Ctrl(object sender, EventArgs e)
        {
           
        }
        private void Remove_Layer(object sender, EventArgs e)
        {
           
        }
    
        private void RemoveModel_Ctrl(object sender, EventArgs e)
        {
         
        }
        private void FlyToObject_Ctrl(object sender, EventArgs e)
        {
          
        }
        private void Feature3DVisible_Ctrl(object sender, EventArgs e)
        {
           
        }
        private void ModelSelectable_Ctrl(object sender, EventArgs e)
        {
            
        }
        private void ModelEditable_Ctrl(object sender, EventArgs e)
        {
            
        }

        private void User_Ctrl(object sender, EventArgs e)
        {
            if (m_UserManagement == null || m_UserManagement.IsDisposed)
            {
                m_UserManagement = new SQLUtility.User_Management();
            }
            try
            {
                m_UserManagement.StartPosition = FormStartPosition.CenterScreen;
                m_UserManagement.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_UserManagement.Dispose();
            }
        }

        private void Goods_Ctrl(object sender, EventArgs e)
        {
            if (m_GoodManagement == null || m_GoodManagement.IsDisposed)
            {
                m_GoodManagement = new SQLUtility.Goods_Management();
            }
            try
            {
                m_GoodManagement.StartPosition = FormStartPosition.CenterScreen;
                m_GoodManagement.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_GoodManagement.Dispose();
            }
        }

        private void Finance_Ctrl(object sender, EventArgs e)
        {
            //if (m_FinanceManagement == null || m_FinanceManagement.IsDisposed)
            //{
            //    m_FinanceManagement = new SQLUtility.Finance_Management();
            //}
            //try
            //{
            //    m_FinanceManagement.StartPosition = FormStartPosition.CenterScreen;
            //    m_FinanceManagement.Show();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    m_FinanceManagement.Dispose();
            //}
        }

        private void CameraView_Ctrl(object sender, EventArgs e)
        {
            if (m_CameraViewWnd == null || m_CameraViewWnd.IsDisposed)
            {
                m_CameraViewWnd = new SQLUtility.CameraViewWnd();
            }
            try
            {
                m_CameraViewWnd.StartPosition = FormStartPosition.CenterScreen;
                m_CameraViewWnd.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_CameraViewWnd.Dispose();
            }
        }
        

        private void SymbolResource_Ctrl(object sender, EventArgs e)
        {
       
        }

        private void COMDataCapture_Ctrl(object sender, EventArgs e)
        {
            //m_DataCaptureWnd.m_ModbusDataAcquisitionWnd.Show();
        }

        private void DataAnalyze_Ctrl(object sender, EventArgs e)
        {
            //try
            //{
            //    m_DataAnalyzeWnd.StartPosition = FormStartPosition.CenterScreen;
            //    m_DataAnalyzeWnd.Show();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    m_DataAnalyzeWnd.Dispose();
            //}
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_DataCaptureWnd.CloseNetData();

            // LineGraph.Designer.Designer.DestroyPlugin();
            if (m_WorkSpaceCtrl != null)
            {
                m_WorkSpaceCtrl.CloseWorkSpace();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // LineGraph.Designer.Designer.InitPlugin();
            m_WorkSpaceCtrl.OpenWorkSpace();
            m_DataCaptureWnd.StartNetData();
        }
    }
}
