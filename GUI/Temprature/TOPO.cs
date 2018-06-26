using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace LineGraph.GUI
{
    class TOPO
    {
        public TOPO()
        { }

        Bitmap BT = null;
        Color co;
        public string[,] wh = null;
        int oldW;
        int oldH;

        /// <summary>
        /// 画TOPO图节点
        /// </summary>
        /// <param name="node">节点数组，包括节点ID码,节点温度,节点湿度,时间</param>
        /// <param name="ROU">路由器图片</param>
        /// <param name="RFD">终端节点图片</param>
        /// <param name="ImageWidth">图片宽度</param>
        /// <param name="ImageHeight">图片高度</param>
        /// <param name="to16">是否显示16进制</param>
        public void Node(string[,] node, Image ROU, Image RFD, int imageWidth, int imageHeight, bool to16)
        {
            try
            {
                if (node != null)
                {
                    int xx = 0;
                    int yy = 150;           //竖直间距
                    ImageHeight = imageHeight;
                    ImageWidth = imageWidth;
                    if (wh == null)
                    {
                        wh = new string[node.Length / 4, 2];
                        wh[0, 0] = Convert.ToString((BT.Width - ImageWidth) / 2);
                        wh[0, 1] = "0";
                    }
                    else
                    {
                        string[,] wh1 = wh;
                        wh = new string[node.Length / 4, 2];
                        if (wh1.Length <= wh.Length)
                        {
                            for (int i = 0; i < wh1.Length / 2; i++)
                            {
                                wh[i, 0] = wh1[i, 0];
                                wh[i, 1] = wh1[i, 1];
                            }
                        }
                        else
                        {
                            for (int i = 0; i < wh.Length / 2; i++)
                            {
                                wh[i, 0] = wh1[i, 0];
                                wh[i, 1] = wh1[i, 1];
                            }
                        }
                        for (int i = wh1.Length / 2 - 1; i >= 1; i--)
                        {
                            if (wh1[i, 0] != null)
                            {
                                xx = int.Parse(wh1[i, 0]);
                                yy = int.Parse(wh1[i, 1]);
                                break;
                            }
                        }
                    }


                    for (int i = 0; i < wh.Length / 2; i++)
                    {
                        if (wh[i, 0] == null)
                        {
                            if (xx + ImageWidth + 130 <= BT.Width)   //130代表水平间距
                            {
                                xx += ImageWidth + 130;
                            }
                            else
                            {
                                xx = 0;
                                yy += 50;         //竖直间距
                            }
                            wh[i, 0] = xx.ToString();
                            wh[i, 1] = yy.ToString();
                        }
                        else
                        {
                            wh[i, 0] = Convert.ToString(int.Parse(wh[i, 0]) * BT.Width / oldW);
                            wh[i, 1] = Convert.ToString(int.Parse(wh[i, 1]) * BT.Height / oldH);
                            if (int.Parse(wh[i, 0]) + ImageWidth + 30 > BT.Width)
                            {
                                wh[i, 0] = Convert.ToString(BT.Width - ImageWidth - 30);
                            }
                            if (int.Parse(wh[i, 1]) + ImageHeight + 50 > BT.Height)
                            {
                                wh[i, 1] = Convert.ToString(BT.Height - ImageHeight - 50);
                            }
                        }

                        if (node[i, 0] == "0")
                        {
                            DrawNode(ROU, int.Parse(wh[i, 0]), int.Parse(wh[i, 1]),"结点"+ node[i, 0], node[i, 1], node[i, 2], node[i, 3]);
                        }
                        else
                        {
                            DrawNode(RFD, int.Parse(wh[i, 0]), int.Parse(wh[i, 1]), "结点" + node[i, 0], node[i, 1], node[i, 2], node[i, 3]);
                        }
                        
                    }
                    Drawborder();
                    oldW = BT.Width;
                    oldH = BT.Height;
                }
            }
            catch
            {
            }
        }

        Font fon = new Font("宋体", 9F);
        int ImageWidth;
        int ImageHeight;

        public void DrawNode(Image Node, int x, int y, string name, string wd, string sd, string tm)
        {
            Graphics g = Graphics.FromImage(BT);
            g.DrawImage(Node, x, y, ImageWidth, ImageHeight);

            g.DrawString(name, fon, Brushes.Black, x - 15, ImageHeight + y + 3);
            if (name != "结点0")
            {
                g.DrawString("温度:" + 0.01*int.Parse(wd)+" ℃", fon, Brushes.Black, x - 15, ImageHeight + y + 17);
                g.DrawString("湿度:" + 0.01*int.Parse(sd)+" %", fon, Brushes.Black, x - 15, ImageHeight + y + 31);
                g.DrawString("时刻:" + tm, fon, Brushes.Black, x - 15, ImageHeight + y + 59);
            }            
        }
                

        /// <summary>
        /// 节点连线
        /// </summary>
        /// <param name="node">节点数组，包括节点地址，节点父地址，节点类型，节点信号强度</param>
        public void Nodeline(string[,] node)
        {
            if (node != null)
            {
                for (int i = 1; i < wh.Length / 2; i++)
                {
                    if (node[i, 0] != null)
                    {
                        Graphics g = Graphics.FromImage(BT);
                        Pen linepen = new Pen(Color.Green, 1);

                        float x = int.Parse(wh[i, 0]) + ImageWidth / 2 + (int.Parse(wh[0, 0]) - (int.Parse(wh[i, 0]) + ImageWidth / 2)) / 2;
                        float y = int.Parse(wh[i, 1]) + (int.Parse(wh[0, 1]) + ImageHeight / 2 - int.Parse(wh[i, 1])) / 2;
                        linepen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap((float)(linepen.Width * 3), (float)(linepen.Width * 4), true);
                        linepen.CustomStartCap = new System.Drawing.Drawing2D.AdjustableArrowCap((float)(linepen.Width * 3), (float)(linepen.Width * 4), true);
                        g.DrawLine(linepen, new Point(int.Parse(wh[i, 0]) + ImageWidth / 2, int.Parse(wh[i, 1])), new Point(int.Parse(wh[0, 0])
                            + ImageWidth / 2, int.Parse(wh[0, 1]) + ImageHeight / 2));
                        g.DrawString("连通", fon, Brushes.Black, x, y);

                    }
                }
            }
        }

        /// <summary>
        /// 清除TOPO图
        /// </summary>
        public void Clear()
        {
            Graphics g = Graphics.FromImage(BT);
            g.Clear(co);
        }

        public void ClearALL()
        {
            wh = null;
            CheckedNode = null;

            Graphics g = Graphics.FromImage(BT);
            g.Clear(co);
        }
        /// <summary>
        /// 返回TOPO图
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitMap()
        {
            return BT;
        }

        /// <summary>
        /// 设置TOPO图大小
        /// </summary>
        /// <param name="width">TOPO图宽</param>
        /// <param name="height">TOPO图高</param>
        public void bitmap(int width, int height)
        {
            if (BT != null)
            {
                oldW = BT.Width;
                oldH = BT.Height;
            }
            else
            {
                oldW = width;
                oldH = height;
            }
            BT = new Bitmap(width, height);

            co = BT.GetPixel(10, 10);
        }
        string CheckedNode = null;

        public void mouseclick(int x, int y)
        {
            CheckedNode = null;
            if (wh != null)
            {
                for (int i = 0; i < wh.Length / 2; i++)
                {
                    if (wh[i, 0] != null && int.Parse(wh[i, 0]) <= x && x <= int.Parse(wh[i, 0]) + ImageWidth && int.Parse(wh[i, 1]) <= y && y <= int.Parse(wh[i, 1]) + ImageHeight)
                    {
                        if (CheckedNode == null || int.Parse(CheckedNode) != i)
                        {
                            CheckedNode = i.ToString();
                            return;
                        }
                    }
                }
            }
        }

        public void mousemove(int x, int y)
        {
            if (wh != null)
            {
                if (CheckedNode != null && int.Parse(CheckedNode) < wh.Length / 2)
                {
                    wh[int.Parse(CheckedNode), 0] = x.ToString();
                    wh[int.Parse(CheckedNode), 1] = y.ToString();
                }
            }
        }

        public void Drawborder()
        {
            if (CheckedNode != null && wh != null && int.Parse(CheckedNode) < wh.Length / 2)
            {
                Graphics g = Graphics.FromImage(BT);
                Pen p = new Pen(Color.Blue);
                p.DashStyle = DashStyle.Dash;
                g.DrawRectangle(p, int.Parse(wh[int.Parse(CheckedNode), 0]) - 25, int.Parse(wh[int.Parse(CheckedNode), 1]) - 5, ImageWidth + 50, ImageHeight + 80);
                //g.FillRectangle(Brushes.LightSkyBlue, int.Parse(wh[int.Parse(CheckedNode), 0]) - 25, int.Parse(wh[int.Parse(CheckedNode), 1]) - 5, ImageWidth + 50, ImageHeight + 30);
            }
        }

        public void DrawborderNUM(int i)
        {
            if (i < wh.Length / 2)
            {
                Graphics g = Graphics.FromImage(BT);

                Pen p = new Pen(Color.Red);
                p.DashStyle = DashStyle.Dash;
                g.DrawRectangle(p, int.Parse(wh[i, 0]) - 27, int.Parse(wh[i, 1]) - 7, ImageWidth + 52, ImageHeight + 82);
            }
        }

        public void treechecked(int check)
        {
            CheckedNode = check.ToString();
        }

        public string getchecked()
        {
            return CheckedNode;
        }
        
    }
}
