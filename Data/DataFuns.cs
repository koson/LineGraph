using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LineGraph.Data
{
    public static class Funs
    {
        /*CRC算法
        2.1.置16位寄存器为全1，作为CRC寄存器。
        2.2.把一个8位数据与16位CRC寄存器的低字节相异或，把结果放于CRC寄存器中。
        2.3.把寄存器的内容右移一位（朝低位），用0填补最高位，检查最低位（移出位）。
        2.4.如果最低位为0，重复2.3（再移位）；如果最低位为1，CRC寄存器与多项式A001H（1010 0000 0000 0001）进行异或。
        2.5.重复2.3、2.4，直到右移8次，这样整个8位数据全部进行了处理。
        2.6.重复2.2－2.5，进行下一个8位数据的处理。
        2.7.将一帧的所有数据字节处理完后得到CRC-16寄存器。
        2.8.将CRC-16寄存器的低字节和高字节交换，得到的值即为CRC-16码。
        */
        public static string GetCRC16(byte[] code)
        {
            string crcString = "";
            int crcRegister = 0xffff;
            for (int i = 0; i < code.Length - 1; i++)
            {
                crcRegister = (crcRegister & 0xff00) | code[i] ^ (crcRegister & 0xff);
                int cf = 0;
                for (int j = 0; j < 8; j++)
                {
                    cf = crcRegister & 1;
                    crcRegister = crcRegister >> 1;
                    if (cf == 1)
                        crcRegister = crcRegister ^ 0xA001;
                }
            }
            int t = crcRegister & 0xff;
            crcRegister = crcRegister >> 8;
            crcRegister = crcRegister & 0xff;
            t = t << 8;
            t = t & 0xff00;
            crcRegister = t | crcRegister;
            crcString = Convert.ToString(crcRegister, 16).ToUpper();
            return crcString;
        }

        /// <summary>
        /// Calculates the CRC16 for Modbus-RTU
        /// </summary>
        /// <param name="data">Byte buffer to send</param>
        /// <param name="numberOfBytes">Number of bytes to calculate CRC</param>
        /// <param name="startByte">First byte in buffer to start calculating CRC</param>
        public static UInt16 calculateCRC(byte[] data, UInt16 numberOfBytes, int startByte)
        {
            byte[] auchCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40
            };

            byte[] auchCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
            0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
            0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
            0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
            0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
            0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
            0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
            0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
            0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
            0x40
            };
            UInt16 usDataLen = numberOfBytes;
            byte uchCRCHi = 0xFF;
            byte uchCRCLo = 0xFF;
            int i = 0;
            int uIndex;
            while (usDataLen > 0)
            {
                usDataLen--;
                if ((i + startByte) < data.Length)
                {
                    uIndex = uchCRCLo ^ data[i + startByte];
                    uchCRCLo = (byte)(uchCRCHi ^ auchCRCHi[uIndex]);
                    uchCRCHi = auchCRCLo[uIndex];
                }
                i++;
            }
            return (UInt16)((UInt16)uchCRCHi << 8 | uchCRCLo);
        }
        /// <summary>
        /// 将二进制值转ASCII格式十六进制字符串
        /// </summary>
        /// <paramname="data">二进制值</param>
        /// <paramname="length">定长度的二进制</param>
        /// <returns>ASCII格式十六进制字符串</returns>
        public static float[] dataProcess(ushort[] data)
        {
            byte[] byteArray1 = BitConverter.GetBytes(data[0]);
            byte[] byteArray2 = BitConverter.GetBytes(data[1]);
            byte[] byteArray3 = BitConverter.GetBytes(data[2]);
            byte[] byteArray4 = BitConverter.GetBytes(data[3]);
            byte[] byteArray5 = BitConverter.GetBytes(data[4]);
            byte[] byteArray6 = BitConverter.GetBytes(data[5]);
            byte[] byteArray7 = BitConverter.GetBytes(data[6]);
            byte[] byteArray8 = BitConverter.GetBytes(data[7]);
            byte[] byteArray9 = BitConverter.GetBytes(data[8]);
            byte[] byteArray10 = BitConverter.GetBytes(data[9]);
            byte[] byteArray11 = BitConverter.GetBytes(data[10]);
            byte[] byteArray12 = BitConverter.GetBytes(data[11]);


            byte[] intBufferCH1 = new byte[4];
            byte[] intBufferCH2 = new byte[4];
            byte[] intBufferCH3 = new byte[4];
            byte[] intBufferCH4 = new byte[4];
            byte[] intBufferCH5 = new byte[4];
            byte[] intBufferCH6 = new byte[4];

            intBufferCH1[0] = byteArray1[1];
            intBufferCH1[1] = byteArray1[0];
            intBufferCH1[2] = byteArray2[1];
            intBufferCH1[3] = byteArray2[0];
            intBufferCH2[0] = byteArray3[1];
            intBufferCH2[1] = byteArray3[0];
            intBufferCH2[2] = byteArray4[1];
            intBufferCH2[3] = byteArray4[0];
            intBufferCH3[0] = byteArray5[1];
            intBufferCH3[1] = byteArray5[0];
            intBufferCH3[2] = byteArray6[1];
            intBufferCH3[3] = byteArray6[0];
            intBufferCH4[0] = byteArray7[1];
            intBufferCH4[1] = byteArray7[0];
            intBufferCH4[2] = byteArray8[1];
            intBufferCH4[3] = byteArray8[0];
            intBufferCH5[0] = byteArray9[1];
            intBufferCH5[1] = byteArray9[0];
            intBufferCH5[2] = byteArray10[1];
            intBufferCH5[3] = byteArray10[0];
            intBufferCH6[0] = byteArray11[1];
            intBufferCH6[1] = byteArray11[0];
            intBufferCH6[2] = byteArray12[1];
            intBufferCH6[3] = byteArray12[0];

            float CH1 = ByteToFloat(intBufferCH1);
            float CH2 = ByteToFloat(intBufferCH2);
            float CH3 = ByteToFloat(intBufferCH3);
            float CH4 = ByteToFloat(intBufferCH4);
            float CH5 = ByteToFloat(intBufferCH5);
            float CH6 = ByteToFloat(intBufferCH6);
            float[] result = { CH1, CH2, CH3, CH4, CH5, CH6 };
            return result;
        }


        /// <summary>
        /// 将二进制值转ASCII格式十六进制字符串
        /// </summary>
        /// <paramname="data">二进制值</param>
        /// <paramname="length">定长度的二进制</param>
        /// <returns>ASCII格式十六进制字符串</returns>
        public static string toHexString(int data, int length)
        {
            string result = "";
            if (data > 0)
                result = Convert.ToString(data, 16).ToUpper();
            if (result.Length < length)
            {
                // 位数不够补0
                StringBuilder msg = new StringBuilder(0);
                msg.Length = 0;
                msg.Append(result);
                for (; msg.Length < length; msg.Insert(0, "0")) ;
                result = msg.ToString();
            }
            return result;
        }
        ///<summary>
        /// 将浮点数转ASCII格式十六进制字符串（符合IEEE-754标准（32））
        /// </summary>
        /// <paramname="data">浮点数值</param>
        /// <returns>十六进制字符串</returns>
        public static string FloatToIntString(float data)
        {
            byte[] intBuffer = BitConverter.GetBytes(data);
            StringBuilder stringBuffer = new StringBuilder(0);
            for (int i = 0; i < intBuffer.Length; i++)
            {
                stringBuffer.Insert(0, toHexString(intBuffer[i] & 0xff, 2));
            }
            return stringBuffer.ToString();
        }

        /// <summary>
        /// 将ASCII格式十六进制字符串转浮点数（符合IEEE-754标准（32））
        /// </summary>
        /// <param name="data">16进制字符串</param>
        /// <returns></returns>
        public static float StringToFloat(String data)
        {
            if (data.Length < 8 || data.Length > 8)
            {
                //throw new NotEnoughDataInBufferException(data.length(), 8);
                return 0;
            }
            else
            {
                byte[] intBuffer = new byte[4];
                // 将16进制串按字节逆序化（一个字节2个ASCII码）
                for (int i = 0; i < 4; i++)
                {
                    intBuffer[i] = Convert.ToByte(data.Substring((3 - i) * 2, 2), 16);
                }
                return BitConverter.ToSingle(intBuffer, 0);
            }
        }


        /// <summary>
        /// 将byte数组转为浮点数
        /// </summary>
        /// <param name="bResponse">byte数组</param>
        /// <returns></returns>
        public static float ByteToFloat(byte[] bResponse)
        {
            if (bResponse.Length < 4 || bResponse.Length > 4)
            {
                //throw new NotEnoughDataInBufferException(data.length(), 8);
                return 0;
            }
            else
            {
                byte[] intBuffer = new byte[4];
                //将byte数组的位置调换
                intBuffer[0] = bResponse[3];
                intBuffer[1] = bResponse[2];
                intBuffer[2] = bResponse[1];
                intBuffer[3] = bResponse[0];
                return BitConverter.ToSingle(intBuffer, 0);

            }
        }

        public static string DeleteSpacce(string s)
        {
            s = s.Replace(" ", "");
            return s;
        }

        public static string BaToS(byte[] buffer)
        {
            int n = buffer.Length;
            StringBuilder builder = new StringBuilder();
            string s = "";
            foreach (byte b in buffer)
            {
                builder.Append(b.ToString("X2") + " ");
            }
            s = builder.ToString();
            s = DeleteSpacce(s);
            return s;
        }

        /// <summary>
        /// 将字符串转为字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns>返回字节数组</returns>
        public static byte[] SToBa(string s)
        {
            s = s.Replace(" ", "");
            byte[] Sendbyte = new byte[s.Length / 2];
            for (int i = 0, j = 0; i < s.Length; i = i + 2, j++)
            {
                string mysubsing = s.Substring(i, 2);
                Sendbyte[j] = Convert.ToByte(mysubsing, 16);
            }

            return Sendbyte;
        }

        public static int ByteToInt(byte[] bResponse)
        {
            if (bResponse.Length < 2 || bResponse.Length > 2)
            {
                //throw new NotEnoughDataInBufferException(data.length(), 8);
                return 0;
            }
            else
            {
                byte[] intBuffer = new byte[2];
                //将byte数组的位置调换
                intBuffer[0] = bResponse[1];
                intBuffer[1] = bResponse[0];

                return BitConverter.ToInt16(intBuffer, 0);

            }
        }


        /// <summary>
        /// 十进制转换为bcd编码
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int IntToBcd(int a)
        {
            int ret = 0, shl = 0;
            while (a > 0)
            {
                ret |= (a % 10) << shl;
                a /= 10;
                shl += 4;
            }
            return ret;
        }

        /// <summary>
        /// 将BCD码专为int十进制
        /// </summary>
        /// <param name="body">byte数据</param>
        /// <param name="offset">起始偏移量</param>
        /// <param name="len">BCD长度（包含字节书）</param>
        /// <returns>返回转换完成的十进制结果</returns>
        public static int Bcd2Int(byte[] body, int offset, int len)
        {
            int ret = 0;
            for (int i = 0; i < len; i++)
            {
                int tmp = ((body[offset + len - 1 - i] >> 4) & 0x0F) * 10 + ((body[offset + len - 1 - i]) & 0x0F);
                ret = ret * 100 + tmp;
            }
            return ret;
        }

        /// <summary>
        /// 获取本机的IP地址，第一个IPV4地址，失败的话返回默认"192.168.0.1";
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            try
            {
                string hostName = Dns.GetHostName(); //得到主机名
                IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
                foreach (IPAddress ip in ipEntry.AddressList)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "192.168.0.1";
            }
            catch (Exception)
            {
                //MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "192.168.0.1";
            }
        }

        /// <summary>
        /// 去掉冠字号码识别错误的内容，用_替代 
        /// </summary>
        /// <param name="code">待处理的冠字号</param>
        /// <returns>处理后的冠字号</returns>
        public static string ReplaceBadCharOfRmbCode(string code)
        {
            byte[] str = Encoding.ASCII.GetBytes(code);
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] < '0' || str[i] > '9') && (str[i] < 'a' || str[i] > 'z') && (str[i] < 'A' || str[i] > 'Z'))
                {
                    str[i] = (byte)('_');
                }
            }
            return Encoding.ASCII.GetString(str);
        }

        /// <summary>
        /// 判断文件是否被占用
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>true表示正在使用,false没有使用</returns>
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,

                FileShare.None);

                inUse = false;
            }
            catch
            {
                // ignored
            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用
        }


        private static List<DateTime> _dtShowed = new List<DateTime>();

        /// <summary>
        /// 在文件名上用，获取一个不重复的时间字符串
        /// </summary>
        /// <param name="formatString">格式化字符串，务必输入正确</param>
        /// <returns></returns>
        public static string GetNoneRepeadTimeString(string formatString)
        {
            DateTime dtnow = DateTime.Now;

            lock (_dtShowed)
            {
                do
                {
                    bool hasRepeat = false;
                    foreach (DateTime dt in _dtShowed)
                    {
                        if (dtnow.ToString(formatString) == dt.ToString(formatString))
                        {
                            hasRepeat = true;
                        }
                    }
                    if (hasRepeat)
                    {
                        dtnow = dtnow.AddMilliseconds(50);
                    }
                    else
                    {
                        break;
                    }
                } while (true);


                _dtShowed.Add(dtnow);

                while (_dtShowed.Count > 30)
                {
                    _dtShowed.RemoveAt(0);
                }
            }

            return dtnow.ToString(formatString);
        }

        /// <summary>
        /// 获取随机的冠字号码：2位大写字母+8位数字
        /// </summary>
        /// <returns></returns>
        public static string GetRandRmbCode()
        {
            return GetRndString(2, false, false, true, false, "") + GetRndString(8, true, false, false, false, "");
        }

        ///<summary>
        ///生成随机字符串
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRndString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum) { str += "0123456789"; }
            if (useLow) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

 

        //常用正则表达式
        /*
        "^\d+$" //非负整数（正整数 + 0） 
        "^[0-9]*[1-9][0-9]*$" //正整数 
        "^((-\d+)|(0+))$" //非正整数（负整数 + 0） 
        "^-[0-9]*[1-9][0-9]*$" //负整数 
        "^-?\d+$" //整数 
        "^\d+(\.\d+)?$" //非负浮点数（正浮点数 + 0） 
        "^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$" //正浮点数 
        "^((-\d+(\.\d+)?)|(0+(\.0+)?))$" //非正浮点数（负浮点数 + 0） 
        "^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$" //负浮点数 
        "^(-?\d+)(\.\d+)?$" //浮点数 
        "^[A-Za-z]+$" //由26个英文字母组成的字符串 
        "^[A-Z]+$" //由26个英文字母的大写组成的字符串 
        "^[a-z]+$" //由26个英文字母的小写组成的字符串 
        "^[A-Za-z0-9]+$" //由数字和26个英文字母组成的字符串 
        "^\w+$" //由数字、26个英文字母或者下划线组成的字符串 
        "^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$" //email地址 
        "^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$" //url 
        /^(d{2}|d{4})-((0([1-9]{1}))|(1[1|2]))-(([0-2]([1-9]{1}))|(3[0|1]))$/ // 年-月-日 
        /^((0([1-9]{1}))|(1[1|2]))/(([0-2]([1-9]{1}))|(3[0|1]))/(d{2}|d{4})$/ // 月/日/年 
        "^([w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$" //Emil 
        "(d+-)?(d{4}-?d{7}|d{3}-?d{8}|^d{7,8})(-d+)?" //电话号码 
        "^(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5])$" //IP地址 

        YYYY-MM-DD基本上把闰年和2月等的情况都考虑进去了 
        ^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$
        */


        /// <summary>
        /// 判断输入的字符串是否仅为字母
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool CheckStringOnlyHaveLetter(string val)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(val, @"^[A-Za-z]+$");
        }

        /// <summary>
        /// 判断输入的字符串是否仅为数字
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool CheckStringOnlyHaveNumber(string val)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(val, @"^-?\d+$");
        }

        /// <summary>
        /// 判断输入的字符串是否为数字和字母的组合
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool CheckStringOnlyHaveLetterAndNumber(string val)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(val, @"^[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 根据传入文件名（全路径），返回可以使用的文件名，如果有重名，则自动加入_1、_2之类的后缀，直至没有重名
        /// </summary>
        /// <param name="fileName">待检查文件名</param>
        /// <returns></returns>
        public static string GetAvailableFileName(string fileName)
        {
            string retName = fileName;
            string extend = Path.GetExtension(fileName);
            int suffixNo = 0;
            while (File.Exists(fileName))
            {
                string oldSuffix = string.Format("_{0}.{1}", suffixNo, extend);
                suffixNo++;
                string newSuffix = string.Format("_{0}.{1}", suffixNo, extend);
                if (fileName.Contains(oldSuffix))
                {
                    retName = fileName.Replace(oldSuffix, newSuffix);
                }
                else
                {
                    retName = fileName.Replace("." + extend, newSuffix);
                }

            }

            return retName;
        }


    }
}
