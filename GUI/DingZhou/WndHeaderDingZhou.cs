using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineGraph.GUI
{
    public partial class WndHeaderDingZhou : UserControl
    {
        public WndHeaderDingZhou()
        {
            InitializeComponent();

            //logo图片位置
            pictureBoxBG.SendToBack();//将背景图片放到最下面
        }
    }
}
