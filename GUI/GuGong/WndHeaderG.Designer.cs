namespace LineGraph.GUI
{
    partial class WndHeaderG
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
            this.pictureBoxGuGong = new System.Windows.Forms.PictureBox();
            this.pictureBoxPrjName = new System.Windows.Forms.PictureBox();
            this.pictureBoxCQiang = new System.Windows.Forms.PictureBox();
            this.pictureBoxZi = new System.Windows.Forms.PictureBox();
            this.pictureBoxBG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuGong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrjName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCQiang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZi)).BeginInit();
            this.SuspendLayout();


            // 
            // pictureBoxBG
            // 
            this.pictureBoxBG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBG.Image = global::LineGraph.GUI.Properties.Resources.backgroundG;
            this.pictureBoxBG.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBG.Name = "pictureBoxBG";
            this.pictureBoxBG.Size = new System.Drawing.Size(1440, 60);
            this.pictureBoxBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBG.TabIndex = 0;
            this.pictureBoxBG.TabStop = false;


            // 
            // pictureBoxGuGong
            // 
            this.pictureBoxGuGong.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGuGong.Image = global::LineGraph.GUI.Properties.Resources.gugong;
            this.pictureBoxGuGong.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGuGong.Name = "pictureBoxGuGong";
            this.pictureBoxGuGong.Size = new System.Drawing.Size(200, 50);
            this.pictureBoxGuGong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGuGong.TabIndex = 1;
            this.pictureBoxGuGong.TabStop = false;


            // 
            // pictureBoxPrjName
            // 
            this.pictureBoxPrjName.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPrjName.Image = global::LineGraph.GUI.Properties.Resources.projectname;
            this.pictureBoxPrjName.Location = new System.Drawing.Point(214, 0);
            this.pictureBoxPrjName.Name = "pictureBoxPrjName";
            this.pictureBoxPrjName.Size = new System.Drawing.Size(610, 61);
            this.pictureBoxPrjName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPrjName.TabIndex = 2;
            this.pictureBoxPrjName.TabStop = false;

            // 
            // pictureBoxCQiang
            // 
            this.pictureBoxCQiang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCQiang.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCQiang.Image = global::LineGraph.GUI.Properties.Resources.chengqiang;
            this.pictureBoxCQiang.Location = new System.Drawing.Point(0, 50);
            this.pictureBoxCQiang.Name = "pictureBoxCQiang";
            this.pictureBoxCQiang.Size = new System.Drawing.Size(1440, 10);
            this.pictureBoxCQiang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCQiang.TabIndex = 3;
            this.pictureBoxCQiang.TabStop = false;

     
            // 
            // pictureBoxZi
            // 
            this.pictureBoxZi.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxZi.Image = global::LineGraph.GUI.Properties.Resources.ziti1;
            this.pictureBoxZi.Location = new System.Drawing.Point(830, 0);
            this.pictureBoxZi.Name = "pictureBoxZi";
            this.pictureBoxZi.Size = new System.Drawing.Size(610, 50);
            this.pictureBoxZi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxZi.TabIndex = 4;
            this.pictureBoxZi.TabStop = false;

            // 
            // WndHeaderG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxBG);
            this.Controls.Add(this.pictureBoxGuGong);
            this.Controls.Add(this.pictureBoxPrjName);
            this.Controls.Add(this.pictureBoxCQiang);
            this.Controls.Add(this.pictureBoxZi);
            this.Name = "WndHeaderG";
            this.Size = new System.Drawing.Size(1440, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuGong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrjName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCQiang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBG;
        private System.Windows.Forms.PictureBox pictureBoxGuGong;
        private System.Windows.Forms.PictureBox pictureBoxPrjName;
        private System.Windows.Forms.PictureBox pictureBoxCQiang;
        private System.Windows.Forms.PictureBox pictureBoxZi;
    }
}