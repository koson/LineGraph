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
    public partial class SplashScreenGuGong : Form
    {
        /// <summary>  
        /// 启动画面本身  
        /// </summary>  
        static SplashScreenGuGong instance;
        /// <summary>  
        /// 显示的图片  
        /// </summary>  
        Bitmap bitmap;

        public static SplashScreenGuGong Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public SplashScreenGuGong()
        {
            InitializeComponent();

            // 设置窗体的类型  
            const string showInfo = "数据正在加载，请等待...";
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            bitmap = new Bitmap(Properties.Resources.SplashGuGong);
            ClientSize = bitmap.Size;
            using (Font font = new Font("Consoles", 20))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawString(showInfo, font, Brushes.OrangeRed, 10, 10);
                }
            }

            BackgroundImage = bitmap;
        }

        public static void ShowSplashScreen()
        {
            if(instance == null)
            {
                instance = new SplashScreenGuGong();
            }
             
            instance.Show();
        }
    }
}
