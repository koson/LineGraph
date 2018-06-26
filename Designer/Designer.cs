using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LineGraph.Designer
{
    public class Designer
    {
        [DllImport("M5Designer.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern void InitPlugin();

        [DllImport("M5Designer.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern void DestroyPlugin();

    }
}
