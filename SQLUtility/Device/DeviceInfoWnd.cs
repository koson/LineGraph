using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace LineGraph.SQLUtility
{
    public partial class DeviceInfoWnd : Form
    {
        public DeviceInfoWnd()
        {
            InitializeComponent();
        }

        private void WZDictManag_Load(object sender, EventArgs e)//窗体加载
        {
            ShowInfo("");
        }

        public void ShowInfo(string searchValue)
        {
            string query = "SELECT * FROM SensorProducer WHERE CONCAT(序号,类型,型号,厂家全称和简称,信息描述,协议类型,通讯协议,设备编号,制定日期) LIKE '%" + searchValue + "%'";

            MySqlDataAdapter adapter = MySQLDB.GetMySQLDB().getAdapter(query);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGView_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGView_Main.RowTemplate.Height = 60;
            dataGView_Main.AllowUserToAddRows = false;
            dataGView_Main.DataSource = table;
        }


        private void toolStripButtonAdd_Click(object sender, EventArgs e)//新增
        {
            DeviceInfo_AddWnd ks = new DeviceInfo_AddWnd(null, true);
            
            if (ks.ShowDialog() == DialogResult.OK)
            {
                ShowInfo("");
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)//修改
        {
           DataGridViewRow row =  this.dataGView_Main.CurrentRow;

            if (row != null)
            {
                DeviceInfo_AddWnd ks = new DeviceInfo_AddWnd(row, false);
                ks.ShowDialog();
              
            }
            else
            {
                MessageBox.Show("请选择要编辑的请购信息");
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)//删除
        {
            DataGridViewRow row = this.dataGView_Main.CurrentRow;
            if (row != null)
            {
                DialogResult result = MessageBox.Show("确定要删除选择的设备信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // 确认删除
                {
                    
                    string query = "DELETE FROM SensorProducer WHERE 序号=@序号";
                    MySqlCommand cmd = MySQLDB.GetMySQLDB().giveCommand(query);
                    cmd.Parameters.Add("@序号", MySqlDbType.VarChar).Value = row.Cells["序号"];

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Data Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Insertion Failed");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的设备信息");
            }
        }

        private void toolStripButtonShow_Click(object sender, EventArgs e)//查看
        {
            ShowInfo("");
        }

        private void Search_button_Click(object sender, EventArgs e) //浏览
        {
            //ShowInfo(textBoxSearch.Text);
            //this.dataGView_Main.ClearData();

            ////添加查询条件及其参数
            //if (this.comboBox1.Value != null)
            //{
            //    if (this.comboBox1.Value.Trim().Length > 0)
            //    {
            //        //添加查询条件及其参数
            //        if (this.comboBox1.Value != "9")
            //            sql.Add("and STATUS = ?", this.comboBox1.Value.Trim());

            //    }
            //}
            //else
            //{
            //    WJs.alert("请选择状态！");
            //    return;
            //}
            //sql.Add("and PLANDATE <= ?", this.dateTimePicker2.Value);

            //sql.Add("and PLANDATE >= ?", this.dateTimePicker1.Value);

        }
    }
}
