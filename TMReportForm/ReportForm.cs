using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TMReportForm.Properties;
using TMReportSource;

namespace TMReportForm
{
	public partial class ReportForm : Form
	{
		private string threatModelFilePath = string.Empty;
		private string threatModelFileName = string.Empty;
		private string reportType = string.Empty;
		private ReportProcessor _reportProcessor;
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
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Text = string.Empty;
				reportViewer1.Reset();
				threatModelFilePath = openFileDialog1.FileName;
				threatModelFileName = openFileDialog1.SafeFileName;
				Text = openFileDialog1.SafeFileName;
				EnableReportTypeButtons(true);
				_reportProcessor = new ReportProcessor(threatModelFilePath);
			}
		}


		private void LoadReport(string reportType) {

			EnableReportTypeButtons(false);

			base.Text = string.Format("{0}: {1}", threatModelFileName.Split('.')[0], reportType);

			reportViewer1.LocalReport.ReportPath = string.Format("Reports/{0}.rdlc", reportType);

			reportViewer1.LocalReport.DataSources.Clear();
		}

		private void LoadThreatReport(string reportType)
		{
			LoadReport(reportType);
			
			var model = _reportProcessor.GetThreatReport();

			EnableReportTypeButtons(true);

			if (ModelValidator.ModelIsValid(model))
			{
				CreateThreatReportDataSource(model);

				reportViewer1.RefreshReport();

			}

		}

		private void MnuActorsView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.ActorsView);

		}

		private void NmuDataAssetsView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.DataAssetsView);
		}

		private void MnuInteractionsView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.InteractionsView);
		}

		private void MnuStrideView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.StrideView);
		}

		private void MnuSdlPhase_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.SDLPhaseView);
		}

		private void MnuThreatsView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.ThreatsView);
		}

		private void mnuComponentView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.ComponentView);
		}

		private void mnuStatisticsView_Click(object sender, EventArgs e)
		{
			LoadThreatReport(Resources.StatisticsView);
		}

		private void CreateThreatReportDataSource(ThreatModel model)
		{
			ReportDataSource DataSet1 = new ReportDataSource { Name = "DataSet1", Value = model.Threats };

			reportViewer1.LocalReport.DataSources.Add(DataSet1);

			ReportDataSource DataSet2 = new ReportDataSource { Name = "DataSet2", Value = model.Notes };

			reportViewer1.LocalReport.DataSources.Add(DataSet2);

			ReportDataSource DataSet3 = new ReportDataSource { Name = "DataSet3", Value = model.MetaInformation };

			reportViewer1.LocalReport.DataSources.Add(DataSet3);

		}

	}
}