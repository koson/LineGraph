using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using SuperMap.Data;

namespace LineGraph.SQLUtility
{
    public partial class DeviceCompanyWnd : Form
    {
        public DeviceCompanyWnd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmAddressBook_Load(object sender, EventArgs e)
        {
            LoadList();

            btnDelete.Enabled = false;
        }

        private void LoadList()
        {
            string sql = string.Format("SELECT * FROM DeviceCompany");
            try
            {
                dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                MySqlDataAdapter adapter = MySQLDB.GetMySQLDB().getAdapter(sql);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvList.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //恢复控件的值
            RestControls();

            this.Close();
        }

        /// <summary>
        /// 恢复控件的值
        /// </summary>
        private void RestControls()
        {
            cboDeviceProducer.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 查找
            int num = 0;  // 数据库操作结果              

            try
            {
                // 查询用的sql语句
                string sql = string.Format("SELECT COUNT(*) FROM DeviceCompany WHERE 单位名称='{0}'",
                        cboDeviceProducer.Text.Trim());
                // 创建Command 对象
                MySqlCommand command = MySQLDB.GetMySQLDB().giveCommand(sql);
                num = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "抱歉");
            }

            if (num == 1)  // 验证通过
            {
                MessageBox.Show(("已注册！"), "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                //构造insert语句
                string sql = "INSERT INTO DeviceCompany (单位名称) VALUES(@单位名称)";
                //构造sql语句的参数
                MySqlParameter[] ps = //使用数组初始化器
                {
                new MySqlParameter("@单位名称",cboDeviceProducer.Text),
                };
                //执行插入操作
                int index = MySQLDB.GetMySQLDB().ExecuteNonQuery(sql, ps);

                //添加操作
                if (index > 0)
                {
                    LoadList();

                    //sql = "SELECT @@Identity FROM SensorDevice";  // 查询新增加的记录的标识号
                    //command.CommandText = sql;             // 重新指定 Command 对象的 SQL 语句
                    //Convert.ToInt32(command.ExecuteScalar());  // 强制类型转换会出错
                    MessageBox.Show("注册成功！");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("添加失败，请稍候重试");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //恢复控件的值
            RestControls();
        }

        // 删除传感
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvList.CurrentRow;

            DialogResult result;   // 对话框结果
            int deleteResult = 0;  // 操作结果
            if (row != null)
            {
                result = MessageBox.Show("确实要删除该传感吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // 确认删除
                {
                    string sql = string.Format("DELETE FROM DeviceCompany WHERE 单位名称='{0}'",
                    row.Cells[0].Value.ToString());

                    try
                    {
                        MySqlCommand command = MySQLDB.GetMySQLDB().giveCommand(sql);
                        deleteResult = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (deleteResult == 1)
                    {
                        LoadList();

                        btnDelete.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的传感信息");
            }
        }
    }
}
