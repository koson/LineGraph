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
    public partial class MainFormJuXian: Form
    {
        //private GUI.SensorWnd m_SensorWnd = null;
        private LineGraph.Data.ExcelData m_ExcelData = null;

        private LineGraph.SQLUtility.DeviceInfoWnd m_DeviceInfoWnd = null;
        private LineGraph.SQLUtility.User_Management m_UserManagement = null;
        private LineGraph.SQLUtility.CameraViewWnd m_CameraViewWnd = null;
        private LineGraph.SQLUtility.YangHu m_YangHu = null;
        private LineGraph.SQLUtility.trees_Management m_TreeManage = null;
        private LineGraph.SQLUtility.GPSForm m_GPSForm = null;
        private LineGraph.SQLUtility.FormAccountManage m_FinanceFormMain = null;
        private LineGraph.SQLUtility.frmEmployInfo m_Human_frmMain = null;

        private LineGraph.DataReceiver.BroadcastForm m_BroadcastForm = null;

        public MainFormJuXian()
        {
            InitializeComponent();

            WndMenuList.WorkSpaceCtrl += new GUI.WndMenuListJuXian.WorkSpaceCtrlEventHandler(WorkSpace_Ctrl);
            WndMenuList.LengthCtrl += new GUI.WndMenuListJuXian.LengthCtrlEventHandler(Length_Ctrl);
            WndMenuList.AreaCtrl += new GUI.WndMenuListJuXian.AreaCtrlEventHandler(Area_Ctrl);
            WndMenuList.HeightCtrl += new GUI.WndMenuListJuXian.HeightCtrlEventHandler(Height_Ctrl);
            WndMenuList.ClearResultCtrl += new GUI.WndMenuListJuXian.ClearResultCtrlEventHandler(ClearResult_Ctrl);
            WndMenuList.SensorInfoCtrl += new GUI.WndMenuListJuXian.SensorInfoCtrlEventHandler(SensorInfo_Ctrl);
            WndMenuList.AddModelCtrl += new GUI.WndMenuListJuXian.AddModelCtrlEventHandler(AddModelImage_Ctrl);
            WndMenuList.DataCaptureCtrl += new GUI.WndMenuListJuXian.DataCaptureCtrlEventHandle(DataCapture_Ctrl);
            WndMenuList.LayerStyleCtrl += new GUI.WndMenuListJuXian.layerStyleCtrlEventHandler(LayerStyle_Ctrl);
            WndMenuList.SQLCtrl += new GUI.WndMenuListJuXian.SQLCtrlEventHandler(SQL_Ctrl);
            WndMenuList.PropertyCtrl += new GUI.WndMenuListJuXian.PropertyCtrlEventHandler(Property_Ctrl);
            WndMenuList.SensorCtrl += new GUI.WndMenuListJuXian.SensorCtrlEventHandler(Sensor_Ctrl);
            WndMenuList.WorkerCtrl += new GUI.WndMenuListJuXian.WorkerCtrlEventHandler(Worker_Ctrl);
            WndMenuList.AddSceneCtrl += new GUI.WndMenuListJuXian.AddSceneCtrlEventHandler(AddScene_Ctrl) ;
            WndMenuList.QingXieSheYingCtrl += new GUI.WndMenuListJuXian.QingXieSheYingCtrlEventHandle(QingXieSheYing_Ctrl);
            WndMenuList.SaveKmlCtrl += new GUI.WndMenuListJuXian.SaveKmlCtrlEventHandler(SaveKml_Ctrl) ;
            WndMenuList.RemoveLayer += new GUI.WndMenuListJuXian.RemoveLayerCtrlEventHandler(Remove_Layer) ;
            WndMenuList.RemoveModelCtrl += new GUI.WndMenuListJuXian.RemoveModelCtrlEventHandler(RemoveModel_Ctrl) ;
            WndMenuList.FlyToObjectCtrl += new GUI.WndMenuListJuXian.FlyToObjectCtrlEventHandler(FlyToObject_Ctrl);
            WndMenuList.Feature3DVisibleCtrl += new GUI.WndMenuListJuXian.Feature3DVisibleCtrlEventHandler(Feature3DVisible_Ctrl);
            WndMenuList.ModelSelectableCtrl += new GUI.WndMenuListJuXian.ModelSelectableCtrlEventHandler(ModelSelectable_Ctrl);
            WndMenuList.ModelEditableCtrl += new GUI.WndMenuListJuXian.ModelEditableCtrlEventHandler(ModelEditable_Ctrl);
            WndMenuList.UserCtrl += new GUI.WndMenuListJuXian.UserCtrlEventHandle(User_Ctrl);
            WndMenuList.GoodsCtrl += new GUI.WndMenuListJuXian.GoodsCtrlEventHandle(Goods_Ctrl);
            WndMenuList.FinanceCtrl += new GUI.WndMenuListJuXian.FinanceCtrlEventHandle(Finance_Ctrl);
            WndMenuList.ThreeDdesignerCtrl += new GUI.WndMenuListJuXian.ThreeDdesignerCtrlEventHandle(ThreeDesigner_Ctrl);
            WndMenuList.SymbolResourceCtrl += new GUI.WndMenuListJuXian.SymbolResourceCtrlEventHandle(SymbolResource_Ctrl);
            WndMenuList.COMDataCaptureCtrl += new GUI.WndMenuListJuXian.COMDataCaptureCtrlEventHandle(COMDataCapture_Ctrl);
            WndMenuList.DataAnalyzeCtrl += new GUI.WndMenuListJuXian.DataAnalyzeCtrlEventHandle(DataAnalyze_Ctrl);
            WndMenuList.CameraViewCtrl += new GUI.WndMenuListJuXian.CameraViewCtrlEventHandle(CameraView_Ctrl);
            WndMenuList.TreeStyleCtrl += new GUI.WndMenuListJuXian.TreeStyleCtrlEventHandle(TreeStyle_Ctrl);
            WndMenuList.TreeProtectCtrl += new GUI.WndMenuListJuXian.TreeProtectCtrlEventHandle(TreeProtect_Ctrl);
            WndMenuList.TreeManageCtrl += new GUI.WndMenuListJuXian.TreeManageCtrlEventHandle(TreeManage_Ctrl);
            WndMenuList.GPSLocationCtrl += new GUI.WndMenuListJuXian.GPSLocationCtrlEventHandle(GPSLocation_Ctrl);
            WndMenuList.ProjectSummaryCtrl += new GUI.WndMenuListJuXian.ProjectSummaryCtrlEventHandle(ProjectSummary_Ctrl);
            WndMenuList.MapCtrl += new GUI.WndMenuListJuXian.MapCtrlEventHandle(Map_Ctrl);
            WndMenuList.FullAirCtrl += new GUI.WndMenuListJuXian.FullAirCtrlEventHandle(FullAir_Ctrl);
            WndMenuList.BroadcastCtrl += new GUI.WndMenuListJuXian.BroadcastCtrlEventHandle(Broadcast_Ctrl);
            WndMenuList.TreeSceneCtrl += new GUI.WndMenuListJuXian.TreeSceneCtrlEventHandle(TreeScene_Ctrl);
            WndMenuList.UserManagement += UserManagement_Ctrl;


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
            this.splitContainer.Panel2.Controls.Add(this.m_DataCaptureWnd.m_DataReceiverWnd);

            this.splitContainer.Panel2.Controls.SetChildIndex(this.m_DataCaptureWnd.m_DataReceiverWnd, 1);
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
            int index = (int)sender;
            m_WorkSpaceCtrl.OpenWorkSpaceMap(index);
            this.splitContainer.Panel2.Controls.Add(this.m_MapControlWnd);
            this.splitContainer.Panel2.Controls.SetChildIndex(m_MapControlWnd, 2);
        }

        private void QingXieSheYing_Ctrl(object sender, EventArgs e)
        {
            m_WorkSpaceCtrl.OpenWorkSpaceOSGB();
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
            if (m_Human_frmMain == null || m_Human_frmMain.IsDisposed)
            {
                m_Human_frmMain = new SQLUtility.frmEmployInfo();
            }
            try
            {
                m_Human_frmMain.StartPosition = FormStartPosition.CenterScreen;
                m_Human_frmMain.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_Human_frmMain.Dispose();
            }
        }

        private void Goods_Ctrl(object sender, EventArgs e)
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

        private void Finance_Ctrl(object sender, EventArgs e)
        {
            if (m_FinanceFormMain == null || m_FinanceFormMain.IsDisposed)
            {
                m_FinanceFormMain = new SQLUtility.FormAccountManage();
            }
            try
            {
                m_FinanceFormMain.StartPosition = FormStartPosition.CenterScreen;
                m_FinanceFormMain.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_FinanceFormMain.Dispose();
            }
        }

        private void ThreeDesigner_Ctrl(object sender, EventArgs e)
        {
            int index = (int)sender;
            if(index == 0)
            {
                m_SceneControlWnd.ShowPointMarkerWnd();
            }

            if(index == 3)
            {
                m_SceneControlWnd.ShowFillWnd();
            }
            
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
            m_DataCaptureWnd.m_ModbusDataAcquisitionWnd.Show();
        }

        private void DataAnalyze_Ctrl(object sender, EventArgs e)
        {
            this.splitContainer.Panel2.Controls.Remove(this.m_DataCaptureWnd.m_DataReceiverWnd);

            this.splitContainer.Panel2.Controls.Add(m_DataAnalyzeWnd);
            this.splitContainer.Panel2.Controls.SetChildIndex(m_DataAnalyzeWnd,3);
        }

        private void TreeStyle_Ctrl(object sender, EventArgs e)
        {
         
        }

        private void TreeProtect_Ctrl(object sender, EventArgs e)
        {
            if (m_YangHu == null || m_YangHu.IsDisposed)
            {
                m_YangHu = new SQLUtility.YangHu();
            }
            try
            {
                m_YangHu.StartPosition = FormStartPosition.CenterScreen;
                m_YangHu.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_YangHu.Dispose();
            }
        }

        private void TreeManage_Ctrl(object sender, EventArgs e)
        {
            if (m_TreeManage == null || m_TreeManage.IsDisposed)
            {
                m_TreeManage = new SQLUtility.trees_Management();
            }
            try
            {
                m_TreeManage.StartPosition = FormStartPosition.CenterScreen;
                m_TreeManage.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_TreeManage.Dispose();
            }
        }

        private void GPSLocation_Ctrl(object sender, EventArgs e)
        {
            if (m_GPSForm == null || m_GPSForm.IsDisposed)
            {
                m_GPSForm = new SQLUtility.GPSForm();
            }
            try
            {
                m_GPSForm.StartPosition = FormStartPosition.CenterScreen;
                m_GPSForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_GPSForm.Dispose();
            }
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

        private void FullAir_Ctrl(object sender, EventArgs e)
        {
            string FileName = @"..\..\Bin64\Ref\3DData\JuXian\张闻天故居展示\张闻天故居.exe";

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

        
        private void Broadcast_Ctrl(object sender, EventArgs e)
        {
             if (m_BroadcastForm == null || m_BroadcastForm.IsDisposed)
            {
                m_BroadcastForm = new DataReceiver.BroadcastForm();
            }
            try
            {
                m_BroadcastForm.StartPosition = FormStartPosition.CenterScreen;
                m_BroadcastForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_BroadcastForm.Dispose();
            }
        }

        private void TreeScene_Ctrl(object sender, EventArgs e)
        {
            m_SceneControlWnd.SetRegionPoint();
        }

        private void UserManagement_Ctrl(object sender, EventArgs e)
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
            m_WorkSpaceCtrl.OpensSceneSpace();
            //m_DataCaptureWnd.StartNetData();
        }
    }
}
