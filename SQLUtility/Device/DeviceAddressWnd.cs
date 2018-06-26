using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using SuperMap.Data;

namespace LineGraph.SQLUtility
{
    public partial class DeviceAddressWnd : Form
    {
        public delegate void CameraDataAdjustEventHandler(object sender);
        public event CameraDataAdjustEventHandler CameraDataAdjustHandler;

        public delegate void AddModelIDEventHandler(object sender);
        public event AddModelIDEventHandler AddModelIDHandler;

        public delegate void AddModelEventHandler(object sender);
        public event AddModelEventHandler AddModelHandler;

        public delegate void DeleteModelEventHandler(object sender, EventArgs e);
        public event DeleteModelEventHandler DeleteModelHandler;

        private Point3D m_point3D;
        public int nModelIndex = 0;
        public string strModelID;
        public string strModelNOID;

        private DeviceAddressWnd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private static DeviceAddressWnd _frm;

        public static DeviceAddressWnd Create()
        {
            if (_frm == null)
            {
                _frm = new DeviceAddressWnd();
            }
            return _frm;
        }


        public void SetSaveStatus(bool bSave)
        {
            if(bSave)
            {
                btnSave.Text = "添加";
            }
            else
            {
                btnSave.Text = "修改";
            } 
        }

        public void SetModelPoint(Point3D point3D)
        {
            m_point3D = point3D;
        }

        public void UpdateView()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + "AdrCfg";

            StreamWriter outputFile = File.CreateText(strPath);

            for (int GroupIndex = 0; GroupIndex < UserHelper.nDeviceNum; GroupIndex++)
            {
                ShowDeviceList(GroupIndex, outputFile);
            }

            outputFile.Close();
        }

        private void FrmAddressBook_Load(object sender, EventArgs e)
        {
            cboDeviceStyle.Items.Clear();
            for (int i = 0; i < UserHelper.nDeviceNum; i++)
            {
                cboDeviceStyle.Items.Add(UserHelper.sDeviceName[i]);
            }

            cboDeviceProducer.Items.Clear();
            for (int i = 0; i < UserHelper.nCompanyNum; i++)
            {
                cboDeviceProducer.Items.Add(UserHelper.sCompanyName[i]);
            }


            //string sql = string.Format("SELECT * FROM SensorProducer");
            //try
            //{
            //    MySqlCommand command = MySQLDB.GetMySQLDB().giveCommand(sql);
            //    MySqlDataReader reader = command.ExecuteReader();  // 执行查询

            //    cboDeviceProducer.Items.Clear();
            //    while (reader.Read())
            //    {
            //        cboDeviceProducer.Items.Add(reader["厂家全称和简称"]);
            //    }
            //    reader.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadList();

            btnDelete.Enabled = false;
        }

