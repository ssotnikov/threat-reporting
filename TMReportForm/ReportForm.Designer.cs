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
			this.mnuReportName = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuGenerateReport = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = null;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
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
            this.mnuReportName,
            this.toolStripSeparator2,
            this.mnuGenerateReport});
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
			this.mnuOpenModel.Click += new System.EventHandler(this.mnuOpenModel_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// mnuReportName
			// 
			this.mnuReportName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuReportName.Image = global::TMReportForm.Properties.Resources.reports;
			this.mnuReportName.Name = "mnuReportName";
			this.mnuReportName.Size = new System.Drawing.Size(32, 22);
			this.mnuReportName.Text = "Report";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// mnuGenerateReport
			// 
			this.mnuGenerateReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuGenerateReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuGenerateReport.Image")));
			this.mnuGenerateReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuGenerateReport.Name = "mnuGenerateReport";
			this.mnuGenerateReport.Size = new System.Drawing.Size(23, 22);
			this.mnuGenerateReport.Click += new System.EventHandler(this.mnuGenerateReport_Click);
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
		private System.Windows.Forms.ToolStripButton mnuGenerateReport;
		private System.Windows.Forms.ToolStripSplitButton mnuReportName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}

