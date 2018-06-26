using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineGraph.SQLUtility
{
    public partial class ShuiZhun_DataViewWnd: UserControl
    {
        public ShuiZhun_DataViewWnd()
        {
            InitializeComponent();
        }

        private void DataViewer_Load(object sender, EventArgs e)
        {
        }

        public void UpdateListView(Data.UDPData data)
        {
            m_ShuiZhunDataGridWnd.UpdateListView(data);
            m_ShuiZhunDataGraphWnd.UpdateGraphData(data);
            //m_TempratureMeterWnd.UpdateValueChanged(data.Temprature);
        }
    }
}
