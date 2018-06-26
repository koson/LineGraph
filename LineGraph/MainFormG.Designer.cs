using System.Drawing;
using LineGraph.GUI;
using SuperMap.Data;
using SuperMap.Realspace;
using System.Collections.Generic;

namespace LineGraph
{
    partial class MainFormG
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();

            WndHeader = new WndHeaderG();
            WndMenuList = new WndMenuList();
            m_WorkSpaceCtrl = new SuperMapUtility.WorkSpaceManageWnd();
            m_SceneControlWnd = new SuperMapUtility.SceneControlWnd(m_WorkSpaceCtrl.m_workspace, m_WorkSpaceCtrl.m_SceneControl);
            m_MapControlWnd = new SuperMapUtility.MapControlWnd(m_WorkSpaceCtrl.m_workspace, m_WorkSpaceCtrl.m_MapControl);

            //m_DataCaptureWnd = DataReceiver.DataCaptureWnd.Create();
            m_DataCaptureWnd = new DataReceiver.DTUFrmMain();

            m_DataAnalyzeWnd = new SQLUtility.DataAnalyzeWnd();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.SuspendLayout();

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
            WndHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Panel1.Controls.Add(this.WndHeader);
            // 
            // splitContainerTop.Panel2
            // 
            WndMenuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Panel2.Controls.Add(this.WndMenuList);
            this.splitContainerTop.Size = new System.Drawing.Size(1440, 60);
            this.splitContainerTop.SplitterDistance = 60;
            this.splitContainerTop.IsSplitterFixed = true;
            this.splitContainerTop.TabIndex = 0;

            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainerTop);
            // 
            // splitContainer.Panel2
            // 
            this.m_SceneControlWnd.BackColor = System.Drawing.Color.White;
            this.m_SceneControlWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_SceneControlWnd.Location = new System.Drawing.Point(3, 3);
            this.m_SceneControlWnd.Margin = new System.Windows.Forms.Padding(0);
            this.m_SceneControlWnd.Name = "m_SceneControlWnd";
            this.m_SceneControlWnd.Size = new System.Drawing.Size(720, 900);
            this.m_SceneControlWnd.TabIndex = 0;

            // 
            // m_DataCaptureWnd.m_DataReceiverWnd
            // 
            this.m_DataCaptureWnd.m_DataReceiverWnd.AutoScroll = true;
            this.m_DataCaptureWnd.m_DataReceiverWnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_DataCaptureWnd.m_DataReceiverWnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_DataCaptureWnd.m_DataReceiverWnd.Location = new System.Drawing.Point(0, 0);
            this.m_DataCaptureWnd.m_DataReceiverWnd.Name = "flowLayoutPanelMarker";
            this.m_DataCaptureWnd.m_DataReceiverWnd.Size = new System.Drawing.Size(720, 900);
            this.m_DataCaptureWnd.m_DataReceiverWnd.TabIndex = 1;

            // 
            // m_MapControlWnd
            // 
            this.m_MapControlWnd.AutoScroll = true;
            this.m_MapControlWnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_MapControlWnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_MapControlWnd.Location = new System.Drawing.Point(0, 0);
            this.m_MapControlWnd.Name = "m_MapControlWnd";
            this.m_MapControlWnd.Size = new System.Drawing.Size(720, 900);
            this.m_MapControlWnd.TabIndex = 2;

            // 
            // m_DataAnalyzeWnd
            // 
            this.m_DataAnalyzeWnd.AutoScroll = true;
            this.m_DataAnalyzeWnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_DataAnalyzeWnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_DataAnalyzeWnd.Location = new System.Drawing.Point(0, 0);
            this.m_DataAnalyzeWnd.Name = "m_DataAnalyzeWnd";
            this.m_DataAnalyzeWnd.Size = new System.Drawing.Size(720, 900);
            this.m_DataAnalyzeWnd.TabIndex = 3;

            this.splitContainer.Panel2.Controls.Add(this.m_SceneControlWnd);
            this.splitContainer.Size = new System.Drawing.Size(1440, 900);
            this.splitContainer.SplitterDistance = 120;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.TabIndex = 0;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "综合在线监测与预警系统";
            //Bitmap bitmap = new Bitmap(Properties.Resources.logo);
            //System.IntPtr iconHandle = bitmap.GetHicon();
            //this.Icon = Icon.FromHandle(iconHandle);
            this.Icon = Properties.Resources.LOGO_Earth;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);

            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
            this.splitContainerTop.ResumeLayout(false);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitContainerTop;

        private LineGraph.GUI.WndHeaderG WndHeader;
        private LineGraph.GUI.WndMenuList WndMenuList;
        private LineGraph.SuperMapUtility.SceneControlWnd m_SceneControlWnd;
        private LineGraph.SuperMapUtility.MapControlWnd m_MapControlWnd;

        private LineGraph.SuperMapUtility.WorkSpaceManageWnd m_WorkSpaceCtrl;

        //private LineGraph.DataReceiver.DataCaptureWnd m_DataCaptureWnd;

        private LineGraph.DataReceiver.DTUFrmMain m_DataCaptureWnd = null;

        private LineGraph.SQLUtility.DataAnalyzeWnd m_DataAnalyzeWnd;
    }
}