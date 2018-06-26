using ZedGraph;
using System.Drawing;

namespace LineGraph.DataGraph
{
    partial class JiaSu_DataGraphWnd 
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
            this.m_JiaSuDuXlist = new PointPairList();
            this.m_JiaSuDuYlist = new PointPairList();
            this.m_JiaSuDuZlist = new PointPairList();

            this.SuspendLayout();

            // 
            // graphControl
            // 
            //this.graphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            //this.graphControl.AxisXTitle = "时间(s)";
            //this.graphControl.AxisYTitle = "加速计传感参数";
            ////this.graphControl.AxisYTitle = "高速公路车辆监控";
            //this.graphControl.GraphStyle = GraphMode.FixMoveMode;
            //this.graphControl.GraphTitle = "实时曲线";
            //this.graphControl.InitialMaxX = 100F;
            //this.graphControl.InitialMaxY = 30F;
            //this.graphControl.InitialMinX = 0F;
            //this.graphControl.InitialMinY = -30F;
            //this.graphControl.Location = new System.Drawing.Point(0, 0);
            //this.graphControl.Name = "graphControl";
            //this.graphControl.Size = new System.Drawing.Size(671, 377);
            //this.graphControl.TabIndex = 9;
            //this.graphControl.XDataAccuracy = 0.1F;
            //this.graphControl.YDataAccuracy = 0.1F;

            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.Size = new System.Drawing.Size(671, 407);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.GraphPane.Title.Text = "动态曲线";
            this.zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
            this.zedGraphControl1.GraphPane.YAxis.Title.Text = "加速计传感参数";
            this.zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;

   
            myJiaSuDuXCurve = zedGraphControl1.GraphPane.AddCurve("X",
                m_JiaSuDuXlist, Color.Red, SymbolType.None);

            myJiaSuDuYCurve = zedGraphControl1.GraphPane.AddCurve("Y",
                m_JiaSuDuYlist, Color.Green, SymbolType.None);

            myJiaSuDuZCurve = zedGraphControl1.GraphPane.AddCurve("Z",
                m_JiaSuDuZlist, Color.Blue, SymbolType.None);

            zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;


            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 407);
    
            this.Controls.Add(this.zedGraphControl1);
       
            this.Name = "DataViewer";
            this.Text = "Real Time Graph";
            this.Load += new System.EventHandler(this.DataGraph_Load);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private PointPairList m_JiaSuDuXlist;
        private LineItem myJiaSuDuXCurve;

        private PointPairList m_JiaSuDuYlist;
        private LineItem myJiaSuDuYCurve;

        private PointPairList m_JiaSuDuZlist;
        private LineItem myJiaSuDuZCurve;
    }
}

