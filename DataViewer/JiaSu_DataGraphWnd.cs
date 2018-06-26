using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LineGraph.DataGraph
{
    public partial class JiaSu_DataGraphWnd : UserControl
    {

        public JiaSu_DataGraphWnd ()
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
            m_JiaSuDuXlist.Add(x, data.JIASUDU_X);
            m_JiaSuDuYlist.Add(x, data.JIASUDU_Y);
            m_JiaSuDuZlist.Add(x, data.JIASUDU_Z);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
            if (m_JiaSuDuXlist.Count >= 10)
            {
                m_JiaSuDuXlist.RemoveAt(0);
            }
            if (m_JiaSuDuYlist.Count >= 10)
            {
                m_JiaSuDuYlist.RemoveAt(0);
            }
            if (m_JiaSuDuZlist.Count >= 10)
            {
                m_JiaSuDuZlist.RemoveAt(0);
            }

        }

  
        private void DataGraph_Load(object sender, EventArgs e)
        {
         
        }
    }
}
