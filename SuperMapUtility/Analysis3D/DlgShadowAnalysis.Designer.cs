namespace SuperMap.SampleCode.Realspace
{
    partial class DlgShadowAnalysis
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ShadowType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_MinAltitude = new System.Windows.Forms.TextBox();
            this.tb_MaxAltitude = new System.Windows.Forms.TextBox();
            this.cb_TimeZone = new System.Windows.Forms.ComboBox();
            this.cb_StartTime = new System.Windows.Forms.ComboBox();
            this.cb_EndTime = new System.Windows.Forms.ComboBox();
            this.cb_TimeInterval = new System.Windows.Forms.ComboBox();
            this.meters = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_GetShadowRatio = new System.Windows.Forms.CheckBox();
            this.btn_StartAnalysis = new System.Windows.Forms.Button();
            this.btn_ClearResult = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_spacing = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.label_shadowRatio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "阴影类型";
            // 
            // cb_ShadowType
            // 
            this.cb_ShadowType.FormattingEnabled = true;
            this.cb_ShadowType.Items.AddRange(new object[] {
            "所有对象产生阴影",
            "选定对象产生阴影",
            "不开启阴影"});
            this.cb_ShadowType.Location = new System.Drawing.Point(86, 15);
            this.cb_ShadowType.Name = "cb_ShadowType";
            this.cb_ShadowType.Size = new System.Drawing.Size(162, 20);
            this.cb_ShadowType.TabIndex = 1;
            this.cb_ShadowType.SelectedIndexChanged += new System.EventHandler(this.cb_ShadowType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "最小高度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "最大高度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "时区";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "开始时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "结束时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "分析时间间隔";
            // 
            // tb_MinAltitude
            // 
            this.tb_MinAltitude.Location = new System.Drawing.Point(87, 47);
            this.tb_MinAltitude.Name = "tb_MinAltitude";
            this.tb_MinAltitude.Size = new System.Drawing.Size(109, 21);
            this.tb_MinAltitude.TabIndex = 8;
            this.tb_MinAltitude.TextChanged += new System.EventHandler(this.tb_MinAltitude_TextChanged);
            // 
            // tb_MaxAltitude
            // 
            this.tb_MaxAltitude.Location = new System.Drawing.Point(86, 78);
            this.tb_MaxAltitude.Name = "tb_MaxAltitude";
            this.tb_MaxAltitude.Size = new System.Drawing.Size(109, 21);
            this.tb_MaxAltitude.TabIndex = 9;
            this.tb_MaxAltitude.TextChanged += new System.EventHandler(this.tb_MaxAltitude_TextChanged);
            // 
            // cb_TimeZone
            // 
            this.cb_TimeZone.FormattingEnabled = true;
            this.cb_TimeZone.Items.AddRange(new object[] {
            "整个图层",
            "所选对象"});
            this.cb_TimeZone.Location = new System.Drawing.Point(39, 144);
            this.cb_TimeZone.Name = "cb_TimeZone";
            this.cb_TimeZone.Size = new System.Drawing.Size(210, 20);
            this.cb_TimeZone.TabIndex = 10;
            this.cb_TimeZone.SelectedIndexChanged += new System.EventHandler(this.cb_TimeZone_SelectedIndexChanged);
            // 
            // cb_StartTime
            // 
            this.cb_StartTime.FormattingEnabled = true;
            this.cb_StartTime.Items.AddRange(new object[] {
            "6 AM",
            "7 AM",
            "8 AM",
            "9 AM",
            "10 AM",
            "11 AM",
            "12 PM",
            "1 PM",
            "2 PM",
            "3 PM",
            "4 PM",
            "5 PM",
            "6 PM",
            "7 PM",
            "8 PM"});
            this.cb_StartTime.Location = new System.Drawing.Point(86, 185);
            this.cb_StartTime.Name = "cb_StartTime";
            this.cb_StartTime.Size = new System.Drawing.Size(109, 20);
            this.cb_StartTime.TabIndex = 11;
            this.cb_StartTime.SelectedIndexChanged += new System.EventHandler(this.cb_StartTime_SelectedIndexChanged);
            // 
            // cb_EndTime
            // 
            this.cb_EndTime.FormattingEnabled = true;
            this.cb_EndTime.Items.AddRange(new object[] {
            "6 AM",
            "7 AM",
            "8 AM",
            "9 AM",
            "10 AM",
            "11 AM",
            "12 PM",
            "1 PM",
            "2 PM",
            "3 PM",
            "4 PM",
            "5 PM",
            "6 PM",
            "7 PM",
            "8 PM"});
            this.cb_EndTime.Location = new System.Drawing.Point(87, 222);
            this.cb_EndTime.Name = "cb_EndTime";
            this.cb_EndTime.Size = new System.Drawing.Size(109, 20);
            this.cb_EndTime.TabIndex = 12;
            this.cb_EndTime.SelectedIndexChanged += new System.EventHandler(this.cb_EndTime_SelectedIndexChanged);
            // 
            // cb_TimeInterval
            // 
            this.cb_TimeInterval.FormattingEnabled = true;
            this.cb_TimeInterval.Items.AddRange(new object[] {
            "15",
            "30",
            "60"});
            this.cb_TimeInterval.Location = new System.Drawing.Point(87, 256);
            this.cb_TimeInterval.Name = "cb_TimeInterval";
            this.cb_TimeInterval.Size = new System.Drawing.Size(109, 20);
            this.cb_TimeInterval.TabIndex = 13;
            this.cb_TimeInterval.SelectedIndexChanged += new System.EventHandler(this.cb_TimeInterval_SelectedIndexChanged);
            // 
            // meters
            // 
            this.meters.AutoSize = true;
            this.meters.Location = new System.Drawing.Point(208, 50);
            this.meters.Name = "meters";
            this.meters.Size = new System.Drawing.Size(41, 12);
            this.meters.TabIndex = 14;
            this.meters.Text = "meters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "meters";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "minutes";
            // 
            // cb_GetShadowRatio
            // 
            this.cb_GetShadowRatio.AutoSize = true;
            this.cb_GetShadowRatio.Location = new System.Drawing.Point(6, 367);
            this.cb_GetShadowRatio.Name = "cb_GetShadowRatio";
            this.cb_GetShadowRatio.Size = new System.Drawing.Size(132, 16);
            this.cb_GetShadowRatio.TabIndex = 17;
            this.cb_GetShadowRatio.Text = "获取选定点的阴影率";
            this.cb_GetShadowRatio.UseVisualStyleBackColor = true;
            this.cb_GetShadowRatio.CheckedChanged += new System.EventHandler(this.cb_GetShadowRatio_CheckedChanged);
            // 
            // btn_StartAnalysis
            // 
            this.btn_StartAnalysis.Location = new System.Drawing.Point(66, 291);
            this.btn_StartAnalysis.Name = "btn_StartAnalysis";
            this.btn_StartAnalysis.Size = new System.Drawing.Size(129, 23);
            this.btn_StartAnalysis.TabIndex = 18;
            this.btn_StartAnalysis.Text = "绘制区域并开始分析";
            this.btn_StartAnalysis.UseVisualStyleBackColor = true;
            this.btn_StartAnalysis.Click += new System.EventHandler(this.btn_StartAnalysis_Click);
            // 
            // btn_ClearResult
            // 
            this.btn_ClearResult.Location = new System.Drawing.Point(151, 320);
            this.btn_ClearResult.Name = "btn_ClearResult";
            this.btn_ClearResult.Size = new System.Drawing.Size(98, 23);
            this.btn_ClearResult.TabIndex = 19;
            this.btn_ClearResult.Text = "清除结果";
            this.btn_ClearResult.UseVisualStyleBackColor = true;
            this.btn_ClearResult.Click += new System.EventHandler(this.btn_ClearResult_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "间距";
            // 
            // tb_spacing
            // 
            this.tb_spacing.Location = new System.Drawing.Point(87, 110);
            this.tb_spacing.Name = "tb_spacing";
            this.tb_spacing.Size = new System.Drawing.Size(109, 21);
            this.tb_spacing.TabIndex = 21;
            this.tb_spacing.TextChanged += new System.EventHandler(this.tb_spacing_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "meters";
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(9, 320);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(132, 23);
            this.btn_Apply.TabIndex = 23;
            this.btn_Apply.Text = "更新当前分析结果";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // label_shadowRatio
            // 
            this.label_shadowRatio.AutoSize = true;
            this.label_shadowRatio.Location = new System.Drawing.Point(10, 395);
            this.label_shadowRatio.Name = "label_shadowRatio";
            this.label_shadowRatio.Size = new System.Drawing.Size(131, 12);
            this.label_shadowRatio.TabIndex = 25;
            this.label_shadowRatio.Text = "当前点的阴影率为：***";
            // 
            // DlgShadowAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 418);
            this.Controls.Add(this.label_shadowRatio);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_spacing);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_ClearResult);
            this.Controls.Add(this.btn_StartAnalysis);
            this.Controls.Add(this.cb_GetShadowRatio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.meters);
            this.Controls.Add(this.cb_TimeInterval);
            this.Controls.Add(this.cb_EndTime);
            this.Controls.Add(this.cb_StartTime);
            this.Controls.Add(this.cb_TimeZone);
            this.Controls.Add(this.tb_MaxAltitude);
            this.Controls.Add(this.tb_MinAltitude);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_ShadowType);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(277, 375);
            this.Name = "DlgShadowAnalysis";
            this.Text = "阴影分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgShadowAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.DlgShadowAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_ShadowType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_MinAltitude;
        private System.Windows.Forms.TextBox tb_MaxAltitude;
        private System.Windows.Forms.ComboBox cb_TimeZone;
        private System.Windows.Forms.ComboBox cb_StartTime;
        private System.Windows.Forms.ComboBox cb_EndTime;
        private System.Windows.Forms.ComboBox cb_TimeInterval;
        private System.Windows.Forms.Label meters;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cb_GetShadowRatio;
        private System.Windows.Forms.Button btn_StartAnalysis;
        private System.Windows.Forms.Button btn_ClearResult;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_spacing;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Label label_shadowRatio;
    }
}