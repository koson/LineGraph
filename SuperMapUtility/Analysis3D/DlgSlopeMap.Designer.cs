namespace SuperMap.SampleCode.Realspace
{
    partial class DlgSlopeMap
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
            this.btn_StartAnalyst = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Opacity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_DisplayStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cb_IsShowSlopInfo = new System.Windows.Forms.CheckBox();
            this.tb_maxVisibleSlope = new System.Windows.Forms.TextBox();
            this.tb_minVisibleSlope = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_StopAnalysis = new System.Windows.Forms.Button();
            this.colorButton_Border = new SuperMap.UI.ColorButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_IsShowBorder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(112, 247);
            this.btn_Clear.MaximumSize = new System.Drawing.Size(89, 23);
            this.btn_Clear.MinimumSize = new System.Drawing.Size(50, 23);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(89, 23);
            this.btn_Clear.TabIndex = 33;
            this.btn_Clear.Text = "清除结果";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_StartAnalyst
            // 
            this.btn_StartAnalyst.Location = new System.Drawing.Point(43, 213);
            this.btn_StartAnalyst.Name = "btn_StartAnalyst";
            this.btn_StartAnalyst.Size = new System.Drawing.Size(133, 23);
            this.btn_StartAnalyst.TabIndex = 32;
            this.btn_StartAnalyst.Text = "绘制区域并开始分析";
            this.btn_StartAnalyst.UseVisualStyleBackColor = true;
            this.btn_StartAnalyst.Click += new System.EventHandler(this.btn_StartAnalyst_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "%";
            // 
            // tb_Opacity
            // 
            this.tb_Opacity.Location = new System.Drawing.Point(67, 40);
            this.tb_Opacity.Name = "tb_Opacity";
            this.tb_Opacity.Size = new System.Drawing.Size(71, 21);
            this.tb_Opacity.TabIndex = 28;
            this.tb_Opacity.TextChanged += new System.EventHandler(this.tb_Opacity_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "不透明度";
            // 
            // cb_DisplayStyle
            // 
            this.cb_DisplayStyle.FormattingEnabled = true;
            this.cb_DisplayStyle.Items.AddRange(new object[] {
            "填充色",
            "坡向",
            "填充和坡向"});
            this.cb_DisplayStyle.Location = new System.Drawing.Point(67, 6);
            this.cb_DisplayStyle.Name = "cb_DisplayStyle";
            this.cb_DisplayStyle.Size = new System.Drawing.Size(136, 20);
            this.cb_DisplayStyle.TabIndex = 18;
            this.cb_DisplayStyle.SelectedIndexChanged += new System.EventHandler(this.cb_DisplayStyle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "显示模式";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // cb_IsShowSlopInfo
            // 
            this.cb_IsShowSlopInfo.AutoSize = true;
            this.cb_IsShowSlopInfo.Location = new System.Drawing.Point(10, 133);
            this.cb_IsShowSlopInfo.Name = "cb_IsShowSlopInfo";
            this.cb_IsShowSlopInfo.Size = new System.Drawing.Size(96, 16);
            this.cb_IsShowSlopInfo.TabIndex = 34;
            this.cb_IsShowSlopInfo.Text = "显示坡度信息";
            this.cb_IsShowSlopInfo.UseVisualStyleBackColor = true;
            this.cb_IsShowSlopInfo.CheckedChanged += new System.EventHandler(this.cb_IsShowSlopInfo_CheckedChanged);
            // 
            // tb_maxVisibleSlope
            // 
            this.tb_maxVisibleSlope.Location = new System.Drawing.Point(129, 100);
            this.tb_maxVisibleSlope.Name = "tb_maxVisibleSlope";
            this.tb_maxVisibleSlope.Size = new System.Drawing.Size(74, 21);
            this.tb_maxVisibleSlope.TabIndex = 67;
            this.tb_maxVisibleSlope.TextChanged += new System.EventHandler(this.tb_maxVisibleSlope_TextChanged);
            // 
            // tb_minVisibleSlope
            // 
            this.tb_minVisibleSlope.Location = new System.Drawing.Point(128, 70);
            this.tb_minVisibleSlope.Name = "tb_minVisibleSlope";
            this.tb_minVisibleSlope.Size = new System.Drawing.Size(75, 21);
            this.tb_minVisibleSlope.TabIndex = 66;
            this.tb_minVisibleSlope.TextChanged += new System.EventHandler(this.tb_minVisibleSlope_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 65;
            this.label10.Text = "分析的最大可见坡度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 64;
            this.label9.Text = "分析的最小可见坡度";
            // 
            // btn_StopAnalysis
            // 
            this.btn_StopAnalysis.Location = new System.Drawing.Point(12, 247);
            this.btn_StopAnalysis.Name = "btn_StopAnalysis";
            this.btn_StopAnalysis.Size = new System.Drawing.Size(94, 23);
            this.btn_StopAnalysis.TabIndex = 68;
            this.btn_StopAnalysis.Text = "结束分析";
            this.btn_StopAnalysis.UseVisualStyleBackColor = true;
            this.btn_StopAnalysis.Click += new System.EventHandler(this.btn_StopAnalysis_Click);
            // 
            // colorButton_Border
            // 
            this.colorButton_Border.AlphaEnabled = false;
            this.colorButton_Border.Color = System.Drawing.Color.Empty;
            this.colorButton_Border.Location = new System.Drawing.Point(82, 178);
            this.colorButton_Border.Name = "colorButton_Border";
            this.colorButton_Border.ShowOtherColor = false;
            this.colorButton_Border.Size = new System.Drawing.Size(121, 23);
            this.colorButton_Border.TabIndex = 71;
            this.colorButton_Border.UseVisualStyleBackColor = true;
            this.colorButton_Border.ColorChanged += new System.EventHandler(this.colorButton_Border_ColorChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "边框线颜色";
            // 
            // cb_IsShowBorder
            // 
            this.cb_IsShowBorder.AutoSize = true;
            this.cb_IsShowBorder.Checked = true;
            this.cb_IsShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsShowBorder.Location = new System.Drawing.Point(10, 159);
            this.cb_IsShowBorder.Name = "cb_IsShowBorder";
            this.cb_IsShowBorder.Size = new System.Drawing.Size(96, 16);
            this.cb_IsShowBorder.TabIndex = 69;
            this.cb_IsShowBorder.Text = "是否显示边框";
            this.cb_IsShowBorder.UseVisualStyleBackColor = true;
            this.cb_IsShowBorder.CheckedChanged += new System.EventHandler(this.cb_IsShowBorder_CheckedChanged);
            // 
            // DlgSlopeMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 275);
            this.Controls.Add(this.colorButton_Border);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_IsShowBorder);
            this.Controls.Add(this.btn_StopAnalysis);
            this.Controls.Add(this.tb_maxVisibleSlope);
            this.Controls.Add(this.tb_minVisibleSlope);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_IsShowSlopInfo);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_StartAnalyst);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_Opacity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_DisplayStyle);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(230, 350);
            this.MinimumSize = new System.Drawing.Size(230, 200);
            this.Name = "DlgSlopeMap";
            this.Text = "坡度坡向分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSlopeMap_FormClosing);
            this.Load += new System.EventHandler(this.DlgSlopeMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_StartAnalyst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Opacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_DisplayStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox cb_IsShowSlopInfo;
        private System.Windows.Forms.TextBox tb_maxVisibleSlope;
        private System.Windows.Forms.TextBox tb_minVisibleSlope;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_StopAnalysis;
        private SuperMap.UI.ColorButton colorButton_Border;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_IsShowBorder;

    }
}