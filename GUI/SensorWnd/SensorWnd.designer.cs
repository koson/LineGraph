
namespace LineGraph.GUI
{
    partial class SensorWnd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FlowPanel = new FlowPanel();
            this.SuspendLayout();
            // 
            // myFlowPanel1
            // 
            this.FlowPanel.BackColor = System.Drawing.Color.DarkGray;
            this.FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FlowPanel.FormHeigth = 400;
            this.FlowPanel.Location = new System.Drawing.Point(0, 0);
            this.FlowPanel.Name = "myFlowPanel1";
            this.FlowPanel.RowFormCount = 2;
            this.FlowPanel.Size = new System.Drawing.Size(1000, 800);
            this.FlowPanel.TabIndex = 0;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.FlowPanel);
            this.Name = "SensorWnd";
            this.Text = "传感监测";
            this.Load += new System.EventHandler(this.main_form_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_form_Close);
            this.ResumeLayout(false);
        }

        #endregion

        private LineGraph.GUI.FlowPanel FlowPanel;
    }
}

