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
using SuperMap.Analyst.SpatialAnalyst;

namespace LineGraph.SuperMapUtility
{
    public enum OSGBQueryType
    {
        SQL,
        Buffer,
    };
    public partial class DlgOSGBQuery : Form
    {
        private Workspace m_workspace = null;
        private SceneControl m_sceneControl = null;
        private String m_sqlQueryCondition = String.Empty;
        private OSGBQueryType m_queryType = OSGBQueryType.SQL;
        private DatasetVector m_srcDatasetVector = null;
        private Layer3DDataset m_layerSrcRegion = null;
        private Recordset m_selectRegion = null;
        private double m_bufferRadius = 0;
        private Layer3DDataset m_layerResultDataset = null;
        private Layer3DDataset m_layerBufferDataset = null;
        public bool m_bCleared = false;

        public DlgOSGBQuery()
        {
            InitializeComponent();
        }

        public void SetValue(Workspace workspace, SceneControl sceneControl)
        {
            m_workspace = workspace;
            m_sceneControl = sceneControl;
        }


        private void DlgOSGBQuery_Load(object sender, EventArgs e)
        {
            m_bCleared = false;
        }
        public bool SetQueryType(OSGBQueryType queryType)
        {
            m_queryType = queryType;

            m_srcDatasetVector = this.GetDataset();

            if (m_srcDatasetVector == null)
            {
                MessageBox.Show("找不到指定的面数据集！");
                return false;
            }

            if (m_queryType == OSGBQueryType.SQL)
            {
                this.gb_SqlQuery.Enabled = true;
                this.gb_BufferQuery.Enabled = false;
                m_sceneControl.ObjectSelected -= new SuperMap.UI.ObjectSelectedEventHandler(m_sceneControl_ObjectSelected);
            }
            else
            {
                this.gb_SqlQuery.Enabled = false;
                this.gb_BufferQuery.Enabled = true;

                //缓存区分析，需要先把原始数据集添加到场景中
                if (m_sceneControl.Scene.Layers.Contains(m_srcDatasetVector.Name))
                {
                    m_layerSrcRegion = m_sceneControl.Scene.Layers[m_srcDatasetVector.Name] as Layer3DDataset;
                }
                else
                {
                    m_layerSrcRegion = AddSrcRegionToScene(m_srcDatasetVector);
                }

                //将场景中其他图层设为不可见
                Layer3Ds layer3Ds = m_sceneControl.Scene.Layers;
                for (int i = 0; i < layer3Ds.Count; i++)
                {
                    Layer3D layer = layer3Ds[i];
                    if (layer.Name != m_layerSrcRegion.Name)
                    {
                        layer.IsVisible = false;
                    }
                }

                //注册事件
                m_sceneControl.ObjectSelected -= new SuperMap.UI.ObjectSelectedEventHandler(m_sceneControl_ObjectSelected);
                m_sceneControl.ObjectSelected += new SuperMap.UI.ObjectSelectedEventHandler(m_sceneControl_ObjectSelected);
            }
            return true;
        }
        //获取数据集
        private DatasetVector GetDataset()
        {
            DatasetVector datasetVector = null;
            //获取原始数据集
           
            Datasource ds = m_workspace.Datasources[0];
            datasetVector = ds.Datasets[0] as DatasetVector;
         
            return datasetVector;

        }

        //SQL查询
        public void SQLQuery(String queryCondition)
        {
            //清除已有查询结果
            if (m_layerResultDataset != null)
            {
                this.ClearResult();
            }
            // 构造一个查询参数对象
            QueryParameter queryParam = new QueryParameter();
            queryParam.AttributeFilter = queryCondition;
            queryParam.CursorType = CursorType.Dynamic;
            Recordset recordset = m_srcDatasetVector.Query(queryParam);

            if (recordset.RecordCount == 0)
            {
                MessageBox.Show("查询结果为空，请重新输入查询条件！");
                return;
            }
            // 以 datasetVector 为模板创建数据集
            String retName = "sql_Result";
            if (m_workspace.Datasources[0].Datasets.Contains(retName))
            {
                m_workspace.Datasources[0].Datasets.Delete(retName);
            }
            DatasetVector dataset_result = (DatasetVector)m_workspace.Datasources[0].Datasets.CreateFromTemplate(retName, m_srcDatasetVector);

            dataset_result.Append(recordset);

            //将结果添加到场景中
            Color color = Color.FromArgb(180, 0, 233, 0);
            m_layerResultDataset = this.AddResultToScene(dataset_result, color) as Layer3DDataset;

            // 释放对象
            recordset.Dispose();
        }

