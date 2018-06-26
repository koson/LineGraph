using SuperMap.Realspace;

namespace LineGraph.SuperMapUtility
{
    partial class SceneControlWnd
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
            if (m_DlgOSGBQuery != null)
            {
                m_DlgOSGBQuery.Dispose();
                m_DlgOSGBQuery = null;
            }
            if (m_DlgAttribute != null)
            {
                m_DlgAttribute.Dispose();
                m_DlgAttribute = null;
            }

            if (m_DlgSetLayerStyle != null)
            {
                m_DlgSetLayerStyle.Dispose();
                m_DlgSetLayerStyle = null;
            }

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
            this.m_toolStripButtons = new System.Windows.Forms.ToolStrip();
            this.m_toolStripButtonMeasureDistance = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonMeasureTerrainDistance = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonMeasureHorizotalDistance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolStripButtonMeasureArea = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonMeasureTerrainArea = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolStripButtonMeasureAltitude = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripButton_StopMeasure = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.flowLayoutPanelMarker = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelFill = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolStripButtonClearPoint = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtonClearFill = new System.Windows.Forms.ToolStripButton();
            this.m_toolStripButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // 
            // m_sceneControl
            // 
            this.m_sceneControl.Action = SuperMap.UI.Action3D.Pan;
            this.m_sceneControl.BackColor = System.Drawing.Color.White;
            this.m_sceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_sceneControl.InteractionMode = SuperMap.UI.InteractionMode3D.Default;
            this.m_sceneControl.IsAlwaysUpdate = false;
            this.m_sceneControl.IsCursorCustomized = false;
            this.m_sceneControl.IsFPSVisible = false;
            this.m_sceneControl.IsKeyboardNavigationEnabled = false;
            this.m_sceneControl.IsMouseNavigationEnabled = true;
            this.m_sceneControl.IsStatusBarVisible = true;
            this.m_sceneControl.IsWaitCursorEnabled = false;
            this.m_sceneControl.Location = new System.Drawing.Point(0, 0);
            this.m_sceneControl.Margin = new System.Windows.Forms.Padding(0);
            this.m_sceneControl.Name = "sceneControl";
            this.m_sceneControl.Size = new System.Drawing.Size(475, 573);
            this.m_sceneControl.TabIndex = 0;
            this.m_sceneControl.TrackMode = SuperMap.UI.TrackMode3D.Edit;
            this.m_sceneControl.Scene.Workspace = m_workspace;

            // 
            // flowLayoutPanelMarker
            // 
            this.flowLayoutPanelMarker.AutoScroll = true;
            this.flowLayoutPanelMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelMarker.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelMarker.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMarker.Name = "flowLayoutPanelMarker";
            this.flowLayoutPanelMarker.Size = new System.Drawing.Size(200, 573);
            this.flowLayoutPanelMarker.TabIndex = 1;

            // 
            // flowLayoutPanelFill
            // 
            this.flowLayoutPanelFill.AutoScroll = true;
            this.flowLayoutPanelFill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelFill.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelFill.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelFill.Name = "flowLayoutPanelFill";
            this.flowLayoutPanelFill.Size = new System.Drawing.Size(200, 573);
            this.flowLayoutPanelFill.TabIndex = 2;

