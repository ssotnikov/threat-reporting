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
		private string threatModelFile = string.Empty;

		public ReportForm()
		{
			InitializeComponent();
		}



		private void Form1_Load(object sender, EventArgs e)
		{
			mnuReportName.Enabled = false;
		}

		private void mnuOpenModel_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				threatModelFile = openFileDialog1.FileName;
				Text = openFileDialog1.SafeFileName;
				InitReportMenu();
			}
		}

		private void InitReportMenu()
		{
			mnuReportName.DropDownItems.Clear();

			ToolStripMenuItem itemActorsView = new ToolStripMenuItem(Properties.Resources.ActorsView);
			itemActorsView.Name = "ActorsView";
			mnuReportName.DropDownItems.Add(itemActorsView);
			itemActorsView.Click += ItemActorsView_Click;

			ToolStripMenuItem itemDataAssetsView = new ToolStripMenuItem(Properties.Resources.DataAssetsView);
			itemDataAssetsView.Name = "DataAssetsView";
			mnuReportName.DropDownItems.Add(itemDataAssetsView);
			itemDataAssetsView.Click += ItemDataAssetsView_Click;

			ToolStripMenuItem itemInteractionsView = new ToolStripMenuItem(Properties.Resources.InteractionsView);
			itemInteractionsView.Name = "InteractionsView";
			mnuReportName.DropDownItems.Add(itemInteractionsView);
			itemInteractionsView.Click += ItemInteractionsView_Click;

			ToolStripMenuItem itemThreatsView = new ToolStripMenuItem(Properties.Resources.ThreatsView);
			itemThreatsView.Name = "ThreatsView";
			mnuReportName.DropDownItems.Add(itemThreatsView);
			itemThreatsView.Click += ItemThreatsView_Click;

			mnuReportName.Enabled = true;
		}

		private void ItemThreatsView_Click(object sender, EventArgs e)
		{
			LoadReport(((ToolStripMenuItem)sender).Name);
		}

		private void ItemInteractionsView_Click(object sender, EventArgs e)
		{
			LoadReport(((ToolStripMenuItem)sender).Name);
		}

		private void ItemDataAssetsView_Click(object sender, EventArgs e)
		{
			LoadReport(((ToolStripMenuItem)sender).Name);
		}

		private void ItemActorsView_Click(object sender, EventArgs e)
		{
			LoadReport(((ToolStripMenuItem)sender).Name);
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
				Value = ReportProcessor.GetReport(threatModelFile)
			};

			reportViewer1.LocalReport.DataSources.Add(rds);

			reportViewer1.RefreshReport();
		}
	}
}