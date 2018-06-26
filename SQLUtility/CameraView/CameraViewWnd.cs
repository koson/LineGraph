//using CameraViewDbHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LineGraph.SQLUtility
{
    public partial class CameraViewWnd : Form
    {
        public CameraViewWnd()
        {
            InitializeComponent();
#if DEBUG 
            tbIP.Text = "20.20.55.102";
            tbPort.Text = "2100";
            tbAccount.Text = "admin";
            tbPassword.Text = "admin00";
#endif
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            try
            {
                //using (CameraViewEntities db = new CameraViewEntities())
                //{
                //    PoliceStation ps = new PoliceStation();
                //    ps.Id = Guid.NewGuid();
                //    ps.Ip = "192.168.1.122";
                //    ps.Name = "洪家楼北路派出所";
                //    db.PoliceStations.Add(ps);
                //    db.SaveChanges();
                //    NotRecordDevice device = new NotRecordDevice();
                //    device.Id = Guid.NewGuid();
                //    device.PoliceStationID = ps.Id;
                //    device.Name = "001";
                //    device.Title = "洪家楼北路站牌A";
                //    device.CheckTime = DateTime.Now;
                //    db.NotRecordDevices.Add(device);
                //    NotRecordDevice device1 = new NotRecordDevice();
                //    device1.Id = Guid.NewGuid();
                //    device1.PoliceStationID = ps.Id;
                //    device1.Name = "002";
                //    device1.Title = "洪家楼北路站牌B";
                //    device1.CheckTime = DateTime.Now;
                //    db.NotRecordDevices.Add(device1);
                //    db.SaveChanges();

                //    //NotRecordDevice device = db.NotRecordDevices.FirstOrDefault();
                //    //MessageBox.Show(device.PoliceStation.Name);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal; //还原窗体 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = true; //托盘图标隐藏
            }
            if (this.WindowState == FormWindowState.Minimized)//最小化事件
            {
                this.Hide();//最小化时窗体隐藏
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CrossThreadWork();
        }

        private void CrossThreadWork()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(DoWork));
            thread1.Start("更新Label");
        }

        private void DoWork(object str)
        {
            #region 禁用控件
            if (btnLogin.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {
                    this.btnLogin.Enabled = false;
                };
                this.btnRefresh.Invoke(actionDelegate, "");
            }
            else
            {
                this.btnLogin.Enabled = false;
            }
            if (btnRefresh.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {
                    this.btnRefresh.Enabled = false;
                };
                this.btnRefresh.Invoke(actionDelegate, "");
            }
            else
            {
                this.btnRefresh.Enabled = false;
            }
            #endregion
            #region 表单判断
            if (string.IsNullOrWhiteSpace(tbIP.Text.Trim()))
            {
                MessageBox.Show("IP不能为空");
                return;
            }
            int port = 0;
            if (!int.TryParse(tbPort.Text, out port))
            {
                MessageBox.Show("端口号填写不对");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbAccount.Text.Trim()))
            {
                MessageBox.Show("账号不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Text.Trim()))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            #endregion
            try
            {
                int rs = Pvg.NP_NET_Init();
                if (rs == 0)
                {
                    int _loginID = 0;
                    rs = Pvg.NP_NET_Login(out _loginID, tbIP.Text, port, tbAccount.Text, tbPassword.Text);
                    if (rs == 0)
                    {
                        //离线摄像机
                        List<PVGCameraInfo> brokenList = new List<PVGCameraInfo>();
                        //在线摄像机
                        List<PVGCameraInfo> noBrokenList = new List<PVGCameraInfo>();
                        StringBuilder sb = new StringBuilder();
                        #region 摄像机列表查询
                        int count = 0;
                        Pvg.NP_NET_ListObjects(_loginID, Pvg.NPNetObjectType.NPNET_TYPE_CAMERA, "", out count,
                            (userParam, userHD, objType, objName, objInfo) =>
                            {
                                PVGCameraInfo caminfo = ParseJson<PVGCameraInfo>(objInfo);
                                //在线摄像机
                                if (caminfo.isBroken == 0)
                                {
                                    noBrokenList.Add(caminfo);
                                }
                                else
                                {
                                    brokenList.Add(caminfo);
                                }
                                return true;
                            }, IntPtr.Zero);
                        #endregion
                        //dataGridView1.DataSource = null;
                        //dataGridView1.DataSource = brokenList;
                        #region 跨线程赋值
                        if (dataGridView1.InvokeRequired)
                        {
                            Action<List<PVGCameraInfo>> actionDelegate = (x) =>
                            {
                                this.dataGridView1.DataSource = null;
                                this.dataGridView1.DataSource = (List<PVGCameraInfo>)x;
                            };
                            this.dataGridView1.Invoke(actionDelegate, brokenList);
                        }
                        else
                        {
                            this.dataGridView1.DataSource = (List<PVGCameraInfo>)str;
                        }
                        #endregion 
                        List<PVGCameraInfo> workList = new List<PVGCameraInfo>();
                        for (int i = 0; i < noBrokenList.Count; i++)
                        {
                            sb.AppendLine("\r\n");
                            #region 录像查询
                            //avPath:av/99    "2016-11-29 13:20:00.000"
                            Pvg.NP_NET_QueryRecord(_loginID, noBrokenList[i].name, 0, DateTime.Now.AddHours(-5).ToString("yyyy-MM-dd hh:mm:ss") + ":00.000", DateTime.Now.AddHours(-4).ToString("yyyy-MM-dd hh:mm:ss") + ":00.000", (userParam, userHD, avPath, beginTime, endTime) =>
                              {
                                  sb.AppendLine(noBrokenList[i].name + "     " + userParam + " " + userHD + " " + avPath + " " + beginTime + " " + " " + endTime);
                                  //有输出结果的证明在工作
                                  workList.Add(noBrokenList[i]);
                                  return true;
                              }, IntPtr.Zero);
                            #endregion
                        }
                        workList = workList.Distinct().ToList();
                        List<PVGCameraInfo> noWorkList = noBrokenList.Except(workList).ToList();
                        MessageBox.Show(noWorkList.Count.ToString());
                        using (StreamWriter sw = new StreamWriter("a.txt", false, Encoding.UTF8))
                        {
                            sw.Write(sb.ToString());
                        }
                        //dataGridView2.DataSource = null;
                        //dataGridView2.DataSource = workList;
                        #region 跨线程赋值
                        if (dataGridView2.InvokeRequired)
                        {
                            Action<List<PVGCameraInfo>> actionDelegate = (x) =>
                            {
                                this.dataGridView2.DataSource = null;
                                this.dataGridView2.DataSource = (List<PVGCameraInfo>)x;
                            };
                            this.dataGridView2.Invoke(actionDelegate, noWorkList);
                        }
                        else
                        {
                            this.dataGridView2.DataSource = (List<PVGCameraInfo>)str;
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("登录失败");
                    }
                }
                else
                {
                    MessageBox.Show("初始化失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #region 启用控件
            if (btnLogin.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {
                    this.btnLogin.Enabled = true;
                };
                this.btnRefresh.Invoke(actionDelegate, "");
            }
            else
            {
                this.btnLogin.Enabled = true;
            }
            if (btnRefresh.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {
                    this.btnRefresh.Enabled = true;
                };
                this.btnRefresh.Invoke(actionDelegate, "");
            }
            else
            {
                this.btnRefresh.Enabled = true;
            }
            #endregion
        }
        public T ParseJson<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CrossThreadWork();
        }
    }
    public class PVGCameraInfo
    {
        /// <summary>
        /// 通道号
        /// </summary>
        [DataMember]
        public string addr { get; set; }
        /// <summary>
        /// pvg6.3 0：模拟摄像机 1：数字摄像机
        /// pvg6.7 0：枪机  1：球机
        /// </summary>
        [DataMember]
        public int avType { get; set; }
        [DataMember]
        public string customInfo { get; set; }

        [DataMember]
        public string extInfo { get; set; }

        [DataMember]
        public string longitude { get; set; }
        [DataMember]
        public string latitude { get; set; }

        [DataMember]
        public string recordSite { get; set; }

        [DataMember]
        public string storageAddr { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        [DataMember]
        public string host { get; set; }
        /// <summary>
        /// 0：在线 1：离线
        /// </summary>
        [DataMember]
        public int isBroken { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        [DataMember]
        public int level { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string name { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [DataMember]
        public string path { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string title { get; set; }

        /// <summary>
        /// 是否支持云台
        /// </summary>
        [DataMember]
        public bool PTZEnable { get; set; }

        /*
         *    "addr" : "1:rtsp",
    "avType" : 1,
    "customInfo" : "",
    "extInfo" : "",
    "host" : "192.168.1.171",
    "isBroken" : 0,
    "latitude" : "",
    "level" : 0,
    "longitude" : "",
    "name" : "av/utc_1_171",
    "path" : "",
    "recordSite" : "",
    "storageAddr" : "192.168.1.8",
    "title" : "utc_1_171"
         */
    }


    class Pvg
    {
        /// <summary>
        /// sdk库文件路径
        /// </summary>
        public const string NP_NetSDKDllPath = @"pvgsdk\np_netsdk.dll";

        /// <summary>
        /// 对象列举回调函数
        /// </summary>
        /// <param name="userParam">用户数据</param>
        /// <param name="userHD">登录句柄,由NP_NET_Login()获得</param>
        /// <param name="objType">列举的设备类型</param>
        /// <param name="objName">对象名称</param>
        /// <param name="objInfo">对象所有属性,可以通过NP_NET_InfoParseKeyValue()来解析</param>
        public delegate bool CallBack_OnListObj(IntPtr userParam, int userHD, NPNetObjectType objType, string objName, string objInfo);

        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <returns>NPSDK_OK 成功  其它 失败 错误码</returns>
        [DllImport(NP_NetSDKDllPath)]
        public static extern int NP_NET_Init();

        /// <summary>
        /// 登录PVG服务器
        /// </summary>
        /// <param name="userHD">用户句柄,如果确肯定为非0值</param>
        /// <param name="ipOrHost">PVG服务器的ip或dns</param>
        /// <param name="port">PVG服务器的服务端口</param>
        /// <param name="userName">登录用户名</param>
        /// <param name="passwd">登录密码</param>
        /// <returns>NPSDK_OK 成功  其它 失败 错误码</returns>
        [DllImport(NP_NetSDKDllPath)]
        public static extern int NP_NET_Login(out int userHD, string ipOrHost, int port, string userName, string passwd);

        /// <summary>
        /// 列举对象
        /// </summary>
        /// <param name="userHD">登录句柄,由NP_NET_Login()获得</param>
        /// <param name="objType">要列举的设备类型</param>
        /// <param name="serName">父对象(服务器名称),当为NULL或_T("")时为根对象</param>
        /// <param name="count">列举到的对象个数</param>
        /// <param name="fnOnListObj">对象列举回调函数</param>
        /// <param name="userParam">用户数据（作为回调函数的参数）</param>
        /// <returns>NPSDK_OK 成功  其它 失败 错误码</returns>
        [DllImport(NP_NetSDKDllPath)]
        public static extern int NP_NET_ListObjects(int userHD, NPNetObjectType objType, string serName /*=NULL*/, out int count /*=NULL*/, CallBack_OnListObj fnOnListObj, IntPtr userParam);

        /// <summary>
        /// 对象类型
        /// </summary>
        public enum NPNetObjectType
        {
            /// <summary>
            /// 传入SDK时表示列举全部
            /// </summary>
            NPNET_TYPE_UNKNOWN = 0,
            /// <summary>
            /// 关联服务器
            /// </summary>
            NPNET_TYPE_SERVER = 0x0001, ///< 关联服务器
                                        /// <summary>
                                        /// 网关服务器
                                        /// </summary>
            NPNET_TYPE_GATEWAY = 0x0002,
            /// <summary>
            /// 接入设备
            /// </summary>
            NPNET_TYPE_DEVICE = 0x0004,
            /// <summary>
            /// 摄像头
            /// </summary>
            NPNET_TYPE_CAMERA = 0x0010,
            /// <summary>
            /// 监视器
            /// </summary>
            NPNET_TYPE_MONITOR = 0x0020,
            /// <summary>
            /// 音频通道（输入/输出/对讲）
            /// </summary>
            NPNET_TYPE_AUDIO = 0x0040,
            /// <summary>
            /// 输入干线
            /// </summary>
            NPNET_TYPE_TRUNKIN = 0x0100,
            /// <summary>
            /// 输出干线
            /// </summary>
            NPNET_TYPE_TRUNKOUT = 0x0200,
            /// <summary>
            /// 报警输入
            /// </summary>
            NPNET_TYPE_ALARMIN = 0x1000,
            /// <summary>
            /// 报警输出
            /// </summary>
            NPNET_TYPE_ALARMOUT = 0x2000,
        }

        public delegate bool CallBack_OnListSegments(IntPtr userParam, int userHD, string avPath, string beginTime, string endTime);


        [DllImport(NP_NetSDKDllPath)]
        public static extern int NP_NET_QueryRecord(int userHD, string avPath, int vodType, string beginTime, string endTime, CallBack_OnListSegments fnOnListSegment, IntPtr userParam/*=NULL*/    );

    }
}
