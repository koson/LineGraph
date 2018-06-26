using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace LineGraph.DataGraph
{
    public partial class DataShowWnd : UserControl
    {
        private string m_msg = "";

        public DataShowWnd()
        {
            InitializeComponent();
        }

        public DataShowWnd(string msg)
        {
            this.m_msg = msg;
            InitializeComponent();
        }

        public void BindDataInfo(DateTime XDate, double YValue)
        {
            //zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
            double x = (double)XDate.ToOADate();
            m_list.Add(x, YValue);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
            if (m_list.Count >= 10)
            {
                m_list.RemoveAt(0);
            }
        }

        private void DataShowWnd_Load(object sender, EventArgs e)
        {

        }
    }
}