        //将原始面数据集加载到场景中
        private Layer3DDataset AddSrcRegionToScene(DatasetVector dataset)
        {
            Layer3Ds layer3Ds = m_sceneControl.Scene.Layers;

            //设置图层风格为依模型
            Layer3DSettingVector settingVector = new Layer3DSettingVector();
            GeoStyle3D style3D = new GeoStyle3D();
            style3D.AltitudeMode = AltitudeMode.RelativeToGround;
            style3D.BottomAltitude = 1;
            style3D.FillForeColor = Color.Blue;
            settingVector.Style = style3D;

            //将数据添加到场景中
            Layer3DDataset layerDataset = layer3Ds.Add(dataset, settingVector, true, dataset.Name);
            layerDataset.UpdateData();
            m_sceneControl.Scene.EnsureVisible(layerDataset);

            m_sceneControl.Scene.Refresh();
            return layerDataset;
        }
        //将查询结果显示到场景中
        private Layer3D AddResultToScene(DatasetVector dataset, Color color)
        {
            Layer3Ds layer3Ds = m_sceneControl.Scene.Layers;

            //设置图层风格为依模型
            Layer3DSettingVector settingVector = new Layer3DSettingVector();
            GeoStyle3D style3D = new GeoStyle3D();
            style3D.AltitudeMode = AltitudeMode.ClampToObject;
            style3D.FillForeColor = color;
            settingVector.Style = style3D;

            //将数据添加到场景中
            Layer3DDataset layerDataset = layer3Ds.Add(dataset, settingVector, true);
            layerDataset.UpdateData();
            m_sceneControl.Scene.EnsureVisible(layerDataset);

            return layerDataset;
        }

