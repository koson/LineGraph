using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LineGraph.SQLUtility
{
      
    public partial class trees_add : Form
    {
        string sql = "";       //查询条件

      
        string strcon = "Data Source=AC;Initial Catalog=GuGong_JianCeDB;User ID=sa;Password=123456;";
        DataSet ds = new DataSet();
        DataTable dt;
        DataRowCollection drc;
        SqlConnection conn;

        public trees_add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 //try
 //           {
 //               string goods_Name = textBox1.Text;
 //               string goods_Property = textBox2.Text;
 //               string confirmPassWord = textBox3.Text;
 //               string goods_Company = textBox4.Text;
 //               string             SN = textBox5.Text;
 //               String goods_Location = textBox6.Text;

 //               sql = "select * from goods2";
 //               SqlDataAdapter myda = new SqlDataAdapter(sql, strcon);
 //               myda.Fill(ds, "tb");
 //               dt = ds.Tables["tb"];
 //               for (int i = 0; i < dt.Rows.Count; i++)
 //               {
 //                   if (goods_Name == dt.Rows[i]["goods_Name"].ToString())
 //                   {
 //                       MessageBox.Show("此类树木已存在！");
 //                       return;
 //                   }
 //               }
 //      if (confirmPassWord == "admin" && goods_Property != "" && confirmPassWord != "")
 //               {
 //                   SqlConnection conn = new SqlConnection(strcon);
 //                   conn.Open();
 //                   sql = "INSERT INTO goods2 (SN,goods_Name,goods_Property,goods_Company,goods_Location) VALUES ('" + SN + "','" + goods_Name + "','" + goods_Property + "','" + goods_Company + "','" + goods_Location + "')";
 //                   SqlCommand cmd = new SqlCommand(sql, conn);
 //                   cmd.ExecuteNonQuery();
 //                   conn.Close();
 //                   this.Close(); //关闭窗体


 //                   EventArgsTest test = new EventArgsTest();
 //                   test.Message = "test message";

 //                   EventTest.SendMessageFunction(sender, test);
 //               }
 //               else
 //               {
 //                   MessageBox.Show("请输入树木管理密钥！");
 //               }

 //           }
 //           catch (Exception ex)
 //           {
 //               MessageBox.Show(ex.Message, "错误提示");
 //           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trees_add_Load(object sender, EventArgs e)
        {

        }
    }
    }

