﻿namespace LineGraph.GUI
{
    partial class WndHeader
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
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            //this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            //this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1440, 60);
            this.panelTop.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::LineGraph.GUI.Properties.Resources.background;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1440, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            //// 
            //// pictureBox2
            //// 
            //this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            //this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            //this.pictureBox2.Image = global::LineGraph.GUI.Properties.Resources.chengqiang;
            //this.pictureBox2.Location = new System.Drawing.Point(0, 40);
            //this.pictureBox2.Name = "pictureBox2";
            //this.pictureBox2.Size = new System.Drawing.Size(1440, 20);
            //this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //this.pictureBox2.TabIndex = 1;
            //this.pictureBox2.TabStop = false;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 60);
            this.Text = "WndHeader";
            this.Controls.Add(this.panelTop);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        //private System.Windows.Forms.PictureBox pictureBox2;
    }
}