        //Buffer查询
        public void BufferQuery()
        {
            try
            {
                //清除已有查询结果
                if (m_layerResultDataset != null)
                {
                    this.ClearResult();
                }
                //创建结果面数据集
                String bufferName = "bufferRegionDataset";
                if (m_workspace.Datasources[0].Datasets.Contains(bufferName))
                {
                    m_workspace.Datasources[0].Datasets.Delete(bufferName);
                }
                DatasetVector bufferDataset = (DatasetVector)m_workspace.Datasources[0].Datasets.CreateFromTemplate(bufferName, m_srcDatasetVector);

                BufferAnalystParameter bufferAnalystParam = new BufferAnalystParameter();
                bufferAnalystParam.EndType = BufferEndType.Round;
                bufferAnalystParam.LeftDistance = m_bufferRadius;

                Boolean isTrue = SuperMap.Analyst.SpatialAnalyst.BufferAnalyst.CreateBuffer(m_selectRegion, bufferDataset, bufferAnalystParam, false, true);

                m_layerBufferDataset = this.AddResultToScene(bufferDataset, Color.FromArgb(100, 255, 255, 0)) as Layer3DDataset;

                //进行叠加分析
                QueryParameter para = new QueryParameter();
                para.SpatialQueryMode = SpatialQueryMode.Intersect;
                para.SpatialQueryObject = bufferDataset;

                Recordset recordset = m_srcDatasetVector.Query(para);

                List<Int32> ids = new List<int>(recordset.RecordCount);

                while (!recordset.IsEOF)
                {
                    ids.Add(recordset.GetID());
                    recordset.MoveNext();
                }

                String resultName = "BufferResult";
                if (m_workspace.Datasources[0].Datasets.Contains(resultName))
                {
                    m_workspace.Datasources[0].Datasets.Delete(resultName);
                }
                DatasetVector dataset_result = (DatasetVector)m_workspace.Datasources[0].Datasets.CreateFromTemplate(resultName, m_srcDatasetVector);
                Console.Write(isTrue);


                // 将空间查询结果追加到新建的数据集中
                dataset_result.Append(recordset);

                m_layerSrcRegion.IsVisible = false;
                //将结果数据集添加到场景中

                Color color = Color.FromArgb(200, 0, 233, 0);
                m_layerResultDataset = this.AddResultToScene(dataset_result, color) as Layer3DDataset;

                //如果场景中有osgb图层，设置osgb图层可见
                Layer3Ds layer3ds = m_sceneControl.Scene.Layers;
                for (int i = 0; i < layer3ds.Count; i++)
                {
                    Layer3D layer = layer3ds[i];
                    if (layer.Type == Layer3DType.OSGB)
                    {
                        layer.IsVisible = true;
                    }
                }

                recordset.Dispose();
                m_selectRegion.Dispose();
                m_selectRegion = null;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_QueryCondition_TextChanged(object sender, EventArgs e)
        {
            m_sqlQueryCondition = this.tb_QueryCondition.Text;
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            if (m_queryType == OSGBQueryType.SQL)
            {
                this.SQLQuery(m_sqlQueryCondition);
            }
            else if (m_queryType == OSGBQueryType.Buffer)
            {
                if (m_selectRegion == null)
                {
                    MessageBox.Show("执行buffer查询，请先选择一个面对象！");
                    return;
                }
                if (m_bufferRadius == 0)
                {
                    MessageBox.Show("请先输入缓存区分析半径！");
                    return;
                }
                //执行缓存区分析
                this.BufferQuery();
            }

        }

        /// <summary>
        /// SceneControl的选择事件，通过该事件从场景中选取一个面对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_sceneControl_ObjectSelected(object sender, SuperMap.UI.ObjectSelectedEventArgs e)
        {
            try
            {
                if (m_queryType == OSGBQueryType.SQL)
                    return;

                if (e.Count > 0 && m_layerSrcRegion.Selection.Count > 0)
                {
                    Int32 id = m_layerSrcRegion.Selection[0];

                    if (m_selectRegion != null)
                    {
                        m_selectRegion.Dispose();
                        m_selectRegion = null;
                    }

                    m_selectRegion = m_srcDatasetVector.Query("SmID=" + id.ToString(), CursorType.Dynamic);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_bufferRadius_TextChanged(object sender, EventArgs e)
        {
            String str = this.tb_bufferRadius.Text;
            if (str == null)
            {
                MessageBox.Show("请输入缓冲半径！");
                return;
            }
            m_bufferRadius = Convert.ToDouble(str);

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.ClearResult();
        }

        public void ClearResult()
        {
            try
            {
                if (m_selectRegion != null)
                {
                    m_selectRegion.Dispose();
                    m_selectRegion = null;
                }

                if (m_layerBufferDataset != null)
                {
                    m_sceneControl.Scene.Layers.Remove(m_layerBufferDataset.Name);
                    m_layerBufferDataset = null;
                }
                if (m_layerResultDataset != null)
                {
                    m_sceneControl.Scene.Layers.Remove(m_layerResultDataset.Name);
                    m_layerResultDataset = null;
                }

                //if (m_layerSrcRegion != null)
                //{
                //    m_sceneControl.Scene.Layers.Remove(m_layerSrcRegion.Name);
                //    m_layerResultDataset = null;
                //}
                this.tb_bufferRadius.Text = "0.0";
                Datasource datasource = m_workspace.Datasources[0];
                if (datasource.Datasets.Contains("sql_Result"))
                {
                    datasource.Datasets.Delete("sql_Result");
                }
                if (datasource.Datasets.Contains("bufferRegionDataset"))
                {
                    datasource.Datasets.Delete("bufferRegionDataset");

                }
                if (datasource.Datasets.Contains("BufferResult"))
                {
                    datasource.Datasets.Delete("BufferResult");

                }

                m_bCleared = true;
            }
            catch (System.Exception ex)
            {
                m_bCleared = false;
                MessageBox.Show(ex.ToString());
            }

            //m_sceneControl.Scene.Refresh();
        }

        private void DlgOSGBQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ClearResult();

            if (m_layerSrcRegion != null)
            {
                m_sceneControl.Scene.Layers.Remove(m_layerSrcRegion.Name);
                m_layerResultDataset = null;
            }
            m_sceneControl.ObjectSelected -= new SuperMap.UI.ObjectSelectedEventHandler(m_sceneControl_ObjectSelected);
        }
    }
}
