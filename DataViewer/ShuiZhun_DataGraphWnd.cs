using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LineGraph.DataGraph
{
    public partial class ShuiZhun_DataGraphWnd : UserControl
    {

        public ShuiZhun_DataGraphWnd ()
        {
            InitializeComponent();
        }


        public void UpdateGraphData(Data.UDPData data)
        {
            if (this.zedGraphControl1.InvokeRequired)
            {
                Action<Data.UDPData> action = new Action<Data.UDPData>(UpdateGraphData);
                this.Invoke(action, data);
                return;
            }

            double x = (double)DateTime.Now.ToOADate();
            m_CHENJIANGlist.Add(x, data.CHENJIANG);
            //m_ZHENDONGlist.Add(x, data.ZHENDONG);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
            if (m_CHENJIANGlist.Count >= 10)
            {
                m_CHENJIANGlist.RemoveAt(0);
            }
            //if (m_ZHENDONGlist.Count >= 10)
            //{
            //    m_ZHENDONGlist.RemoveAt(0);
            //}
        }

        private void DataGraph_Load(object sender, EventArgs e)
        {
        }
    }
}
