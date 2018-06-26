namespace LineGraph.SQLUtility
{
    partial class ShuiZhun_DataGridWnd 
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
            this.水准仪listResult = new System.Windows.Forms.ListView();
     
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            //this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            //this.columnHeader91 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            //this.columnHeader92 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            //this.columnHeader93 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader101 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader102 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader103 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
 
            this.水准仪listResult.SuspendLayout();

            this.SuspendLayout();

            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 22;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "设备ID";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "点号";
            this.columnHeader21.Width = 60;

            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "接收时间";
            this.columnHeader11.Width = 155;

            //// 
            //// columnHeader9
            //// 
            //this.columnHeader9.Text = "振动测试值";
            //this.columnHeader9.Width = 120;
            //// 
            //// columnHeader91
            //// 
            //this.columnHeader91.Text = "振动初始值";
            //this.columnHeader91.Width = 120;

            //// 
            //// columnHeader92
            //// 
            //this.columnHeader92.Text = "振动单次变化量";
            //this.columnHeader92.Width = 120;

            //// 
            //// columnHeader93
            //// 
            //this.columnHeader93.Text = "振动累计变化量";
            //this.columnHeader93.Width = 120;

            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "沉降测试值";
            this.columnHeader10.Width = 120;

            // 
            // columnHeader101
            // 
            this.columnHeader101.Text = "沉降初始值";
            this.columnHeader101.Width = 120;

            // 
            // columnHeader102
            // 
            this.columnHeader102.Text = "沉降单次变化量";
            this.columnHeader102.Width = 120;

            // 
            // columnHeader103
            // 
            this.columnHeader103.Text = "沉降累计变化量";
            this.columnHeader103.Width = 120;

            // 
            // listResult
            // 
            this.水准仪listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            //this.columnHeader2,
            this.columnHeader21,

            //this.columnHeader91,
            this.columnHeader101,

            //this.columnHeader9,
            this.columnHeader10,

            //this.columnHeader92,
            this.columnHeader102,

            //this.columnHeader93,
            this.columnHeader103,
            this.columnHeader11});
            this.水准仪listResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.水准仪listResult.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.水准仪listResult.FullRowSelect = true;
            this.水准仪listResult.GridLines = true;
            this.水准仪listResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.水准仪listResult.Location = new System.Drawing.Point(0, 0);
            this.水准仪listResult.Name = "水准仪listResult";
            this.水准仪listResult.Size = new System.Drawing.Size(575, 399);
            this.水准仪listResult.TabIndex = 0;
            this.水准仪listResult.UseCompatibleStateImageBehavior = false;
            this.水准仪listResult.View = System.Windows.Forms.View.Details;
            this.水准仪listResult.Scrollable = true;

            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 399);
            this.Controls.Add(this.水准仪listResult);
            this.Text = "DataGridWnd";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AutoScroll = true;
            this.水准仪listResult.ResumeLayout(false);
            this.水准仪listResult.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        //private System.Windows.Forms.ColumnHeader columnHeader9;
        //private System.Windows.Forms.ColumnHeader columnHeader91;
        //private System.Windows.Forms.ColumnHeader columnHeader92;
        //private System.Windows.Forms.ColumnHeader columnHeader93;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader101;
        private System.Windows.Forms.ColumnHeader columnHeader102;
        private System.Windows.Forms.ColumnHeader columnHeader103;
        private System.Windows.Forms.ColumnHeader columnHeader11;

        private System.Windows.Forms.ListView 水准仪listResult;
     
    }
}