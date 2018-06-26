using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using SuperMap.UI;

namespace SuperMap.SampleCode.Realspace
{
    public partial class DlgSunTrajectory : Form
    {
        private SceneControl m_sceneControl = null;
        private ReadOnlyCollection<TimeZoneInfo> m_TimeZones;

        public DlgSunTrajectory()
        {
            InitializeComponent();
        }

        public void Initialize(SceneControl sceneControl)
        {
            m_sceneControl = sceneControl;

            InitializeTimeZoneComboBox();
            InitializeDateTimePicker();
            IntializeTimeTrackBar();
        }

        //初始化时区下拉框
        void InitializeTimeZoneComboBox()
        {
            if (timeZoneComboBox.Items.Count > 0)
                timeZoneComboBox.Items.Clear();
            m_TimeZones = TimeZoneInfo.GetSystemTimeZones();
            int i = 0;
            for (i = 0; i < m_TimeZones.Count; i++)
            {
                TimeZoneInfo zone = m_TimeZones[i];
                timeZoneComboBox.Items.Add(zone.DisplayName);
            }
            int index = m_TimeZones.IndexOf(TimeZoneInfo.Local);
            timeZoneComboBox.SelectedIndex = index;
        }

        //初始化日期时间选择器
        void InitializeDateTimePicker()
        {
            DateTime dateTime = DateTime.Now;
            dateTimePicker.Value = dateTime;
            dateTimePicker.Refresh();
        }

        //初始化时间滑块
        void IntializeTimeTrackBar()
        {
            DateTime dateTime = DateTime.Now;
            int minute = dateTime.Hour * 60 + dateTime.Minute;
            timeTrackBar.Value = minute;
        }

        private void timeZoneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeZoneInfo selectedTimeZone;
            int index = timeZoneComboBox.SelectedIndex;
            selectedTimeZone = m_TimeZones[index];
            updateDateTime(selectedTimeZone);
            TimeSpan timeSpan = selectedTimeZone.BaseUtcOffset;
            m_sceneControl.Scene.Sun.BaseUtcOffset = timeSpan;
        }

        private void updateDateTime(TimeZoneInfo timeZoneInfo)
        {
            DateTime currentTime = DateTime.Now;
            DateTime dateTime = TimeZoneInfo.ConvertTime(currentTime, TimeZoneInfo.Local, timeZoneInfo);

            dateTimePicker.Value = dateTime;
            dateTimePicker.Refresh();

            int minute = dateTime.Hour * 60 + dateTime.Minute;
            timeTrackBar.Value = minute;

            m_sceneControl.Scene.Sun.SunDateTime = dateTime;
        }

        private void timeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int value = timeTrackBar.Value;
            timeLabel.Text = Convert.ToString(value / 60) + ":" + Convert.ToString(value % 60);

            DateTime dateTime = DateTime.Parse(timeLabel.Text);

            m_sceneControl.Scene.Sun.SunDateTime = dateTime;
        }

        private void local_Button_Click(object sender, EventArgs e)
        {
            //本地时区
            int index = m_TimeZones.IndexOf(TimeZoneInfo.Local);
            timeZoneComboBox.SelectedIndex = index;
            //本机系统日期时间
            DateTime dateTime = DateTime.Now;
            dateTimePicker.Value = dateTime;
            dateTimePicker.Refresh();

            int minute = dateTime.Hour * 60 + dateTime.Minute;
            timeTrackBar.Value = minute;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeTrackBar.Value = (timeTrackBar.Value + 1) % 1440;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker.Value;
            m_sceneControl.Scene.Sun.SunDateTime = dateTime;
        }
    }
}
