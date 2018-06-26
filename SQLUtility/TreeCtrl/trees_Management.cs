using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LineGraph.SQLUtility
{
    public partial class trees_Management : Form
    {
        string sql = "";       //查询条件
        // string strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BGKDB.MDB;";
        string strcon = "Data Source=AC;Initial Catalog=GuGong_JianCeDB;User ID=sa;Password=123456;";
        DataSet ds = new DataSet();
        DataTable dt;
        DataRowCollection drc;
        public trees_Management()
        {
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //填充表格

           // EventTest.message += EventTest_message; //委托通信
        }
        //public void EventTest_message(object sender, EventArgsTest e)
        //{

        //    goodsQuery();

        //}
        private void button1_Click(object sender, EventArgs e)
        {
            return;
            goodsQuery();

        }
        public void goodsQuery()
        { 
        
         try
            {
                string condition = " 1=1 ";
                if (!string.IsNullOrEmpty(comboBox2.Text))//传感器名称
                {
                    condition =condition+" and goods_Name like '%" + comboBox2.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(comboBox1.Text) && comboBox1.Text != "全部")//传感器参数
                {
                    condition += "and goods_Company='" + comboBox1.Text + "'";
                }

                sql = "select goods_ID as 序号,SN as 树木编号,goods_Name as 树木名称, goods_Property as 树木生态习性, goods_Company as 商品生产地区 from goods2";
                if (!string.IsNullOrEmpty(condition))
                {
                    sql += " where " + condition;
                }

                SqlDataAdapter myda = new SqlDataAdapter(sql, strcon);

                myda.Fill(ds, "tb");
                dt = ds.Tables["tb"];
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    //dataGridView2.DataSource = dt;
                    ds.Tables.Clear();//清除ds中的表
                    ds.Clear();       //清空ds

                    //DataGridViewLinkColumn dlink = new DataGridViewLinkColumn();
                    //dlink.Text = "删除";//添加的这列的显示文字，即每行最后一列显示的文字。
                    //dlink.Name = "linkDelete";
                    //dlink.HeaderText = "删除";//列的标题
                    //dlink.UseColumnTextForLinkValue = true;//上面设置的dlink.Text文字在列中显示
                    //dataGridView2.Columns.Insert(4, dlink);//将创建的列添加到UserdataGridView中
                    dt.Columns.Add("删除");

                    drc = dt.Rows;
                    dataGridView1.DataSource = dt.DefaultView;

                    dataGridView1.ClearSelection();
                    dataGridView1.AllowUserToAddRows = false; //不显示最后空白行
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提示");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dataGridView1.Columns["删除"].Index)
                {
                    int rows = dataGridView1.CurrentRow.Index; //得到当前行的索引
                    string id = dataGridView1.Rows[rows].Cells[0].Value.ToString(); //得到表的主键ID，就是上表中的userid

                    if (id != null && id != "" && MessageBox.Show("您确定要删除吗？", "重要提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    {
                        SqlConnection conn = new SqlConnection(strcon);
                        conn.Open();
                        sql = "delete from goods2 where goods_ID=" + id;
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        drc.RemoveAt(rows);
                        dataGridView1.DataSource = dt;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string fileName = "";
            //string saveFileName = "";
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.DefaultExt = "xls";
            //saveDialog.Filter = "Excel文件|*.xls";
            //saveDialog.FileName = fileName;
            //saveDialog.ShowDialog();
            //saveFileName = saveDialog.FileName;
            //if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //if (xlApp == null)
            //{
            //    MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
            //    return;
            //}
            //Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
            ////写入标题             
            //for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //{ worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }
            ////写入数值
            //for (int r = 0; r < dataGridView1.Rows.Count; r++)
            //{
            //    for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //    {//Worksheet.Cells[row, column] - 就是某行某列的单元格，注意这里的下标row和column都是从1开始。
            //        worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;
            //    }
            //    System.Windows.Forms.Application.DoEvents();
            //}
            //worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            //MessageBox.Show(fileName + "商品数据资料保存成功", "提示", MessageBoxButtons.OK);
            //if (saveFileName != "")
            //{
            //    try
            //    {//Workbook - 一个个excel文件，经常是使用Workbooks类对其进行操作。
            //        workbook.Saved = true;
            //        workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
            //    }
            //    catch (Exception ex)
            //    {//fileSaved = false;                      
            //        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            //    }
            //}
            //xlApp.Quit();
            //GC.Collect();//强行销毁   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trees_add trees_add = new trees_add();
            trees_add.StartPosition = FormStartPosition.CenterScreen;
            trees_add.TopMost = true;
            trees_add.Show();
        }

        }
    }

