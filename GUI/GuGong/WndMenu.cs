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
    public partial class WndMenu : UserControl
    {
        public WndMenu()
        {
            InitializeComponent();
        }

        public delegate void WndCloseEventHandler(object sender, EventArgs e);
        public event WndCloseEventHandler WndClose;

        public delegate void ShowScreenEventHandler(object sender, EventArgs e);
        public event ShowScreenEventHandler ShowScreen;

        public delegate void WorkSpaceCtrlEventHandler(object sender, EventArgs e);
        public event WorkSpaceCtrlEventHandler WorkSpaceCtrl;

        public delegate void LengthCtrlEventHandler(object sender, EventArgs e);
        public event LengthCtrlEventHandler LengthCtrl;

        public delegate void AreaCtrlEventHandler(object sender, EventArgs e);
        public event AreaCtrlEventHandler AreaCtrl;

        public delegate void HeightCtrlEventHandler(object sender, EventArgs e);
        public event HeightCtrlEventHandler HeightCtrl;

        public delegate void ClearResultCtrlEventHandler(object sender, EventArgs e);
        public event ClearResultCtrlEventHandler ClearResultCtrl;

        public delegate void layerStyleCtrlEventHandler(object sender, EventArgs e);
        public event layerStyleCtrlEventHandler LayerStyleCtrl;

        public delegate void PropertyCtrlEventHandler(object sender, EventArgs e);
        public event PropertyCtrlEventHandler PropertyCtrl;

        public delegate void SQLCtrlEventHandler(object sender, EventArgs e);
        public event SQLCtrlEventHandler SQLCtrl;

        public delegate void SensorCtrlEventHandler(object sender, EventArgs e);
        public event SensorCtrlEventHandler SensorCtrl;

        public delegate void WorkerCtrlEventHandler(object sender, EventArgs e);
        public event WorkerCtrlEventHandler WorkerCtrl;

        public delegate void VideoerCtrlEventHandler(object sender, EventArgs e);
        public event VideoerCtrlEventHandler VideoCtrl;

        public delegate void DesignerCtrlEventHandler(object sender, EventArgs e);
        public event DesignerCtrlEventHandler DesignerCtrl;

        private void MenuItem_CloseWnd_Click(object sender, EventArgs e)
        {
            if (WndClose != null)
            {
                WndClose(sender, e);
            }
        }

        private void MenuItem_ShowScreen_Click(object sender, EventArgs e)
        {
            if (ShowScreen != null)
            {
                ShowScreen(sender, e);
            }
        }

        private void MenuItem_WorkSpaceCtrl_Click(object sender, EventArgs e)
        {
            if (WorkSpaceCtrl != null)
            {
                WorkSpaceCtrl(sender, e);
            }
        }

        private void MenuItem_Length_Click(object sender, EventArgs e)
        {
            if (LengthCtrl != null)
            {
                LengthCtrl(sender, e);
            }
        }

        private void MenuItem_Area_Click(object sender, EventArgs e)
        {
            if (AreaCtrl != null)
            {
                AreaCtrl(sender, e);
            }
        }

        private void MenuItem_Height_Click(object sender, EventArgs e)
        {
            if (HeightCtrl != null)
            {
                HeightCtrl(sender, e);
            }
        }

        private void MenuItem_ClearResult_Click(object sender, EventArgs e)
        {
            if (ClearResultCtrl != null)
            {
                ClearResultCtrl(sender, e);
            }
        }

        private void MenuItem_LayerStyle_Click(object sender, EventArgs e)
        {
            if (LayerStyleCtrl != null)
            {
                LayerStyleCtrl(sender, e);
            }
        }

        private void MenuItem_Property_Click(object sender, EventArgs e)
        {
            if (PropertyCtrl != null)
            {
                PropertyCtrl(sender, e);
            }
        }

        private void MenuItem_SQL_Click(object sender, EventArgs e)
        {
            if (SQLCtrl != null)
            {
                SQLCtrl(sender, e);
            }
        }

        //private void MenuItem_Buffer_Click(object sender, EventArgs e)
        //{
        //    if (LayerStyleCtrl != null)
        //    {
        //        LayerStyleCtrl(sender, e);
        //    }
        //}
        private void MenuItem_Sensor_Click(object sender, EventArgs e)
        {
            if (SensorCtrl != null)
            {
                SensorCtrl(sender, e);
            }
        }
        private void MenuItem_Worker_Click(object sender, EventArgs e)
        {
            if (WorkerCtrl != null)
            {
                WorkerCtrl(sender, e);
            }
        }
        private void MenuItem_Videoer_Click(object sender, EventArgs e)
        {
            if (VideoCtrl != null)
            {
                VideoCtrl(sender, e);
            }
        }

        private void MenuItem_Designer_Click(object sender, EventArgs e)
        {
            if (DesignerCtrl != null)
            {
                DesignerCtrl(sender, e);
            }
        }
    }
}
