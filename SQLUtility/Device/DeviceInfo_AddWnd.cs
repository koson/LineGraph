using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;


namespace LineGraph.SQLUtility
{
    public partial class DeviceInfo_AddWnd : Form
    {
        public DeviceInfo_AddWnd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }
        private DataGridViewRow r;
        private bool isAdd = false;
        private int _NextIndex;

        public DeviceInfo_AddWnd(DataGridViewRow r, bool _isAdd)
        {
            isAdd = _isAdd;
            this.r = r;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _NextIndex = 1;
        }

   
        private void WZDict_Add_Load(object sender, EventArgs e)
        {
            cboDeviceStyle.Items.Clear();
            for(int i = 0;i< UserHelper.nDeviceNum;i++)
            {
                cboDeviceStyle.Items.Add(UserHelper.sDeviceName[i]);
            }

            cboCompany.Items.Clear();
            for (int i = 0; i < UserHelper.nCompanyNum; i++)
            {
                cboCompany.Items.Add(UserHelper.sCompanyName[i]);
            }

            cboProtocolStyle.Items.Clear();
            for (int i = 0; i < UserHelper.nProtocolNum; i++)
            {
                cboProtocolStyle.Items.Add(UserHelper.sProtocolName[i]);
            }

            cboProtocolNO.Items.Clear();
            for (int i = 0; i < UserHelper.nProtocolNONum; i++)
            {
                cboProtocolNO.Items.Add(UserHelper.sProtocolNO[i]);
            }

            if (!this.isAdd)//编辑
            {
                _NextIndex = (int)r.Cells["序号"].Value;

                this.cboDeviceStyle.Text = r.Cells["类型"].Value.ToString();

                this.yTextBox_XH.Text = r.Cells["型号"].Value.ToString();
                
                this.cboCompany.Text = r.Cells["厂家全称和简称"].Value.ToString();

                this.yTextBox_REASON.Text = r.Cells["信息描述"].Value.ToString();

                this.cboProtocolStyle.Text = r.Cells["协议类型"].Value.ToString();

                this.cboProtocolNO.Text = r.Cells["通讯协议"].Value.ToString();

                this.yTextBox_BH.Text = r.Cells["设备编号"].Value.ToString();

                this.ytDateTime_MakeTime.Value = Convert.ToDateTime(r.Cells["制定日期"].Value);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!this.isAdd)//编辑
            {
                string query = "UPDATE SensorProducer SET 类型=@类型,型号=@型号,厂家全称和简称=@厂家全称和简称 ,信息描述=@信息描述 ,协议类型=@协议类型,通讯协议=@通讯协议,设备编号=@设备编号,制定日期=@制定日期, WHERE 序号=@序号";
                MySqlCommand cmd = MySQLDB.GetMySQLDB().giveCommand(query);
                cmd.Parameters.Add("@序号", MySqlDbType.VarChar).Value = this._NextIndex;
                cmd.Parameters.Add("@类型", MySqlDbType.VarChar).Value = this.cboDeviceStyle.Text;
     
                cmd.Parameters.Add("@型号", MySqlDbType.VarChar).Value = this.yTextBox_XH.Text;
           
                cmd.Parameters.Add("@厂家全称和简称", MySqlDbType.VarChar).Value = this.cboCompany.Text;
           
                cmd.Parameters.Add("@信息描述", MySqlDbType.VarChar).Value = this.yTextBox_REASON.Text;

                cmd.Parameters.Add("@协议类型", MySqlDbType.VarChar).Value = this.cboProtocolStyle.Text;
                cmd.Parameters.Add("@通讯协议", MySqlDbType.VarChar).Value = this.cboProtocolNO.Text;
                cmd.Parameters.Add("@设备编号", MySqlDbType.VarChar).Value = this.yTextBox_BH.Text;

                cmd.Parameters.Add("@制定日期", MySqlDbType.VarChar).Value = this.ytDateTime_MakeTime.Text;
   
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }

            }
            else
            {
                string query = "INSERT INTO SensorProducer(序号,类型,型号,厂家全称和简称,信息描述,协议类型,通讯协议,设备编号,制定日期) VALUES (@序号,@类型,@型号,@厂家全称和简称,@信息描述,@协议类型,@通讯协议,@设备编号,@制定日期)";
                MySqlCommand cmd = MySQLDB.GetMySQLDB().giveCommand(query);
                cmd.Parameters.Add("@序号", MySqlDbType.VarChar).Value = this._NextIndex;
                cmd.Parameters.Add("@类型", MySqlDbType.VarChar).Value = this.cboDeviceStyle.Text;
                cmd.Parameters.Add("@型号", MySqlDbType.VarChar).Value = this.yTextBox_XH.Text;
                cmd.Parameters.Add("@厂家全称和简称", MySqlDbType.VarChar).Value = this.cboCompany.Text;
                cmd.Parameters.Add("@信息描述", MySqlDbType.VarChar).Value = this.yTextBox_REASON.Text;
                cmd.Parameters.Add("@协议类型", MySqlDbType.VarChar).Value = this.cboProtocolStyle.Text;
                cmd.Parameters.Add("@通讯协议", MySqlDbType.VarChar).Value = this.cboProtocolNO.Text;
                cmd.Parameters.Add("@设备编号", MySqlDbType.VarChar).Value = this.yTextBox_BH.Text;
                cmd.Parameters.Add("@制定日期", MySqlDbType.VarChar).Value = this.ytDateTime_MakeTime.Text;
                
                if (cmd.ExecuteNonQuery() == 1)
                {
                    _NextIndex++;
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }

            }

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            //OpenFileDialog img = new OpenFileDialog();
            //img.Filter = "Choose Image (*.JPG;*.PNG) | *.jpg;*.png";

            //if (img.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBoxDevice.Image = Image.FromFile(img.FileName);
            //}
        }

    }
}
