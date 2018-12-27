using Microsoft.Reporting.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
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
		private ThreatReportProcessor _reportProcessor;
		private JObject _reportTypes;
		public ReportForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			EnableReportTypeButtons(false);
			btnGenerateReport.Enabled = false;
		}

		private void EnableReportTypeButtons(bool enable)
		{
			mnuSelectReportType.Enabled = enable;
		}

		private void CreateReportTypesMenu()
		{
			using (StreamReader r = new StreamReader(@"ReportTypes.json"))
			{
				var jsSource = r.ReadToEnd();
				_reportTypes = JObject.Parse(jsSource);
				var reportTypes = _reportTypes["ReportTypes"].ToList();
				if (reportTypes.Count > 0)
				{
					mnuSelectReportType.DropDownItems.Clear();
					foreach (var type in reportTypes)
					{
						var reportTypeMenuItem = new ToolStripMenuItem();
						JProperty jProperty = (JProperty)type;
						reportTypeMenuItem.Name = jProperty.Name;
						reportTypeMenuItem.ToolTipText = jProperty.Value["Title"].ToString();
						reportTypeMenuItem.Checked = false;
						reportTypeMenuItem.Text = jProperty.Value["Title"].ToString();
						reportTypeMenuItem.Click += ReportTypeMenuItem_Click;
						mnuSelectReportType.DropDownItems.Add(reportTypeMenuItem);
					}
				}
			}

		}

		private void ReportTypeMenuItem_Click(object sender, EventArgs e)
		{
			btnGenerateReport.Enabled = false;

			reportViewer1.Reset();

			foreach (ToolStripMenuItem item in mnuSelectReportType.DropDownItems)
			{
				item.Checked = false;
			}

			((ToolStripMenuItem)sender).Checked = true;

			reportType = ((ToolStripMenuItem)sender).Text;

			btnGenerateReport.Enabled = true;

			Text = string.Format("{0}: {1}", threatModelFileName.Split('.')[0], reportType);

		}

		private void btnGenerateReport_Click(object sender, EventArgs e)
		{
			mnuSelectReportType.Enabled = false;

			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport(reportType);

			reportViewer1.RefreshReport();

			mnuSelectReportType.Enabled = true;
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Open Threat Model";

			openFileDialog1.FileName = "*.tm7";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Text = string.Empty;

				reportViewer1.Reset();

				threatModelFilePath = openFileDialog1.FileName;

				threatModelFileName = openFileDialog1.SafeFileName;

				CreateReportTypesMenu();

				EnableReportTypeButtons(true);

				_reportProcessor = new ThreatReportProcessor(threatModelFilePath);

			}
		}

		private void LoadReport(string reportType)
		{

			EnableReportTypeButtons(false);

			reportViewer1.LocalReport.ReportPath = string.Format("Reports/{0}.rdlc", reportType);

		}

		private void LoadThreatReport(string reportType)
		{

			LoadReport(reportType);

			CreateThreatReportDataSource(reportType);

			EnableReportTypeButtons(true);

		}

		private void CreateThreatReportDataSource(string reportType)
		{
			ReportDataSource DataSet1 = new ReportDataSource { Name = "Threats", Value = _reportProcessor.GetThreats() };

			reportViewer1.LocalReport.DataSources.Add(DataSet1);

			ReportDataSource DataSet2 = new ReportDataSource { Name = "Notes", Value = _reportProcessor.GetNotes() };

			reportViewer1.LocalReport.DataSources.Add(DataSet2);

			ReportDataSource DataSet3 = new ReportDataSource { Name = "Meta", Value = _reportProcessor.GetMetaInformation() };

			reportViewer1.LocalReport.DataSources.Add(DataSet3);

			if (reportType == Resources.ComponentView)
			{

				ReportDataSource DataSet4 = new ReportDataSource { Name = "Components", Value = _reportProcessor.GetComponentsByType("GE.P") };

				reportViewer1.LocalReport.DataSources.Add(DataSet4);
			}

		}
	}
}