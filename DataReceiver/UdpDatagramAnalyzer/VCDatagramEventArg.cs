using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineGraph.DataReceiver
{
    /// <summary>
    /// VC数据报文解析事件参数
    /// </summary>
    public class VCDatagramEventArg : EventArgs
    {
        /// <summary>
        /// 解析完成的数据报文数据模型实例
        /// </summary>
        public VCParamsDatagramModel Data { get; set; }

        public VCDatagramEventArg(VCParamsDatagramModel data)
        {
            Data = data;
        }
    }
}
