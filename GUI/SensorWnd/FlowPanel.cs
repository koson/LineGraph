using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LineGraph.GUI
{
    public partial class FlowPanel : UserControl
    {
        private int MaxOffsetLength = 0;//最大偏移量
        private int CurrentOffsetLength = 0;//当前向上偏移量
        private int FORM_SPAN = 0;//窗体间的间隙
        private int FORM_HEIGTH = 400;//窗体的高度
        private int FORM_ROW_COUNT = 2;//一行显示多少个窗体
        private List<Form> FormList = new List<Form>();//窗体列表

        public FlowPanel()
        {
            InitializeComponent();
        }

        public void Add(Form form)
        {
            this.SuspendLayout();

            //设定窗体属性
            form.FormClosing += delegate(object a, FormClosingEventArgs e) { e.Cancel = true; };
            form.TopLevel = false;
            form.Location = this.GetNextFormLocation(this.FormList.Count);
            form.Size = new Size(this.GetFormWidth(), this.FORM_HEIGTH);
            form.Click += delegate(object sender, EventArgs e) { this.label1.Focus(); };

            //绑定窗体
            this.Controls.Add(form);
            this.FormList.Add(form);
            form.Show();

            this.ResumeLayout(false);

            //刷新布局
            this.FlushFormLayout();
        }

        public void Clear(Form form)//移除窗体 并不关闭窗体
        {
            this.SuspendLayout();

            for (int i = 0; i < FormList.Count; i++)
            {
                if (FormList[i] == form)
                {
                    this.Controls.Remove(FormList[i]);
                    this.FormList.Remove(form);
                    break;
                }
            }

            this.ResumeLayout(false);

            //刷新布局
            this.FlushFormLayout();
        }

        private void SetOffset()
        {
            int num = (this.FormList.Count - 1) / this.FORM_ROW_COUNT;
            int heigth = (this.FORM_SPAN + this.FORM_HEIGTH) * num + this.FORM_SPAN;
            this.MaxOffsetLength = heigth + FORM_HEIGTH + FORM_SPAN > this.Height ? heigth + FORM_HEIGTH + FORM_SPAN - this.Height : 0;
        }

        private int GetFormWidth()
        {
            return (this.Width - this.FORM_SPAN * (FORM_ROW_COUNT + 1)) / FORM_ROW_COUNT;
        }

        private Point GetNextFormLocation(int current_form_count)
        {
            int width = 0, heigth = 0;

            //计算横坐标
            {
                int num = current_form_count % this.FORM_ROW_COUNT;
                width = (this.FORM_SPAN + this.GetFormWidth()) * num + this.FORM_SPAN;
            }
            //计算综坐标
            {
                int num = current_form_count / this.FORM_ROW_COUNT;
                heigth = (this.FORM_HEIGTH + this.FORM_SPAN) * num + this.FORM_SPAN - this.CurrentOffsetLength;
            }
            return new Point(width, heigth);
        }
        private void FlushFormLayout()
        {
            this.SetOffset();
            for (int i = 0; i < this.FormList.Count; i++)
            {
                this.FormList[i].Location = this.GetNextFormLocation(i);
                this.FormList[i].Size = new Size(this.GetFormWidth(), this.FORM_HEIGTH);
                this.FormList[i].Show();
            }
        }

        public int RowFormCount
        {
            get
            {
                return this.FORM_ROW_COUNT;
            }
            set
            {
                if (value > 0)
                {
                    this.FORM_ROW_COUNT = value;
                    this.FlushFormLayout();
                }
            }
        }
        public int FormHeigth
        {
            get
            {
                return this.FORM_HEIGTH;
            }
            set
            {
                if (value > 0)
                {
                    this.FORM_HEIGTH = value;
                    this.FlushFormLayout();
                }
            }
        }

        //事件
        private void MyFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            this.label1.Focus();
        }

        private void MyFlowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            this.FlushFormLayout();
        }

        protected override void WndProc(ref Message m)
        {
            //鼠标滚轮 滚动屏幕
            //if (m.Msg == 0x020A)
            //{
            //    if (m.WParam.ToInt32() > 0)
            //    {
            //        CurrentOffsetLength -= 40;
            //        CurrentOffsetLength = CurrentOffsetLength < 0 ? 0 : CurrentOffsetLength;
            //    }
            //    else
            //    {
            //        CurrentOffsetLength += 40;
            //        CurrentOffsetLength = CurrentOffsetLength > MaxOffsetLength ? MaxOffsetLength : CurrentOffsetLength;
            //    }
            //    FlushFormLayout();
            //}

            base.WndProc(ref m);
        }
    }
}
