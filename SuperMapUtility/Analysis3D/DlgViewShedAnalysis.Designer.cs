namespace SuperMap.SampleCode.Realspace
{
    partial class DlgViewShedAnalysis
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ColorScheme = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Analyst = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.numeric_Pitch = new System.Windows.Forms.NumericUpDown();
            this.numeric_Direction = new System.Windows.Forms.NumericUpDown();
            this.numeric_VerticalFOV = new System.Windows.Forms.NumericUpDown();
            this.numeric_HorizontalFOV = new System.Windows.Forms.NumericUpDown();
            this.numeric_Distance = new System.Windows.Forms.NumericUpDown();
            this.gb_Observer = new System.Windows.Forms.GroupBox();
            this.tb_ObserverHeight = new System.Windows.Forms.TextBox();
            this.tb_ObserverY = new System.Windows.Forms.TextBox();
            this.tb_ObserverX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_Quality = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.colorButton = new SuperMap.UI.ColorButton();
            this.btn_StopAnalysis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Direction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VerticalFOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HorizontalFOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Distance)).BeginInit();
            this.gb_Observer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "meters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "可视距离";
            // 
            // cb_ColorScheme
            // 
            this.cb_ColorScheme.FormattingEnabled = true;
            this.cb_ColorScheme.Items.AddRange(new object[] {
            "标准(红/绿)",
            "自定义(黄/蓝)",
            "随机"});
            this.cb_ColorScheme.Location = new System.Drawing.Point(69, 288);
            this.cb_ColorScheme.MaximumSize = new System.Drawing.Size(112, 0);
            this.cb_ColorScheme.Name = "cb_ColorScheme";
            this.cb_ColorScheme.Size = new System.Drawing.Size(112, 20);
            this.cb_ColorScheme.TabIndex = 26;
            this.cb_ColorScheme.SelectedIndexChanged += new System.EventHandler(this.cb_ColorScheme_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "颜色设定";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "deg.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "垂直视域";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "deg.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "水平视域";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "方向角";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "倾斜角";
            // 
            // btn_Analyst
            // 
            this.btn_Analyst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Analyst.Location = new System.Drawing.Point(12, 373);
            this.btn_Analyst.Name = "btn_Analyst";
            this.btn_Analyst.Size = new System.Drawing.Size(61, 26);
            this.btn_Analyst.TabIndex = 31;
            this.btn_Analyst.Text = "开始分析";
            this.btn_Analyst.UseVisualStyleBackColor = true;
            this.btn_Analyst.Click += new System.EventHandler(this.btn_Analyst_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Clear.Location = new System.Drawing.Point(152, 373);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(65, 25);
            this.btn_Clear.TabIndex = 32;
            this.btn_Clear.Text = "清除结果";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // numeric_Pitch
            // 
            this.numeric_Pitch.DecimalPlaces = 1;
            this.numeric_Pitch.Location = new System.Drawing.Point(69, 254);
            this.numeric_Pitch.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numeric_Pitch.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numeric_Pitch.Name = "numeric_Pitch";
            this.numeric_Pitch.Size = new System.Drawing.Size(112, 21);
            this.numeric_Pitch.TabIndex = 33;
            this.numeric_Pitch.ValueChanged += new System.EventHandler(this.numeric_Pitch_ValueChanged);
            // 
            // numeric_Direction
            // 
            this.numeric_Direction.DecimalPlaces = 1;
            this.numeric_Direction.Location = new System.Drawing.Point(69, 216);
            this.numeric_Direction.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numeric_Direction.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numeric_Direction.Name = "numeric_Direction";
            this.numeric_Direction.Size = new System.Drawing.Size(112, 21);
            this.numeric_Direction.TabIndex = 34;
            this.numeric_Direction.ValueChanged += new System.EventHandler(this.numeric_Direction_ValueChanged);
            // 
            // numeric_VerticalFOV
            // 
            this.numeric_VerticalFOV.DecimalPlaces = 1;
            this.numeric_VerticalFOV.Location = new System.Drawing.Point(69, 182);
            this.numeric_VerticalFOV.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numeric_VerticalFOV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_VerticalFOV.Name = "numeric_VerticalFOV";
            this.numeric_VerticalFOV.Size = new System.Drawing.Size(112, 21);
            this.numeric_VerticalFOV.TabIndex = 35;
            this.numeric_VerticalFOV.Value = new decimal(new int[] {
            600,
            0,
            0,
            65536});
            this.numeric_VerticalFOV.ValueChanged += new System.EventHandler(this.numeric_VerticalFOV_ValueChanged);
            // 
            // numeric_HorizontalFOV
            // 
            this.numeric_HorizontalFOV.DecimalPlaces = 1;
            this.numeric_HorizontalFOV.Location = new System.Drawing.Point(69, 148);
            this.numeric_HorizontalFOV.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numeric_HorizontalFOV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_HorizontalFOV.Name = "numeric_HorizontalFOV";
            this.numeric_HorizontalFOV.Size = new System.Drawing.Size(112, 21);
            this.numeric_HorizontalFOV.TabIndex = 36;
            this.numeric_HorizontalFOV.Value = new decimal(new int[] {
            900,
            0,
            0,
            65536});
            this.numeric_HorizontalFOV.ValueChanged += new System.EventHandler(this.numeric_HorizontalFOV_ValueChanged);
            // 
            // numeric_Distance
            // 
            this.numeric_Distance.DecimalPlaces = 1;
            this.numeric_Distance.Location = new System.Drawing.Point(69, 116);
            this.numeric_Distance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numeric_Distance.Name = "numeric_Distance";
            this.numeric_Distance.Size = new System.Drawing.Size(112, 21);
            this.numeric_Distance.TabIndex = 37;
            this.numeric_Distance.Value = new decimal(new int[] {
            1000,
            0,
            0,
            65536});
            this.numeric_Distance.ValueChanged += new System.EventHandler(this.numeric_Distance_ValueChanged);
            // 
            // gb_Observer
            // 
            this.gb_Observer.Controls.Add(this.tb_ObserverHeight);
            this.gb_Observer.Controls.Add(this.tb_ObserverY);
            this.gb_Observer.Controls.Add(this.tb_ObserverX);
            this.gb_Observer.Controls.Add(this.label3);
            this.gb_Observer.Controls.Add(this.label4);
            this.gb_Observer.Controls.Add(this.label12);
            this.gb_Observer.Location = new System.Drawing.Point(2, 2);
            this.gb_Observer.Name = "gb_Observer";
            this.gb_Observer.Size = new System.Drawing.Size(226, 102);
            this.gb_Observer.TabIndex = 38;
            this.gb_Observer.TabStop = false;
            this.gb_Observer.Text = "观察点";
            // 
            // tb_ObserverHeight
            // 
            this.tb_ObserverHeight.Location = new System.Drawing.Point(57, 78);
            this.tb_ObserverHeight.Name = "tb_ObserverHeight";
            this.tb_ObserverHeight.Size = new System.Drawing.Size(122, 21);
            this.tb_ObserverHeight.TabIndex = 6;
            this.tb_ObserverHeight.Text = "0.0";
            this.tb_ObserverHeight.TextChanged += new System.EventHandler(this.tb_ObserverHeight_TextChanged);
            // 
            // tb_ObserverY
            // 
            this.tb_ObserverY.Location = new System.Drawing.Point(57, 48);
            this.tb_ObserverY.Name = "tb_ObserverY";
            this.tb_ObserverY.Size = new System.Drawing.Size(122, 21);
            this.tb_ObserverY.TabIndex = 5;
            this.tb_ObserverY.Text = "0.0";
            this.tb_ObserverY.TextChanged += new System.EventHandler(this.tb_ObserverY_TextChanged);
            // 
            // tb_ObserverX
            // 
            this.tb_ObserverX.Location = new System.Drawing.Point(57, 15);
            this.tb_ObserverX.Name = "tb_ObserverX";
            this.tb_ObserverX.Size = new System.Drawing.Size(122, 21);
            this.tb_ObserverX.TabIndex = 4;
            this.tb_ObserverX.Text = "0.0";
            this.tb_ObserverX.TextChanged += new System.EventHandler(this.tb_ObserverX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "高度";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "分析质量";
            // 
            // cb_Quality
            // 
            this.cb_Quality.FormattingEnabled = true;
            this.cb_Quality.Items.AddRange(new object[] {
            "low",
            "medium",
            "high"});
            this.cb_Quality.Location = new System.Drawing.Point(69, 317);
            this.cb_Quality.Name = "cb_Quality";
            this.cb_Quality.Size = new System.Drawing.Size(112, 20);
            this.cb_Quality.TabIndex = 40;
            this.cb_Quality.SelectedIndexChanged += new System.EventHandler(this.cb_Quality_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 350);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 41;
            this.label14.Text = "提示线颜色";
            // 
            // colorButton
            // 
            this.colorButton.AlphaEnabled = false;
            this.colorButton.Color = System.Drawing.Color.White;
            this.colorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colorButton.Location = new System.Drawing.Point(81, 343);
            this.colorButton.Name = "colorButton";
            this.colorButton.ShowOtherColor = false;
            this.colorButton.Size = new System.Drawing.Size(100, 23);
            this.colorButton.TabIndex = 42;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.ColorChanged += new System.EventHandler(this.colorButton_ColorChanged);
            // 
            // btn_StopAnalysis
            // 
            this.btn_StopAnalysis.Location = new System.Drawing.Point(79, 373);
            this.btn_StopAnalysis.Name = "btn_StopAnalysis";
            this.btn_StopAnalysis.Size = new System.Drawing.Size(65, 26);
            this.btn_StopAnalysis.TabIndex = 43;
            this.btn_StopAnalysis.Text = "结束分析";
            this.btn_StopAnalysis.UseVisualStyleBackColor = true;
            this.btn_StopAnalysis.Click += new System.EventHandler(this.btn_StopAnalysis_Click);
            // 
            // DlgViewShedAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 410);
            this.Controls.Add(this.btn_StopAnalysis);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_Quality);
            this.Controls.Add(this.gb_Observer);
            this.Controls.Add(this.numeric_Distance);
            this.Controls.Add(this.numeric_HorizontalFOV);
            this.Controls.Add(this.numeric_VerticalFOV);
            this.Controls.Add(this.numeric_Direction);
            this.Controls.Add(this.numeric_Pitch);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Analyst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ColorScheme);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.MaximumSize = new System.Drawing.Size(245, 450);
            this.MinimumSize = new System.Drawing.Size(245, 420);
            this.Name = "DlgViewShedAnalysis";
            this.Text = "可视域分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgViewShedAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.DlgViewShedAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Direction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_VerticalFOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HorizontalFOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Distance)).EndInit();
            this.gb_Observer.ResumeLayout(false);
            this.gb_Observer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ColorScheme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Analyst;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.NumericUpDown numeric_Pitch;
        private System.Windows.Forms.NumericUpDown numeric_Direction;
        private System.Windows.Forms.NumericUpDown numeric_VerticalFOV;
        private System.Windows.Forms.NumericUpDown numeric_HorizontalFOV;
        private System.Windows.Forms.NumericUpDown numeric_Distance;
        private System.Windows.Forms.GroupBox gb_Observer;
        private System.Windows.Forms.TextBox tb_ObserverHeight;
        private System.Windows.Forms.TextBox tb_ObserverY;
        private System.Windows.Forms.TextBox tb_ObserverX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_Quality;
        private System.Windows.Forms.Label label14;
        private SuperMap.UI.ColorButton colorButton;
        private System.Windows.Forms.Button btn_StopAnalysis;
    }
}