using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LineGraph.GUI;
using System.Threading;

namespace LineGraph
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool IsNew = false;
            Mutex mutex = new Mutex(false, "LineGraph", out IsNew);
            if (!IsNew)
            {
                // 已经启动了
                MessageBox.Show("程序已经启动！");
                return;
            }

            SQLUtility.MySQLLogin m_MySQLLogin = new SQLUtility.MySQLLogin();
            m_MySQLLogin.ConnectMySQL();

            //SQLUtility.DeviceInfoCtrlWnd m_DeviceInfoCtrlWnd = new SQLUtility.DeviceInfoCtrlWnd();
            //m_DeviceInfoCtrlWnd.ShowDialog();

            #region GuGong
            MainFormG RunForm = new MainFormG();
            LineGraph.SQLUtility.LoginGuGong LoginForm = new LineGraph.SQLUtility.LoginGuGong();
            #endregion

            #region DingZhou
            //MainFormDingZhou RunForm = new MainFormDingZhou();
            //LineGraph.SQLUtility.LoginDingZhou LoginForm = new LineGraph.SQLUtility.LoginDingZhou();
            #endregion

            #region Road
            //MainFormRoad RunForm = new MainFormRoad();
            //LineGraph.SQLUtility.LoginRoad LoginForm = new LineGraph.SQLUtility.LoginRoad();
            #endregion

            #region JuXian
            //MainFormJuXian RunForm = new MainFormJuXian();
            //LineGraph.SQLUtility.LoginJuXian LoginForm = new LineGraph.SQLUtility.LoginJuXian();
            #endregion

            DialogResult Dr = LoginForm.ShowDialog();

            if (Dr == DialogResult.OK)
            {
                Application.Run(RunForm);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}



