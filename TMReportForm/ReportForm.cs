using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMReportSource;

namespace TMReportForm
{
	public partial class ReportForm : Form
	{
		private string threatModelFilePath = string.Empty;
		private string threatModelFileName = string.Empty;
		private string reportType = string.Empty;

		public ReportForm()
		{
			InitializeComponent();
		}



		private void Form1_Load(object sender, EventArgs e)
		{
			mnuReportName.Enabled = false;
			mnuGenerateReport.Enabled = false;
		}

		private void mnuOpenModel_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Text = string.Empty;
				reportViewer1.Reset();
				threatModelFilePath = openFileDialog1.FileName;
				threatModelFileName = openFileDialog1.SafeFileName;
				InitReportMenu();
			}
		}

		private void InitReportMenu()
		{
			mnuReportName.DropDownItems.Clear();

			ToolStripMenuItem itemActorsView = new ToolStripMenuItem(Properties.Resources.ActorsView);
			itemActorsView.Name = "ActorsView";
			mnuReportName.DropDownItems.Add(itemActorsView);
			itemActorsView.Click += ItemView_Click;

			ToolStripMenuItem itemDataAssetsView = new ToolStripMenuItem(Properties.Resources.DataAssetsView);
			itemDataAssetsView.Name = "DataAssetsView";
			mnuReportName.DropDownItems.Add(itemDataAssetsView);
			itemDataAssetsView.Click += ItemView_Click;

			ToolStripMenuItem itemInteractionsView = new ToolStripMenuItem(Properties.Resources.InteractionsView);
			itemInteractionsView.Name = "InteractionsView";
			mnuReportName.DropDownItems.Add(itemInteractionsView);
			itemInteractionsView.Click += ItemView_Click;

			ToolStripMenuItem itemThreatsView = new ToolStripMenuItem(Properties.Resources.ThreatsView);
			itemThreatsView.Name = "ThreatsView";
			mnuReportName.DropDownItems.Add(itemThreatsView);
			itemThreatsView.Click += ItemView_Click;

			ToolStripMenuItem itemStrideView = new ToolStripMenuItem(Properties.Resources.StrideView);
			itemStrideView.Name = "StrideView";
			mnuReportName.DropDownItems.Add(itemStrideView);
			itemStrideView.Click += ItemView_Click;

			mnuGenerateReport.Enabled = false;
			mnuReportName.Enabled = true;
		}

		private void ItemView_Click(object sender, EventArgs e)
		{
			reportType = ((ToolStripMenuItem)sender).Name;
			mnuGenerateReport.Enabled = true;
			Text = string.Format("{0}: {1}", threatModelFileName, reportType);
		}

		private void LoadReport(string reportName)
		{
			reportViewer1.LocalReport.ReportPath = string.Format("Reports/{0}.rdlc", reportName);
			reportViewer1.LocalReport.DataSources.Clear();
			ReportParameter p = new ReportParameter("ReportName", Text);
			reportViewer1.LocalReport.SetParameters(p);

			ReportDataSource rds = new ReportDataSource
			{
				Name = "DataSet1",
				Value = ReportProcessor.GetReport(threatModelFilePath)
			};

			reportViewer1.LocalReport.DataSources.Add(rds);

			reportViewer1.RefreshReport();
		}

		private void mnuGenerateReport_Click(object sender, EventArgs e)
		{
			LoadReport(reportType);
		}
	}
}