namespace SuperMap.SampleCode.Realspace
{
    partial class DlgSunTrajectory
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
            this.local_Button = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeTrackBar = new System.Windows.Forms.TrackBar();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.timeZoneComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // local_Button
            // 
            this.local_Button.Location = new System.Drawing.Point(153, 206);
            this.local_Button.Name = "local_Button";
            this.local_Button.Size = new System.Drawing.Size(75, 23);
            this.local_Button.TabIndex = 16;
            this.local_Button.Text = "系统设置";
            this.local_Button.UseVisualStyleBackColor = true;
            this.local_Button.Click += new System.EventHandler(this.local_Button_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(16, 154);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(23, 12);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.Text = "0:0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "请滑动时间滑块";
            // 
            // timeTrackBar
            // 
            this.timeTrackBar.Location = new System.Drawing.Point(5, 121);
            this.timeTrackBar.Maximum = 1439;
            this.timeTrackBar.Name = "timeTrackBar";
            this.timeTrackBar.Size = new System.Drawing.Size(221, 45);
            this.timeTrackBar.TabIndex = 13;
            this.timeTrackBar.ValueChanged += new System.EventHandler(this.timeTrackBar_ValueChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(5, 76);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(223, 21);
            this.dateTimePicker.TabIndex = 12;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "请选择日期";
            // 
            // timeZoneComboBox
            // 
            this.timeZoneComboBox.FormattingEnabled = true;
            this.timeZoneComboBox.Location = new System.Drawing.Point(5, 24);
            this.timeZoneComboBox.Name = "timeZoneComboBox";
            this.timeZoneComboBox.Size = new System.Drawing.Size(223, 20);
            this.timeZoneComboBox.TabIndex = 10;
            this.timeZoneComboBox.SelectedIndexChanged += new System.EventHandler(this.timeZoneComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "请选择时区";
            // 
            // DlgSunTrajectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 235);
            this.Controls.Add(this.local_Button);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeTrackBar);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeZoneComboBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(256, 273);
            this.MinimumSize = new System.Drawing.Size(256, 273);
            this.Name = "DlgSunTrajectory";
            this.Text = "设置太阳轨迹...";
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button local_Button;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar timeTrackBar;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox timeZoneComboBox;
        private System.Windows.Forms.Label label1;
    }
}