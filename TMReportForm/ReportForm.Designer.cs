namespace TMReportForm
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.mnuOpenModel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuThreatsView = new System.Windows.Forms.ToolStripButton();
			this.mnuActorsView = new System.Windows.Forms.ToolStripButton();
			this.mnuDataAssetsView = new System.Windows.Forms.ToolStripButton();
			this.mnuInteractionsView = new System.Windows.Forms.ToolStripButton();
			this.mnuSdlPhase = new System.Windows.Forms.ToolStripButton();
			this.mnuStrideView = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = null;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.EnableExternalImages = true;
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "";
			this.reportViewer1.Location = new System.Drawing.Point(0, 25);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(923, 541);
			this.reportViewer1.TabIndex = 0;
			this.reportViewer1.WaitControlDisplayAfter = 1;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenModel,
            this.toolStripSeparator1,
            this.mnuThreatsView,
            this.mnuActorsView,
            this.mnuDataAssetsView,
            this.mnuInteractionsView,
            this.mnuSdlPhase,
            this.mnuStrideView});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(923, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// mnuOpenModel
			// 
			this.mnuOpenModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuOpenModel.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenModel.Image")));
			this.mnuOpenModel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuOpenModel.Name = "mnuOpenModel";
			this.mnuOpenModel.Size = new System.Drawing.Size(23, 22);
			this.mnuOpenModel.Text = "Open Model";
			this.mnuOpenModel.Click += new System.EventHandler(this.MnuOpenModel_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// mnuThreatsView
			// 
			this.mnuThreatsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuThreatsView.Image = global::TMReportForm.Properties.Resources.reports;
			this.mnuThreatsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuThreatsView.Name = "mnuThreatsView";
			this.mnuThreatsView.Size = new System.Drawing.Size(23, 22);
			this.mnuThreatsView.ToolTipText = "Threats Ordered List";
			this.mnuThreatsView.Click += new System.EventHandler(this.MnuThreatsView_Click);
			// 
			// mnuActorsView
			// 
			this.mnuActorsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuActorsView.Image = global::TMReportForm.Properties.Resources.actors;
			this.mnuActorsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuActorsView.Name = "mnuActorsView";
			this.mnuActorsView.Size = new System.Drawing.Size(23, 22);
			this.mnuActorsView.ToolTipText = "Threats Grouped by Actor";
			this.mnuActorsView.Click += new System.EventHandler(this.MnuActorsView_Click);
			// 
			// mnuDataAssetsView
			// 
			this.mnuDataAssetsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuDataAssetsView.Image = global::TMReportForm.Properties.Resources.data;
			this.mnuDataAssetsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuDataAssetsView.Name = "mnuDataAssetsView";
			this.mnuDataAssetsView.Size = new System.Drawing.Size(23, 22);
			this.mnuDataAssetsView.ToolTipText = "Threats Grouped by Data Asset";
			this.mnuDataAssetsView.Click += new System.EventHandler(this.NmuDataAssetsView_Click);
			// 
			// mnuInteractionsView
			// 
			this.mnuInteractionsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuInteractionsView.Image = global::TMReportForm.Properties.Resources.interaction;
			this.mnuInteractionsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuInteractionsView.Name = "mnuInteractionsView";
			this.mnuInteractionsView.Size = new System.Drawing.Size(23, 22);
			this.mnuInteractionsView.ToolTipText = "Threats Grouped by Interaction";
			this.mnuInteractionsView.Click += new System.EventHandler(this.MnuInteractionsView_Click);
			// 
			// mnuSdlPhase
			// 
			this.mnuSdlPhase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuSdlPhase.Image = global::TMReportForm.Properties.Resources.sdl_phase;
			this.mnuSdlPhase.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuSdlPhase.Name = "mnuSdlPhase";
			this.mnuSdlPhase.Size = new System.Drawing.Size(23, 22);
			this.mnuSdlPhase.ToolTipText = "Threats Grouped by SDL Phase";
			this.mnuSdlPhase.Click += new System.EventHandler(this.MnuSdlPhase_Click);
			// 
			// mnuStrideView
			// 
			this.mnuStrideView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuStrideView.Image = global::TMReportForm.Properties.Resources.stride;
			this.mnuStrideView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuStrideView.Name = "mnuStrideView";
			this.mnuStrideView.Size = new System.Drawing.Size(23, 22);
			this.mnuStrideView.ToolTipText = "Threats Grouped by STRIDE";
			this.mnuStrideView.Click += new System.EventHandler(this.MnuStrideView_Click);
			// 
			// ReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(923, 566);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ReportForm";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton mnuOpenModel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton mnuActorsView;
		private System.Windows.Forms.ToolStripButton mnuDataAssetsView;
		private System.Windows.Forms.ToolStripButton mnuInteractionsView;
		private System.Windows.Forms.ToolStripButton mnuThreatsView;
		private System.Windows.Forms.ToolStripButton mnuSdlPhase;
		private System.Windows.Forms.ToolStripButton mnuStrideView;
	}
}

