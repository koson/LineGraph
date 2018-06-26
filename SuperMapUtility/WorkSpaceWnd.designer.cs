using SuperMap.UI;

namespace LineGraph.SuperMapUtility
{
    partial class WorkSpaceWnd
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
            this.m_workspaceControl = new SuperMap.UI.WorkspaceControl();

            this.SuspendLayout();
            // 
            // m_workspaceControl
            // 
            this.m_workspaceControl.AllowDefaultAction = true;
            this.m_workspaceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_workspaceControl.Location = new System.Drawing.Point(0, 0);
            this.m_workspaceControl.Name = "workspaceControl";
            this.m_workspaceControl.Size = new System.Drawing.Size(200, 390);
            this.m_workspaceControl.TabIndex = 0;
            // 
            // 
            // 
            this.m_workspaceControl.WorkspaceToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_workspaceControl.WorkspaceToolBar.Location = new System.Drawing.Point(0, 0);
            this.m_workspaceControl.WorkspaceToolBar.Name = "WorkspaceToolBar";
            this.m_workspaceControl.WorkspaceToolBar.Size = new System.Drawing.Size(200, 25);
            this.m_workspaceControl.WorkspaceToolBar.TabIndex = 0;
            // 
            // 
            // 
            this.m_workspaceControl.WorkspaceTree.AllowDrop = true;
            this.m_workspaceControl.WorkspaceTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_workspaceControl.WorkspaceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_workspaceControl.WorkspaceTree.HideSelection = false;
            this.m_workspaceControl.WorkspaceTree.ItemHeight = 17;
            this.m_workspaceControl.WorkspaceTree.Location = new System.Drawing.Point(0, 50);
            this.m_workspaceControl.WorkspaceTree.Name = "WorkspaceTree";
            this.m_workspaceControl.WorkspaceTree.SelectedNodes = new System.Windows.Forms.TreeNode[0];
            this.m_workspaceControl.WorkspaceTree.Size = new System.Drawing.Size(200, 390);
            this.m_workspaceControl.WorkspaceTree.TabIndex = 1;
            this.m_workspaceControl.WorkspaceTree.Workspace = m_workspace;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_workspaceControl);
            this.Text = "WorkSpaceWnd";
            this.ClientSize = new System.Drawing.Size(200, 390);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SuperMap.UI.WorkspaceControl m_workspaceControl;
    }
}