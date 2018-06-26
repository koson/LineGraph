//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LineGraph.DataReceiver
//{
//    /// <summary>
//    /// VC数据报协议参数数据模型
//    /// </summary>
//    public class VCParamsDatagramModel
//    {

//        /// <summary>
//        /// 设备ID,设备在平台上添加时的编号
//        /// </summary>
//        public string DeviceID { get; set; }

//        /// <summary>
//        /// 用户ID,设备在平台上添加时的编号
//        /// </summary>
//        public string UserID { get; set; }

//        /// <summary>
//        /// 报文类型
//        /// </summary>
//        public string CommandType { get; set; }

//        /// <summary>
//        /// 报文长度
//        /// </summary>
//        public string CommandLength { get; set; }

//        /// <summary>
//        /// 时间
//        /// </summary>
//        public DateTime Time { get; set; }

//        /// <summary>
//        /// 测站类型
//        /// </summary>
//        public int StationType { get; set; }

//        public string ID { get; set; }

//        public Dictionary<int, int> TempraturedataDic;
//        public float Temprature { get; set; }

//        public int QingQiaodataCount;
//        public Dictionary<int, int> QingQiaodataDic;
//        public float[,] QingQiao { get; set; }

//        public int JIASUDUdataCount;
//        public Dictionary<int, int> JIASUDUdataDic;
//        public float[,] JIASUDU { get; set; }

//        public int ZHENDONGdataCount;
//        public Dictionary<int, int> ZHENDONGdataDic;
//        public float[] ZHENDONG { get; set; }

//        public int CHENJIANGdataCount;
//        public Dictionary<int, int> CHENJIANGdataDic;
//        public float[] CHENJIANG { get; set; }


//        public VCParamsDatagramModel()
//        {
//            int[] TempraturecolName = { 0 };

//            TempraturedataDic = new Dictionary<int, int>();
//            TempraturedataDic.Add(TempraturecolName[0], 0);
//            Temprature = 0;

//            QingQiaodataCount = 0;
//            int[] QingQiaocolName = { 300, 301, 302 };
//            QingQiao = new float[32,3];
//            //for (int i = 0; i < 32; i++)
//            //{
//            //    for (int j = 0; j < 3; j++)
//            //    {
//            //        QingQiao[i, j] = 0;
//            //    }
//            //}
//            QingQiaodataDic = new Dictionary<int, int>();
//            for (int i = 0; i < 3; i++)
//            {
//                QingQiaodataDic.Add(QingQiaocolName[i], i);  
//            }

//            JIASUDUdataCount = 0;
//            int[] JIASUDUcolName = { 303, 304, 305 };
//            JIASUDU = new float[32,3];
//            //for (int i = 0; i < 32; i++)
//            //{
//            //    for (int j = 0; j < 3; j++)
//            //    {
//            //        JIASUDU[i, j] = 0;
//            //    }
//            //}
//            JIASUDUdataDic = new Dictionary<int, int>();
//            for (int i = 0; i < 3; i++)
//            {
//                JIASUDUdataDic.Add(JIASUDUcolName[i], i);
//            }

//            ZHENDONGdataCount = 0;
//            int[] ZHENDONcolName = { 306 };
//            ZHENDONG = new float[32];
//            //for (int i = 0; i < 32; i++)
//            //{
//            //    ZHENDONG[i] = 0;
//            //}
//            ZHENDONGdataDic = new Dictionary<int, int>();
//            ZHENDONGdataDic.Add(ZHENDONcolName[0],0);

//            CHENJIANGdataCount = 0;
//            int[] CHENJIANGcolName = { 307 };
//            CHENJIANG = new float[32];
//            //for (int i = 0; i < 32; i++)
//            //{
//            //    CHENJIANG[i] = 0;
//            //}
//            CHENJIANGdataDic = new Dictionary<int, int>();
//            CHENJIANGdataDic.Add(CHENJIANGcolName[0], 0);
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineGraph.DataReceiver
{
    /// <summary>
    /// VC数据报协议参数数据模型
    /// </summary>
    public class VCParamsDatagramModel
    {

        /// <summary>
        /// 设备ID,设备在平台上添加时的编号
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// 用户ID,设备在平台上添加时的编号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 报文类型
        /// </summary>
        public string CommandType { get; set; }

        /// <summary>
        /// 报文长度
        /// </summary>
        public string CommandLength { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 测站类型
        /// </summary>
        public int StationType { get; set; }

        public string ID { get; set; }

        public Dictionary<int, int> TempraturedataDic;
        public float Temprature { get; set; }

        public int QingQiaodataCount;
        public Dictionary<int, int> QingQiaodataDic;
        public float[,] QingQiao { get; set; }

        public int JIASUDUdataCount;
        public Dictionary<int, int> JIASUDUdataDic;
        public float[,] JIASUDU { get; set; }

        public int ZHENDONGdataCount;
        public Dictionary<int, int> ZHENDONGdataDic;
        public float[] ZHENDONG { get; set; }

        public int CHENJIANGdataCount;
        public Dictionary<int, int> CHENJIANGdataDic;
        public float[] CHENJIANG { get; set; }

        public VCParamsDatagramModel()
        {
            int[] TempraturecolName = { 0 };

            TempraturedataDic = new Dictionary<int, int>();
            TempraturedataDic.Add(TempraturecolName[0], 0);
            Temprature = 0;

            QingQiaodataCount = 0;
            int[] QingQiaocolName = { 300, 301, 302 };
            QingQiao = new float[32, 3];
            QingQiaodataDic = new Dictionary<int, int>();
            for (int i = 0; i < 3; i++)
            {
                QingQiaodataDic.Add(QingQiaocolName[i], i);
            }

            JIASUDUdataCount = 0;
            int[] JIASUDUcolName = { 303, 304, 305 };
            JIASUDU = new float[32, 3];
            JIASUDUdataDic = new Dictionary<int, int>();
            for (int i = 0; i < 3; i++)
            {
                JIASUDUdataDic.Add(JIASUDUcolName[i], i);
            }

            ZHENDONGdataCount = 0;
            int[] ZHENDONcolName = { 306 };
            ZHENDONG = new float[32];
            ZHENDONGdataDic = new Dictionary<int, int>();
            ZHENDONGdataDic.Add(ZHENDONcolName[0], 0);

            CHENJIANGdataCount = 0;
            int[] CHENJIANGcolName = { 307 };
            CHENJIANG = new float[32];
            CHENJIANGdataDic = new Dictionary<int, int>();
            CHENJIANGdataDic.Add(CHENJIANGcolName[0], 0);
        }
    }
}

