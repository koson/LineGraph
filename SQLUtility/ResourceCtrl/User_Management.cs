using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
//using System.Data.SqlClient;

namespace LineGraph.SQLUtility
{
    public partial class User_Management : Form
    {
        string sql = "";       //查询条件
        // string strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BGKDB.MDB;";
        //string strcon = "Data Source=AC;Initial Catalog=GuGong_JianCeDB;User ID=sa;Password=123456;";
        DataSet ds = new DataSet();
        //DataTable dt;
       // DataRowCollection drc;

        public User_Management()
        {
            InitializeComponent();
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //填充表格

            //EventTest.message += EventTest_message; //委托通信
        }

        //添加用户后查询
        public void EventTest_message(object sender, EventArgs e)
        {
            //   MessageBox.Show("test");
            userQuery();
        }

        private void userManagement_Load(object sender, EventArgs e)
        {
            userQuery();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            userQuery();
        }

        //用户查询
        private void userQuery()
        {
            try
            {
                string condition = " 1=1 ";
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    condition = condition + " and UserName like '%" + comboBox2.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(comboBox1.Text) && comboBox1.Text != "全部")
                {
                    condition += "and UserAccess='" + comboBox1.Text + "'";
                }

                sql = "select * from Users";
                sql = "select UserID as 序号, UserName as 用户名, UserPassWord as 密码, UserAccess as 权限 from Users";
                if (!string.IsNullOrEmpty(condition))
                {
                    sql += " where " + condition;
                }

                //SqlDataAdapter myda = new SqlDataAdapter(sql, strcon);

                //myda.Fill(ds, "tb");
                //dt = ds.Tables["tb"];
                //if (dt.Rows.Count > 0)
                //{
                //    dataGridView2.DataSource = null;
                //    //dataGridView2.DataSource = dt;
                //    ds.Tables.Clear();//清除ds中的表
                //    ds.Clear();       //清空ds

                //    //DataGridViewLinkColumn dlink = new DataGridViewLinkColumn();
                //    //dlink.Text = "删除";//添加的这列的显示文字，即每行最后一列显示的文字。
                //    //dlink.Name = "linkDelete";
                //    //dlink.HeaderText = "删除";//列的标题
                //    //dlink.UseColumnTextForLinkValue = true;//上面设置的dlink.Text文字在列中显示
                //    //dataGridView2.Columns.Insert(4, dlink);//将创建的列添加到UserdataGridView中
                //    dt.Columns.Add("删除");

                //    drc = dt.Rows;
                //    dataGridView2.DataSource = dt.DefaultView;

                //    dataGridView2.ClearSelection();
                //    dataGridView2.AllowUserToAddRows = false; //不显示最后空白行
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提示");
            }

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (e.Value != null && e.Value.ToString().Length > 0)
                    {
                        e.Value = new string('*', e.Value.ToString().Length);
                    }
                }
                if (e.ColumnIndex == 3)
                {

                    //       int val = Convert.ToInt32(e.Value);
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.Value = "管理员";
                            break;
                        case "1":
                            e.Value = "普通用户";
                            break;
                        default:
                            break;
                    }
                    e.FormattingApplied = true;

                }
                if (e.ColumnIndex == 4)
                {
                    e.Value = "删除";
                    e.CellStyle.ForeColor = Color.Blue;//设置单元的字的颜色
                    e.CellStyle.Font = new Font("宋体", 9, FontStyle.Underline); //设置字体样式
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        //dataGridView单元格点击事件
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dataGridView2.Columns["删除"].Index)
                {
                    int rows = dataGridView2.CurrentRow.Index; //得到当前行的索引
                    string id = dataGridView2.Rows[rows].Cells[0].Value.ToString(); //得到表的主键ID，就是上表中的userid

                    //if (id != null && id != "" && MessageBox.Show("您确定要删除吗？", "重要提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    SqlConnection conn = new SqlConnection(strcon);
                    //    conn.Open();
                    //    sql = "delete from Users where UserID=" + id;
                    //    SqlCommand cmd = new SqlCommand(sql, conn);
                    //    cmd.ExecuteNonQuery();
                    //    conn.Close();

                    //    drc.RemoveAt(rows);
                    //    dataGridView2.DataSource = dt;
                    //}
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

        //添加用户
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            User_add addUser = new User_add();
            addUser.ShowDialog();
        }

        private void Form1_Closeing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
