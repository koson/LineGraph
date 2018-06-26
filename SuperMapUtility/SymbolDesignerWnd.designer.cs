using SuperMap.Data;
using SuperMap.Realspace;

namespace LineGraph.SuperMapUtility
{
    partial class SymbolDesignerWnd
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
            this.m_buttonClearRegion3D = new System.Windows.Forms.Button();
            this.m_buttonClearPoint3D = new System.Windows.Forms.Button();
            m_SymbolResourceWnd = new SymbolResourceWnd(m_workspace);
            splitContainerTop = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.SuspendLayout();
      
            // 
            // m_buttonClearRegion3D
            // 
            this.m_buttonClearRegion3D.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_buttonClearRegion3D.Enabled = false;
            this.m_buttonClearRegion3D.Location = new System.Drawing.Point(0, 0);
            this.m_buttonClearRegion3D.Name = "m_buttonClearRegion3D";
            this.m_buttonClearRegion3D.Size = new System.Drawing.Size(112, 23);
            this.m_buttonClearRegion3D.TabIndex = 0;
            this.m_buttonClearRegion3D.Text = "清除面操作";
            this.m_buttonClearRegion3D.UseVisualStyleBackColor = false;
            this.m_buttonClearRegion3D.Click += new System.EventHandler(this.m_buttonClearRegion3D_Click);
            // 
            // m_buttonClearPoint3D
            // 
            this.m_buttonClearPoint3D.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_buttonClearPoint3D.Enabled = false;
            this.m_buttonClearPoint3D.Location = new System.Drawing.Point(150, 0);
            this.m_buttonClearPoint3D.Name = "m_buttonClearPoint3D";
            this.m_buttonClearPoint3D.Size = new System.Drawing.Size(112, 23);
            this.m_buttonClearPoint3D.TabIndex = 0;
            this.m_buttonClearPoint3D.Text = "清除点操作";
            this.m_buttonClearPoint3D.UseVisualStyleBackColor = false;
            this.m_buttonClearPoint3D.Click += new System.EventHandler(this.m_ButtonClearPoint_Click);
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            this.splitContainerTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTop.Panel1
            // 
            this.m_SymbolResourceWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Panel1.Controls.Add(this.m_SymbolResourceWnd);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.m_buttonClearPoint3D);
            this.splitContainerTop.Panel2.Controls.Add(this.m_buttonClearRegion3D);
            this.splitContainerTop.Size = new System.Drawing.Size(1000, 730);
            this.splitContainerTop.SplitterDistance = 700;
            this.splitContainerTop.TabIndex = 1;

            // 
            // SymbolDesignerWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 730);
            this.Controls.Add(this.splitContainerTop);
            this.Name = "SymbolDesignerWnd";
            this.Text = "三维规划";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_Closing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
            this.splitContainerTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonClearPoint3D;
        private System.Windows.Forms.Button m_buttonClearRegion3D;
        private SymbolResourceWnd m_SymbolResourceWnd;
        private System.Windows.Forms.SplitContainer splitContainerTop;

        private Workspace m_workspace;
    }
}



