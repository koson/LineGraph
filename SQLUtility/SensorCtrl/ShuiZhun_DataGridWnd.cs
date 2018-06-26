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
    public partial class ShuiZhun_DataGridWnd : UserControl
    {
        private int _NextSZIndex;

        public ShuiZhun_DataGridWnd ()
        {
            InitializeComponent();

            _NextSZIndex = 1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void UpdateListView(Data.UDPData data)
        {
            if (this.水准仪listResult.InvokeRequired)
            {
                Action<Data.UDPData> action = new Action<Data.UDPData>(UpdateListView);
                this.Invoke(action, data);
                return;
            }

            int indexOfFirstNotUse = -1;
            for (int i = 0; i < UserHelper.ShuiZhunDataList.Count; ++i)
            {
                if (UserHelper.ShuiZhunDataList[i].Key == data.DeviceID)
                {
                    indexOfFirstNotUse = i;
                    break;
                }
            }

            if (indexOfFirstNotUse == -1)
                return;

            string NOID = UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.strNOID;
            //float 振动初始值 = UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.ZHENDONGO;
            float 沉降初始值 = UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.CHENJIANGO;

            //float 振动测试值 = data.ZHENDONG - UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.ZHENDONGT;
            float 沉降测试值 = data.CHENJIANG- UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.CHENJIANGT;

            //float 振动单次变化量 = data.ZHENDONG;
            float 沉降单次变化量 = data.CHENJIANG;

            //float 振动累计变化量 = data.ZHENDONG - 振动初始值;
            float 沉降累计变化量 = data.CHENJIANG - 沉降初始值;

            //UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.ZHENDONGT = data.ZHENDONG;
            UserHelper.ShuiZhunDataList[indexOfFirstNotUse].Value.CHENJIANGT = data.CHENJIANG;

            this.水准仪listResult.Items.Add(new ListViewItem(
                  new string[]
                  {
                    _NextSZIndex.ToString(),
                    NOID.ToString(),
                    //振动初始值.ToString(),
                    沉降初始值.ToString(),
                    //振动测试值.ToString(),
                    沉降测试值.ToString(),
                    //振动单次变化量.ToString(),
                    沉降单次变化量.ToString(),
                    //振动累计变化量.ToString(),
                    沉降累计变化量.ToString(),
                    data.Time.ToString()
                  })
            {
                BackColor = (0 == _NextSZIndex % 2) ? System.Drawing.Color.LightGray : System.Drawing.Color.Green
            });
            
            if (this.水准仪listResult.Items.Count == 100)
                this.水准仪listResult.Items.RemoveAt(0);

            try
            {
                //构造insert语句
                string sql = "INSERT INTO SensorSZData (ID,NOID,沉降初始值,沉降测试值,沉降单次变化量,沉降累计变化量,TIME) VALUES(@ID,@NOID,@沉降初始值,@沉降测试值,@沉降单次变化量,@沉降累计变化量,@TIME)";
                //构造sql语句的参数
                MySqlParameter[] ps = //使用数组初始化器
                {
                    new MySqlParameter("@ID",_NextSZIndex),
                    new MySqlParameter("@NOID",NOID),
                    new MySqlParameter("@沉降初始值",沉降初始值),
                    new MySqlParameter("@沉降测试值",沉降测试值),
                    new MySqlParameter("@沉降单次变化量",沉降单次变化量),
                    new MySqlParameter("@沉降累计变化量",沉降累计变化量),
                    new MySqlParameter("@TIME",data.Time)
                };
                //执行插入操作
                int index = MySQLDB.GetMySQLDB().ExecuteNonQuery(sql, ps);

                //添加操作
                if (index > 0)
                {
                    //MessageBox.Show("添加成功！");
                    _NextSZIndex++;
                }
                else
                {
                    //MessageBox.Show("添加失败，请稍候重试");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
