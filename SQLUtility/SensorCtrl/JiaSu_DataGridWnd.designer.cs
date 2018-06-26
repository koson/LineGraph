namespace LineGraph.SQLUtility
{
    partial class JiaSu_DataGridWnd 
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
            this.加速计listResult = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader71 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader72 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader73 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader81 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader82 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader83 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.加速计listResult.SuspendLayout();
            this.SuspendLayout();

            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "";
            this.columnHeader31.Width = 22;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "设备ID";
            this.columnHeader32.Width = 100;

            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "点号";
            this.columnHeader34.Width = 60;

            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "接收时间";
            this.columnHeader33.Width = 155;


            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "加速度_X测试值";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "加速度_X初始值";
            this.columnHeader61.Width = 120;

            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "加速度_X单次变化量";
            this.columnHeader62.Width = 120;

            // 
            // columnHeader63
            // 
            this.columnHeader63.Text = "加速度_X累计变化量";
            this.columnHeader63.Width = 120;


            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "加速度_Y测试值";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader71
            // 
            this.columnHeader71.Text = "加速度_Y初始值";
            this.columnHeader71.Width = 120;

            // 
            // columnHeader72
            // 
            this.columnHeader72.Text = "加速度_Y单次变化量";
            this.columnHeader72.Width = 120;

            // 
            // columnHeader73
            // 
            this.columnHeader73.Text = "加速度_Y累计变化量";
            this.columnHeader73.Width = 120;


            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "加速度_Z测试值";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader81
            // 
            this.columnHeader81.Text = "加速度_Z初始值";
            this.columnHeader81.Width = 120;

            // 
            // columnHeader82
            // 
            this.columnHeader82.Text = "加速度_Z单次变化量";
            this.columnHeader82.Width = 120;

            // 
            // columnHeader83
            // 
            this.columnHeader83.Text = "加速度_Z累计变化量";
            this.columnHeader83.Width = 120;


            this.加速计listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31,
            //this.columnHeader32,
            this.columnHeader34,

             this.columnHeader61,
             this.columnHeader71,
             this.columnHeader81,

            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,

            this.columnHeader62,
            this.columnHeader72,
            this.columnHeader82,

            this.columnHeader63,
            this.columnHeader73,
            this.columnHeader83,
            this.columnHeader33});
            this.加速计listResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.加速计listResult.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.加速计listResult.FullRowSelect = true;
            this.加速计listResult.GridLines = true;
            this.加速计listResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.加速计listResult.Location = new System.Drawing.Point(0, 0);
            this.加速计listResult.Name = "加速计listResult";
            this.加速计listResult.Size = new System.Drawing.Size(575, 399);
            this.加速计listResult.TabIndex = 0;
            this.加速计listResult.UseCompatibleStateImageBehavior = false;
            this.加速计listResult.View = System.Windows.Forms.View.Details;
            this.加速计listResult.Scrollable = true;


            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 399);
            this.Controls.Add(this.加速计listResult);
            this.Text = "DataGridWnd";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AutoScroll = true;
            this.加速计listResult.ResumeLayout(false);
            this.加速计listResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader61;
        private System.Windows.Forms.ColumnHeader columnHeader62;
        private System.Windows.Forms.ColumnHeader columnHeader63;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader71;
        private System.Windows.Forms.ColumnHeader columnHeader72;
        private System.Windows.Forms.ColumnHeader columnHeader73;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader81;
        private System.Windows.Forms.ColumnHeader columnHeader82;
        private System.Windows.Forms.ColumnHeader columnHeader83;

        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;

        private System.Windows.Forms.ListView 加速计listResult;

    }
}