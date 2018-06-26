﻿using System;
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
    public partial class SplashScreen : Form
    {
        /// <summary>  
        /// 启动画面本身  
        /// </summary>  
        static SplashScreen instance;
        /// <summary>  
        /// 显示的图片  
        /// </summary>  
        Bitmap bitmap;

        public static SplashScreen Instance
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

        public SplashScreen()
        {
            InitializeComponent();

            // 设置窗体的类型  
            const string showInfo = "数据正在加载，请等待...";
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            bitmap = new Bitmap(Properties.Resources.SplashScreen);
            ClientSize = bitmap.Size;

            using (Font font = new Font("Consoles", 14))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawString(showInfo, font, Brushes.OrangeRed, 230, 300);
                }
            }

            BackgroundImage = bitmap;
        }

        public static void ShowSplashScreen()
        {
            instance = new SplashScreen();
            instance.Show();
        }
    }
}
