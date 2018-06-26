namespace LineGraph.SuperMapUtility
{
    partial class DlgOSGBQuery
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
            this.gb_SqlQuery = new System.Windows.Forms.GroupBox();
            this.tb_QueryCondition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_BufferQuery = new System.Windows.Forms.GroupBox();
            this.tb_bufferRadius = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Query = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.gb_SqlQuery.SuspendLayout();
            this.gb_BufferQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_SqlQuery
            // 
            this.gb_SqlQuery.Controls.Add(this.tb_QueryCondition);
            this.gb_SqlQuery.Controls.Add(this.label1);
            this.gb_SqlQuery.Location = new System.Drawing.Point(17, 20);
            this.gb_SqlQuery.Name = "gb_SqlQuery";
            this.gb_SqlQuery.Size = new System.Drawing.Size(252, 119);
            this.gb_SqlQuery.TabIndex = 0;
            this.gb_SqlQuery.TabStop = false;
            this.gb_SqlQuery.Text = "SQL查询";
            // 
            // tb_QueryCondition
            // 
            this.tb_QueryCondition.Location = new System.Drawing.Point(8, 54);
            this.tb_QueryCondition.Multiline = true;
            this.tb_QueryCondition.Name = "tb_QueryCondition";
            this.tb_QueryCondition.Size = new System.Drawing.Size(236, 59);
            this.tb_QueryCondition.TabIndex = 1;
            this.tb_QueryCondition.TextChanged += new System.EventHandler(this.tb_QueryCondition_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入查询条件:";
            // 
            // gb_BufferQuery
            // 
            this.gb_BufferQuery.Controls.Add(this.tb_bufferRadius);
            this.gb_BufferQuery.Controls.Add(this.label3);
            this.gb_BufferQuery.Controls.Add(this.label2);
            this.gb_BufferQuery.Location = new System.Drawing.Point(17, 159);
            this.gb_BufferQuery.Name = "gb_BufferQuery";
            this.gb_BufferQuery.Size = new System.Drawing.Size(252, 93);
            this.gb_BufferQuery.TabIndex = 1;
            this.gb_BufferQuery.TabStop = false;
            this.gb_BufferQuery.Text = "Buffer查询";
            // 
            // tb_bufferRadius
            // 
            this.tb_bufferRadius.Location = new System.Drawing.Point(71, 62);
            this.tb_bufferRadius.Name = "tb_bufferRadius";
            this.tb_bufferRadius.Size = new System.Drawing.Size(173, 21);
            this.tb_bufferRadius.TabIndex = 2;
            this.tb_bufferRadius.TextChanged += new System.EventHandler(this.tb_bufferRadius_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "缓冲半径:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "请在场景中选择一个面对象";
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(88, 274);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 2;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(186, 274);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "清除结果";
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // DlgOSGBQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 322);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Query);
            this.Controls.Add(this.gb_BufferQuery);
            this.Controls.Add(this.gb_SqlQuery);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 360);
            this.Name = "DlgOSGBQuery";
            this.Text = "查询";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgOSGBQuery_FormClosing);
            this.Load += new System.EventHandler(this.DlgOSGBQuery_Load);
            this.gb_SqlQuery.ResumeLayout(false);
            this.gb_SqlQuery.PerformLayout();
            this.gb_BufferQuery.ResumeLayout(false);
            this.gb_BufferQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_SqlQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_QueryCondition;
        private System.Windows.Forms.GroupBox gb_BufferQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_bufferRadius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Button btn_Clear;
    }
}