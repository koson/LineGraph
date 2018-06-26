using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using ZedGraph;
using System.Data.SqlClient;

namespace LineGraph.GUI
{
    public partial class TempratureControlWnd : Form
    {
        static bool _continue;
        static bool _show = false;
        public static bool isRecord = false;   //是否同时记录到数据库
        public static int tim1 = 3000;         //传感器节点扫描周期时间 ms
        public static int rx = 5;             //节点掉线扫描灵敏度 * tim1 = 掉线时间判断

        bool ax = false;                        //鼠标左键标识
        public static DataTable dt;           //实时监测数据
        public static Image Rou = null;       //节点显示路由图片
        public static Image Rfd = null;       //节点显示终端图片
        public static Image bgimage = null;    //背景显示图片
        public static string select = "";     //鼠标选择的节点
        public static int nodei = 1;          //查看结点i的数据
        public static int columni = 1;          //columni=1表示查看温度，=2表示查看湿度
        public static string strConnection = "";  //数据库连接语句

        static string sts = "";　　　　    　//下位机送上来的字符串

        PointPairList list = new PointPairList();    //结点一温度
        PointPairList list1 = new PointPairList();   //结点二温度
        PointPairList list2 = new PointPairList();   //结点三温度
        PointPairList slist = new PointPairList();    //结点一湿度
        PointPairList slist1 = new PointPairList();   //结点二湿度
        PointPairList slist2 = new PointPairList();   //结点三湿度
        LineItem myCurve;
  
        string[,] Node = null;                //网络节点字符串数组
        TOPO to = new TOPO();

        public TempratureControlWnd()
        {
            InitializeComponent();

            Rou = Image.FromFile(Application.StartupPath + "\\image\\NodeRouter.bmp");
            Rfd = Image.FromFile(Application.StartupPath + "\\image\\NodeEnd.bmp");

            ///
            ///表格数据初始化节点数据表
            ///
            to.bitmap(pictureBox1.Width, pictureBox1.Height);
            dt = new DataTable();
            dt.Columns.Add("idm");                //节点ID编码
            dt.Columns.Add("wd");                 //节点温度
            dt.Columns.Add("sd");                 //节点湿度
            dt.Columns.Add("ontime");             //连接时刻

            for (int i = 1; i < 50; i++)
            {
                _serialPort.PortName = "COM" + i.ToString();
                try
                {
                    _serialPort.Open();
                    _serialPort.Close();
                    comboBox1.Text = "COM" + i.ToString();
                    button3.Enabled = true;

                }
                catch
                {
                    // str += "端口：COM" + i.ToString() + "不可用" + "\r\n";
                }
            }

            if (comboBox1.Text == null)
                MessageBox.Show("1~50串口均不可用，请手动查看设备管理器或检查串口连接是否正常");

            // Allow the user to set the appropriate properties.
            _serialPort.PortName = comboBox1.Text;
            _serialPort.BaudRate = _serialPort.BaudRate;
            _serialPort.Parity = _serialPort.Parity;
            _serialPort.DataBits = _serialPort.DataBits;
            _serialPort.StopBits = _serialPort.StopBits;
            _serialPort.Handshake = _serialPort.Handshake;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            Thread readThread = new Thread(Read);
            readThread.Start();

            _serialPort.Close();
            _serialPort.Open();
            _continue = true;
            _show = false;          
        }

        public void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = "";
                    if (!_serialPort.IsOpen)
                    {
                        message = "false";
                    }

                    if (_serialPort.IsOpen)
                    {
                        message = _serialPort.ReadLine();
                        if(_show)
                            textBox1.AppendText(message);
                    }

                }
                catch (TimeoutException) { }
                //finally { Thread.Sleep(10); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            this.zedGraphControl1.GraphPane.Title.Text = "动态折线图";
            this.zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
            this.zedGraphControl1.GraphPane.YAxis.Title.Text = "温度（°C）";
            this.zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;

            for (int i = 0; i < 100; i++)
            {
                double x = (double)new XDate(DateTime.Now.AddSeconds(-(100 - i)));
                double y = 0;
                list.Add(x, y);
                list1.Add(x, y);
                list2.Add(x, y);
            }

            DateTime dt = DateTime.Now;

