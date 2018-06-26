using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LineGraph.DataReceiver
{
    public partial class DTUFrmMain : Form
    {
        #region 窗体、变量及构造函数
        DTUdll DTUService = DTUdll.Instance;
        byte[] FileSend;

        private int _NextProtocolIndex;

        public DTUFrmMain()
        {
            InitializeComponent();
            this.tabFunc.SelectedIndex = 0;
            this.cboSet_RcvType.SelectedIndex = 1;
            this.cboSendDataType.SelectedIndex = 1;
            this.cboSendFileType.SelectedIndex = 1;
            tmrSSBTime_Tick(null, null);
            Log("程序启动");

            _NextProtocolIndex = 0;
        }

        private void tabFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabFunc.SelectedIndex == 2) Log("要远程对设备参数进行修改，必须要以下条件： \r\n\t" +
                    "1. 设备必须能连接到此数据中心并处于连接状态\r\n\t" +
                    "2. 设备必须为刚刚连接到此数据中心，即连接后无数据交互时选择“远程控制模式”\r\n\t" +
                    "   若设备已经连接，并产生了数据交互，请关闭服务中心，20S后再打开数据中心\r\n\t" +
                    "3. 列表中有设备登录后，左键点击所选的ID号码，然后选择“远程控制模式”");
            this.chkAutoSendData.Checked = false;
            this.chkAutoSendFile.Checked = false;
        }

        public void StartNetData()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + "AdrCfg";

            StreamReader sReader = new StreamReader(strPath, Encoding.Default);

            while (sReader.Peek() >= 0)
            {
                string line = sReader.ReadLine();
                byte[] AdrByte = System.Text.Encoding.Default.GetBytes(line);

                if(AdrByte[0] == 0)
                {
                    UserHelper.sDeviceXiJuProtocol[UserHelper.sDeviceXiJuProtocolAdr] = AdrByte[1];
                    //Create CRC
                    UInt16 crc = Data.Funs.calculateCRC(UserHelper.sDeviceXiJuProtocol, Convert.ToUInt16(UserHelper.sDeviceXiJuProtocol.Length - 2), 0);
                    byte[] byteData = BitConverter.GetBytes((int)crc);
                    UserHelper.sDeviceXiJuProtocol[UserHelper.sDeviceXiJuProtocolCrc0] = byteData[0];
                    UserHelper.sDeviceXiJuProtocol[UserHelper.sDeviceXiJuProtocolCrc1] = byteData[1];

                    byte[] XiJuProtocol = new byte[UserHelper.sDeviceXiJuProtocol.Length];
                    Array.Copy(UserHelper.sDeviceXiJuProtocol, XiJuProtocol, UserHelper.sDeviceXiJuProtocol.Length);

                    UserHelper.DeviceDataProtocolList.Add(XiJuProtocol);

                }
                else
                {
                    UserHelper.sDeviceRuiFenProtocol[UserHelper.sDeviceRuiFenProtocolAdr] = AdrByte[1];

                    byte byteData = 0;
                    for (int i = 1; i < UserHelper.sDeviceRuiFenProtocol.Length - 1;i++)
                    {
                        byteData  += UserHelper.sDeviceRuiFenProtocol[i];
                    }

                    UserHelper.sDeviceRuiFenProtocol[UserHelper.sDeviceRuiFenProtocolCrc0] = byteData;

                    byte[] RuiFenProtocol = new byte[UserHelper.sDeviceRuiFenProtocol.Length];
                    Array.Copy(UserHelper.sDeviceRuiFenProtocol, RuiFenProtocol, UserHelper.sDeviceRuiFenProtocol.Length);


                    UserHelper.DeviceDataProtocolList.Add(RuiFenProtocol);
                }

                UserHelper.DeviceDataAdrList.Add(new KeyValuePair<byte, byte>(AdrByte[1], AdrByte[0]));

            }

            tsbStart_Click(null, null);
        }

        public void CloseNetData()
        {
            tsbStop_Click(null, null);
        }

        public void SendData(byte[] Sendbts)
        {
            string err = null;
            byte[] bts = null;
            uint dtuID = 0;
            if (CheckSendData(out dtuID, out bts, out err))
            {
                this.SendData(dtuID, Sendbts);
            }
            else
            {
                LogWarning("发送数据", err);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.DTUService.Started)
            //{
            //    if (MessageBox.Show("服务启动运行中，确定要停止服务并退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            //    {
            //        this.DTUService.StopService();
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}

            this.Hide();
            e.Cancel = true;
        }

        private void dgvDTUList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = ((uint)e.Value).ToString("X").PadLeft(8, '0');
            }
        }

        private void cboSendDataTarg_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((uint)e.Value).ToString("X").PadLeft(8, '0');
        }
        #endregion

        #region 工具条状态栏
        private void tmrSSBTime_Tick(object sender, EventArgs e)
        {
            ssbDatetime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + @"\help.chm");
        }

        private void ssbCompany_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("IEXPLORE.EXE", this.ssbCompany.Tag.ToString());
        }

        private void tsbClearLog_Click(object sender, EventArgs e)
        {
            this.rtxLog.Clear();
            this.Log("清空日志");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.saveLogDialog.FileName = "";
                if (this.saveLogDialog.ShowDialog() == DialogResult.OK)
                {
                    this.rtxLog.SaveFile(this.saveLogDialog.FileName, this.saveLogDialog.FilterIndex == 1 ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText);
                }
                Log("保存日志到：" + this.saveLogDialog.FileName);
            }
            catch (Exception ee)
            {
                LogWarning("保存日志", ee.Message);
            }
        }

        private void SvcStateChanged(bool started)
        {
            this.tsbStart.Enabled = !started;
            this.tsbStop.Enabled = started;
            this.tsbSend.Enabled = started;
            this.ssbSvcState.Enabled = started;
            this.ssbSvcState.Text = "服务状态：" + (started ? "启动" : "停止");
            this.dtuListDataset1.Clear();
            this.dtuListDataset1.AcceptChanges();
            this.numSet_Port.Enabled = !started;
            this.tmrDTU.Enabled = started;
            this.tmrData.Enabled = started;
            this.chkAutoSendData.Checked = false;
            this.chkAutoSendFile.Checked = false;
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            bool flag = DTUService.StartService((ushort)this.numSet_Port.Value);
            if (flag)
            {
                this.SvcStateChanged(true);
                Log("启动服务(Port=" + this.numSet_Port.Value.ToString() + ")");
            }
            else
            {
                LogWarning("启动服务(Port=" + this.numSet_Port.Value.ToString() + ")", DTUService.LastError);
            }
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            bool flag = DTUService.StopService();
            if (flag)
            {
                this.SvcStateChanged(false);
                Log("停止服务");
            }
            else
            {
                LogWarning("停止服务", DTUService.LastError);
            }
            inDtuTicks = false;
        }

        private void tsbSend_Click(object sender, EventArgs e)
        {
            switch (this.tabFunc.SelectedIndex)
            {
                case 0:
                    this.btnSendData_Click(sender, e);
                    break;
                case 1:
                    this.btnSendFile_Click(sender, e);
                    break;

                case 2:
                    this.btnDTUSetGet_Click(sender, e);
                    break;
            }
        }
        #endregion

        #region 列表维护及接收数据
        bool inDtuTicks = false;
        //维护列表
        Dictionary<uint, DTUInfoStruct> dtuList;
        private void tmrDTU_Tick(object sender, EventArgs e)
        {
            if (inDtuTicks) return;
            //
            try
            {
                if (DTUService.GetDTUList(out dtuList))
                {
                    DTUListDataset.DTUListDataTable dtuTB = dtuListDataset1.DTUList;
                    //this.Text = dtuList.Count.ToString();
                    //删除数据集中的无效记录
                    foreach (DTUListDataset.DTUListRow row in dtuTB)
                    {
                        //Application.DoEvents();
                        if (!DTUService.Started) return;
                        if (!dtuList.ContainsKey(row.ID))
                        {
                            Log("用户 " + row.ID.ToString("X").PadLeft(8, '0') + " 断开连接");
                            row.Delete();
                        }
                    }
                    dtuTB.AcceptChanges();
                    //增加更新及标记过期
                    foreach (DTUInfoStruct dtu in dtuList.Values)
                    {
                        //Application.DoEvents();
                        if (!DTUService.Started) return;
                        uint uid = dtu.m_modemId;
                        DTUListDataset.DTUListRow dtuRow = dtuTB.FindByID(uid);
                        if (dtuRow == null)
                        {
                            dtuRow = dtuTB.NewDTUListRow();
                        }
                        if (dtuRow.RowState == DataRowState.Detached || dtuRow.ID != uid) dtuRow.ID = uid;
                        string ss = Util.Byte11ToPhoneNO(dtu.m_phoneno, 0);
                        if (dtuRow.RowState == DataRowState.Detached || dtuRow.PhoneNO != ss) dtuRow.PhoneNO = ss;
                        ss = Util.Byte4ToIP(dtu.m_dynip, 0);
                        if (dtuRow.RowState == DataRowState.Detached || dtuRow.DynIP != ss) dtuRow.DynIP = ss;
                        DateTime dt = Util.ULongToDatetime(dtu.m_conn_time); ;
                        if (dtuRow.RowState == DataRowState.Detached || dtuRow.ConnectTime != dt) dtuRow.ConnectTime = dt;
                        dt = Util.ULongToDatetime(dtu.m_refresh_time);
                        if (dtuRow.RowState == DataRowState.Detached || dtuRow.LastActTime != dt) dtuRow.LastActTime = dt;
                        int avt = (int)this.numSet_LiveSecs.Value;
                        bool vi = true;
                        if (avt > 0)
                        {
                            vi = (dtuRow.LastActTime.AddSeconds(avt) > DateTime.Now);
                        }
                        if (dtuRow.RowState == DataRowState.Detached)
                        {
                            if (vi)
                            {
                                Log("用户 " + dtuRow.ID.ToString("X").PadLeft(8, '0') + " 建立连接");
                            }
                        }
                        else
                        {
                            if (vi && !dtuRow.Visible) Log("用户 " + dtuRow.ID.ToString("X").PadLeft(8, '0') + " 连接激活");
                            if (!vi && dtuRow.Visible) Log("用户 " + dtuRow.ID.ToString("X").PadLeft(8, '0') + " 连接失效");
                        }
                        if (dtuRow.RowState == DataRowState.Detached || dtuRow.Visible != vi) dtuRow.Visible = vi;
                        if (dtuRow.RowState == DataRowState.Detached) dtuTB.AddDTUListRow(dtuRow);

                        inDtuTicks = true;
                    }
                    dtuTB.AcceptChanges();
                }
                else
                {
                    LogWarning("读取DTU列表", DTUService.LastError);
                    return;
                }
            }
            catch (Exception ee)
            {
                LogWarning("读取列表", ee.Message);
            }
            finally
            {
                //inDtuTicks = false;
            }
        }

        //private bool inDataTicks = false;
        private void tmrData_Tick(object sender, EventArgs e)
        {
            //if (inDtuTicks || inDataTicks) return;
            //inDataTicks = true;
            try
            {
                //读取数据
                DTUDataStruct dat = new DTUDataStruct();
                while (this.DTUService.GetNextData(out dat))
                {
                    LogRecive(dat);
                    Application.DoEvents();
                    if (!DTUService.Started) return;
                    //自动回应
                    if (dat.m_data_type == 1 && this.chkSet_AutoReply.Checked)
                    {
                        if (!this.DTUService.SendHex(dat.m_modemId, dat.m_data_buf, dat.m_data_len))
                        {
                            LogWarning("自动回应数据", DTUService.LastError);

                        }
                    }
                }
            }
            catch (Exception ee)
            {
                LogWarning("读取数据", ee.Message);
            }
            finally
            {
                //inDataTicks = false;
            }
        }
        #endregion

        #region 发送数据

        private bool CheckSendData(out uint dtuID, out byte[] sendBts, out string errString)
        {
            sendBts = null;
            errString = null;
            dtuID = 0;
            if (!this.DTUService.Started)
            {
                errString = "服务尚未启动";
                return false;
            }
            if (this.cboSendDataTarg.SelectedValue == null)
            {
                errString = "没有选择发送目标";
                return false;
            }
            dtuID = (uint)this.cboSendDataTarg.SelectedValue;
            //if (this.txtSendData.TextLength == 0)
            //{
            //    errString = "发送内容不能为空";
            //    return false;
            //}
            //if (cboSendDataType.SelectedIndex == 0)
            //{
            //    sendBts = Encoding.Default.GetBytes(this.txtSendData.Text);
            //    return true;
            //}
            //else
            //{
            //    if (!Util.ByteArrayFromHexString(this.txtSendData.Text, out sendBts) || sendBts.Length == 0)
            //    {
            //        errString = "输入Hex格式有误：Hex格式每个字节由一到两个十六进制字符组成，每两个字节之间用空格、逗号或分号分开，如：00 A8;8 12,ef 0F";
            //        return false;
            //    }
            //    return true;
            //}
            return true;
        }

        private void chkAutoSendData_CheckedChanged(object sender, EventArgs e)
        {
            bool value = chkAutoSendData.Checked;
            if (value)
            {
                string err = null;
                byte[] bts = null;
                uint dtuID = 0;
                if (CheckSendData(out dtuID, out bts, out err))
                {
                    this.SendData(dtuID, bts);
                    this.tmrAutoSendData.Interval = (int)this.numAutoSendDataCycle.Value * 1000;
                }
                else
                {
                    LogWarning("启动自动发送数据", err);
                    chkAutoSendData.Checked = false;
                    return;
                }
            }
            this.tmrAutoSendData.Enabled = value;
            this.cboSendDataType.Enabled = !value;
            this.numAutoSendDataCycle.Enabled = !value;
            this.txtSendData.Enabled = !value;
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            string err = null;
            byte[] bts = null;
            uint dtuID = 0;
            if (CheckSendData(out dtuID, out bts, out err))
            {
                this.SendData(dtuID, bts);
            }
            else
            {
                LogWarning("发送数据", err);
            }
        }

        private void tmrAutoSendData_Tick(object sender, EventArgs e)
        {
            //string err = null;
            //byte[] bts = null;
            //uint dtuID = 0;
            //if (CheckSendData(out dtuID, out bts, out err))
            //{
            //    this.SendData(dtuID, bts);
            //}
            //else
            //{
            //    this.chkAutoSendData.Checked = false;
            //}

            string err = null;
            byte[] bts = null;
            uint dtuID = 0;
            if (CheckSendData(out dtuID, out bts, out err))
            {
                this.SendData(dtuID, UserHelper.DeviceDataProtocolList[_NextProtocolIndex]);
            }
          
            _NextProtocolIndex++;
            if(_NextProtocolIndex >= UserHelper.DeviceDataProtocolList.Count)
            {
                _NextProtocolIndex = 0;
            }
        }

        private void SendData(uint dtuID, byte[] bts)
        {
            if (this.DTUService.SendHex(dtuID, bts))
            {
                LogSendData(dtuID, bts);
            }
            else
            {
                LogWarning("向用户 " + dtuID.ToString("X").PadLeft(8, '0') + " 发送数据", this.DTUService.LastError);
            }
        }
        #endregion

        #region 发送文件
        private bool CheckSendFile(out uint dtuID, out string errString)
        {
            errString = null;
            dtuID = 0;
            if (!this.DTUService.Started)
            {
                errString = "服务尚未启动";
                return false;
            }
            if (this.cboSendFileTarg.SelectedValue == null)
            {
                errString = "没有选择发送目标";
                return false;
            }
            dtuID = (uint)this.cboSendFileTarg.SelectedValue;
            if (this.FileSend == null || FileSend.Length == 0)
            {
                errString = "发送内容不能为空";
                return false;
            }
            return true;
        }

        private void cboSendFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FileSend != null) this.DispFile();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog.FileName);
                    if (fi.Length > 65535) throw new Exception("文件长度超过64k");
                    this.FileSend = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                    this.txtSendFileName.Text = openFileDialog.FileName;
                    this.DispFile();
                }
            }
            catch (Exception ee)
            {
                this.txtSendFileName.Clear();
                this.FileSend = null;
                this.txtSendFileContent.Clear();
                LogWarning("加载文件", ee.Message);
            }
        }

        private void DispFile()
        {
            if (this.FileSend != null)
            {
                if (this.cboSendFileType.SelectedIndex == 0)
                {
                    this.txtSendFileContent.Text = System.Text.Encoding.Default.GetString(FileSend);
                }
                else
                {
                    this.txtSendFileContent.Text = Util.ByteArrayToHexString(FileSend);
                }
            }
        }

        private void chkAutoSendFile_CheckedChanged(object sender, EventArgs e)
        {
            bool value = chkAutoSendFile.Checked;
            if (value)
            {
                string err = null;
                uint dtuID = 0;
                if (CheckSendFile(out dtuID, out err))
                {
                    this.SendFile(dtuID);
                    this.tmrAutoSendFile.Interval = (int)this.numAutoSendFileCycle.Value * 1000;
                }
                else
                {
                    LogWarning("启动自动发送文件", err);
                    chkAutoSendFile.Checked = false;
                    return;
                }
            }
            this.tmrAutoSendFile.Enabled = value;
            this.numAutoSendFileCycle.Enabled = !value;
            this.btnLoadFile.Enabled = !value;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string err = null;
            uint dtuID = 0;
            if (CheckSendFile(out dtuID, out err))
            {
                this.SendFile(dtuID);
            }
            else
            {
                LogWarning("发送文件", err);
            }
        }

        private void tmrAutoSendFile_Tick(object sender, EventArgs e)
        {
            string err = null;
            uint dtuID = 0;
            if (CheckSendFile(out dtuID, out err))
            {
                this.SendFile(dtuID);
            }
            else
            {
                this.chkAutoSendFile.Checked = false;
            }
        }

        private void SendFile(uint dtuID)
        {
            if (FileSend == null || FileSend.Length == 0) return;
            int flen = FileSend.Length, startIndex = 0;

            while (startIndex < flen)
            {
                if (!this.DTUService.SendHex(dtuID, FileSend, startIndex, 1450))
                {
                    LogWarning("向用户 " + dtuID.ToString("X").PadLeft(8, '0') + " 发送文件", this.DTUService.LastError);
                    return;
                }
                startIndex += 1450;
            }
            LogSendFile(dtuID);
        }
        #endregion

        #region 发送控制命令

        private bool CheckSendCtrl(out uint dtuID, out string errString)
        {
            errString = null;
            dtuID = 0;
            if (!this.DTUService.Started)
            {
                errString = "服务尚未启动";
                return false;
            }
            if (this.cboControlTarg.SelectedValue == null)
            {
                errString = "没有选择发送目标";
                return false;
            }
            dtuID = (uint)this.cboControlTarg.SelectedValue;
            return true;
        }

        private void btnDTUSetClear_Click(object sender, EventArgs e)
        {
            this.txtDTUID.Text = "";
            this.txtDTULiveCycle.Text = "";
            this.txtDTUMainDNS.Text = "";
            this.txtDTUMainIP.Text = "";
            this.txtDTUMainPort.Text = "";
            this.txtDTUSecondDNS.Text = "";
            this.txtDTUSecondIP.Text = "";
            this.txtDTUSecondPort.Text = "";
            this.cboDTUActiveMode.SelectedIndex = -1;
            this.cboDTUWorkMode.SelectedIndex = -1;
            this.txtATHis.Clear();
        }

        private void btnDTUReset_Click(object sender, EventArgs e)
        {
            this.SendControl("AT+RESET");
        }

        private void btnDTUSetEntry_Click(object sender, EventArgs e)
        {
            this.SendControl("***COMMIT CONFIG***");
        }

        private void btnDTUSetGet_Click(object sender, EventArgs e)
        {
            this.SendControl("AT+SHOW");
        }

        private void btnDTUSetSend_Click(object sender, EventArgs e)
        {
            const uint waitMilSec = 1000;

            string err = null;
            uint dtuID = 0;
            if (CheckSendCtrl(out dtuID, out err))
            {
                try
                {
                    DisDo(false);

                    if (this.txtDTUID.TextLength > 0)
                    {
                        string ss = txtDTUID.Text.Trim();
                        uint nwID = 0;
                        if (ss.Length != 8 || !uint.TryParse(ss, System.Globalization.NumberStyles.HexNumber, null, out nwID))
                        {
                            LogWarning("发送配置", "配置ID号必须为8位十六进制字符，如：03FF2c00");
                        }
                        else
                        {
                            if (!this.SendControl("AT+IDNT=" + nwID.ToString("X").PadLeft(8, '0')))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTUMainIP.TextLength > 0)
                    {
                        string ss = txtDTUMainIP.Text.Trim();
                        System.Net.IPAddress ip = null;
                        if (!System.Net.IPAddress.TryParse(ss, out ip))
                        {
                            LogWarning("发送配置", "请输入正确的主IP地址，如：192.168.0.11");
                        }
                        else
                        {
                            if (!this.SendControl("AT+IPAD=" + ip.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTUSecondIP.TextLength > 0)
                    {
                        string ss = txtDTUSecondIP.Text.Trim();
                        System.Net.IPAddress ip = null;
                        if (!System.Net.IPAddress.TryParse(ss, out ip))
                        {
                            LogWarning("发送配置", "请输入正确的副IP地址，如：192.168.0.11");
                        }
                        else
                        {
                            if (!this.SendControl("AT+IPSEC=" + ip.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTUMainDNS.TextLength > 0)
                    {
                        string ss = txtDTUMainDNS.Text.Trim();
                        System.Net.IPAddress ip = null;
                        if (!System.Net.IPAddress.TryParse(ss, out ip))
                        {
                            LogWarning("发送配置", "请输入正确的主DNS地址，如：202.101.100.100");
                        }
                        else
                        {
                            if (!this.SendControl("AT+DNSSVR=" + ip.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTUSecondDNS.TextLength > 0)
                    {
                        string ss = txtDTUSecondDNS.Text.Trim();
                        System.Net.IPAddress ip = null;
                        if (!System.Net.IPAddress.TryParse(ss, out ip))
                        {
                            LogWarning("发送配置", "请输入正确的副DNS地址，如：202.101.100.100");
                        }
                        else
                        {
                            if (!this.SendControl("AT+DNSSV2=" + ip.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTULiveCycle.TextLength > 0)
                    {
                        string ss = txtDTULiveCycle.Text.Trim();
                        int num = 0;
                        if (!int.TryParse(ss, out num) || num < 1 || num > 999)
                        {
                            LogWarning("发送配置", "请输入正确的心跳时间数字(1 - 999)");
                        }
                        else
                        {
                            if (!this.SendControl("AT+POLLTIME=" + num.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTUMainPort.TextLength > 0)
                    {
                        string ss = txtDTUMainPort.Text.Trim();
                        int num = 0;
                        if (!int.TryParse(ss, out num) || num < 10 || num > 65535)
                        {
                            LogWarning("发送配置", "请输入正确的主IP端口数字(10 - 65535)");
                        }
                        else
                        {
                            if (!this.SendControl("AT+PORT=" + num.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.txtDTUSecondPort.TextLength > 0)
                    {
                        string ss = txtDTUSecondPort.Text.Trim();
                        int num = 0;
                        if (!int.TryParse(ss, out num) || num < 10 || num > 65535)
                        {
                            LogWarning("发送配置", "请输入正确的副IP端口数字(10 - 65535)");
                        }
                        else
                        {
                            if (!this.SendControl("AT+PTSEC=" + num.ToString()))
                            {
                                return;
                            }
                            Util.Wait(waitMilSec);
                        }
                    }

                    if (this.cboDTUWorkMode.SelectedIndex >= 0)
                    {
                        if (!this.SendControl("AT+MODE=" + cboDTUWorkMode.Text))
                        {
                            return;
                        }
                        Util.Wait(waitMilSec);
                    }

                    if (this.cboDTUActiveMode.SelectedIndex >= 0)
                    {
                        if (!this.SendControl("AT+ACTI=" + cboDTUActiveMode.Text))
                        {
                            return;
                        }
                        Util.Wait(waitMilSec);
                    }

                    this.SendControl("AT+SHOW");

                }
                catch
                {
                }
                finally
                {
                    DisDo(true);
                }
            }
            else
            {
                LogWarning("发送配置", err);
            }
        }

        private void DisDo(bool state)
        {
            this.tsbStop.Enabled = state && this.DTUService.Started;
            this.tsbSend.Enabled = state && this.DTUService.Started;
            this.grpSvcSetting.Enabled = state;
            this.tabFunc.Enabled = state;
            this.dgvDTUList.Enabled = state;
        }

        private void btnSendAT_Click(object sender, EventArgs e)
        {
            string txt = this.txtATCmd.Text.Trim();
            if (txt.Length == 0)
                LogWarning("发送直接AT命令", "命令内容不能为空");
            else
            {
                if (this.SendControl(txt))
                {
                    this.txtATHis.AppendText(txt + "\r\n");
                    this.txtATHis.ScrollToCaret();
                }
            }
        }

        private bool SendControl(string text)
        {
            try
            {
                string err = null;
                uint dtuID = 0;
                if (CheckSendCtrl(out dtuID, out err))
                {

                    if (this.DTUService.SendControl(dtuID, text))
                    {
                        LogSendControl(dtuID, text);
                        return true;
                    }
                    else
                    {
                        LogWarning("向用户 " + dtuID.ToString("X").PadLeft(8, '0') + " 发送控制命令", this.DTUService.LastError);
                        return false;
                    }
                }
                else
                {
                    LogWarning("发送控制命令", err);
                    return false;
                }
            }
            catch (Exception ee)
            {
                LogWarning("发送控制命令", ee.Message);
                return false;
            }
        }
        #endregion

        #region 日志显示
        private void Log(string work)
        {
            this.Log(work, null, Color.Black);
        }

        private void LogWarning(string work, string errorMessage)
        {
            this.Log(work, "失败：" + errorMessage, Color.Red);
        }

        private void LogSendData(uint id, byte[] bts)
        {
            if (this.cboSendDataType.SelectedIndex == 0)
            {
                string text = this.txtSendData.Text;
                this.Log("向用户 " + id.ToString("X").PadLeft(8, '0') + " 发送文本", "(TextLen=" + text.Length.ToString() + ")\r\n" + text, Color.Blue);
            }
            else
            {
                this.Log("向用户 " + id.ToString("X").PadLeft(8, '0') + " 发送字节", "(HexCount=" + bts.Length.ToString() + ")\r\n" + Util.ByteArrayToHexString(bts), Color.Blue);
            }
        }

        private void LogSendFile(uint id)
        {
            this.Log("向用户 " + id.ToString("X").PadLeft(8, '0') + " 发送文件", "(FileLen=" + FileSend.Length.ToString() + ")\r\n" + this.txtSendFileName.Text, Color.Blue);
        }

        private void LogSendControl(uint id, string text)
        {
            this.Log("向用户 " + id.ToString("X").PadLeft(8, '0') + " 发送远程控制命令", "(TextLen=" + text.Length.ToString() + ")\r\n" + text, Color.Blue);
        }

        private void LogRecive(DTUDataStruct dat)
        {
            if (dat.m_data_type == 2)
            {
                string text = System.Text.Encoding.Default.GetString(dat.m_data_buf, 0, dat.m_data_len);
                this.Log("从用户 " + dat.m_modemId.ToString("X").PadLeft(8, '0') + " 接收控制命令回应", "(TextLen=" + text.Length.ToString() + ")\r\n" + text, Color.LightSeaGreen);
            }
            else if (this.cboSet_RcvType.SelectedIndex == 0)
            {
                string text = System.Text.Encoding.Default.GetString(dat.m_data_buf, 0, dat.m_data_len);
                this.Log("从用户 " + dat.m_modemId.ToString("X").PadLeft(8, '0') + " 接收文本", "(TextLen=" + text.Length.ToString() + ")\r\n" + text, Color.LightSeaGreen);
            }
            else
            {
                this.Log("从用户 " + dat.m_modemId.ToString("X").PadLeft(8, '0') + " 接收字节", "(HexCount=" + dat.m_data_len.ToString() + ")\r\n" + Util.ByteArrayToHexString(dat.m_data_buf, 0, dat.m_data_len), Color.LightSeaGreen);
            }

            if (dat.m_data_len > 0)
            {
                Byte[] Buffer = new byte[dat.m_data_len];
                Array.Copy(dat.m_data_buf, 0, Buffer, 0, dat.m_data_len);
                _Client_OnReceived(Buffer);
            }
        }

        private readonly List<byte> _CacheBuffer = new List<byte>();
        private void _Client_OnReceived(byte[] Data)
        {
            //缓存接收到的网络数据报；
            //并解析所有收到的数据报
            _CacheBuffer.AddRange(Data);
            byte[] buffer = Analyze(_CacheBuffer.ToArray());

            //解析数据完成；
            //移除解析完成的数据报
            int cachelen = _CacheBuffer.Count;
            int len = buffer.Length;
            _CacheBuffer.InsertRange(0, buffer);
            _CacheBuffer.RemoveRange(len, cachelen);
        }

   

        /// <summary>
        /// 协议开始声明
        /// </summary>
        private const string HEADERCONTEXT = "680D";

        private const string HEADERCONTEXT2 = "0304";

        //public event EventHandler<VCDatagramEventArg> OnAnalyzed;

        private int Analyze(string context, int offset = 0)
        {
            string sDeviceAdr;
            //查找数据报开头
            int index = context.IndexOf(HEADERCONTEXT, offset);
            if (-1 == index)
            {
                index = context.IndexOf(HEADERCONTEXT2, offset+1);
                if(-1 == index)
                {
                    return offset;
                }
           
                index -= 2;
                sDeviceAdr = context.Substring(index, 2);
                index += 2;

                index += HEADERCONTEXT2.Length;

                string sDataParaI = context.Substring(index, 4);
                Byte[] DataParaI = Data.Funs.SToBa(sDataParaI);
                int nDataParaI = Data.Funs.ByteToInt(DataParaI);

                index += 4;
                string sDataParaF = context.Substring(index, 4);
                Byte[] DataParaF = Data.Funs.SToBa(sDataParaF);
                int nDataParaF = Data.Funs.ByteToInt(DataParaF);
                float fDataParaF = nDataParaF / 65535;

                float fDataPara = nDataParaI + fDataParaF;

                {
                    VCParamsDatagramModel tDatagramModel = new VCParamsDatagramModel();
                    int DeviceAdr = Int32.Parse(sDeviceAdr, System.Globalization.NumberStyles.HexNumber);
                    //if(DeviceAdr < 10)
                    //{
                    //    tDatagramModel.DeviceID = sDeviceAdr;
                    //}
                    //else
                    {
                        tDatagramModel.DeviceID = DeviceAdr.ToString();
                    }
                    
                    tDatagramModel.CHENJIANGdataCount = 1;
                    tDatagramModel.CHENJIANG[0] = fDataPara;

                    tDatagramModel.Time = DateTime.Now;

                    VCDatagramEventArg m = new VCDatagramEventArg(tDatagramModel);

                    m_DataReceiverWnd.DatagramAnalyzerCtrl_OnAnalyzed(null, m);

                }

                index += 4;
                string sEnd = context.Substring(index, 4);

            }
            else
            {
                //int byteCount = 2;//680D(2字节)

                index += HEADERCONTEXT.Length;
                sDeviceAdr = context.Substring(index, 2);
                //Byte[] DeviceID = SToBa(sDeviceAdr);

                index += 2;
                string sDataStyle = context.Substring(index, 2);
                //Byte[] DataStyleByte = SToBa(sDataStyle);

                if (sDataStyle == "84")
                {
                    index += 2;
                    string sDataParaXZ = context.Substring(index, 2);
                    byte[] nDataParaFloatX = Data.Funs.SToBa(sDataParaXZ);//高4位正负
                    int nDataParaXZ = nDataParaFloatX[0] >> 4;
                    int nDataParaX = nDataParaFloatX[0] & 0x0F;
                    int nDataParaXI1 = nDataParaX * 10;

                    index += 2;
                    string sDataParaXI = context.Substring(index, 2);
                    Byte[] DataParaXI = Data.Funs.SToBa(sDataParaXI);
                    int nDataParaXI0 = DataParaXI[0] >> 4;
                    int nDataParaXI = nDataParaXI1 + nDataParaXI0;


                    int nDataParaXF1 = DataParaXI[0] & 0x0F;
                    double fDataParaXF1 = nDataParaXF1 * 0.1;
                    //int nDataParaXI = Funs.Bcd2Int(DataParaXI, 0, 1);

                    index += 2;
                    string sDataParaXF1 = context.Substring(index, 2);
                    Byte[] DataParaXF1 = Data.Funs.SToBa(sDataParaXF1);
                    int nDataParaXF2 = Data.Funs.Bcd2Int(DataParaXF1, 0, 1);
                    double fDataParaXF2 = nDataParaXF2 * 0.001;

                    //index += 2;
                    //string sDataParaXF2 = context.Substring(index, 2);
                    //Byte[] DataParaXF2 = SToBa(sDataParaXF2);
                    //int nDataParaXF2 = Funs.Bcd2Int(DataParaXF2, 0, 1);
                    //double fDataParaXF2 = nDataParaXF2 * 0.0001;

                    double fDataParaXF = nDataParaXI + fDataParaXF1 + fDataParaXF2;

                    if (nDataParaXZ == 1)
                    {
                        fDataParaXF = -fDataParaXF;
                    }

                    //index += 2;
                    //string sDataParaYZ = context.Substring(index, 2);

                    //index += 2;
                    //string sDataParaYI = context.Substring(index, 2);
                    //Byte[] DataParaYI = SToBa(sDataParaYI);
                    //int nDataParaYI = Funs.Bcd2Int(DataParaYI, 0, 1);

                    //index += 2;
                    //string sDataParaYF1 = context.Substring(index, 2);
                    //Byte[] DataParaYF1 = SToBa(sDataParaYF1);
                    //int nDataParaYF1 = Funs.Bcd2Int(DataParaYF1, 0, 1);
                    //double fDataParaYF1 = nDataParaYF1 * 0.01;

                    //index += 2;
                    //string sDataParaYF2 = context.Substring(index, 2);
                    //Byte[] DataParaYF2 = SToBa(sDataParaYF2);
                    //int nDataParaYF2 = Funs.Bcd2Int(DataParaYF2, 0, 1);
                    //double fDataParaYF2 = nDataParaYF2 * 0.0001;

                    //double fDataParaYF = nDataParaYI + fDataParaYF1 + fDataParaYF2;

                    //if (sDataParaYZ == "10")
                    //{
                    //    fDataParaYF = -fDataParaYF;
                    //}

                    index += 2;
                    string sDataParaYZ = context.Substring(index, 2);
                    byte[] nDataParaFloatY = Data.Funs.SToBa(sDataParaYZ);//高4位正负
                    int nDataParaYZ = nDataParaFloatY[0] >> 4;
                    int nDataParaY = nDataParaFloatY[0] & 0x0F;
                    int nDataParaYI1 = nDataParaY * 10;

                    index += 2;
                    string sDataParaYI = context.Substring(index, 2);
                    Byte[] DataParaYI = Data.Funs.SToBa(sDataParaYI);
                    int nDataParaYI0 = DataParaYI[0] >> 4;
                    int nDataParaYI = nDataParaYI1 + nDataParaYI0;


                    int nDataParaYF1 = DataParaYI[0] & 0x0F;
                    double fDataParaYF1 = nDataParaYF1 * 0.1;
                    //int nDataParaXI = Funs.Bcd2Int(DataParaXI, 0, 1);

                    index += 2;
                    string sDataParaYF1 = context.Substring(index, 2);
                    Byte[] DataParaYF1 = Data.Funs.SToBa(sDataParaYF1);
                    int nDataParaYF2 = Data.Funs.Bcd2Int(DataParaYF1, 0, 1);
                    double fDataParaYF2 = nDataParaYF2 * 0.001;

                    //index += 2;
                    //string sDataParaXF2 = context.Substring(index, 2);
                    //Byte[] DataParaXF2 = SToBa(sDataParaXF2);
                    //int nDataParaXF2 = Funs.Bcd2Int(DataParaXF2, 0, 1);
                    //double fDataParaXF2 = nDataParaXF2 * 0.0001;

                    double fDataParaYF = nDataParaYI + fDataParaYF1 + fDataParaYF2;

                    if (nDataParaYZ == 1)
                    {
                        fDataParaYF = -fDataParaYF;
                    }

                    index += 2;
                    string sDataParaTZ = context.Substring(index, 2);
                    byte[] nDataParaFloatT = Data.Funs.SToBa(sDataParaTZ);//高4位正负
                    int nDataParaTZ = nDataParaFloatT[0] >> 4;
                    int nDataParaT = nDataParaFloatT[0] & 0x0F;
                    int nDataParaTI1 = nDataParaT * 10;

                    index += 2;
                    string sDataParaTI = context.Substring(index, 2);
                    Byte[] DataParaTI = Data.Funs.SToBa(sDataParaTI);
                    int nDataParaTI0 = DataParaTI[0] >> 4;
                    int nDataParaTI = nDataParaTI1 + nDataParaTI0;


                    int nDataParaTF1 = DataParaTI[0] & 0x0F;
                    double fDataParaTF1 = nDataParaTF1 * 0.1;
                    //int nDataParaXI = Funs.Bcd2Int(DataParaXI, 0, 1);

                    index += 2;
                    string sDataParaTF1 = context.Substring(index, 2);
                    Byte[] DataParaTF1 = Data.Funs.SToBa(sDataParaTF1);
                    int nDataParaTF2 = Data.Funs.Bcd2Int(DataParaTF1, 0, 1);
                    double fDataParaTF2 = nDataParaTF2 * 0.001;

                    //index += 2;
                    //string sDataParaXF2 = context.Substring(index, 2);
                    //Byte[] DataParaXF2 = SToBa(sDataParaXF2);
                    //int nDataParaXF2 = Funs.Bcd2Int(DataParaXF2, 0, 1);
                    //double fDataParaXF2 = nDataParaXF2 * 0.0001;

                    double fDataParaTF = nDataParaTI + fDataParaTF1 + fDataParaTF2;

                    if (nDataParaTZ == 1)
                    {
                        fDataParaTF = -fDataParaTF;
                    }

                    {
                        VCParamsDatagramModel tDatagramModel = new VCParamsDatagramModel();
     
                        int DeviceAdr = Int32.Parse(sDeviceAdr, System.Globalization.NumberStyles.HexNumber);
                        //if (DeviceAdr < 10)
                        //{
                        //    tDatagramModel.DeviceID = sDeviceAdr;
                        //}
                        //else
                        {
                            tDatagramModel.DeviceID = DeviceAdr.ToString();
                        }

                        int indexOfFirstNotUse = -1;
                        for (int i = 0; i < UserHelper.DeviceDataAdrList.Count; ++i)
                        {
                            if (UserHelper.DeviceDataAdrList[i].Key == DeviceAdr)
                            {
                                indexOfFirstNotUse = i;
                                if(UserHelper.DeviceDataAdrList[indexOfFirstNotUse].Value == 0)
                                {
                                    continue;
                                }
                                
                                break;
                            }
                        }

                        if (UserHelper.DeviceDataAdrList[indexOfFirstNotUse].Value == 1)
                        {
                            tDatagramModel.QingQiaodataCount = 1;
                            tDatagramModel.QingQiao[0, 0] = (float)fDataParaXF;
                            tDatagramModel.QingQiao[0, 1] = (float)fDataParaYF;
                        }

                        if (UserHelper.DeviceDataAdrList[indexOfFirstNotUse].Value == 2)
                        {
                            tDatagramModel.JIASUDUdataCount = 1;
                            tDatagramModel.JIASUDU[0, 0] = (float)fDataParaXF;
                            tDatagramModel.JIASUDU[0, 1] = (float)fDataParaYF;
                        }

                        tDatagramModel.Temprature = (float)fDataParaTF;

                        tDatagramModel.Time = DateTime.Now;

                        VCDatagramEventArg m = new VCDatagramEventArg(tDatagramModel);
                 
                        m_DataReceiverWnd.DatagramAnalyzerCtrl_OnAnalyzed(null, m);

                    }
                }

                index += 2;
                string sEnd = context.Substring(index, 2);
            }
                


            //重新赋值下一个数据报开始位置
            //并递归调用解析数据报
            offset = index + 1;
            return Analyze(context, offset);

        }


        protected byte[] Analyze(byte[] buffer)
        {
            try
            {
                string context = Data.Funs.BaToS(buffer);

                int offset = Analyze(context);
                context = context.Remove(0, offset);
                Array.Clear(buffer, 0, buffer.Length);
                buffer = Data.Funs.SToBa(context);
            }
            catch (Exception)
            {
                Array.Clear(buffer, 0, buffer.Length);
                buffer = new byte[0];
            }

            return buffer;
        }

        private void Log(string work, string tag, Color tagColor)
        {
            int tlen = rtxLog.TextLength;
            if (tlen > 200000) this.tsbClearLog_Click(null, null);
            this.rtxLog.SelectionStart = tlen;
            if (this.rtxLog.Text != "") this.rtxLog.SelectedText = "\r\n";
            this.rtxLog.SelectionColor = Color.Black;
            this.rtxLog.SelectedText = DateTime.Now.ToString("hh:mm:ss ") + work;
            if (!string.IsNullOrEmpty(tag))
            {
                this.rtxLog.SelectionColor = tagColor;
                this.rtxLog.SelectedText = "……"; 
                this.rtxLog.SelectedText = tag; 
            }
            this.rtxLog.SelectedText = "\r\n";
            this.rtxLog.ScrollToCaret();
            this.ssbTips.Text = work;
        }
        #endregion
    }
}
