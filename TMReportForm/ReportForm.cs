using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TMReportForm.Properties;
using TMReportSource;
using TMReportSource.Objects.VulnReport;

namespace TMReportForm
{
	public partial class ReportForm : Form
	{
		private string threatModelFilePath = string.Empty;
		private string threatModelFileName = string.Empty;
		private string reportType = string.Empty;
		private ThreatReportProcessor _reportProcessor;
		private VulnReportProcessor _vulnReportProcessor;
		public ReportForm()
		{
			InitializeComponent();
		}



		private void Form1_Load(object sender, EventArgs e)
		{
			EnableReportTypeButtons(false);
		}

		private void EnableReportTypeButtons(bool enable)
		{
			mnuActorsView.Enabled = enable;
			mnuInteractionsView.Enabled = enable;
			mnuSdlPhase.Enabled = enable;
			mnuStrideView.Enabled = enable;
			mnuThreatsView.Enabled = enable;
			mnuDataAssetsView.Enabled = enable;
			mnuComponentView.Enabled = enable;
			mnuStatisticsView.Enabled = enable;
		}

		private void MnuOpenModel_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Open Threat Model";

			openFileDialog1.FileName = "*.tm7";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Text = string.Empty;

				reportViewer1.Reset();

				threatModelFilePath = openFileDialog1.FileName;

				threatModelFileName = openFileDialog1.SafeFileName;

				Text = openFileDialog1.SafeFileName;

				EnableReportTypeButtons(true);

				_reportProcessor = new ThreatReportProcessor(threatModelFilePath);

			}
		}


		private void LoadReport(string reportType) {

			EnableReportTypeButtons(false);

			base.Text = string.Format("{0}: {1}", threatModelFileName.Split('.')[0], reportType);

			reportViewer1.LocalReport.ReportPath = string.Format("Reports/{0}.rdlc", reportType);

		}

		private void LoadThreatReport(string reportType)
		{
			LoadReport(reportType);

			EnableReportTypeButtons(true);

			CreateThreatReportDataSource(reportType);

		}

		//private void LoadVulnReport() {

		//	var model = _vulnReportProcessor.GetReport();

		//	CreateVulnReportDataSource(model);

		//}

		private void MnuActorsView_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(Resources.ActorsView);

			reportViewer1.RefreshReport();

		}

		private void NmuDataAssetsView_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(Resources.DataAssetsView);

			reportViewer1.RefreshReport();
		}

		private void MnuInteractionsView_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(Resources.InteractionsView);

			reportViewer1.RefreshReport();
		}

		private void MnuStrideView_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(Resources.StrideView);

			reportViewer1.RefreshReport();
		}

		private void MnuSdlPhase_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(Resources.SDLPhaseView);

			reportViewer1.RefreshReport();
		}

		private void MnuThreatsView_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(Resources.ThreatsView);

			reportViewer1.RefreshReport();
		}

		private void mnuComponentView_Click(object sender, EventArgs e)
		{
			reportViewer1.LocalReport.DataSources.Clear();

			//openFileDialog1.Title = "Attach static scan results";

			//openFileDialog1.FileName = "*.json";

			//openFileDialog1.Multiselect = true;

			//_vulnReportProcessor = new VulnReportProcessor();

			//if (openFileDialog1.ShowDialog() == DialogResult.OK)
			//{
			//	_vulnReportProcessor.FileName = openFileDialog1.FileName;

			//}

			//LoadVulnReport();

			LoadThreatReport(Resources.ComponentView);

			reportViewer1.RefreshReport();
		}

		private void mnuStatisticsView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.StatisticsView);

			reportViewer1.RefreshReport();
		}

		private void CreateThreatReportDataSource(string reportType)
		{
			ReportDataSource DataSet1 = new ReportDataSource { Name = "Threats", Value = _reportProcessor.GetThreats() };

			reportViewer1.LocalReport.DataSources.Add(DataSet1);

			ReportDataSource DataSet2 = new ReportDataSource { Name = "Notes", Value = _reportProcessor.GetNotes() };

			reportViewer1.LocalReport.DataSources.Add(DataSet2);

			ReportDataSource DataSet3 = new ReportDataSource { Name = "Meta", Value = _reportProcessor.GetMetaInformation() };

			reportViewer1.LocalReport.DataSources.Add(DataSet3);

			if (reportType == Resources.ComponentView) {

				ReportDataSource DataSet4 = new ReportDataSource { Name = "Components", Value = _reportProcessor.GetComponentsByType("GE.P") };

				reportViewer1.LocalReport.DataSources.Add(DataSet4);
			}

		}

		//private void CreateVulnReportDataSource(VulnModel model) {

		//	ReportDataSource ds = new ReportDataSource { Name = "Vulns", Value = model.Vulns };

		//	reportViewer1.LocalReport.DataSources.Add(ds);
		//}

	}
}