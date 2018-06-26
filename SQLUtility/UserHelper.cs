using System;
using System.Collections.Generic;
using System.Text;

namespace LineGraph.SQLUtility
{
    //��¼��¼���û�Id
    class UserHelper
    {
        //public static int loginId;  //��¼���û�Id
        public static string DeviceStyleTableName = "DeviceStyle";
        public static string[] DeviceStyleTable = {"�豸����"};
        public static string[] sDeviceName = { "����ˮ׼��", "��Ǵ�����", "���ٶȼ�" };
        public static int nDeviceNum = 3;

        public static string DeviceCompanyTableName = "DeviceCompany";
        public static string[] DeviceCompanyTable = { "��λ����" };
        public static string[] sCompanyName = { "��������ҿƼ����޹�˾/�������", "�Ͼ����޵��Ӽ������޹�˾/�Ͼ�����" };
        public static int nCompanyNum = 2;

        public static string[] sProtocolName = { "����Э��", "RTUЭ��" };
        public static int nProtocolNum = 2;

        public static string[] sProtocolNO = { "68,04,00,04,08 ", " 02,03,00,04,00,02,85,F9" };
        public static int nProtocolNONum = 2;

        public static string[] UsersTable = { "ID", "LoginPwd" };

        public static string SensorProducerTableName = "SensorProducer";
        public static string[] SensorProducerTable = { "���", "����","�ͺ�", "����ȫ�ƺͼ��", "��Ϣ����", "Э������", "ͨѶЭ��", "�豸���","�ƶ�����" };
        //����ˮ׼��/SCA110T/��λ����/

        public static string SensorDeviceTableName = "SensorDevice";
        //public static string[] SensorDeviceTable = { "ID", "NAME", "�ͺ�", "��λ����", "POS_X", "POS_Y", "POS_Z", "NOID" , "��ע" };
        public static string[] SensorDeviceTable = { "DEVICEID", "��λ����", "����", "ADRNO", "DTUID", "POS_X", "POS_Y", "POS_Z"};

        public static string[] SensorDataTableName = { "SensorSZData", "SensorQJData", "SensorJSData" };
        public static string[] SensorSZDataTable = { "ID", "NOID",  "������ʼֵ",  "��������ֵ",  "�������α仯��", "�����ۼƱ仯��", "TIME" };
        public static string[] SensorQJDataTable = { "ID", "NOID", "X��ʼֵ", "Y��ʼֵ", "X����ֵ", "Y����ֵ", "X���α仯��", "Y���α仯��", "X�ۼƱ仯��", "Y�ۼƱ仯��", "TIME" };
        public static string[] SensorJSDataTable = { "ID","NOID", "X��ʼֵ", "Y��ʼֵ", "Z��ʼֵ", "X����ֵ", "Y����ֵ", "Z����ֵ", "X���α仯��", "Y���α仯��", "Z���α仯��", "X�ۼƱ仯��", "Y�ۼƱ仯��", "Z�ۼƱ仯��", "TIME" };

        public class QINGJIAOData
        {
            public string strNOID { get; set; }
            public float QINGJIAO_TX { get; set; }//����
            public float QINGJIAO_TY { get; set; }

            public float QINGJIAO_OX { get; set; }//��ʼֵ
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


