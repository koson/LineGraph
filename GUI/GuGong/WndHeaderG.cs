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
    public partial class WndHeaderG : UserControl
    {
        public WndHeaderG()
        {
            InitializeComponent();

            //logo图片位置
            pictureBoxBG.SendToBack();//将背景图片放到最下面
            pictureBoxPrjName.BackColor = Color.Transparent;//将Panel设为透明
            pictureBoxPrjName.Parent = this.pictureBoxBG;//将panel父控件设为背景图片控件
            pictureBoxPrjName.BringToFront();//将panel放在前面
            pictureBoxGuGong.BackColor = Color.Transparent;//将Panel设为透明
            pictureBoxGuGong.Parent = this.pictureBoxBG;//将panel父控件设为背景图片控件
            pictureBoxGuGong.BringToFront();//将panel放在前面
            pictureBoxZi.BackColor = Color.Transparent;//将Panel设为透明
            pictureBoxZi.Parent = this.pictureBoxBG;//将panel父控件设为背景图片控件
            pictureBoxZi.BringToFront();//将panel放在前面
            pictureBoxCQiang.BackColor = Color.Transparent;//将Panel设为透明
            pictureBoxCQiang.Parent = this.pictureBoxBG;//将panel父控件设为背景图片控件
            pictureBoxCQiang.BringToFront();//将panel放在前面
        }
    }
}
