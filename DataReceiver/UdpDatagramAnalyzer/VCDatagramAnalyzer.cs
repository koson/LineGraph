using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineGraph.DataReceiver
{
    /// <summary>
    /// VC网络数据报协议数据解析程序
    /// </summary>
    public sealed class VCDatagramAnalyzer : SimpleDatagramAnalyzer
    {
        /// <summary>
        /// 协议开始声明
        /// </summary>
        private const string HEADERCONTEXT = "7E7E";
       
        /// <summary>
        /// 协议头
        /// </summary>
        private const string PROTOCOLSTART = "<PPVSPMessage>";
        /// <summary>
        /// 协议尾
        /// </summary>
        private const string PROTOCOLEND = "</PPVSPMessage>";

        public event EventHandler<VCDatagramEventArg> OnAnalyzed;

        static VCDatagramAnalyzer()
        {
        }

        protected override byte[] Analyze(byte[] buffer)
        {
            try
            {
                string context = Data.Funs.BaToS(buffer);
       
                int offset = Analyze(context);
                context = context.Remove(0, offset);
                Array.Clear(buffer, 0, buffer.Length);
                buffer = Data.Funs.SToBa(context);
            }
            catch(Exception) 
            {
                Array.Clear(buffer, 0, buffer.Length);
                buffer = new byte[0];
            }

            return base.Analyze(buffer);
        }

        private int Analyze(string context, int offset = 0)
        {
            //查找数据报开头
            int index = context.IndexOf(HEADERCONTEXT, offset);
            if (-1 == index)
                return offset;

            int byteCount = 2;//7E7E(2字节)

            index += HEADERCONTEXT.Length;
            string sDeviceID = context.Substring(index, 16);
            Byte[] DeviceIDByte = Data.Funs.SToBa(sDeviceID);

            byteCount += 8;//8字节设备唯一编号

            index += 16;
            string sUserID = context.Substring(index, 10);
            Byte[] UserIDByte = Data.Funs.SToBa(sUserID);

            byteCount += 5;//5字节用户编号

            index += 10;
            string sDataStyle = context.Substring(index, 2);
            Byte[] DataStyleByte = Data.Funs.SToBa(sDataStyle);

            byteCount += 1;//1字节功能码

            index += 2;
            string sDataLength = context.Substring(index, 4);
            byte[] DataLengthByte = Data.Funs.SToBa(sDataLength);
            int nDataLength = Data.Funs.ByteToInt(DataLengthByte);
            nDataLength = nDataLength & 0xFFF;

            byteCount += 2;//2字节报文长度

            index += 4;
            string sDataBegin = context.Substring(index, 2);
            byte[] DataBeginByte = Data.Funs.SToBa(sDataBegin);

            byteCount += 1;//1字节起始符

            byteCount += nDataLength;
            byteCount += 1;

            offset = index;
            byte[] FlowIDByte;
            byte[] TimeByte;
            if(sDataBegin == "16")
            {
                throw new Exception("Capture 16");
            }
            if (sDataBegin == "02")
            {
                VCParamsDatagramModel tDatagramModel = new VCParamsDatagramModel();
             
                tDatagramModel.DeviceID = sDeviceID;
              
                index += 2;
                string sFlowID = context.Substring(index, 4);
                FlowIDByte = Data.Funs.SToBa(sFlowID);//2字节流水号

                index += 4;
                //index += 12;//6字节发送时间
                string sTime = context.Substring(index, 12);
                TimeByte = Data.Funs.SToBa(sTime);

                string TimeYear = context.Substring(index, 2);
                int nTimeYear = Convert.ToByte(TimeYear);
                string sTimeYear = string.Format("{0}{1}", 20, nTimeYear);
                nTimeYear = Convert.ToInt16(sTimeYear);

                index += 2;
                string sTimeMonth = context.Substring(index, 2);
                int nTimeMonth = Convert.ToByte(sTimeMonth);

                index += 2;
                string sTimeDay = context.Substring(index, 2);
                int nTimeDay = Convert.ToByte(sTimeDay);
                index += 2;

                string sTimeHour = context.Substring(index, 2);
                int nTimeHour = Convert.ToByte(sTimeHour);

                index += 2;
                string sTimeMinute = context.Substring(index, 2);
                int nTimeMinute = Convert.ToByte(sTimeMinute);

                index += 2;
                string sTimeSecond = context.Substring(index, 2);
                int nTimeSecond = Convert.ToByte(sTimeSecond);
                tDatagramModel.Time = new DateTime(nTimeYear, nTimeMonth, nTimeDay, nTimeHour, nTimeMinute, nTimeSecond);
                index += 2;

                index += 12;//6字节采集时间
                string sStationStyle = context.Substring(index, 2);
                int nStationStyle = Convert.ToByte(sStationStyle);
                tDatagramModel.StationType = nStationStyle;//1字节测站类型

                int nDataParaLength = (nDataLength - 15) / 8;//8字节数据（2要素编码地址	2数据类型 4数据域）

                index += 2;

                for (int i = 0; i < nDataParaLength; i++)
                {
                    string sDataParaStyle = context.Substring(index, 4);

                    byte[] DataParaStyle = Data.Funs.SToBa(sDataParaStyle);
                    int nDataParaStyle = Data.Funs.ByteToInt(DataParaStyle);
                    int nDataParaStyleIndex = nDataParaStyle & 0x1F;
                    nDataParaStyle = nDataParaStyle >> 5;

                    index += 4;//2要素编码地址
                    string sDataParaFloat = context.Substring(index, 2);
                    byte[] nDataParaFloat = Data.Funs.SToBa(sDataParaFloat);//高4位FLOAT 低4位正负、幂
                    int nDataParaF = nDataParaFloat[0] >> 4;//float
                    int nDataPara = nDataParaFloat[0] & 0x0F;
                    int nDataParaZ = nDataPara >> 3;//正负0为正，1为负。
                    int nDataParaM = nDataPara & 0x08;//幂
                    
                    index += 4;//2数据类型(低1字节保留)
                    string sDataParaValue = context.Substring(index, 8);
                    index += 8;//4数据域

                    float fDataParaValue = 0;
                    if (nDataParaF == 1)
                    {
                        byte[] DataParaValueByte = Data.Funs.SToBa(sDataParaValue);
                        fDataParaValue = Data.Funs.ByteToFloat(DataParaValueByte);
                    }
                    if (nDataParaF == 0)
                    {
                        byte[] DataParaValueByte = Data.Funs.SToBa(sDataParaValue);
                        fDataParaValue = Data.Funs.ByteToInt(DataParaValueByte);
                    }
                    if(nDataParaZ == 1)
                    {
                        fDataParaValue = -fDataParaValue;
                    }

                    fDataParaValue = fDataParaValue * (float)Math.Pow(10, nDataParaM);

                    if (tDatagramModel.TempraturedataDic.ContainsKey(nDataParaStyle))
                    {
                        tDatagramModel.Temprature = fDataParaValue;
                    }

                    if (tDatagramModel.QingQiaodataDic.ContainsKey(nDataParaStyle))
                    {
                        tDatagramModel.QingQiao[nDataParaStyleIndex, tDatagramModel.QingQiaodataDic[nDataParaStyle]] = fDataParaValue;
                        if ((nDataParaStyleIndex + 1) > tDatagramModel.QingQiaodataCount)
                        {
                            tDatagramModel.QingQiaodataCount = nDataParaStyleIndex + 1;
                        }
                    }

                    if (tDatagramModel.JIASUDUdataDic.ContainsKey(nDataParaStyle))
                    {
                        tDatagramModel.JIASUDU[nDataParaStyleIndex, tDatagramModel.JIASUDUdataDic[nDataParaStyle]] = fDataParaValue;

                        if ((nDataParaStyleIndex + 1) > tDatagramModel.JIASUDUdataCount)
                        {
                            tDatagramModel.JIASUDUdataCount = nDataParaStyleIndex + 1;
                        }
                    }

                    if (tDatagramModel.ZHENDONGdataDic.ContainsKey(nDataParaStyle))
                    {
                        tDatagramModel.ZHENDONG[nDataParaStyleIndex] = fDataParaValue;

                        if ((nDataParaStyleIndex + 1) > tDatagramModel.ZHENDONGdataCount)
                        {
                            tDatagramModel.ZHENDONGdataCount = nDataParaStyleIndex + 1;
                        }
                    }

                    if (tDatagramModel.CHENJIANGdataDic.ContainsKey(nDataParaStyle))
                    {
                        tDatagramModel.CHENJIANG[nDataParaStyleIndex] = fDataParaValue;

                        if ((nDataParaStyleIndex + 1) > tDatagramModel.CHENJIANGdataCount)
                        {
                            tDatagramModel.CHENJIANGdataCount = nDataParaStyleIndex + 1;
                        }
                    }
                }

                string sEnd = context.Substring(index, 2);
                if (sEnd == "03")
                {
                    //解析数据报
                    if (null != OnAnalyzed)
                    {
                        VCDatagramEventArg m = new VCDatagramEventArg(tDatagramModel);
                        OnAnalyzed(this, m);

                        Byte[] data = new byte[30];
                        data[0] = 0x7E;
                        data[1] = 0x7E;

                        Array.Copy(DeviceIDByte, 0, data, 2, DeviceIDByte.Length);
                        Array.Copy(UserIDByte, 0, data, 2 + DeviceIDByte.Length, UserIDByte.Length);

                        data[15] = DataStyleByte[0];
                        data[16] = 0x80;
                        data[17] = 0x08;
                        data[18] = 0x02;

                        Array.Copy(FlowIDByte, 0, data, 19, FlowIDByte.Length);

                        DateTime Date = DateTime.Now;
                        byte[] dataTime = new byte[6];
                        string sYear = Date.Year.ToString();
                        byte[] byteYear = Data.Funs.SToBa(sYear);
                        dataTime[0] = byteYear[1];

                        string sMonth = Date.Month.ToString();
                        dataTime[1] = Convert.ToByte(sMonth, 16);

                        string sDay = Date.Day.ToString();
                        dataTime[2] = Convert.ToByte(sDay, 16);

                        string sHour = Date.Hour.ToString();
                        dataTime[3] = Convert.ToByte(sHour, 16);

                        string sMinute = Date.Minute.ToString();
                        dataTime[4] = Convert.ToByte(sMinute, 16);

                        string sSecond = Date.Second.ToString();
                        dataTime[5] = Convert.ToByte(sSecond, 16);

                        Array.Copy(dataTime, 0, data, 19 + FlowIDByte.Length, dataTime.Length);


                        data[27] = 0x04;

                        //Create CRC
                        UInt16 crc = Data.Funs.calculateCRC(data, Convert.ToUInt16(data.Length - 8), 6);
                        byte[] byteData = BitConverter.GetBytes((int)crc);
                        data[data.Length - 2] = byteData[0];
                        data[data.Length - 1] = byteData[1];

                        //string scrc = GetCRC16(data);
                        //byte[] crcByte = SToBa(scrc);
                        //Array.Copy(crcByte, 0, data, 28, crcByte.Length);

                        SendAnswerData(data);
                    }
                }

                index += 2;

                index += 4;
            }
            else
            {
                return offset;
            }


            //重新赋值下一个数据报开始位置
            //并递归调用解析数据报
            offset = index + 1;
            return Analyze(context, offset);
        }
    }
}
