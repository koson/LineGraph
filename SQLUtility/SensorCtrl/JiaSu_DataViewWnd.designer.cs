namespace LineGraph.SQLUtility
{
    partial class JiaSu_DataViewWnd
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
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            splitContainerTop = new System.Windows.Forms.SplitContainer();
            m_JiaSuDataGraphWnd = new DataGraph.JiaSu_DataGraphWnd();
            m_JiaSuDataGridWnd = new SQLUtility.JiaSu_DataGridWnd();
            m_TempratureMeterWnd = new GUI.TempratureMeterWnd();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // splitContainerTop
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            this.splitContainerTop.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerTop.Panel1
            // 
            this.m_JiaSuDataGraphWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Panel1.Controls.Add(this.m_JiaSuDataGraphWnd);
            // 
            // splitContainerTop.Panel2
            // 
            this.m_TempratureMeterWnd.Location = new System.Drawing.Point(0, 40);
            this.m_TempratureMeterWnd.Name = "m_TempratureMeterWnd";
            this.m_TempratureMeterWnd.Size = new System.Drawing.Size(220, 220);
            this.m_TempratureMeterWnd.TabIndex = 5;
            this.m_TempratureMeterWnd.Text = "m_TempratureMeterWnd";
            //this.splitContainerTop.Panel2.Controls.Add(this.m_TempratureMeterWnd);
            this.splitContainerTop.Size = new System.Drawing.Size(720, 360);
            this.splitContainerTop.SplitterDistance = 500;
            this.splitContainerTop.TabIndex = 1;

            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.splitContainerRight.Panel1.Controls.Add(this.splitContainerTop);
            this.splitContainerRight.Panel1.Controls.Add(this.m_JiaSuDataGraphWnd);
            // 
            // splitContainerRight.Panel2
            // 
            m_JiaSuDataGridWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Panel2.Controls.Add(this.m_JiaSuDataGridWnd);
            this.splitContainerRight.Size = new System.Drawing.Size(720, 780 - 22);
            this.splitContainerRight.SplitterDistance = 330;
            this.splitContainerRight.TabIndex = 0;
            // 
            // DataViewerWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerRight);
            this.Name = "DataViewerWnd";
            this.Size = new System.Drawing.Size(720, 780 - 22);
            this.Load += new System.EventHandler(this.DataViewer_Load);


            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);

            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
            this.splitContainerTop.ResumeLayout(false);

            this.ResumeLayout(false);
        }

        #endregion

        private DataGraph.JiaSu_DataGraphWnd m_JiaSuDataGraphWnd;
        private SQLUtility.JiaSu_DataGridWnd m_JiaSuDataGridWnd;
        private System.Windows.Forms.SplitContainer splitContainerRight;

        private System.Windows.Forms.SplitContainer splitContainerTop;
        private LineGraph.GUI.TempratureMeterWnd m_TempratureMeterWnd;
    }
}