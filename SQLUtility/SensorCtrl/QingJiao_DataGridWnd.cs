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
    public partial class QingJiao_DataGridWnd : UserControl
    {
        private long _NextQJIndex;

        public QingJiao_DataGridWnd()
        {
            InitializeComponent();

            _NextQJIndex = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void UpdateListView(Data.UDPData data)
        {
            if (this.倾角仪listResult.InvokeRequired)
            {
                Action<Data.UDPData> action = new Action<Data.UDPData>(UpdateListView);
                this.Invoke(action, data);
                return;
            }

            int indexOfFirstNotUse = -1;
            for (int i = 0; i < UserHelper.QINGJIAODataList.Count; ++i)
            {
                if (UserHelper.QINGJIAODataList[i].Key == data.DeviceID)
                {
                    indexOfFirstNotUse = i;
                    break;
                }
            }

            if (indexOfFirstNotUse == -1)
                return;

            string NOID = UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.strNOID;
            float X初始值 = UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.QINGJIAO_OX;
            float Y初始值 = UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.QINGJIAO_OY;


            float X测试值 = data.QINGJIAO_X;
            float Y测试值 = data.QINGJIAO_Y;

            float X单次变化量 = data.QINGJIAO_X - UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.QINGJIAO_TX;
            float Y单次变化量 = data.QINGJIAO_Y - UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.QINGJIAO_TY;


            float X累计变化量 = data.QINGJIAO_X - X初始值;
            float Y累计变化量 = data.QINGJIAO_Y - Y初始值;


            UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.QINGJIAO_TX = data.QINGJIAO_X;
            UserHelper.QINGJIAODataList[indexOfFirstNotUse].Value.QINGJIAO_TY = data.QINGJIAO_Y;

            this.倾角仪listResult.Items.Add(new ListViewItem(
                  new string[]
                  {
                    _NextQJIndex.ToString(),
                       NOID,
                    X初始值.ToString(),
                    Y初始值.ToString(),
                    X测试值.ToString(),
                    Y测试值.ToString(),
                    X单次变化量.ToString(),
                    Y单次变化量.ToString(),
                    X累计变化量.ToString(),
                    Y累计变化量.ToString(),
                    data.Time.ToString()
                  })
            {
                BackColor = (0 == _NextQJIndex % 2) ? System.Drawing.Color.LightGray : System.Drawing.Color.Green
            });
            

            if (this.倾角仪listResult.Items.Count == 100)
                this.倾角仪listResult.Items.RemoveAt(0);

            try
            {
                //构造insert语句
                string sql = "INSERT INTO SensorQJData (ID,NOID,X初始值,Y初始值,X测试值,Y测试值,X单次变化量,Y单次变化量,X累计变化量,Y累计变化量,TIME) VALUES(@ID,@NOID,@X初始值,@Y初始值,@X测试值,@Y测试值,@X单次变化量,@Y单次变化量,@X累计变化量,@Y累计变化量,@TIME)";
                //构造sql语句的参数
                MySqlParameter[] ps = //使用数组初始化器
                {
                    new MySqlParameter("@ID",_NextQJIndex),
                    new MySqlParameter("@NOID",NOID),
                    new MySqlParameter("@X初始值",X初始值),
                    new MySqlParameter("@Y初始值",Y初始值),
                    new MySqlParameter("@X测试值",X测试值),
                    new MySqlParameter("@Y测试值",Y测试值),
                    new MySqlParameter("@X单次变化量",X单次变化量),
                    new MySqlParameter("@Y单次变化量",Y单次变化量),
                    new MySqlParameter("@X累计变化量",X累计变化量),
                    new MySqlParameter("@Y累计变化量",Y累计变化量),
                    new MySqlParameter("@TIME",data.Time)
                };
                //执行插入操作
                int index = MySQLDB.GetMySQLDB().ExecuteNonQuery(sql, ps);

                //添加操作
                if (index > 0)
                {
                    //MessageBox.Show("添加成功！");
                    _NextQJIndex++;
                }
                else
                {
                    //MessageBox.Show("添加失败，请稍候重试");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
