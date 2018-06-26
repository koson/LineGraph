using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LineGraph.SQLUtility
{
    public partial class LoginDingZhou : Form
    {
     
        public LoginDingZhou()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void m_buttonOK_Click(object sender, EventArgs e)
        {
            // 如果输入验证成功，就验证身份，并转到相应的窗体
            if (ValidateInput())
            {
                int num = 0;  // 数据库操作结果              

                try
                {
                    // 查询用的sql语句
                    //string sql = string.Format("SELECT COUNT(*) FROM Users WHERE ID={0} AND LoginPwd = '{1}'",
                    //    int.Parse(m_textBoxUser.Text.Trim()), m_textBoxPassword.Text.Trim());

                    string sql = string.Format("SELECT COUNT(*) FROM Users WHERE ID='{0}' AND LoginPwd = '{1}'",
                       (m_textBoxUser.Text.Trim()), m_textBoxPassword.Text.Trim());
                    // 创建Command 对象
                    MySqlCommand command = MySQLDB.GetMySQLDB().giveCommand(sql);
                    num = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "登录提示");
                }

                if (num == 1)  // 验证通过
                {
                    // 设置登录的用户号码
                    //UserHelper.loginId = int.Parse(m_textBoxUser.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("输入的用户名或密码有误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool ValidateInput()
        {
            // 验证用户输入
            if (m_textBoxUser.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录的号码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_textBoxUser.Focus();
                return false;
            }
            else if (m_textBoxPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_textBoxPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
