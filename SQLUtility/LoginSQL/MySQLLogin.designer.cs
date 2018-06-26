namespace LineGraph.SQLUtility
{
    partial class MySQLLogin
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
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userIdTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.userIdTextBox.Location = new System.Drawing.Point(12, 9);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(200, 26);
            this.userIdTextBox.TabIndex = 3;
            this.userIdTextBox.Text = "User Id";
            this.userIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userIdTextBox.Click += new System.EventHandler(this.OnClick_RemoveText);
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectButton.Location = new System.Drawing.Point(630, 9);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(93, 24);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "CONNECT";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.passwordTextBox.Location = new System.Drawing.Point(218, 9);
            this.passwordTextBox.MaxLength = 35;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(200, 26);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Click += new System.EventHandler(this.OnClick_RemoveText);
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDatabase.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F);
            this.textBoxDatabase.Location = new System.Drawing.Point(424, 9);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(200, 26);
            this.textBoxDatabase.TabIndex = 8;
            this.textBoxDatabase.Text = "Database";
            this.textBoxDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDatabase.Click += new System.EventHandler(this.OnClick_RemoveText);
            // 
            // MySQLLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(735, 44);
            this.Controls.Add(this.textBoxDatabase);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userIdTextBox);
            this.Name = "MySQLLogin";
            this.Text = "数据库登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox textBoxDatabase;
    }
}