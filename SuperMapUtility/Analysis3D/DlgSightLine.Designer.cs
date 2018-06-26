namespace SuperMap.SampleCode.Realspace
{
    partial class DlgSightLine
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_Observer = new System.Windows.Forms.GroupBox();
            this.tb_ObserverHeight = new System.Windows.Forms.TextBox();
            this.tb_ObserverY = new System.Windows.Forms.TextBox();
            this.tb_ObserverX = new System.Windows.Forms.TextBox();
            this.gb_Targets = new System.Windows.Forms.GroupBox();
            this.tb_TargetHeight = new System.Windows.Forms.TextBox();
            this.tb_TargetY = new System.Windows.Forms.TextBox();
            this.tb_TargetX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_TargetPtsIndex = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Analyst = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_StopAnalysis = new System.Windows.Forms.Button();
            this.cb_ColorScheme = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_GetBarrierPoint = new System.Windows.Forms.Button();
            this.gb_Observer.SuspendLayout();
            this.gb_Targets.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "高度";
            // 
            // gb_Observer
            // 
            this.gb_Observer.Controls.Add(this.tb_ObserverHeight);
            this.gb_Observer.Controls.Add(this.tb_ObserverY);
            this.gb_Observer.Controls.Add(this.tb_ObserverX);
            this.gb_Observer.Controls.Add(this.label2);
            this.gb_Observer.Controls.Add(this.label3);
            this.gb_Observer.Controls.Add(this.label4);
            this.gb_Observer.Location = new System.Drawing.Point(-1, 3);
            this.gb_Observer.Name = "gb_Observer";
            this.gb_Observer.Size = new System.Drawing.Size(217, 106);
            this.gb_Observer.TabIndex = 8;
            this.gb_Observer.TabStop = false;
            this.gb_Observer.Text = "观察点";
            // 
            // tb_ObserverHeight
            // 
            this.tb_ObserverHeight.Location = new System.Drawing.Point(44, 76);
            this.tb_ObserverHeight.Name = "tb_ObserverHeight";
            this.tb_ObserverHeight.Size = new System.Drawing.Size(167, 21);
            this.tb_ObserverHeight.TabIndex = 6;
            this.tb_ObserverHeight.Text = "0.0";
            this.tb_ObserverHeight.TextChanged += new System.EventHandler(this.tb_ObserverHeight_TextChanged);
            // 
            // tb_ObserverY
            // 
            this.tb_ObserverY.Location = new System.Drawing.Point(44, 47);
            this.tb_ObserverY.Name = "tb_ObserverY";
            this.tb_ObserverY.Size = new System.Drawing.Size(167, 21);
            this.tb_ObserverY.TabIndex = 5;
            this.tb_ObserverY.Text = "0.0";
            this.tb_ObserverY.TextChanged += new System.EventHandler(this.tb_ObserverY_TextChanged);
            // 
            // tb_ObserverX
            // 
            this.tb_ObserverX.Location = new System.Drawing.Point(44, 20);
            this.tb_ObserverX.Name = "tb_ObserverX";
            this.tb_ObserverX.Size = new System.Drawing.Size(167, 21);
            this.tb_ObserverX.TabIndex = 4;
            this.tb_ObserverX.Text = "0.0";
            this.tb_ObserverX.TextChanged += new System.EventHandler(this.tb_ObserverX_TextChanged);
            // 
            // gb_Targets
            // 
            this.gb_Targets.Controls.Add(this.tb_TargetHeight);
            this.gb_Targets.Controls.Add(this.tb_TargetY);
            this.gb_Targets.Controls.Add(this.tb_TargetX);
            this.gb_Targets.Controls.Add(this.label6);
            this.gb_Targets.Controls.Add(this.label7);
            this.gb_Targets.Controls.Add(this.label8);
            this.gb_Targets.Controls.Add(this.cb_TargetPtsIndex);
            this.gb_Targets.Controls.Add(this.label1);
            this.gb_Targets.Location = new System.Drawing.Point(-1, 110);
            this.gb_Targets.Name = "gb_Targets";
            this.gb_Targets.Size = new System.Drawing.Size(217, 152);
            this.gb_Targets.TabIndex = 9;
            this.gb_Targets.TabStop = false;
            this.gb_Targets.Text = "目标点";
            // 
            // tb_TargetHeight
            // 
            this.tb_TargetHeight.Location = new System.Drawing.Point(77, 117);
            this.tb_TargetHeight.Name = "tb_TargetHeight";
            this.tb_TargetHeight.Size = new System.Drawing.Size(134, 21);
            this.tb_TargetHeight.TabIndex = 13;
            this.tb_TargetHeight.TextChanged += new System.EventHandler(this.tb_TargetHeight_TextChanged);
            // 
            // tb_TargetY
            // 
            this.tb_TargetY.Location = new System.Drawing.Point(77, 81);
            this.tb_TargetY.Name = "tb_TargetY";
            this.tb_TargetY.Size = new System.Drawing.Size(134, 21);
            this.tb_TargetY.TabIndex = 12;
            this.tb_TargetY.TextChanged += new System.EventHandler(this.tb_TargetY_TextChanged);
            // 
            // tb_TargetX
            // 
            this.tb_TargetX.Location = new System.Drawing.Point(77, 50);
            this.tb_TargetX.Name = "tb_TargetX";
            this.tb_TargetX.Size = new System.Drawing.Size(134, 21);
            this.tb_TargetX.TabIndex = 11;
            this.tb_TargetX.TextChanged += new System.EventHandler(this.tb_TargetX_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "高度";
            // 
            // cb_TargetPtsIndex
            // 
            this.cb_TargetPtsIndex.FormattingEnabled = true;
            this.cb_TargetPtsIndex.Location = new System.Drawing.Point(77, 21);
            this.cb_TargetPtsIndex.Name = "cb_TargetPtsIndex";
            this.cb_TargetPtsIndex.Size = new System.Drawing.Size(134, 20);
            this.cb_TargetPtsIndex.TabIndex = 1;
            this.cb_TargetPtsIndex.SelectedIndexChanged += new System.EventHandler(this.cb_TargetPtsIndex_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前目标点";
            // 
            // btn_Analyst
            // 
            this.btn_Analyst.Location = new System.Drawing.Point(23, 299);
            this.btn_Analyst.Name = "btn_Analyst";
            this.btn_Analyst.Size = new System.Drawing.Size(77, 26);
            this.btn_Analyst.TabIndex = 10;
            this.btn_Analyst.Text = "开始分析";
            this.btn_Analyst.UseVisualStyleBackColor = true;
            this.btn_Analyst.Click += new System.EventHandler(this.btn_Analyst_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(123, 332);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(72, 26);
            this.btn_Clear.TabIndex = 11;
            this.btn_Clear.Text = "清除结果";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_StopAnalysis
            // 
            this.btn_StopAnalysis.Location = new System.Drawing.Point(123, 299);
            this.btn_StopAnalysis.Name = "btn_StopAnalysis";
            this.btn_StopAnalysis.Size = new System.Drawing.Size(72, 26);
            this.btn_StopAnalysis.TabIndex = 12;
            this.btn_StopAnalysis.Text = "结束分析";
            this.btn_StopAnalysis.UseVisualStyleBackColor = true;
            this.btn_StopAnalysis.Click += new System.EventHandler(this.btn_StopAnalysis_Click);
            // 
            // cb_ColorScheme
            // 
            this.cb_ColorScheme.FormattingEnabled = true;
            this.cb_ColorScheme.Items.AddRange(new object[] {
            "标准(红/绿)",
            "自定义(黄/蓝)",
            "随机"});
            this.cb_ColorScheme.Location = new System.Drawing.Point(98, 273);
            this.cb_ColorScheme.MaximumSize = new System.Drawing.Size(112, 0);
            this.cb_ColorScheme.Name = "cb_ColorScheme";
            this.cb_ColorScheme.Size = new System.Drawing.Size(112, 20);
            this.cb_ColorScheme.TabIndex = 28;
            this.cb_ColorScheme.SelectedIndexChanged += new System.EventHandler(this.cb_ColorScheme_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "视线颜色设定";
            // 
            // btn_GetBarrierPoint
            // 
            this.btn_GetBarrierPoint.Location = new System.Drawing.Point(23, 334);
            this.btn_GetBarrierPoint.Name = "btn_GetBarrierPoint";
            this.btn_GetBarrierPoint.Size = new System.Drawing.Size(77, 23);
            this.btn_GetBarrierPoint.TabIndex = 29;
            this.btn_GetBarrierPoint.Text = "获取障碍点";
            this.btn_GetBarrierPoint.UseVisualStyleBackColor = true;
            this.btn_GetBarrierPoint.Click += new System.EventHandler(this.btn_GetBarrierPoint_Click);
            // 
            // DlgSightLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 362);
            this.Controls.Add(this.btn_GetBarrierPoint);
            this.Controls.Add(this.cb_ColorScheme);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_StopAnalysis);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Analyst);
            this.Controls.Add(this.gb_Targets);
            this.Controls.Add(this.gb_Observer);
            this.MaximumSize = new System.Drawing.Size(238, 400);
            this.MinimumSize = new System.Drawing.Size(135, 337);
            this.Name = "DlgSightLine";
            this.Text = "可见性分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSightLine_FormClosing);
            this.Load += new System.EventHandler(this.DlgSightLine_Load);
            this.gb_Observer.ResumeLayout(false);
            this.gb_Observer.PerformLayout();
            this.gb_Targets.ResumeLayout(false);
            this.gb_Targets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_Observer;
        private System.Windows.Forms.GroupBox gb_Targets;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_TargetPtsIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ObserverHeight;
        private System.Windows.Forms.TextBox tb_ObserverY;
        private System.Windows.Forms.TextBox tb_ObserverX;
        private System.Windows.Forms.TextBox tb_TargetHeight;
        private System.Windows.Forms.TextBox tb_TargetY;
        private System.Windows.Forms.TextBox tb_TargetX;
        private System.Windows.Forms.Button btn_Analyst;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_StopAnalysis;
        private System.Windows.Forms.ComboBox cb_ColorScheme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_GetBarrierPoint;
    }
}