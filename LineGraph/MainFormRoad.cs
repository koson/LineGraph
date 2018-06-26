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


namespace LineGraph
{
    public partial class MainFormRoad: Form
    {
        //private GUI.SensorWnd m_SensorWnd = null;
        private LineGraph.Data.ExcelData m_ExcelData = null;

        private LineGraph.SQLUtility.DeviceInfoWnd m_DeviceInfoWnd = null;
        private LineGraph.SQLUtility.User_Management m_UserManagement = null;
        private LineGraph.SQLUtility.Goods_Management m_GoodManagement = null;
        //private LineGraph.SQLUtility.Finance_Management m_FinanceManagement = null;

        private LineGraph.SuperMapUtility.SymbolDesignerWnd m_ThreeDesignerWnd = null;

        public MainFormRoad()
        {
            InitializeComponent();

            WndMenuList.WorkSpaceCtrl += new GUI.WndMenuListRoad.WorkSpaceCtrlEventHandler(WorkSpace_Ctrl);
            WndMenuList.LengthCtrl += new GUI.WndMenuListRoad.LengthCtrlEventHandler(Length_Ctrl);
            WndMenuList.AreaCtrl += new GUI.WndMenuListRoad.AreaCtrlEventHandler(Area_Ctrl);
            WndMenuList.HeightCtrl += new GUI.WndMenuListRoad.HeightCtrlEventHandler(Height_Ctrl);
            WndMenuList.ClearResultCtrl += new GUI.WndMenuListRoad.ClearResultCtrlEventHandler(ClearResult_Ctrl);
            WndMenuList.SensorInfoCtrl += new GUI.WndMenuListRoad.SensorInfoCtrlEventHandler(SensorInfo_Ctrl);
            WndMenuList.AddModelCtrl += new GUI.WndMenuListRoad.AddModelCtrlEventHandler(AddModelImage_Ctrl);
            WndMenuList.DataCaptureCtrl += new GUI.WndMenuListRoad.DataCaptureCtrlEventHandle(DataCapture_Ctrl);
            WndMenuList.LayerStyleCtrl += new GUI.WndMenuListRoad.layerStyleCtrlEventHandler(LayerStyle_Ctrl);
            WndMenuList.SQLCtrl += new GUI.WndMenuListRoad.SQLCtrlEventHandler(SQL_Ctrl);
            WndMenuList.PropertyCtrl += new GUI.WndMenuListRoad.PropertyCtrlEventHandler(Property_Ctrl);
            WndMenuList.SensorCtrl += new GUI.WndMenuListRoad.SensorCtrlEventHandler(Sensor_Ctrl);
            WndMenuList.WorkerCtrl += new GUI.WndMenuListRoad.WorkerCtrlEventHandler(Worker_Ctrl);
            WndMenuList.AddKmlCtrl += new GUI.WndMenuListRoad.AddKmlCtrlEventHandler(AddKml_Ctrl) ;
            WndMenuList.SaveKmlCtrl += new GUI.WndMenuListRoad.SaveKmlCtrlEventHandler(SaveKml_Ctrl) ;
            WndMenuList.RemoveLayer += new GUI.WndMenuListRoad.RemoveLayerCtrlEventHandler(Remove_Layer) ;
            WndMenuList.RemoveModelCtrl += new GUI.WndMenuListRoad.RemoveModelCtrlEventHandler(RemoveModel_Ctrl) ;
            WndMenuList.FlyToObjectCtrl += new GUI.WndMenuListRoad.FlyToObjectCtrlEventHandler(FlyToObject_Ctrl);
            WndMenuList.Feature3DVisibleCtrl += new GUI.WndMenuListRoad.Feature3DVisibleCtrlEventHandler(Feature3DVisible_Ctrl);
            WndMenuList.ModelSelectableCtrl += new GUI.WndMenuListRoad.ModelSelectableCtrlEventHandler(ModelSelectable_Ctrl);
            WndMenuList.ModelEditableCtrl += new GUI.WndMenuListRoad.ModelEditableCtrlEventHandler(ModelEditable_Ctrl);
            WndMenuList.UserCtrl += new GUI.WndMenuListRoad.UserCtrlEventHandle(User_Ctrl);
            WndMenuList.GoodsCtrl += new GUI.WndMenuListRoad.GoodsCtrlEventHandle(Goods_Ctrl);
            WndMenuList.FinanceCtrl += new GUI.WndMenuListRoad.FinanceCtrlEventHandle(Finance_Ctrl);
            WndMenuList.ThreeDdesignerCtrl += new GUI.WndMenuListRoad.ThreeDdesignerCtrlEventHandle(ThreeDesigner_Ctrl);
            WndMenuList.SymbolResourceCtrl += new GUI.WndMenuListRoad.SymbolResourceCtrlEventHandle(SymbolResource_Ctrl);
            WndMenuList.QingXieSheYingCtrl += new GUI.WndMenuListRoad.QingXieSheYingCtrlEventHandle(QingXieSheYing_Ctrl);

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

        private void ThreeDesigner_Ctrl(object sender, EventArgs e)
        {
            if (m_ThreeDesignerWnd == null || m_ThreeDesignerWnd.IsDisposed)
            {
                m_ThreeDesignerWnd = new SuperMapUtility.SymbolDesignerWnd(m_WorkSpaceCtrl.m_workspace, m_WorkSpaceCtrl.m_SceneControl);
            }
            try
            {
                m_ThreeDesignerWnd.StartPosition = FormStartPosition.CenterScreen;
                m_ThreeDesignerWnd.Show();
                m_ThreeDesignerWnd.BringToFront();
                //m_ThreeDesignerWnd.TopMost = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_ThreeDesignerWnd.Dispose();
            }

           
        }

        private void SymbolResource_Ctrl(object sender, EventArgs e)
        {

        }

        private void QingXieSheYing_Ctrl(object sender, EventArgs e)
        {
            m_WorkSpaceCtrl.Layer3D_Click();
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
            //m_WorkSpaceCtrl.OpenWorkSpace();
            m_DataCaptureWnd.StartNetData();
        }
    }
}