            // 
            // m_toolStripButtons
            // 
            this.m_toolStripButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolStripButtonMeasureHorizotalDistance,
            this.m_toolStripButtonMeasureDistance,
            this.m_toolStripButtonMeasureTerrainDistance,
            this.toolStripSeparator2,
            this.m_toolStripButtonMeasureArea,
            this.m_toolStripButtonMeasureTerrainArea,
            this.toolStripSeparator3,
            this.m_toolStripButtonMeasureAltitude,
            this.toolStripSeparator1,
            this.toolStripButton_StopMeasure,
            this.toolStripSeparator4,
            this.m_toolStripButtonClear,
            this.toolStripSeparator5,
            this.m_toolStripButtonClearPoint,
            this.m_toolStripButtonClearFill});
            this.m_toolStripButtons.Location = new System.Drawing.Point(0, 0);
            this.m_toolStripButtons.Name = "m_toolStripButtons";
            this.m_toolStripButtons.Size = new System.Drawing.Size(721, 25);
            this.m_toolStripButtons.TabIndex = 0;
            this.m_toolStripButtons.Text = "toolStrip1";
            // 
            // m_toolStripButtonMeasureDistance
            // 
            this.m_toolStripButtonMeasureDistance.AutoToolTip = false;
            this.m_toolStripButtonMeasureDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonMeasureDistance.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonMeasureDistance.Image")));
            this.m_toolStripButtonMeasureDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonMeasureDistance.Name = "m_toolStripButtonMeasureDistance";
            this.m_toolStripButtonMeasureDistance.Size = new System.Drawing.Size(84, 22);
            this.m_toolStripButtonMeasureDistance.Text = "空间距离量算";
            this.m_toolStripButtonMeasureDistance.Click += new System.EventHandler(this.m_toolStripButtonMeasureDistance_Click);
            // 
            // m_toolStripButtonMeasureTerrainDistance
            // 
            this.m_toolStripButtonMeasureTerrainDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonMeasureTerrainDistance.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonMeasureTerrainDistance.Image")));
            this.m_toolStripButtonMeasureTerrainDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonMeasureTerrainDistance.Name = "m_toolStripButtonMeasureTerrainDistance";
            this.m_toolStripButtonMeasureTerrainDistance.Size = new System.Drawing.Size(84, 22);
            this.m_toolStripButtonMeasureTerrainDistance.Text = "依地距离量算";
            this.m_toolStripButtonMeasureTerrainDistance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.m_toolStripButtonMeasureTerrainDistance.Click += new System.EventHandler(this.m_toolStripButtonMeasureTerrainDistance_Click);
            // 
            // m_toolStripButtonMeasureHorizotalDistance
            // 
            this.m_toolStripButtonMeasureHorizotalDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
           // this.m_toolStripButtonMeasureHorizotalDistance.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonMeasureHorizotalDistance.Image")));
            this.m_toolStripButtonMeasureHorizotalDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonMeasureHorizotalDistance.Name = "m_toolStripButtonMeasureHorizotalDistance";
            this.m_toolStripButtonMeasureHorizotalDistance.Size = new System.Drawing.Size(84, 22);
            this.m_toolStripButtonMeasureHorizotalDistance.Text = "水平距离量算";
            this.m_toolStripButtonMeasureHorizotalDistance.Click += new System.EventHandler(this.m_toolStripButtonMeasureHorizotalDistance_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_toolStripButtonMeasureArea
            // 
            this.m_toolStripButtonMeasureArea.AutoToolTip = false;
            this.m_toolStripButtonMeasureArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonMeasureArea.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonMeasureArea.Image")));
            this.m_toolStripButtonMeasureArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonMeasureArea.Name = "m_toolStripButtonMeasureArea";
            this.m_toolStripButtonMeasureArea.Size = new System.Drawing.Size(84, 22);
            this.m_toolStripButtonMeasureArea.Text = "空间面积量算";
            this.m_toolStripButtonMeasureArea.Click += new System.EventHandler(this.m_toolStripButtonMeasureArea_Click);
            // 
            // m_toolStripButtonMeasureTerrainArea
            // 
            this.m_toolStripButtonMeasureTerrainArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonMeasureTerrainArea.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonMeasureTerrainArea.Image")));
            this.m_toolStripButtonMeasureTerrainArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonMeasureTerrainArea.Name = "m_toolStripButtonMeasureTerrainArea";
            this.m_toolStripButtonMeasureTerrainArea.Size = new System.Drawing.Size(84, 22);
            this.m_toolStripButtonMeasureTerrainArea.Text = "依地面积量算";
            this.m_toolStripButtonMeasureTerrainArea.Click += new System.EventHandler(this.m_toolStripButtonMeasureTerrainArea_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // m_toolStripButtonMeasureAltitude
            // 
            this.m_toolStripButtonMeasureAltitude.AutoToolTip = false;
            this.m_toolStripButtonMeasureAltitude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonMeasureAltitude.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonMeasureAltitude.Image")));
            this.m_toolStripButtonMeasureAltitude.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonMeasureAltitude.Name = "m_toolStripButtonMeasureAltitude";
            this.m_toolStripButtonMeasureAltitude.Size = new System.Drawing.Size(60, 22);
            this.m_toolStripButtonMeasureAltitude.Text = "高度量算";
            this.m_toolStripButtonMeasureAltitude.Click += new System.EventHandler(this.m_toolStripButtonMeasureAltitude_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_toolStripButtonClear
            // 
            this.m_toolStripButtonClear.AutoToolTip = false;
            this.m_toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("m_toolStripButtonClear.Image")));
            this.m_toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonClear.Name = "m_toolStripButtonClear";
            this.m_toolStripButtonClear.Size = new System.Drawing.Size(84, 22);
            this.m_toolStripButtonClear.Text = "清空量算结果";
            this.m_toolStripButtonClear.Click += new System.EventHandler(this.m_toolStripButtonClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_sceneControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 548);
            this.panel1.TabIndex = 1;
 
            // 
            // toolStripButton_StopMeasure
            // 
            this.toolStripButton_StopMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.toolStripButton_StopMeasure.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_StopMeasure.Image")));
            this.toolStripButton_StopMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StopMeasure.Name = "toolStripButton_StopMeasure";
            this.toolStripButton_StopMeasure.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton_StopMeasure.Text = "结束量算";
            this.toolStripButton_StopMeasure.Click += new System.EventHandler(this.toolStripButton_StopMeasure_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);

            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(120, 25);

            // 
            // m_toolStripButtonClearPoint
            // 
            this.m_toolStripButtonClearPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonClearPoint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_StopMeasure.Image")));
            this.m_toolStripButtonClearPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonClearPoint.Name = "m_toolStripButtonClearPoint";
            this.m_toolStripButtonClearPoint.Size = new System.Drawing.Size(60, 22);
            this.m_toolStripButtonClearPoint.Text = "结束树木模拟";
            this.m_toolStripButtonClearPoint.Click += new System.EventHandler(this.m_toolStripButtonClearPoint_Click);

            // 
            // m_toolStripButtonClearFill
            // 
            this.m_toolStripButtonClearFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.m_toolStripButtonClearFill.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_StopMeasure.Image")));
            this.m_toolStripButtonClearFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolStripButtonClearFill.Name = "m_toolStripButtonClearFill";
            this.m_toolStripButtonClearFill.Size = new System.Drawing.Size(60, 22);
            this.m_toolStripButtonClearFill.Text = "结束地面模拟";
            this.m_toolStripButtonClearFill.Click += new System.EventHandler(this.m_toolStripButtonClearFill_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_toolStripButtons);
            this.Name = "FormMain";
            this.Text = "三维场景";
            this.m_toolStripButtons.ResumeLayout(false);
            this.m_toolStripButtons.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SuperMap.UI.SceneControl m_sceneControl = null;

        private System.Windows.Forms.ToolStrip m_toolStripButtons;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonMeasureDistance;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonMeasureArea;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonMeasureAltitude;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonClear;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonMeasureTerrainDistance;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonMeasureTerrainArea;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonMeasureHorizotalDistance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButton_StopMeasure;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;


        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMarker;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonClearPoint;
        private System.Windows.Forms.ToolStripButton m_toolStripButtonClearFill;

    }
}