using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LineGraph.Data;


namespace LineGraph.GUI
{
    public partial class SensorWnd : Form
    {
        private LineGraph.GUI.DataShowWnd[] m_DataShowWnds;

        public SensorWnd()
        {
            InitializeComponent();
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.FlowPanel.RowFormCount = 2;//每行显示窗体个数
                this.FlowPanel.FormHeigth = 400;//每个窗体高度

                m_DataShowWnds = new DataShowWnd[6];

                for (int i = 0; i < 6; i++)
                {
                    m_DataShowWnds[i] = new DataShowWnd(i.ToString());
                    this.FlowPanel.Add(m_DataShowWnds[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void main_form_Close(object sender, EventArgs e)
        {
        }

    }
}
