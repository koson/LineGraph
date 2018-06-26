using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LineGraph.DataGraph
{
    public partial class QingJiao_DataGraphWnd : UserControl
    {
  
        public QingJiao_DataGraphWnd()
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
            m_QingJiaoXlist.Add(x, data.QINGJIAO_X);
            m_QingJiaoYlist.Add(x, data.QINGJIAO_Y);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
            if (m_QingJiaoXlist.Count >= 10)
            {
                m_QingJiaoXlist.RemoveAt(0);
            }
            if (m_QingJiaoYlist.Count >= 10)
            {
                m_QingJiaoYlist.RemoveAt(0);
            }
        }


        private void DataGraph_Load(object sender, EventArgs e)
        {
        }

    }
}
