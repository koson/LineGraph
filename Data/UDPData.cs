using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineGraph.Data
{
    /// <summary>
    /// VC数据报协议参数数据模型
    /// </summary>
    public class UDPData
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
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 测站类型
        /// </summary>
        public int StationType { get; set; }

        public float Temprature { get; set; }

        public float QINGJIAO_X { get; set; }
        public float QINGJIAO_Y { get; set; }

        public float JIASUDU_X { get; set; }
        public float JIASUDU_Y { get; set; }
        public float JIASUDU_Z { get; set; }

        //public float ZHENDONG { get; set; }

        public float CHENJIANG { get; set; }
    }
}