            myCurve = zedGraphControl1.GraphPane.AddCurve("结点1",
                list, Color.DarkGreen, SymbolType.None);

            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            rx = Convert.ToInt32(numericUpDown2.Value);
            tim1 = Convert.ToInt32(numericUpDown1.Value * 1000);
            timer1.Interval = tim1;
            timer1.Start();
            MessageBox.Show("OK!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "开始连接")
            {
                sts = "";
                timer1.Stop();
                _serialPort.Close();
                to.Clear();
                dt.Rows.Clear();
                Node = null;

                try
                {
                    _serialPort.PortName = comboBox1.Text;
                    _serialPort.Open();

                    _serialPort.WriteLine(String.Format("{0}", "1234"));     //启动监测
                    _show = true;

                    getStrConnection();   //获取数据库信息
                    isRecord = true;      //启动记录

                    Thread.Sleep(200);
                    button3.Text = "断开连接";
                    timer1.Start();
                    tabControl1.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                button3.Text = "开始连接";

                _continue = false;
                _show = false;

                timer1.Stop();
                _serialPort.Close();
                sts = "";
                to.Clear();
                dt.Rows.Clear();
                Node = null;
            }
        }

        private void getStrConnection()
        {
            int i = 0;
            string str="";
            string strIP = "";
            string strDB = "";
            string strUID = "";
            string strPSW = "";
            using (FileStream fs = File.Open("serverfile.txt", FileMode.Open))
            {
                StreamReader sr = new StreamReader(fs);
                fs.Seek(0, SeekOrigin.Begin);
                str = sr.ReadToEnd();
            }

            for (i = 0; i < str.Length; i++)
            {
                if (strIP==""&&(str.Substring(i, 1) == " " || str.Substring(i, 1) == "\n"))
                {
                    continue;
                }
                else if (str.Substring(i, 1) != " "&& str.Substring(i, 1) != "\n")
                {
                    strIP += str.Substring(i, 1);
                }
                else
                {
                    i++;
                    break;
                }               
            }

            for (; i < str.Length; i++)
            {
                if (strDB == "" && (str.Substring(i, 1) == " " || str.Substring(i, 1) == "\n"))
                {
                    continue;
                }
                else if (str.Substring(i, 1) != " " && str.Substring(i, 1) != "\n")
                {
                    strDB += str.Substring(i, 1);
                }
                else
                {
                    i++;
                    break;
                }
            }

            for (; i < str.Length; i++)
            {
                if (strUID == "" && (str.Substring(i, 1) == " " || str.Substring(i, 1) == "\n"))
                {
                    continue;
                }
                else if (str.Substring(i, 1) != " " && str.Substring(i, 1) != "\n")
                {
                    strUID += str.Substring(i, 1);
                }
                else
                {
                    i++;
                    break;
                }
            }

            for (; i < str.Length; i++)
            {
                if (strPSW == "" && (str.Substring(i, 1) == " " || str.Substring(i, 1) == "\n"))
                {
                    continue;
                }
                else if (str.Substring(i, 1) != " " && str.Substring(i, 1) != "\n")
                {
                    strPSW += str.Substring(i, 1);
                }
                else
                {
                    i++;
                    break;
                }
            }

            if (strPSW == "")
                MessageBox.Show("数据库配置填写有误，请检查serverfile.txt");
            else
            {
                strConnection = "";
                strConnection += "Data Source = ";
                strConnection += strIP;
                strConnection += ";database = ";
                strConnection += strDB;
                strConnection += ";User ID= ";
                strConnection += strUID;
                strConnection += ";Password= ";
                strConnection += strPSW;
            }
        }


        public class ComboxItem
        {
            public string Text = "";

            public string Value = "";
            public ComboxItem(string _Text, string _Value)
            {
                Text = _Text;
                Value = _Value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void dataBind()
        {
            string str1 = "";
            str1 += "传感器";
            str1 += sts.Substring(0, 1);
            str1 += "\t\t温度：";
            str1 += sts.Substring(1, 2);
            str1 += ".";
            str1 += sts.Substring(3, 2);
            str1 += "°C\t湿度：";
            str1 += sts.Substring(5, 3);
            str1 += ".";
            str1 += sts.Substring(8, 2);
            str1 += "%\n";

            textBox1.AppendText(str1) ;

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add("0", "0000", "000000", DateTime.Now);
            }
            bool sx = false; //判断是新增还是修改

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["idm"].ToString() == sts.Substring(0, 1))
                {
                    dt.Rows[i]["wd"] = sts.Substring(1, 4);
                    dt.Rows[i]["sd"] = sts.Substring(5, 5);
                    dt.Rows[i]["ontime"] = DateTime.Now;

                    sx = true; //修改

                    if (isRecord)
                    {
                        using (SqlConnection conn = new SqlConnection(strConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = "insert into T_whd(NodeId,wd,sd,time) values ('" + dt.Rows[i]["idm"].ToString() + "','"
                                    + dt.Rows[i]["wd"].ToString() + "','" + dt.Rows[i]["sd"].ToString() + "','" + DateTime.Now + "')";
                                int a = cmd.ExecuteNonQuery();
                                if (a == 0)
                                    MessageBox.Show("数据库记录失败！", "Message");
                            }
                        }                   
                    }
                    break;
                }
            }

            if (sx == false)
            {
                dt.Rows.Add(sts.Substring(0, 1), sts.Substring(1, 4), sts.Substring(5, 5), DateTime.Now);
                int i = dt.Rows.Count-1;
                comboBox2.Items.Add(new ComboxItem("结点" + sts.Substring(0, 1), sts.Substring(0, 1)));

                if (isRecord)
                {
                    using (SqlConnection conn = new SqlConnection(strConnection))
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into T_whd(NodeId,wd,sd,time) values ('" + dt.Rows[i]["idm"].ToString() + "','" + dt.Rows[i]["wd"].ToString() + "','" + dt.Rows[i]["sd"].ToString() + "','" + DateTime.Now + "')";
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                                MessageBox.Show("数据库记录失败！", "Message");
                        }
                    }     
                }
            }
            sts = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                if (dt.Rows.Count > 1)
                {
                    for (int j = 1; j < dt.Rows.Count; j++)
                    {
                        if (DateTime.Parse(dt.Rows[j]["ontime"].ToString()).AddSeconds(tim1 * rx / 1000) < DateTime.Now)
                        {
                            dt.Rows.RemoveAt(j);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        Node = new string[dt.Rows.Count, 4];

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Node[i, 0] = dt.Rows[i][0].ToString(); //ID码
                            Node[i, 1] = dt.Rows[i]["wd"].ToString(); //温度
                            Node[i, 2] = dt.Rows[i]["sd"].ToString(); //湿度                                
                            Node[i, 3] = dt.Rows[i]["ontime"].ToString(); //时刻
                        }
                        bind();
                    }
                }
            }
            
            if (_serialPort.IsOpen == true)
            {
                int bytes2 = _serialPort.BytesToRead;

                if (bytes2 == 0)  return;
                if (bytes2 != 0)
                {
                    char[] char_buffer2 = new char[bytes2];
                    _serialPort.Read(char_buffer2, 0, bytes2);

                    for (int i = 0; i < bytes2; i++)
                    {
                        if (char_buffer2[i] != (char)'\r')
                            sts += char_buffer2[i].ToString();
                        if (char_buffer2[i] == (char)'#')
                            textBox1.AppendText(DateTime.Now.ToString("u"));
                    }
                    if (sts.Length >= 10)
                    {
                        dataBind();
                    }
                    else sts = "";
                }
            }

            zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
            double x = (double)new XDate(DateTime.Now);
            double y1 = 0, y2 = 0;

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                y1 = double.Parse(dt.Rows[i][1].ToString());
                y1 = y1 * 0.01;
                y2 = double.Parse(dt.Rows[i][2].ToString());
                y2 = y2 * 0.01;

                if (dt.Rows[i][0].ToString() == "1")//匹配结点,使用数组后就会简单很多,现在只存在3个结点，待改进
                {
                    list.Add(x, y1);
                    slist.Add(x, y2);
                }
                else if (dt.Rows[i][0].ToString() == "2")
                {
                    list1.Add(x, y1);
                    slist1.Add(x, y2);
                }
                else
                {
                    list2.Add(x, y1);
                    slist2.Add(x, y2);
                }
            }

            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();

            if (list.Count >= 100)
            {
                list.RemoveAt(0);
                list1.RemoveAt(0);
                list2.RemoveAt(0);

            }
        }

        //拓扑图绑定
        public void bind()
        {
            to.Clear();
            to.Node(Node, Rou, Rfd, 24, 24, false);
            to.Nodeline(Node);
            pictureBox1.Refresh();
            pictureBox1.Image = to.GetBitMap();
        }

        //窗口关闭
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _serialPort.Close();
            }
            catch
            {
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        #region 鼠标、按键事件部分
        /// <summary>
        /// 鼠标、按键事件部分
        /// </summary>
        ///
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                to.mouseclick(e.X, e.Y);
                if (to.getchecked() != null)
                {
                    to.Clear();
                    bind();
                    ax = true;
                }
                else
                {
                    ax = false;
                    to.Clear();
                    bind();
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                ax = false;
                to.mouseclick(e.X, e.Y);
                if (to.getchecked() != null)
                {
                    select = to.getchecked();
                    if (select != "0")
                    {
                        CMS1.Show(pictureBox1, e.X, e.Y);
                    }
                }
                else
                {
                    contextMenuStrip1.Show(pictureBox1, e.X, e.Y);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ax == true)
            {
                try
                {
                    to.Clear();
                    to.mousemove(e.X, e.Y);
                    bind();

                }
                catch
                { }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ax == true)
            {
                try
                {
                    to.Clear();
                    to.mousemove(e.X, e.Y);
                    bind();
                }
                catch
                { }
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                to.bitmap(pictureBox1.Width, pictureBox1.Height);
                bind();
            }
            catch
            { }
        }

        private void 背景选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                this.pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
            catch
            {
                pictureBox1.BackgroundImage = null;
            }
        }

        private void 取消背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    if (topoqx != null && topoqx.IsDisposed == false)
        //    {
        //        topoqx.Close();
        //        topoqx = new Squxian(dt.Rows[int.Parse(select)]["idm"].ToString());
        //        topoqx.Show();
        //    }
        //    else
        //    {
        //        topoqx = new Squxian(dt.Rows[int.Parse(select)]["idm"].ToString());
        //        topoqx.Show();
        //    }
        //}

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                checkBox2.CheckState = CheckState.Unchecked;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                checkBox1.CheckState = CheckState.Unchecked;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.zedGraphControl1.GraphPane.Title.Text = comboBox2.Text+"折线图";
            this.zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
            if (checkBox1.CheckState == CheckState.Checked)
            {
                columni = 1;
                this.zedGraphControl1.GraphPane.YAxis.Title.Text = "温度（°C）";
            }
            else
            {
                columni = 2;
                this.zedGraphControl1.GraphPane.YAxis.Title.Text = "湿度（%）";
            }

            if (comboBox2.Text.ToString() == "全部结点")
                nodei = 0;
            else
            {
                string str = comboBox2.Text;
                nodei = int.Parse(str.Substring(2, 1));
            }

            this.zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
            zedGraphControl1.GraphPane.CurveList.Clear();
           
            DateTime dt = DateTime.Now;

            if (columni == 1)
            {
                if (nodei == 0)
                {
                    myCurve = zedGraphControl1.GraphPane.AddCurve("结点1",
                        list, Color.DarkGreen, SymbolType.None);
                    myCurve = zedGraphControl1.GraphPane.AddCurve("结点2",
                        list1, Color.Red, SymbolType.None);
                    myCurve = zedGraphControl1.GraphPane.AddCurve("结点3",
                        list2, Color.Black, SymbolType.None);
                }
                else
                {
                    if (nodei == 1)
                        myCurve = zedGraphControl1.GraphPane.AddCurve("结点" + nodei,
                            list, Color.DarkGreen, SymbolType.None);
                    else if (nodei == 2)
                        myCurve = zedGraphControl1.GraphPane.AddCurve("结点" + nodei,
                        list1, Color.Red, SymbolType.None);
                    else
                        myCurve = zedGraphControl1.GraphPane.AddCurve("结点" + nodei,
                        list2, Color.Black, SymbolType.None);
                }
            }
            else
            {
                if (nodei == 0)
                {
                    myCurve = zedGraphControl1.GraphPane.AddCurve("结点1",
                        slist, Color.DarkGreen, SymbolType.None);
                    myCurve = zedGraphControl1.GraphPane.AddCurve("结点2",
                        slist1, Color.Red, SymbolType.None);
                    myCurve = zedGraphControl1.GraphPane.AddCurve("结点3",
                        slist2, Color.Black, SymbolType.None);
                }
                else
                {
                    if (nodei == 1)
                        myCurve = zedGraphControl1.GraphPane.AddCurve("结点" + nodei,
                            slist, Color.DarkGreen, SymbolType.None);
                    else if (nodei == 2)
                        myCurve = zedGraphControl1.GraphPane.AddCurve("结点" + nodei,
                        slist1, Color.Red, SymbolType.None);
                    else
                        myCurve = zedGraphControl1.GraphPane.AddCurve("结点" + nodei,
                        slist2, Color.Black, SymbolType.None);
                }
            }
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
        }
    }
}
