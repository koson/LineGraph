namespace SuperMap.SampleCode.Realspace
{
    partial class DlgFloodAnalysis
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
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_DrawAnalystRange = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_StartAnalysis = new System.Windows.Forms.Button();
            this.lbl_low = new System.Windows.Forms.Label();
            this.tb_minAltitude = new System.Windows.Forms.TextBox();
            this.lbl_hight = new System.Windows.Forms.Label();
            this.tb_maxAltitude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Interval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(143, 165);
            this.btn_Clear.MaximumSize = new System.Drawing.Size(89, 23);
            this.btn_Clear.MinimumSize = new System.Drawing.Size(89, 23);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(89, 23);
            this.btn_Clear.TabIndex = 50;
            this.btn_Clear.Text = "清除分析结果";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_DrawAnalystRange
            // 
            this.btn_DrawAnalystRange.Location = new System.Drawing.Point(23, 125);
            this.btn_DrawAnalystRange.Name = "btn_DrawAnalystRange";
            this.btn_DrawAnalystRange.Size = new System.Drawing.Size(167, 23);
            this.btn_DrawAnalystRange.TabIndex = 49;
            this.btn_DrawAnalystRange.Text = "绘制分析区域";
            this.btn_DrawAnalystRange.UseVisualStyleBackColor = true;
            this.btn_DrawAnalystRange.Click += new System.EventHandler(this.btn_DrawAnalystRange_Click);
            // 
            // btn_StartAnalysis
            // 
            this.btn_StartAnalysis.Location = new System.Drawing.Point(14, 165);
            this.btn_StartAnalysis.Name = "btn_StartAnalysis";
            this.btn_StartAnalysis.Size = new System.Drawing.Size(89, 23);
            this.btn_StartAnalysis.TabIndex = 55;
            this.btn_StartAnalysis.Text = "开始分析";
            this.btn_StartAnalysis.UseVisualStyleBackColor = true;
            this.btn_StartAnalysis.Click += new System.EventHandler(this.btn_StartAnalysis_Click);
            // 
            // lbl_low
            // 
            this.lbl_low.AutoSize = true;
            this.lbl_low.Location = new System.Drawing.Point(12, 19);
            this.lbl_low.Name = "lbl_low";
            this.lbl_low.Size = new System.Drawing.Size(65, 12);
            this.lbl_low.TabIndex = 56;
            this.lbl_low.Text = "基础高度：";
            // 
            // tb_minAltitude
            // 
            this.tb_minAltitude.Location = new System.Drawing.Point(76, 16);
            this.tb_minAltitude.Name = "tb_minAltitude";
            this.tb_minAltitude.Size = new System.Drawing.Size(127, 21);
            this.tb_minAltitude.TabIndex = 57;
            this.tb_minAltitude.Text = "100";
            this.tb_minAltitude.TextChanged += new System.EventHandler(this.tb_minAltitude_TextChanged);
            // 
            // lbl_hight
            // 
            this.lbl_hight.AutoSize = true;
            this.lbl_hight.Location = new System.Drawing.Point(12, 49);
            this.lbl_hight.Name = "lbl_hight";
            this.lbl_hight.Size = new System.Drawing.Size(65, 12);
            this.lbl_hight.TabIndex = 58;
            this.lbl_hight.Text = "淹没高度：";
            // 
            // tb_maxAltitude
            // 
            this.tb_maxAltitude.Location = new System.Drawing.Point(76, 46);
            this.tb_maxAltitude.Name = "tb_maxAltitude";
            this.tb_maxAltitude.Size = new System.Drawing.Size(127, 21);
            this.tb_maxAltitude.TabIndex = 59;
            this.tb_maxAltitude.Text = "2000";
            this.tb_maxAltitude.TextChanged += new System.EventHandler(this.tb_maxAltitude_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 60;
            this.label3.Text = "水涨幅度：";
            // 
            // tb_Interval
            // 
            this.tb_Interval.Location = new System.Drawing.Point(76, 79);
            this.tb_Interval.Name = "tb_Interval";
            this.tb_Interval.Size = new System.Drawing.Size(127, 21);
            this.tb_Interval.TabIndex = 61;
            this.tb_Interval.Text = "10";
            this.tb_Interval.TextChanged += new System.EventHandler(this.tb_Interval_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "m";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "m";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 64;
            this.label4.Text = "m/s";
            // 
            // DlgFloodAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 212);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Interval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_maxAltitude);
            this.Controls.Add(this.lbl_hight);
            this.Controls.Add(this.tb_minAltitude);
            this.Controls.Add(this.lbl_low);
            this.Controls.Add(this.btn_StartAnalysis);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_DrawAnalystRange);
            this.MaximumSize = new System.Drawing.Size(286, 250);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "DlgFloodAnalysis";
            this.Text = "淹没分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgFloodAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.DlgFloodAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_DrawAnalystRange;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_StartAnalysis;
        private System.Windows.Forms.Label lbl_low;
        private System.Windows.Forms.TextBox tb_minAltitude;
        private System.Windows.Forms.Label lbl_hight;
        private System.Windows.Forms.TextBox tb_maxAltitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;

    }
}