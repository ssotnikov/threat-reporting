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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
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
			this.mnuComponentView = new System.Windows.Forms.ToolStripButton();
			this.mnuStatisticsView = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource2.Name = "DataSet1";
			reportDataSource2.Value = null;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer1.LocalReport.EnableExternalImages = true;
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "";
			this.reportViewer1.Location = new System.Drawing.Point(0, 31);
			this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(1498, 964);
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
            this.mnuStrideView,
            this.mnuComponentView,
            this.mnuStatisticsView});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(1498, 31);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// mnuOpenModel
			// 
			this.mnuOpenModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuOpenModel.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenModel.Image")));
			this.mnuOpenModel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuOpenModel.Name = "mnuOpenModel";
			this.mnuOpenModel.Size = new System.Drawing.Size(28, 28);
			this.mnuOpenModel.Text = "Open Model";
			this.mnuOpenModel.Click += new System.EventHandler(this.MnuOpenModel_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// mnuThreatsView
			// 
			this.mnuThreatsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuThreatsView.Image = global::TMReportForm.Properties.Resources.reports;
			this.mnuThreatsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuThreatsView.Name = "mnuThreatsView";
			this.mnuThreatsView.Size = new System.Drawing.Size(28, 28);
			this.mnuThreatsView.ToolTipText = "Threats Ordered List";
			this.mnuThreatsView.Click += new System.EventHandler(this.MnuThreatsView_Click);
			// 
			// mnuActorsView
			// 
			this.mnuActorsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuActorsView.Image = global::TMReportForm.Properties.Resources.actors;
			this.mnuActorsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuActorsView.Name = "mnuActorsView";
			this.mnuActorsView.Size = new System.Drawing.Size(28, 28);
			this.mnuActorsView.ToolTipText = "Threats Grouped by Actor";
			this.mnuActorsView.Click += new System.EventHandler(this.MnuActorsView_Click);
			// 
			// mnuDataAssetsView
			// 
			this.mnuDataAssetsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuDataAssetsView.Image = global::TMReportForm.Properties.Resources.data;
			this.mnuDataAssetsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuDataAssetsView.Name = "mnuDataAssetsView";
			this.mnuDataAssetsView.Size = new System.Drawing.Size(28, 28);
			this.mnuDataAssetsView.ToolTipText = "Threats Grouped by Data Asset";
			this.mnuDataAssetsView.Click += new System.EventHandler(this.NmuDataAssetsView_Click);
			// 
			// mnuInteractionsView
			// 
			this.mnuInteractionsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuInteractionsView.Image = global::TMReportForm.Properties.Resources.interaction;
			this.mnuInteractionsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuInteractionsView.Name = "mnuInteractionsView";
			this.mnuInteractionsView.Size = new System.Drawing.Size(28, 28);
			this.mnuInteractionsView.ToolTipText = "Threats Grouped by Interaction";
			this.mnuInteractionsView.Click += new System.EventHandler(this.MnuInteractionsView_Click);
			// 
			// mnuSdlPhase
			// 
			this.mnuSdlPhase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuSdlPhase.Image = global::TMReportForm.Properties.Resources.sdl_phase;
			this.mnuSdlPhase.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuSdlPhase.Name = "mnuSdlPhase";
			this.mnuSdlPhase.Size = new System.Drawing.Size(28, 28);
			this.mnuSdlPhase.ToolTipText = "Threats Grouped by SDL Phase";
			this.mnuSdlPhase.Click += new System.EventHandler(this.MnuSdlPhase_Click);
			// 
			// mnuStrideView
			// 
			this.mnuStrideView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuStrideView.Image = global::TMReportForm.Properties.Resources.stride;
			this.mnuStrideView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuStrideView.Name = "mnuStrideView";
			this.mnuStrideView.Size = new System.Drawing.Size(28, 28);
			this.mnuStrideView.ToolTipText = "Threats Grouped by STRIDE";
			this.mnuStrideView.Click += new System.EventHandler(this.MnuStrideView_Click);
			// 
			// mnuComponentView
			// 
			this.mnuComponentView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuComponentView.Image = global::TMReportForm.Properties.Resources.component;
			this.mnuComponentView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuComponentView.Name = "mnuComponentView";
			this.mnuComponentView.Size = new System.Drawing.Size(28, 28);
			this.mnuComponentView.Text = "Threats Grouped by Component";
			this.mnuComponentView.Click += new System.EventHandler(this.mnuComponentView_Click);
			// 
			// mnuStatisticsView
			// 
			this.mnuStatisticsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuStatisticsView.Image = global::TMReportForm.Properties.Resources.pie_chart;
			this.mnuStatisticsView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuStatisticsView.Name = "mnuStatisticsView";
			this.mnuStatisticsView.Size = new System.Drawing.Size(28, 28);
			this.mnuStatisticsView.Text = "Statistics";
			this.mnuStatisticsView.Click += new System.EventHandler(this.mnuStatisticsView_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Location = new System.Drawing.Point(0, 995);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1498, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1498, 1017);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripButton mnuComponentView;
		private System.Windows.Forms.ToolStripButton mnuStatisticsView;
	}
}

