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
			this.mnuReportName = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = null;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "TMReports.Reports.ThreatList.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 25);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(974, 541);
			this.reportViewer1.TabIndex = 0;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenModel,
            this.mnuReportName});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(974, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// mnuOpenModel
			// 
			this.mnuOpenModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mnuOpenModel.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenModel.Image")));
			this.mnuOpenModel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuOpenModel.Name = "mnuOpenModel";
			this.mnuOpenModel.Size = new System.Drawing.Size(77, 22);
			this.mnuOpenModel.Text = "Open Model";
			this.mnuOpenModel.Click += new System.EventHandler(this.mnuOpenModel_Click);
			// 
			// mnuReportName
			// 
			this.mnuReportName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mnuReportName.Image = ((System.Drawing.Image)(resources.GetObject("mnuReportName.Image")));
			this.mnuReportName.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuReportName.Name = "mnuReportName";
			this.mnuReportName.Size = new System.Drawing.Size(58, 22);
			this.mnuReportName.Text = "Report";
			// 
			// ReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(974, 566);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ReportForm";
			this.Text = "Form1";
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
		private System.Windows.Forms.ToolStripSplitButton mnuReportName;
	}
}

