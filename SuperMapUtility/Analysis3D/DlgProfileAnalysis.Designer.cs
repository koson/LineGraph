namespace SuperMap.SampleCode.Realspace
{
    partial class DlgProfileAnalysis
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StartAnalysis_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearResult_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.StartAnalysis_ToolStripMenuItem,
            this.ClearResult_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(252, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
            // 
            // StartAnalysis_ToolStripMenuItem
            // 
            this.StartAnalysis_ToolStripMenuItem.Name = "StartAnalysis_ToolStripMenuItem";
            this.StartAnalysis_ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.StartAnalysis_ToolStripMenuItem.Text = "开始分析";
            this.StartAnalysis_ToolStripMenuItem.Click += new System.EventHandler(this.StartAnalysis_ToolStripMenuItem_Click);
            // 
            // ClearResult_ToolStripMenuItem
            // 
            this.ClearResult_ToolStripMenuItem.Name = "ClearResult_ToolStripMenuItem";
            this.ClearResult_ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.ClearResult_ToolStripMenuItem.Text = "清除分析结果";
            this.ClearResult_ToolStripMenuItem.Click += new System.EventHandler(this.ClearResult_ToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(252, 239);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // DlgProfileAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 264);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DlgProfileAnalysis";
            this.Text = "剖面线分析";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgProfileAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.DlgProfileAnalysis_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem StartAnalysis_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearResult_ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}