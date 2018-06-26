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
    public partial class User_add : Form
    {
        string sql = "";       //查询条件

        // string strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BGKDB.MDB;";
        string strcon = "Data Source=AC;Initial Catalog=GuGong_JianCeDB;User ID=sa;Password=123456;";
        DataSet ds = new DataSet();
        DataTable dt;
        //DataRowCollection drc;
        public User_add()
        {
            InitializeComponent();
        }

        //确定提交
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = textBox1.Text;
                string passWord = textBox2.Text;
                string confirmPassWord = textBox3.Text;

                sql = "select * from Users";
                SqlDataAdapter myda = new SqlDataAdapter(sql, strcon);
                myda.Fill(ds, "tb");
                dt = ds.Tables["tb"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (userName == dt.Rows[i]["UserName"].ToString())
                    {
                        MessageBox.Show("用户已存在！");
                        return;
                    }
                }
                if (passWord == confirmPassWord && passWord != "" && confirmPassWord != "")
                {
                    SqlConnection conn = new SqlConnection(strcon);
                    conn.Open();
                    sql = "INSERT INTO Users (UserName,UserPassWord,UserAccess) VALUES ('" + userName + "','" + passWord + "','1')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Close(); //关闭窗体


                    //EventArgs test = new EventArgs();
                    //test.Message = "test message";

                    //EventTest.SendMessageFunction(sender, test);
                }
                else
                {
                    MessageBox.Show("密码不一致！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addUser_Load(object sender, EventArgs e)
        {

        }
    }
}
