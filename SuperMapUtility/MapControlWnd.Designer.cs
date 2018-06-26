namespace LineGraph.SuperMapUtility
{
    partial class MapControlWnd
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
            //this.m_MapControl = new SuperMap.UI.MapControl();
            this.SuspendLayout();
            // 
            // m_MapControl
            // 
            this.m_MapControl.Action = SuperMap.UI.Action.Select2;
            this.m_MapControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_MapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MapControl.InteractionMode = SuperMap.UI.InteractionMode.Default;
            this.m_MapControl.IsActionPrior = true;
            this.m_MapControl.IsCursorCustomized = false;
            this.m_MapControl.IsGlobalBrowsing = false;
            this.m_MapControl.IsWaitCursorEnabled = true;
            this.m_MapControl.Location = new System.Drawing.Point(0, 0);
            this.m_MapControl.Margin = new System.Windows.Forms.Padding(48, 22, 48, 22);
            this.m_MapControl.MarginPanEnabled = true;
            this.m_MapControl.MarginPanPercent = 0.5D;
            this.m_MapControl.Name = "m_MapControl";
            this.m_MapControl.RefreshAtTracked = true;
            this.m_MapControl.RefreshInInvalidArea = false;
            this.m_MapControl.RollingWheelWithoutDelay = false;
            this.m_MapControl.SelectionMode = SuperMap.UI.SelectionMode.ContainInnerPoint;
            this.m_MapControl.SelectionPixelTolerance = 0;
            this.m_MapControl.Size = new System.Drawing.Size(778, 336);
            this.m_MapControl.TabIndex = 0;
            this.m_MapControl.TrackMode = SuperMap.UI.TrackMode.Edit;
            this.m_MapControl.Map.Workspace = m_workspace;
            //this.p_MapControl.Load += new System.EventHandler(this.p_MapControl_Load);
            //this.p_MapControl.Click += new System.EventHandler(this.p_MapControl_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "MapControlWnd";
            this.Controls.Add(this.m_MapControl);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SuperMap.UI.MapControl m_MapControl;

        private System.Windows.Forms.Timer timer;
        private bool bplay = false;
    }
}