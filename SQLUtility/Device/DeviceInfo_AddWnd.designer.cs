namespace LineGraph.SQLUtility
{
    partial class DeviceInfo_AddWnd
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.yTextBox_XH = new System.Windows.Forms.TextBox();
            this.yTextBox_REASON = new System.Windows.Forms.TextBox();
            this.cboDeviceStyle = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ytDateTime_MakeTime = new System.Windows.Forms.DateTimePicker();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yTextBox_BH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProtocolStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboProtocolNO = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(405, 260);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(74, 39);
            this.btn_Cancel.TabIndex = 27;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(276, 260);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(74, 39);
            this.btn_Save.TabIndex = 26;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // yTextBox_XH
            // 
            this.yTextBox_XH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yTextBox_XH.Location = new System.Drawing.Point(574, 28);
            this.yTextBox_XH.Name = "yTextBox_XH";
            this.yTextBox_XH.Size = new System.Drawing.Size(201, 21);
            this.yTextBox_XH.TabIndex = 7;
            // 
            // yTextBox_REASON
            // 
            this.yTextBox_REASON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yTextBox_REASON.Location = new System.Drawing.Point(50, 142);
            this.yTextBox_REASON.Multiline = true;
            this.yTextBox_REASON.Name = "yTextBox_REASON";
            this.yTextBox_REASON.Size = new System.Drawing.Size(725, 83);
            this.yTextBox_REASON.TabIndex = 19;
            // 
            // cboDeviceStyle
            // 
            this.cboDeviceStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceStyle.FormattingEnabled = true;
            this.cboDeviceStyle.Location = new System.Drawing.Point(50, 25);
            this.cboDeviceStyle.Name = "cboDeviceStyle";
            this.cboDeviceStyle.Size = new System.Drawing.Size(183, 20);
            this.cboDeviceStyle.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(15, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(569, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "制定日期";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(239, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 10;
            this.label24.Text = "单位名称";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Blue;
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(22, 126);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 18;
            this.label30.Text = "信息描述";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(540, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "型号";
            // 
            // ytDateTime_MakeTime
            // 
            this.ytDateTime_MakeTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.ytDateTime_MakeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ytDateTime_MakeTime.Location = new System.Drawing.Point(628, 251);
            this.ytDateTime_MakeTime.Name = "ytDateTime_MakeTime";
            this.ytDateTime_MakeTime.Size = new System.Drawing.Size(145, 21);
            this.ytDateTime_MakeTime.TabIndex = 25;
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(298, 27);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(232, 20);
            this.cboCompany.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(515, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "设备编号";
            // 
            // yTextBox_BH
            // 
            this.yTextBox_BH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yTextBox_BH.Location = new System.Drawing.Point(574, 81);
            this.yTextBox_BH.Name = "yTextBox_BH";
            this.yTextBox_BH.Size = new System.Drawing.Size(201, 21);
            this.yTextBox_BH.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "协议类型";
            // 
            // cboProtocolStyle
            // 
            this.cboProtocolStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocolStyle.FormattingEnabled = true;
            this.cboProtocolStyle.Location = new System.Drawing.Point(77, 79);
            this.cboProtocolStyle.Name = "cboProtocolStyle";
            this.cboProtocolStyle.Size = new System.Drawing.Size(183, 20);
            this.cboProtocolStyle.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(265, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "通讯协议";
            // 
            // cboProtocolNO
            // 
            this.cboProtocolNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtocolNO.FormattingEnabled = true;
            this.cboProtocolNO.Location = new System.Drawing.Point(325, 80);
            this.cboProtocolNO.Name = "cboProtocolNO";
            this.cboProtocolNO.Size = new System.Drawing.Size(183, 20);
            this.cboProtocolNO.TabIndex = 33;
            // 
            // DeviceInfo_AddWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 311);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboProtocolNO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProtocolStyle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yTextBox_BH);
            this.Controls.Add(this.ytDateTime_MakeTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.yTextBox_XH);
            this.Controls.Add(this.cboDeviceStyle);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.yTextBox_REASON);
            this.Name = "DeviceInfo_AddWnd";
            this.Text = "设备信息";
            this.Load += new System.EventHandler(this.WZDict_Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox yTextBox_XH;
        private System.Windows.Forms.TextBox yTextBox_REASON;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.ComboBox cboDeviceStyle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker ytDateTime_MakeTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yTextBox_BH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProtocolStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboProtocolNO;
    }
}