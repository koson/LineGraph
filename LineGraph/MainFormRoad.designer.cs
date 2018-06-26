using System.Drawing;
using LineGraph.GUI;
using SuperMap.Data;
using SuperMap.Realspace;
using System.Collections.Generic;

namespace LineGraph
{
    partial class MainFormRoad
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
            this.splitContainerDataView = new System.Windows.Forms.SplitContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.splitContainerMidlle = new System.Windows.Forms.SplitContainer();

            //m_workspace = new SuperMap.Data.Workspace(this.components);
            //m_connectionInfo = new WorkspaceConnectionInfo();
            WndHeader = new WndHeaderRoad();
            WndMenuList = new WndMenuListRoad();
            m_WorkSpaceCtrl = new SuperMapUtility.WorkSpaceManageWnd();
            m_SceneControlWnd = new SuperMapUtility.SceneControlWnd(m_WorkSpaceCtrl.m_workspace, m_WorkSpaceCtrl.m_SceneControl);
            m_MapControlWnd = new SuperMapUtility.MapControlWnd(m_WorkSpaceCtrl.m_workspace,m_WorkSpaceCtrl.m_MapControl);
            

            m_DataCaptureWnd = DataReceiver.DataCaptureWnd.Create();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMidlle)).BeginInit();
            this.splitContainerMidlle.Panel1.SuspendLayout();
            this.splitContainerMidlle.Panel2.SuspendLayout();
            this.splitContainerMidlle.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDataView)).BeginInit();
            this.splitContainerDataView.Panel1.SuspendLayout();
            this.splitContainerDataView.Panel2.SuspendLayout();
            this.splitContainerDataView.SuspendLayout();

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
            // splitContainerMiddle
            // 
            this.splitContainerMidlle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMidlle.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMidlle.Name = "splitContainerMiddle";
            // 
            // splitContainerMiddle.Panel1
            // 
            this.splitContainerMidlle.Panel1.Controls.Add(this.splitContainerDataView);
            // 
            // splitContainerMiddle.Panel2
            // 
            this.m_DataCaptureWnd.m_DataReceiverWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMidlle.Panel2.Controls.Add(this.m_DataCaptureWnd.m_DataReceiverWnd);
            this.splitContainerMidlle.Size = new System.Drawing.Size(1440, 780);
            this.splitContainerMidlle.SplitterDistance = 720;
            this.splitContainerMidlle.TabIndex = 0;

            // 
            // splitContainerDataView
            // 
            this.splitContainerDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDataView.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDataView.Name = "splitContainerDataView";
            this.splitContainerDataView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDataView.Panel1
            // 
            m_SceneControlWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDataView.Panel1.Controls.Add(this.m_SceneControlWnd);
            // 
            // splitContainerDataView.Panel2
            // 
            m_MapControlWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDataView.Panel2.Controls.Add(this.m_MapControlWnd);
            this.splitContainerDataView.Size = new System.Drawing.Size(720, 780);
            this.splitContainerDataView.SplitterDistance = 390;
            this.splitContainerDataView.TabIndex = 0;
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
            this.splitContainer.Panel2.Controls.Add(this.splitContainerMidlle);
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
            this.Text = "基础设施实景三维综合管理平台";
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

            this.splitContainerMidlle.Panel1.ResumeLayout(false);
            this.splitContainerMidlle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMidlle)).EndInit();
            this.splitContainerMidlle.ResumeLayout(false);

            this.splitContainerDataView.Panel1.ResumeLayout(false);
            this.splitContainerDataView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDataView)).EndInit();
            this.splitContainerDataView.ResumeLayout(false);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.SplitContainer splitContainerMidlle;
        private System.Windows.Forms.SplitContainer splitContainerDataView;

        private LineGraph.GUI.WndHeaderRoad WndHeader;
        private LineGraph.GUI.WndMenuListRoad WndMenuList;
        private LineGraph.SuperMapUtility.SceneControlWnd m_SceneControlWnd;
        private LineGraph.SuperMapUtility.MapControlWnd m_MapControlWnd;

        //private SuperMap.Data.Workspace m_workspace;
        //private SuperMap.Data.WorkspaceConnectionInfo m_connectionInfo;
        //private LineGraph.SuperMapUtility.WorkSpaceCtrl m_WorkSpaceCtrl = null;

        private LineGraph.SuperMapUtility.WorkSpaceManageWnd m_WorkSpaceCtrl;

        private LineGraph.DataReceiver.DataCaptureWnd m_DataCaptureWnd;
    }
}