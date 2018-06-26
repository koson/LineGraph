namespace LineGraph.SuperMapUtility
{
    partial class DlgNodeAnimation
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
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Model = new System.Windows.Forms.ComboBox();
            this.btn_DrawTrack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Length = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_AddToKML = new System.Windows.Forms.Button();
            this.cb_IsSaveTrack = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label_TimePosition = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_Track = new System.Windows.Forms.ComboBox();
            this.tb_LayerKml = new System.Windows.Forms.TextBox();
            this.cb_PlayMode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "KML图层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "模型";
            // 
            // cb_Model
            // 
            this.cb_Model.FormattingEnabled = true;
            this.cb_Model.Location = new System.Drawing.Point(74, 40);
            this.cb_Model.Name = "cb_Model";
            this.cb_Model.Size = new System.Drawing.Size(168, 20);
            this.cb_Model.TabIndex = 3;
            this.cb_Model.SelectedIndexChanged += new System.EventHandler(this.cb_Model_SelectedIndexChanged);
            // 
            // btn_DrawTrack
            // 
            this.btn_DrawTrack.Location = new System.Drawing.Point(54, 108);
            this.btn_DrawTrack.Name = "btn_DrawTrack";
            this.btn_DrawTrack.Size = new System.Drawing.Size(154, 23);
            this.btn_DrawTrack.TabIndex = 4;
            this.btn_DrawTrack.Text = "绘制运动轨迹";
            this.btn_DrawTrack.UseVisualStyleBackColor = true;
            this.btn_DrawTrack.Click += new System.EventHandler(this.btn_DrawTrack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "运动时长";
            // 
            // tb_Length
            // 
            this.tb_Length.Location = new System.Drawing.Point(74, 169);
            this.tb_Length.Name = "tb_Length";
            this.tb_Length.Size = new System.Drawing.Size(104, 21);
            this.tb_Length.TabIndex = 6;
            this.tb_Length.Text = "8.0";
            this.tb_Length.TextChanged += new System.EventHandler(this.tb_Length_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "s";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(27, 276);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(83, 23);
            this.btn_Start.TabIndex = 9;
            this.btn_Start.Text = "开始运动";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(138, 276);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(88, 23);
            this.btn_Stop.TabIndex = 11;
            this.btn_Stop.Text = "停止运动";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_AddToKML
            // 
            this.btn_AddToKML.Location = new System.Drawing.Point(27, 321);
            this.btn_AddToKML.Name = "btn_AddToKML";
            this.btn_AddToKML.Size = new System.Drawing.Size(199, 23);
            this.btn_AddToKML.TabIndex = 12;
            this.btn_AddToKML.Text = "将绘制的运动轨迹添加到KML图层";
            this.btn_AddToKML.UseVisualStyleBackColor = true;
            this.btn_AddToKML.Click += new System.EventHandler(this.btn_AddToKML_Click);
            // 
            // cb_IsSaveTrack
            // 
            this.cb_IsSaveTrack.AutoSize = true;
            this.cb_IsSaveTrack.Checked = true;
            this.cb_IsSaveTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsSaveTrack.Location = new System.Drawing.Point(14, 137);
            this.cb_IsSaveTrack.Name = "cb_IsSaveTrack";
            this.cb_IsSaveTrack.Size = new System.Drawing.Size(138, 16);
            this.cb_IsSaveTrack.TabIndex = 13;
            this.cb_IsSaveTrack.Text = "将运动轨迹保存到KML";
            this.cb_IsSaveTrack.UseVisualStyleBackColor = true;
            this.cb_IsSaveTrack.CheckedChanged += new System.EventHandler(this.cb_IsSaveTrack_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "获取动画的时间位置";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(138, 196);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(104, 45);
            this.trackBar.TabIndex = 15;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // label_TimePosition
            // 
            this.label_TimePosition.AutoSize = true;
            this.label_TimePosition.Location = new System.Drawing.Point(150, 229);
            this.label_TimePosition.Name = "label_TimePosition";
            this.label_TimePosition.Size = new System.Drawing.Size(11, 12);
            this.label_TimePosition.TabIndex = 16;
            this.label_TimePosition.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "运动轨迹";
            // 
            // cb_Track
            // 
            this.cb_Track.FormattingEnabled = true;
            this.cb_Track.Location = new System.Drawing.Point(74, 73);
            this.cb_Track.Name = "cb_Track";
            this.cb_Track.Size = new System.Drawing.Size(165, 20);
            this.cb_Track.TabIndex = 18;
            this.cb_Track.SelectedIndexChanged += new System.EventHandler(this.cb_Track_SelectedIndexChanged);
            // 
            // tb_LayerKml
            // 
            this.tb_LayerKml.Enabled = false;
            this.tb_LayerKml.Location = new System.Drawing.Point(74, 10);
            this.tb_LayerKml.Name = "tb_LayerKml";
            this.tb_LayerKml.Size = new System.Drawing.Size(165, 21);
            this.tb_LayerKml.TabIndex = 19;
            // 
            // cb_PlayMode
            // 
            this.cb_PlayMode.AutoSize = true;
            this.cb_PlayMode.Location = new System.Drawing.Point(14, 242);
            this.cb_PlayMode.Name = "cb_PlayMode";
            this.cb_PlayMode.Size = new System.Drawing.Size(96, 16);
            this.cb_PlayMode.TabIndex = 8;
            this.cb_PlayMode.Text = "是否循环运动";
            this.cb_PlayMode.UseVisualStyleBackColor = true;
            this.cb_PlayMode.CheckedChanged += new System.EventHandler(this.cb_PlayMode_CheckedChanged);
            // 
            // DlgNodeAnimation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 356);
            this.Controls.Add(this.tb_LayerKml);
            this.Controls.Add(this.cb_Track);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_TimePosition);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_IsSaveTrack);
            this.Controls.Add(this.btn_AddToKML);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.cb_PlayMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Length);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_DrawTrack);
            this.Controls.Add(this.cb_Model);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(270, 400);
            this.MinimumSize = new System.Drawing.Size(270, 260);
            this.Name = "DlgNodeAnimation";
            this.Text = "节点动画";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgNodeAnimation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Model;
        private System.Windows.Forms.Button btn_DrawTrack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_AddToKML;
        private System.Windows.Forms.CheckBox cb_IsSaveTrack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label_TimePosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_Track;
        private System.Windows.Forms.TextBox tb_LayerKml;
        private System.Windows.Forms.CheckBox cb_PlayMode;
    }
}