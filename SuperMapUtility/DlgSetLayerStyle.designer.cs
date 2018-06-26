namespace LineGraph.SuperMapUtility
{
    partial class DlgSetLayerStyle
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
            this.cb_AltitudeMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_BottomAltitude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorButton = new SuperMap.UI.ColorButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "高度模式";
            // 
            // cb_AltitudeMode
            // 
            this.cb_AltitudeMode.FormattingEnabled = true;
            this.cb_AltitudeMode.Items.AddRange(new object[] {
            "贴地",
            "相对地面",
            "绝对高度",
            "相对地下",
            "依模型",
            "修改地形"});
            this.cb_AltitudeMode.Location = new System.Drawing.Point(72, 6);
            this.cb_AltitudeMode.Name = "cb_AltitudeMode";
            this.cb_AltitudeMode.Size = new System.Drawing.Size(121, 20);
            this.cb_AltitudeMode.TabIndex = 1;
            this.cb_AltitudeMode.SelectedIndexChanged += new System.EventHandler(this.cb_AltitudeMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "底部高程";
            // 
            // tb_BottomAltitude
            // 
            this.tb_BottomAltitude.Location = new System.Drawing.Point(72, 41);
            this.tb_BottomAltitude.Name = "tb_BottomAltitude";
            this.tb_BottomAltitude.Size = new System.Drawing.Size(121, 21);
            this.tb_BottomAltitude.TabIndex = 3;
            this.tb_BottomAltitude.TextChanged += new System.EventHandler(this.tb_BottomAltitude_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "前景色";
            // 
            // colorButton
            // 
            this.colorButton.AlphaEnabled = false;
            this.colorButton.Color = System.Drawing.Color.Empty;
            this.colorButton.Location = new System.Drawing.Point(72, 75);
            this.colorButton.Name = "colorButton";
            this.colorButton.ShowOtherColor = false;
            this.colorButton.Size = new System.Drawing.Size(121, 23);
            this.colorButton.TabIndex = 7;
            this.colorButton.Text = "colorButton";
            //this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.ColorChanged += new System.EventHandler(this.colorButton_ColorChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "透明度";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(73, 115);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown.TabIndex = 9;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // DlgSetLayerStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_BottomAltitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_AltitudeMode);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximumSize = new System.Drawing.Size(220, 210);
            this.MinimumSize = new System.Drawing.Size(220, 210);
            this.ClientSize = new System.Drawing.Size(220, 210);
            this.Name = "DlgSetLayerStyle";
            this.Text = "风格设置";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_AltitudeMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_BottomAltitude;
        private System.Windows.Forms.Label label3;
        private SuperMap.UI.ColorButton colorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}