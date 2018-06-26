using System;
using System.Windows.Forms;

namespace LineGraph.GUI
{
    public partial class TempratureMeterWnd : UserControl
    {
        public TempratureMeterWnd()
        {
            InitializeComponent();
            UpdateControls();
        }

        public void UpdateValueChanged(float Value)
        {
            termometer1.Value = Value;
        }

        private void UpdateControls()
        {
            termometer1.StoredMax = termometer1.Min; //Reset StoredMax
        }

        private void termometer1_PropertyChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

    }
}