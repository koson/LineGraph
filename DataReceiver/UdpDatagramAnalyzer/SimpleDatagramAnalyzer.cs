using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineGraph.DataReceiver
{
    /// <summary>
    /// 简单的网络数据报协议数据解析程序
    /// </summary>
    public class SimpleDatagramAnalyzer : DatagramAnalyzer
    {
        protected override byte[] Analyze(byte[] buffer)
        {
            return buffer;
        }
    }
}
