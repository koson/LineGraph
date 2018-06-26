using System;
using ZedGraph;
using System.Drawing;

namespace LineGraph.GUI
{
    partial class DataShowWnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.m_list = new PointPairList();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.Size = new System.Drawing.Size(300, 240);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.GraphPane.Title.Text = "动态曲线";
            this.zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
            this.zedGraphControl1.GraphPane.YAxis.Title.Text = "数值";
            this.zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;

            myCurve = zedGraphControl1.GraphPane.AddCurve("DATA CURVE",
                m_list, Color.Green, SymbolType.None);
            // 
            // DataShowWnd
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 240);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "DataShow";
            this.Text = m_msg + "数据显示";
            this.Load += new System.EventHandler(this.DataShowWnd_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private PointPairList m_list;
        private LineItem myCurve;
    }
}