        private void LoadList()
        {
            //SensorDeviceTable = { "ID", "单位名称", "类型", "ADRNO", "DTUID", "POS_X", "POS_Y", "POS_Z" };

            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT DEVICEID,单位名称,类型,ADRNO,DTUID FROM SensorDevice";
            MySqlDataAdapter adapter = MySQLDB.GetMySQLDB().getAdapter(query);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvList.DataSource = table;
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
            cboDeviceStyle.Text = "";
            cboDeviceProducer.Text = "";
            textSensorID.Text = "";
            txtSensorADR.Text = "";
            txtDTUID.Text = "";

        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取双击的行数据
            var row = dgvList.Rows[e.RowIndex];
            //将行中的数据显示到控件中

            textSensorID.Text = row.Cells[0].Value.ToString();
            cboDeviceProducer.Text = row.Cells[1].Value.ToString();
            cboDeviceStyle.Text = row.Cells[2].Value.ToString();
            txtSensorADR.Text = row.Cells[3].Value.ToString();
            txtDTUID.Text = row.Cells[4].Value.ToString();

            btnSave.Text = "修改";

            btnDelete.Enabled = true;

            //获取行数据
            string sql = string.Format("SELECT * FROM SensorDevice WHERE DEVICEID='{0}'",
                    row.Cells[0].Value.ToString());

            double PosX = 0, PosY = 0;
            bool error = false;    // 标识是否出现错误
            try
            {
                // 查询
                MySqlCommand command = MySQLDB.GetMySQLDB().giveCommand(sql);
                MySqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    PosX = Convert.ToDouble(dataReader["POS_X"]);
                    PosY = Convert.ToDouble(dataReader["POS_Y"]);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show(ex.Message);
            }
            if (!error)
            {
                GeoPoint gp = new GeoPoint(PosX, PosY);
                sender = gp;
                if (CameraDataAdjustHandler != null)
                {
                    CameraDataAdjustHandler(sender);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //判断输入有效性
            if (string.IsNullOrWhiteSpace(cboDeviceStyle.Text))
            {
                MessageBox.Show("请输入类型");
                cboDeviceStyle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cboDeviceProducer.Text))
            {
                MessageBox.Show("请输入单位");
                cboDeviceStyle.Focus();
                return;
            }

            if (textSensorID.Text.Trim() == "")
            {
                MessageBox.Show("请输入设备ID！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSensorADR.Focus();
                return;
            }

            if (txtSensorADR.Text.Trim() == "")
            {
                MessageBox.Show("请输入地址！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSensorADR.Focus();
                return ;
            }

            if (txtDTUID.Text.Trim() == "")
            {
                MessageBox.Show("请输入DTUID！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTUID.Focus();
                return;
            }

        
            //接收用户输入数据
            AddressBook address = new AddressBook()
            {
                Style = cboDeviceStyle.Text,
                Company = cboDeviceProducer.Text,
                SENSORID = textSensorID.Text,
                NOID = txtSensorADR.Text,
                DTUId = txtDTUID.Text
            };
            if (btnSave.Text.Equals("添加"))
            {
                // 查找
                int num = 0;  // 数据库操作结果              

                try
                {
                    // 查询用的sql语句
                    string sql = string.Format("SELECT COUNT(*) FROM SensorDevice WHERE DEVICEID='{0}'",
                            textSensorID.Text.Trim());
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
                    MessageBox.Show(("ID已注册！"), "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // 查询用的sql语句
                    string sql = string.Format("SELECT COUNT(*) FROM SensorDevice WHERE DEVICEID='{0}'",
                            textSensorID.Text.Trim());
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
                    MessageBox.Show(("编号已注册！"), "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    
                    nModelIndex = cboDeviceStyle.SelectedIndex;
                    strModelID = textSensorID.Text;
                    strModelNOID = txtSensorADR.Text;

                    if (nModelIndex == 0)
                    {
                        UserHelper.ShuiZhunData ShuiZhunData = new UserHelper.ShuiZhunData();
                        ShuiZhunData.strNOID = strModelNOID;
                        strModelID = "SZ" + strModelNOID;
                        UserHelper.ShuiZhunDataList.Add(new KeyValuePair<string, UserHelper.ShuiZhunData>(strModelID, ShuiZhunData));
                    }

                    if (nModelIndex == 1)
                    {
                        UserHelper.QINGJIAOData QINGJIAOData = new UserHelper.QINGJIAOData();
                        QINGJIAOData.strNOID = strModelNOID;
                        strModelID = "QJ" + strModelNOID;
                        UserHelper.QINGJIAODataList.Add(new KeyValuePair<string, UserHelper.QINGJIAOData>(strModelID, QINGJIAOData));
                    }

                    if (nModelIndex == 2)
                    {
                        UserHelper.JIASUDUData JIASUDUData = new UserHelper.JIASUDUData();
                        JIASUDUData.strNOID = strModelNOID;
                        strModelID = "JS" + strModelNOID;
                        UserHelper.JIASUDUDataList.Add(new KeyValuePair<string, UserHelper.JIASUDUData>(strModelID, JIASUDUData));
                    }

                    //构造insert语句
                    string sql = "INSERT INTO SensorDevice (DEVICEID,单位名称,类型,ADRNO,DTUID,POS_X,POS_Y,POS_Z) VALUES(@DEVICEID,@单位名称,@类型,@ADRNO,@DTUID,@POS_X,@POS_Y,@POS_Z)";
                    //构造sql语句的参数
                    MySqlParameter[] ps = //使用数组初始化器
                    {
                    new MySqlParameter("@DEVICEID",address.SENSORID),
                    new MySqlParameter("@单位名称",address.Company),
                    new MySqlParameter("@类型",address.Style),
                    new MySqlParameter("@ADRNO",address.NOID),
                    new MySqlParameter("@DTUID",address.DTUId),
                    new MySqlParameter("@POS_X",m_point3D.X),
                    new MySqlParameter("@POS_Y",m_point3D.Y),
                    new MySqlParameter("@POS_Z",m_point3D.Z)
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
    
            }
            else
            {
                //修改操作
                //构造sql语句及参数
                string sql = "UPDATE SensorDevice SET DEVICEID=@DEVICEID,单位名称=@单位名称,类型=@类型,ADRNO=@ADRNO,DTUID=@DTUID WHERE DEVICEID=@DEVICEID";
                MySqlParameter[] ps =
                {
                    new MySqlParameter("@DEVICEID",address.SENSORID),
                    new MySqlParameter("@单位名称",address.Company),
                    new MySqlParameter("@类型",address.Style),
                    new MySqlParameter("@ADRNO",address.NOID),
                    new MySqlParameter("@DTUID",address.DTUId)
                };
                //执行并返回
                int index = MySQLDB.GetMySQLDB().ExecuteNonQuery(sql, ps);
                if (index > 0)
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍候重试");
                }
            }

            //恢复控件的值
            RestControls();
        }

        private void ShowDeviceList(int GroupIndex, StreamWriter outputFile)
        {
            // 查找
             string sql = string.Format(
            "SELECT * FROM SensorDevice WHERE 类型 like '%{0}%'", UserHelper.sDeviceName[GroupIndex].Trim());

            try
            {
                // 执行查询
                MySqlCommand command = MySQLDB.GetMySQLDB().giveCommand(sql);
                MySqlDataReader dataReader = command.ExecuteReader();
                double PosX = 0, PosY = 0, PosZ = 0;
                // 循环添加列表
                while (dataReader.Read())
                {
                    string strID = dataReader["DEVICEID"].ToString();
                    string strNOID = dataReader["ADRNO"].ToString();

                    if (AddModelIDHandler != null)
                    {
                        List<string> lst = new List<string>();
                        lst.Add(strID);
                        lst.Add(strNOID);

                        object sender = lst;
                        AddModelIDHandler(sender);
                    }

                    //{ "水准仪", "倾角仪", "加速计" };
                    if (GroupIndex == 0)
                    {
                        UserHelper.ShuiZhunData ShuiZhunData = new UserHelper.ShuiZhunData();
                        ShuiZhunData.strNOID = strNOID;
                        strID = "SZ" + strNOID;
                        UserHelper.ShuiZhunDataList.Add(new KeyValuePair<string, UserHelper.ShuiZhunData>(strID, ShuiZhunData));
                    }

                    if (GroupIndex == 1)
                    {
                        UserHelper.QINGJIAOData QINGJIAOData = new UserHelper.QINGJIAOData();
                        QINGJIAOData.strNOID = strNOID;
                        strID = "QJ" + strNOID;
                        UserHelper.QINGJIAODataList.Add(new KeyValuePair<string, UserHelper.QINGJIAOData>(strID, QINGJIAOData));
                    }

                    if (GroupIndex == 2)
                    {
                        UserHelper.JIASUDUData JIASUDUData = new UserHelper.JIASUDUData();
                        JIASUDUData.strNOID = strNOID;
                        strID = "JS" + strNOID;
                        UserHelper.JIASUDUDataList.Add(new KeyValuePair<string, UserHelper.JIASUDUData>(strID, JIASUDUData));
                    }

                    char[] buffer = new char[2];
                    buffer[0] = (char)GroupIndex;
                    int byteArray = int.Parse(strNOID); 
                    buffer[1] = (char)byteArray;
                    outputFile.WriteLine(buffer);

                    if (AddModelHandler != null)
                    {
                        PosX = Convert.ToDouble(dataReader["POS_X"]);
                        PosY = Convert.ToDouble(dataReader["POS_Y"]);
                        PosZ = Convert.ToDouble(dataReader["POS_Z"]);

                        Point2Ds Point2Ds = new Point2Ds();
                        Point2D gp1D = new Point2D(PosX, PosY);
                        Point2D gp2D = new Point2D(PosZ, GroupIndex);
                        Point2Ds.Add(gp1D);
                        Point2Ds.Add(gp2D);

                        object sender = Point2Ds;
                        AddModelHandler(sender);

                        GeoPoint gp = new GeoPoint(PosX, PosY);
                        sender = gp;
                        if (CameraDataAdjustHandler != null)
                        {
                            CameraDataAdjustHandler(sender);
                        }
                    }
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    string sql = string.Format("DELETE FROM SensorDevice WHERE DEVICEID='{0}'",
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
                        if (DeleteModelHandler != null)
                        {
                            sender = row.Cells[0].Value.ToString();
                            DeleteModelHandler(sender, e);
                        }

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
