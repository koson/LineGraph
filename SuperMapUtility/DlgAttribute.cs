using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.Realspace;
using SuperMap.Data;

namespace LineGraph.SuperMapUtility
{
    public partial class DlgAttribute : Form
    {
        Layer3DVectorFile lVF;
        DatasetVector ObjDV;
        Selection3D[] m_selections;
        FieldInfos fieldInfos;
        public DlgAttribute()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public void getAtt(Selection3D[] selections)
        {
            m_selections = selections;
            if (treeView1.Nodes.Count != 0)
                treeView1.Nodes.Clear();
            if (dataGridView1.Columns.Count != 0)
                dataGridView1.Columns.Clear();
            if (dataGridView1.Rows.Count != 0)
                dataGridView1.Rows.Clear();
            List<TreeNode> tns = new List<TreeNode>();
            for (int i = 0; i < selections[0].Count; i++)
            {
                TreeNode t = new TreeNode(selections[0][i].ToString());
                tns.Add(t);
            }

            TreeNode tN = new TreeNode("属性", tns.ToArray());
            treeView1.Nodes.Add(tN);
            treeView1.ExpandAll();

            var lll = selections[0].Layer;
            if (selections[0].Layer is Layer3DDataset)
            {
                Layer3DDataset l3d = (Layer3DDataset)selections[0].Layer;
                ObjDV = (DatasetVector)l3d.Dataset;
                fieldInfos = ObjDV.FieldInfos;
            }
            else
            {
                lVF = (Layer3DVectorFile)selections[0].Layer;
                fieldInfos = lVF.GetFieldInfos();
            }
            int[] ID = new int[selections[0].Count];
            for (int i = 0; i < ID.Length; i++)
            {
                ID[i] = selections[0][i];
            }
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "字段名";
            dataGridView1.Columns[1].Name = "字段别名";
            dataGridView1.Columns[2].Name = "字段类型";
            dataGridView1.Columns[3].Name = "必填";
            dataGridView1.Columns[4].Name = "字段值";
            dataGridView1.RowCount = fieldInfos.Count;
            for (int i = 0; i < fieldInfos.Count; i++)
            {
                dataGridView1[0, i].Value = fieldInfos[i].Name;
                dataGridView1[1, i].Value = fieldInfos[i].Caption;
                dataGridView1[2, i].Value = fieldInfos[i].Type;
                dataGridView1[3, i].Value = fieldInfos[i].IsRequired;
            }
            for (int i = 0; i < fieldInfos.Count; i++)
            {

                if (lVF != null && lVF.GetFieldValueOfSelectedObject(i) != null)
                    dataGridView1[4, i].Value = lVF.GetFieldValueOfSelectedObject(i).ToString();
                if (ObjDV != null)
                {
                    QueryParameter query = new QueryParameter();
                    query.AttributeFilter = string.Format("SmID={0}", selections[0][0]);
                    Recordset recordset = ObjDV.Query(query); ;
                    dataGridView1[4, i].Value = recordset.GetFieldValue(i).ToString();
                }
            }
        }
    }
}
