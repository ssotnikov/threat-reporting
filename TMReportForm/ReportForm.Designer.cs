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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuSelectReportType = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnGenerateReport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource4.Name = "DataSet1";
			reportDataSource4.Value = null;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
			this.reportViewer1.LocalReport.EnableExternalImages = true;
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "";
			this.reportViewer1.Location = new System.Drawing.Point(0, 31);
			this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(1125, 676);
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
            this.openToolStripButton,
            this.toolStripSeparator1,
            this.mnuSelectReportType,
            this.toolStripSeparator2,
            this.btnGenerateReport,
            this.toolStripSeparator3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(1125, 31);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(28, 28);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.ToolTipText = "Open TMT file";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// mnuSelectReportType
			// 
			this.mnuSelectReportType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuSelectReportType.Image = global::TMReportForm.Properties.Resources.reports;
			this.mnuSelectReportType.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuSelectReportType.Name = "mnuSelectReportType";
			this.mnuSelectReportType.Size = new System.Drawing.Size(42, 28);
			this.mnuSelectReportType.Text = "&New";
			this.mnuSelectReportType.ToolTipText = "Report Types";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// btnGenerateReport
			// 
			this.btnGenerateReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnGenerateReport.Image = global::TMReportForm.Properties.Resources.generate;
			this.btnGenerateReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGenerateReport.Name = "btnGenerateReport";
			this.btnGenerateReport.Size = new System.Drawing.Size(28, 28);
			this.btnGenerateReport.Text = "Generate Report";
			this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Location = new System.Drawing.Point(0, 707);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1125, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 729);
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
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnGenerateReport;
		private System.Windows.Forms.ToolStripDropDownButton mnuSelectReportType;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}

