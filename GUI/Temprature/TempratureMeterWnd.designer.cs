namespace LineGraph.GUI
{
    partial class TempratureMeterWnd
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
            this.termometer1 = new Thermometer();
            this.termometer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // termometer1
            // 
            this.termometer1.BackColor = System.Drawing.Color.White;
            this.termometer1.BarsBetweenNumbers = 10;
            this.termometer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.termometer1.Font = new System.Drawing.Font("Calibri", 8F);
            this.termometer1.Interval = 20F;
            this.termometer1.Location = new System.Drawing.Point(3, 3);
            this.termometer1.Max = 80F;
            this.termometer1.Min = -30F;
            this.termometer1.Name = "termometer1";
            this.termometer1.Size = new System.Drawing.Size(390, 373);
            this.termometer1.StartAngle = 180;
            this.termometer1.StoredMax = 0F;
            this.termometer1.TabIndex = 1;
            this.termometer1.Text = "termometer1";
            this.termometer1.TextUnit = "´«¸ÐÎÂ¶È";
            this.termometer1.Value = 0F;
            this.termometer1.MinChanged += new System.EventHandler(this.termometer1_PropertyChanged);
            this.termometer1.MaxChanged += new System.EventHandler(this.termometer1_PropertyChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 401);
            this.Controls.Add(this.termometer1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            //this.ShowIcon = false;
            this.Text = "Thermometer Control";
            this.termometer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Thermometer termometer1;
    }
}

