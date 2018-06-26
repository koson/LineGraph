namespace SuperMap.SampleCode.Realspace
{
    partial class DlgContourMap
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
            this.tb_LineInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_DisplayStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorButton = new SuperMap.UI.ColorButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_minVisibleAltitude = new System.Windows.Forms.TextBox();
            this.tb_maxVisibleAltitude = new System.Windows.Forms.TextBox();
            this.btn_StopAnalysis = new System.Windows.Forms.Button();
            this.cb_IsShowBorder = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorButton_Border = new SuperMap.UI.ColorButton();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(121, 283);
            this.btn_Clear.MaximumSize = new System.Drawing.Size(89, 23);
            this.btn_Clear.MinimumSize = new System.Drawing.Size(50, 23);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(84, 23);
            this.btn_Clear.TabIndex = 50;
            this.btn_Clear.Text = "清除结果";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_StartAnalyst
            // 
            this.btn_StartAnalyst.Location = new System.Drawing.Point(52, 254);
            this.btn_StartAnalyst.Name = "btn_StartAnalyst";
            this.btn_StartAnalyst.Size = new System.Drawing.Size(130, 23);
            this.btn_StartAnalyst.TabIndex = 49;
            this.btn_StartAnalyst.Text = "绘制区域并开始分析";
            this.btn_StartAnalyst.UseVisualStyleBackColor = true;
            this.btn_StartAnalyst.Click += new System.EventHandler(this.btn_StartAnalyst_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 46;
            this.label6.Text = "%";
            // 
            // tb_Opacity
            // 
            this.tb_Opacity.Location = new System.Drawing.Point(84, 100);
            this.tb_Opacity.Name = "tb_Opacity";
            this.tb_Opacity.Size = new System.Drawing.Size(66, 21);
            this.tb_Opacity.TabIndex = 45;
            this.tb_Opacity.TextChanged += new System.EventHandler(this.tb_Opacity_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "不透明度";
            // 
            // tb_LineInterval
            // 
            this.tb_LineInterval.Location = new System.Drawing.Point(83, 69);
            this.tb_LineInterval.Name = "tb_LineInterval";
            this.tb_LineInterval.Size = new System.Drawing.Size(121, 21);
            this.tb_LineInterval.TabIndex = 40;
            this.tb_LineInterval.TextChanged += new System.EventHandler(this.tb_LineInterval_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "等高线间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "等高线颜色";
            // 
            // cb_DisplayStyle
            // 
            this.cb_DisplayStyle.FormattingEnabled = true;
            this.cb_DisplayStyle.Items.AddRange(new object[] {
            "填充纹理",
            "等高线",
            "填充纹理加等高线"});
            this.cb_DisplayStyle.Location = new System.Drawing.Point(82, 6);
            this.cb_DisplayStyle.Name = "cb_DisplayStyle";
            this.cb_DisplayStyle.Size = new System.Drawing.Size(121, 20);
            this.cb_DisplayStyle.TabIndex = 35;
            this.cb_DisplayStyle.SelectedIndexChanged += new System.EventHandler(this.cb_DisplayStyle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "显示模式";
            // 
            // colorButton
            // 
            this.colorButton.AlphaEnabled = false;
            this.colorButton.Color = System.Drawing.Color.Empty;
            this.colorButton.Location = new System.Drawing.Point(83, 36);
            this.colorButton.Name = "colorButton";
            this.colorButton.ShowOtherColor = false;
            this.colorButton.Size = new System.Drawing.Size(120, 23);
            this.colorButton.TabIndex = 55;
            this.colorButton.Text = "colorButton";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.ColorChanged += new System.EventHandler(this.colorButton_ColorChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 56;
            this.label9.Text = "分析的最小可见高度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 57;
            this.label10.Text = "分析的最大可见高度";
            // 
            // tb_minVisibleAltitude
            // 
            this.tb_minVisibleAltitude.Location = new System.Drawing.Point(121, 133);
            this.tb_minVisibleAltitude.Name = "tb_minVisibleAltitude";
            this.tb_minVisibleAltitude.Size = new System.Drawing.Size(81, 21);
            this.tb_minVisibleAltitude.TabIndex = 58;
            this.tb_minVisibleAltitude.TextChanged += new System.EventHandler(this.tb_minVisibleAltitude_TextChanged);
            // 
            // tb_maxVisibleAltitude
            // 
            this.tb_maxVisibleAltitude.Location = new System.Drawing.Point(121, 163);
            this.tb_maxVisibleAltitude.Name = "tb_maxVisibleAltitude";
            this.tb_maxVisibleAltitude.Size = new System.Drawing.Size(81, 21);
            this.tb_maxVisibleAltitude.TabIndex = 59;
            this.tb_maxVisibleAltitude.TextChanged += new System.EventHandler(this.tb_maxVisibleAltitude_TextChanged);
            // 
            // btn_StopAnalysis
            // 
            this.btn_StopAnalysis.Location = new System.Drawing.Point(16, 283);
            this.btn_StopAnalysis.Name = "btn_StopAnalysis";
            this.btn_StopAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btn_StopAnalysis.TabIndex = 60;
            this.btn_StopAnalysis.Text = "结束分析";
            this.btn_StopAnalysis.UseVisualStyleBackColor = true;
            this.btn_StopAnalysis.Click += new System.EventHandler(this.btn_StopAnalysis_Click);
            // 
            // cb_IsShowBorder
            // 
            this.cb_IsShowBorder.AutoSize = true;
            this.cb_IsShowBorder.Checked = true;
            this.cb_IsShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsShowBorder.Location = new System.Drawing.Point(12, 194);
            this.cb_IsShowBorder.Name = "cb_IsShowBorder";
            this.cb_IsShowBorder.Size = new System.Drawing.Size(96, 16);
            this.cb_IsShowBorder.TabIndex = 61;
            this.cb_IsShowBorder.Text = "是否显示边框";
            this.cb_IsShowBorder.UseVisualStyleBackColor = true;
            this.cb_IsShowBorder.CheckedChanged += new System.EventHandler(this.cb_IsShowBorder_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "边框线颜色";
            // 
            // colorButton_Border
            // 
            this.colorButton_Border.AlphaEnabled = false;
            this.colorButton_Border.Color = System.Drawing.Color.Empty;
            this.colorButton_Border.Location = new System.Drawing.Point(85, 216);
            this.colorButton_Border.Name = "colorButton_Border";
            this.colorButton_Border.ShowOtherColor = false;
            this.colorButton_Border.Size = new System.Drawing.Size(120, 23);
            this.colorButton_Border.TabIndex = 63;
            this.colorButton_Border.UseVisualStyleBackColor = true;
            this.colorButton_Border.ColorChanged += new System.EventHandler(this.colorButton_Border_ColorChanged);
            // 
            // DlgContourMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 312);
            this.Controls.Add(this.colorButton_Border);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_IsShowBorder);
            this.Controls.Add(this.btn_StopAnalysis);
            this.Controls.Add(this.tb_maxVisibleAltitude);
            this.Controls.Add(this.tb_minVisibleAltitude);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_StartAnalyst);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_Opacity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_LineInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_DisplayStyle);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(286, 350);
            this.MinimumSize = new System.Drawing.Size(230, 250);
            this.Name = "DlgContourMap";
            this.Text = "等高线分析";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgContourMap_FormClosing);
            this.Load += new System.EventHandler(this.DlgContourMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_StartAnalyst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Opacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_LineInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_DisplayStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private SuperMap.UI.ColorButton colorButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_minVisibleAltitude;
        private System.Windows.Forms.TextBox tb_maxVisibleAltitude;
        private System.Windows.Forms.Button btn_StopAnalysis;
        private System.Windows.Forms.CheckBox cb_IsShowBorder;
        private System.Windows.Forms.Label label4;
        private SuperMap.UI.ColorButton colorButton_Border;

    }
}