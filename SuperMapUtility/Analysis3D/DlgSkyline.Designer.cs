namespace SuperMap.SampleCode.Realspace
{
    partial class DlgSkyline
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
            this.cb_TextureQuality = new System.Windows.Forms.ComboBox();
            this.btn_Analyst = new System.Windows.Forms.Button();
            this.btn_ClearResult = new System.Windows.Forms.Button();
            this.gb_Skyline = new System.Windows.Forms.GroupBox();
            this.btn_FlyToViewer = new System.Windows.Forms.Button();
            this.btn_GetSkyline = new System.Windows.Forms.Button();
            this.cb_DisplayMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb_Observer = new System.Windows.Forms.GroupBox();
            this.cb_IsShowObserverPoint = new System.Windows.Forms.CheckBox();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.numeric_Direction = new System.Windows.Forms.NumericUpDown();
            this.numeric_Pitch = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog_Skyline = new System.Windows.Forms.ColorDialog();
            this.gb_HeightLimit = new System.Windows.Forms.GroupBox();
            this.btn_StopDrawLimit = new System.Windows.Forms.Button();
            this.btn_DeleteLimit = new System.Windows.Forms.Button();
            this.btn_HeightLimit = new System.Windows.Forms.Button();
            this.colorButton = new SuperMap.UI.ColorButton();
            this.gb_Skyline.SuspendLayout();
            this.gb_Observer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Direction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Pitch)).BeginInit();
            this.gb_HeightLimit.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "深度纹理的质量";
            // 
            // cb_TextureQuality
            // 
            this.cb_TextureQuality.FormattingEnabled = true;
            this.cb_TextureQuality.Items.AddRange(new object[] {
            "low",
            "medium",
            "high"});
            this.cb_TextureQuality.Location = new System.Drawing.Point(102, 23);
            this.cb_TextureQuality.Name = "cb_TextureQuality";
            this.cb_TextureQuality.Size = new System.Drawing.Size(131, 20);
            this.cb_TextureQuality.TabIndex = 1;
            this.cb_TextureQuality.SelectedIndexChanged += new System.EventHandler(this.cb_TextureQuality_SelectedIndexChanged);
            // 
            // btn_Analyst
            // 
            this.btn_Analyst.Location = new System.Drawing.Point(35, 309);
            this.btn_Analyst.Name = "btn_Analyst";
            this.btn_Analyst.Size = new System.Drawing.Size(88, 23);
            this.btn_Analyst.TabIndex = 2;
            this.btn_Analyst.Text = "开始分析";
            this.btn_Analyst.UseVisualStyleBackColor = true;
            this.btn_Analyst.Click += new System.EventHandler(this.btn_Analyst_Click);
            // 
            // btn_ClearResult
            // 
            this.btn_ClearResult.Location = new System.Drawing.Point(134, 309);
            this.btn_ClearResult.Name = "btn_ClearResult";
            this.btn_ClearResult.Size = new System.Drawing.Size(94, 23);
            this.btn_ClearResult.TabIndex = 3;
            this.btn_ClearResult.Text = "清除分析结果";
            this.btn_ClearResult.UseVisualStyleBackColor = true;
            this.btn_ClearResult.Click += new System.EventHandler(this.btn_ClearResult_Click);
            // 
            // gb_Skyline
            // 
            this.gb_Skyline.Controls.Add(this.colorButton);
            this.gb_Skyline.Controls.Add(this.btn_FlyToViewer);
            this.gb_Skyline.Controls.Add(this.btn_GetSkyline);
            this.gb_Skyline.Controls.Add(this.cb_DisplayMode);
            this.gb_Skyline.Controls.Add(this.label7);
            this.gb_Skyline.Controls.Add(this.gb_Observer);
            this.gb_Skyline.Controls.Add(this.btn_ClearResult);
            this.gb_Skyline.Controls.Add(this.label2);
            this.gb_Skyline.Controls.Add(this.btn_Analyst);
            this.gb_Skyline.Controls.Add(this.label1);
            this.gb_Skyline.Controls.Add(this.cb_TextureQuality);
            this.gb_Skyline.Location = new System.Drawing.Point(1, 3);
            this.gb_Skyline.Name = "gb_Skyline";
            this.gb_Skyline.Size = new System.Drawing.Size(245, 373);
            this.gb_Skyline.TabIndex = 4;
            this.gb_Skyline.TabStop = false;
            this.gb_Skyline.Text = "天际线显示设置";
            // 
            // btn_FlyToViewer
            // 
            this.btn_FlyToViewer.Location = new System.Drawing.Point(35, 344);
            this.btn_FlyToViewer.Name = "btn_FlyToViewer";
            this.btn_FlyToViewer.Size = new System.Drawing.Size(88, 23);
            this.btn_FlyToViewer.TabIndex = 13;
            this.btn_FlyToViewer.Text = "定位到视点";
            this.btn_FlyToViewer.UseVisualStyleBackColor = true;
            this.btn_FlyToViewer.Click += new System.EventHandler(this.btn_FlyToViewer_Click);
            // 
            // btn_GetSkyline
            // 
            this.btn_GetSkyline.Location = new System.Drawing.Point(134, 343);
            this.btn_GetSkyline.Name = "btn_GetSkyline";
            this.btn_GetSkyline.Size = new System.Drawing.Size(94, 23);
            this.btn_GetSkyline.TabIndex = 12;
            this.btn_GetSkyline.Text = "获取天际线";
            this.btn_GetSkyline.UseVisualStyleBackColor = true;
            this.btn_GetSkyline.Click += new System.EventHandler(this.btn_GetSkyline_Click);
            // 
            // cb_DisplayMode
            // 
            this.cb_DisplayMode.FormattingEnabled = true;
            this.cb_DisplayMode.Items.AddRange(new object[] {
            "线",
            "面"});
            this.cb_DisplayMode.Location = new System.Drawing.Point(102, 81);
            this.cb_DisplayMode.Name = "cb_DisplayMode";
            this.cb_DisplayMode.Size = new System.Drawing.Size(131, 20);
            this.cb_DisplayMode.TabIndex = 11;
            this.cb_DisplayMode.SelectedIndexChanged += new System.EventHandler(this.cb_DisplayMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "显示模式";
            // 
            // gb_Observer
            // 
            this.gb_Observer.Controls.Add(this.cb_IsShowObserverPoint);
            this.gb_Observer.Controls.Add(this.numericUpDown_X);
            this.gb_Observer.Controls.Add(this.numericUpDown_Y);
            this.gb_Observer.Controls.Add(this.numericUpDown_Height);
            this.gb_Observer.Controls.Add(this.numeric_Direction);
            this.gb_Observer.Controls.Add(this.numeric_Pitch);
            this.gb_Observer.Controls.Add(this.label6);
            this.gb_Observer.Controls.Add(this.label8);
            this.gb_Observer.Controls.Add(this.label3);
            this.gb_Observer.Controls.Add(this.label4);
            this.gb_Observer.Controls.Add(this.label5);
            this.gb_Observer.Location = new System.Drawing.Point(17, 107);
            this.gb_Observer.Name = "gb_Observer";
            this.gb_Observer.Size = new System.Drawing.Size(224, 196);
            this.gb_Observer.TabIndex = 9;
            this.gb_Observer.TabStop = false;
            this.gb_Observer.Text = "观察点";
            // 
            // cb_IsShowObserverPoint
            // 
            this.cb_IsShowObserverPoint.AutoSize = true;
            this.cb_IsShowObserverPoint.Checked = true;
            this.cb_IsShowObserverPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsShowObserverPoint.Location = new System.Drawing.Point(18, 174);
            this.cb_IsShowObserverPoint.Name = "cb_IsShowObserverPoint";
            this.cb_IsShowObserverPoint.Size = new System.Drawing.Size(108, 16);
            this.cb_IsShowObserverPoint.TabIndex = 42;
            this.cb_IsShowObserverPoint.Text = "是否显示观察点";
            this.cb_IsShowObserverPoint.UseVisualStyleBackColor = true;
            this.cb_IsShowObserverPoint.CheckedChanged += new System.EventHandler(this.cb_IsShowObserverPoint_CheckedChanged);
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.DecimalPlaces = 6;
            this.numericUpDown_X.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_X.Location = new System.Drawing.Point(61, 18);
            this.numericUpDown_X.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDown_X.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.Size = new System.Drawing.Size(150, 21);
            this.numericUpDown_X.TabIndex = 41;
            this.numericUpDown_X.ValueChanged += new System.EventHandler(this.numericUpDown_X_ValueChanged);
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.DecimalPlaces = 6;
            this.numericUpDown_Y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_Y.Location = new System.Drawing.Point(61, 49);
            this.numericUpDown_Y.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDown_Y.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.Size = new System.Drawing.Size(150, 21);
            this.numericUpDown_Y.TabIndex = 40;
            this.numericUpDown_Y.ValueChanged += new System.EventHandler(this.numericUpDown_Y_ValueChanged);
            // 
            // numericUpDown_Height
            // 
            this.numericUpDown_Height.DecimalPlaces = 2;
            this.numericUpDown_Height.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Height.Location = new System.Drawing.Point(61, 81);
            this.numericUpDown_Height.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown_Height.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Height.Name = "numericUpDown_Height";
            this.numericUpDown_Height.Size = new System.Drawing.Size(150, 21);
            this.numericUpDown_Height.TabIndex = 39;
            this.numericUpDown_Height.ValueChanged += new System.EventHandler(this.numericUpDown_Height_ValueChanged);
            // 
            // numeric_Direction
            // 
            this.numeric_Direction.DecimalPlaces = 1;
            this.numeric_Direction.Location = new System.Drawing.Point(61, 112);
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
            this.numeric_Direction.Size = new System.Drawing.Size(150, 21);
            this.numeric_Direction.TabIndex = 38;
            this.numeric_Direction.ValueChanged += new System.EventHandler(this.numeric_Direction_ValueChanged);
            // 
            // numeric_Pitch
            // 
            this.numeric_Pitch.DecimalPlaces = 1;
            this.numeric_Pitch.Location = new System.Drawing.Point(61, 145);
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
            this.numeric_Pitch.Size = new System.Drawing.Size(150, 21);
            this.numeric_Pitch.TabIndex = 37;
            this.numeric_Pitch.ValueChanged += new System.EventHandler(this.numeric_Pitch_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 36;
            this.label6.Text = "倾斜角";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "方向角";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "高度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "天际线颜色";
            // 
            // gb_HeightLimit
            // 
            this.gb_HeightLimit.Controls.Add(this.btn_StopDrawLimit);
            this.gb_HeightLimit.Controls.Add(this.btn_DeleteLimit);
            this.gb_HeightLimit.Controls.Add(this.btn_HeightLimit);
            this.gb_HeightLimit.Location = new System.Drawing.Point(1, 386);
            this.gb_HeightLimit.Name = "gb_HeightLimit";
            this.gb_HeightLimit.Size = new System.Drawing.Size(245, 86);
            this.gb_HeightLimit.TabIndex = 7;
            this.gb_HeightLimit.TabStop = false;
            this.gb_HeightLimit.Text = "区域限高";
            // 
            // btn_StopDrawLimit
            // 
            this.btn_StopDrawLimit.Location = new System.Drawing.Point(134, 20);
            this.btn_StopDrawLimit.Name = "btn_StopDrawLimit";
            this.btn_StopDrawLimit.Size = new System.Drawing.Size(94, 23);
            this.btn_StopDrawLimit.TabIndex = 2;
            this.btn_StopDrawLimit.Text = "停止绘制限高";
            this.btn_StopDrawLimit.UseVisualStyleBackColor = true;
            this.btn_StopDrawLimit.Click += new System.EventHandler(this.btn_StopDrawLimit_Click);
            // 
            // btn_DeleteLimit
            // 
            this.btn_DeleteLimit.Location = new System.Drawing.Point(59, 57);
            this.btn_DeleteLimit.Name = "btn_DeleteLimit";
            this.btn_DeleteLimit.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteLimit.TabIndex = 1;
            this.btn_DeleteLimit.Text = "清除限高";
            this.btn_DeleteLimit.UseVisualStyleBackColor = true;
            this.btn_DeleteLimit.Click += new System.EventHandler(this.btn_DeleteLimit_Click);
            // 
            // btn_HeightLimit
            // 
            this.btn_HeightLimit.Location = new System.Drawing.Point(35, 20);
            this.btn_HeightLimit.Name = "btn_HeightLimit";
            this.btn_HeightLimit.Size = new System.Drawing.Size(88, 23);
            this.btn_HeightLimit.TabIndex = 0;
            this.btn_HeightLimit.Text = "绘制限高范围";
            this.btn_HeightLimit.UseVisualStyleBackColor = true;
            this.btn_HeightLimit.Click += new System.EventHandler(this.btn_HeightLimit_Click);
            // 
            // colorButton
            // 
            this.colorButton.AlphaEnabled = false;
            this.colorButton.Color = System.Drawing.Color.Empty;
            this.colorButton.Location = new System.Drawing.Point(102, 49);
            this.colorButton.Name = "colorButton";
            this.colorButton.ShowOtherColor = false;
            this.colorButton.Size = new System.Drawing.Size(131, 23);
            this.colorButton.TabIndex = 56;
            this.colorButton.Text = "colorButton";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.ColorChanged += new System.EventHandler(this.colorButton_ColorChanged);
            // 
            // DlgSkyline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 476);
            this.Controls.Add(this.gb_HeightLimit);
            this.Controls.Add(this.gb_Skyline);
            this.Name = "DlgSkyline";
            this.Text = "天际线分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSkyline_FormClosing);
            this.Load += new System.EventHandler(this.DlgSkyline_Load);
            this.gb_Skyline.ResumeLayout(false);
            this.gb_Skyline.PerformLayout();
            this.gb_Observer.ResumeLayout(false);
            this.gb_Observer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Direction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Pitch)).EndInit();
            this.gb_HeightLimit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_TextureQuality;
        private System.Windows.Forms.Button btn_Analyst;
        private System.Windows.Forms.Button btn_ClearResult;
        private System.Windows.Forms.GroupBox gb_Skyline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Observer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDialog_Skyline;
        private System.Windows.Forms.NumericUpDown numeric_Direction;
        private System.Windows.Forms.NumericUpDown numeric_Pitch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_X;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_Height;
        private System.Windows.Forms.GroupBox gb_HeightLimit;
        private System.Windows.Forms.Button btn_DeleteLimit;
        private System.Windows.Forms.Button btn_HeightLimit;
        private System.Windows.Forms.Button btn_StopDrawLimit;
        private System.Windows.Forms.ComboBox cb_DisplayMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_IsShowObserverPoint;
        private System.Windows.Forms.Button btn_GetSkyline;
        private System.Windows.Forms.Button btn_FlyToViewer;
        private UI.ColorButton colorButton;
    }
}