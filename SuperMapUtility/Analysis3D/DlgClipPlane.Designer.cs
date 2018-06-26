namespace SuperMap.SampleCode.Realspace
{
    partial class DlgClipPlane
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
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.cb_layers = new System.Windows.Forms.ComboBox();
            this.lab_layers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(154, 53);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 7;
            this.btn_clear.Text = "清除分析";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(26, 53);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 6;
            this.btn_start.Text = "定义裁剪面";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cb_layers
            // 
            this.cb_layers.FormattingEnabled = true;
            this.cb_layers.Location = new System.Drawing.Point(107, 5);
            this.cb_layers.Name = "cb_layers";
            this.cb_layers.Size = new System.Drawing.Size(165, 20);
            this.cb_layers.TabIndex = 5;
            this.cb_layers.SelectedIndexChanged += new System.EventHandler(this.cb_layers_SelectedIndexChanged);
            // 
            // lab_layers
            // 
            this.lab_layers.AutoSize = true;
            this.lab_layers.Location = new System.Drawing.Point(12, 8);
            this.lab_layers.Name = "lab_layers";
            this.lab_layers.Size = new System.Drawing.Size(89, 12);
            this.lab_layers.TabIndex = 4;
            this.lab_layers.Text = "选择分析图层：";
            // 
            // DlgClipPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 93);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.cb_layers);
            this.Controls.Add(this.lab_layers);
            this.Name = "DlgClipPlane";
            this.Text = "裁剪面分析";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DlgClipPlane_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox cb_layers;
        private System.Windows.Forms.Label lab_layers;
    }
}