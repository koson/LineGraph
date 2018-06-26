using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LineGraph.SQLUtility
{
    public partial class DataGridViewWnd : UserControl
    {
        public DataGridViewWnd()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //public void UpdateListView(Data.UDPData data)
        //{
        //    m_QingJiao_DataViewWnd.UpdateListView(data);
        //    m_JiaSu_DataViewWnd.UpdateListView(data);
        //    m_ShuiZhun_DataViewWnd.UpdateListView(data);
        //}
    }
}
