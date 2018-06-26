using System;
using System.Collections.Generic;
using System.Text;

namespace LineGraph.SQLUtility
{
    //记录登录的用户Id
    class UserHelper
    {
        //public static int loginId;  //登录的用户Id
        public static string DeviceStyleTableName = "DeviceStyle";
        public static string[] DeviceStyleTable = {"设备类型"};
        public static string[] sDeviceName = { "静力水准仪", "倾角传感器", "加速度计" };
        public static int nDeviceNum = 3;

        public static string DeviceCompanyTableName = "DeviceCompany";
        public static string[] DeviceCompanyTable = { "单位名称" };
        public static string[] sCompanyName = { "深圳市瑞芬科技有限公司/深圳瑞芬", "南京西巨电子技术有限公司/南京西巨" };
        public static int nCompanyNum = 2;

        public static string[] sProtocolName = { "自由协议", "RTU协议" };
        public static int nProtocolNum = 2;

        public static string[] sProtocolNO = { "68,04,00,04,08 ", " 02,03,00,04,00,02,85,F9" };
        public static int nProtocolNONum = 2;

        public static string[] UsersTable = { "ID", "LoginPwd" };

        public static string SensorProducerTableName = "SensorProducer";
        public static string[] SensorProducerTable = { "序号", "类型","型号", "厂家全称和简称", "信息描述", "协议类型", "通讯协议", "设备编号","制定日期" };
        //静力水准仪/SCA110T/单位名称/

        public static string SensorDeviceTableName = "SensorDevice";
        //public static string[] SensorDeviceTable = { "ID", "NAME", "型号", "单位名称", "POS_X", "POS_Y", "POS_Z", "NOID" , "备注" };
        public static string[] SensorDeviceTable = { "DEVICEID", "单位名称", "类型", "ADRNO", "DTUID", "POS_X", "POS_Y", "POS_Z"};

        public static string[] SensorDataTableName = { "SensorSZData", "SensorQJData", "SensorJSData" };
        public static string[] SensorSZDataTable = { "ID", "NOID",  "沉降初始值",  "沉降测试值",  "沉降单次变化量", "沉降累计变化量", "TIME" };
        public static string[] SensorQJDataTable = { "ID", "NOID", "X初始值", "Y初始值", "X测试值", "Y测试值", "X单次变化量", "Y单次变化量", "X累计变化量", "Y累计变化量", "TIME" };
        public static string[] SensorJSDataTable = { "ID","NOID", "X初始值", "Y初始值", "Z初始值", "X测试值", "Y测试值", "Z测试值", "X单次变化量", "Y单次变化量", "Z单次变化量", "X累计变化量", "Y累计变化量", "Z累计变化量", "TIME" };

        public class QINGJIAOData
        {
            public string strNOID { get; set; }
            public float QINGJIAO_TX { get; set; }//测试
            public float QINGJIAO_TY { get; set; }

            public float QINGJIAO_OX { get; set; }//初始值
            public float QINGJIAO_OY { get; set; }

            public QINGJIAOData()
            {
                QINGJIAO_TX = 0;
                QINGJIAO_TY = 0;

                QINGJIAO_OX = 0;
                QINGJIAO_TY = 0;
            }
        }

        public static List<KeyValuePair<string, QINGJIAOData>> QINGJIAODataList = new List<KeyValuePair<string, QINGJIAOData>>();

        public class JIASUDUData
        {
            public string strNOID { get; set; }
            public float JIASUDU_TX { get; set; }
            public float JIASUDU_TY { get; set; }
            public float JIASUDU_TZ { get; set; }

            public float JIASUDU_OX { get; set; }
            public float JIASUDU_OY { get; set; }
            public float JIASUDU_OZ { get; set; }

            public JIASUDUData()
            {
                JIASUDU_TX = 0;
                JIASUDU_TY = 0;
                JIASUDU_TZ = 0;

                JIASUDU_OX = 0;
                JIASUDU_OY = 0;
                JIASUDU_OZ = 0;
            }
        }

        public static List<KeyValuePair<string, JIASUDUData>> JIASUDUDataList = new List<KeyValuePair<string, JIASUDUData>>();


        public class ShuiZhunData
        {
            public string strNOID { get; set; }
            public float ZHENDONGT { get; set; }
            public float CHENJIANGT { get; set; }

            public float ZHENDONGO { get; set; }
            public float CHENJIANGO { get; set; }

            public ShuiZhunData()
            {
                ZHENDONGT = 0;
                CHENJIANGT = 0;

                ZHENDONGO = 0;
                CHENJIANGO = 0;
            }
        }

        public static List<KeyValuePair<string, ShuiZhunData>> ShuiZhunDataList = new List<KeyValuePair<string, ShuiZhunData>>();
    }
}


