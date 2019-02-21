using Microsoft.Reporting.WinForms;
using Newtonsoft.Json.Linq;
using Sonar;
using Sonar.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThreatModeller;

namespace Report
{
	public partial class ReportForm : Form
	{
		private string threatModelFilePath = string.Empty;
		private string threatModelFileName = string.Empty;
		private string reportType = string.Empty;
		private string reportTitle = string.Empty;
		private Dictionary<string, List<ReportParameter>> reportParams = new Dictionary<string, List<ReportParameter>>();
		private ThreatReportProcessor reportProcessor;
		private JObject reportTypes;
		private SonarSource sonarSource = new SonarSource();
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
				this.reportTypes = JObject.Parse(jsSource);
				var reportTypes = this.reportTypes["ReportTypes"].ToList();

				if (reportTypes.Count > 0)
				{
					mnuSelectReportType.DropDownItems.Clear();
					foreach (var type in reportTypes)
					{
						var reportTypeMenuItem = new ToolStripMenuItem();
						JProperty jProperty = (JProperty)type;
						if (jProperty.Value["Type"].ToString() == "MenuItem")
						{
							reportTypeMenuItem.Name = jProperty.Name;
							reportTypeMenuItem.ToolTipText = jProperty.Value["Title"].ToString();
							reportTypeMenuItem.Checked = false;
							reportTypeMenuItem.Text = jProperty.Value["Title"].ToString();
							reportTypeMenuItem.Tag = jProperty.Value["ReportFileName"].ToString();
							reportTypeMenuItem.Click += ReportTypeMenuItem_Click;
							mnuSelectReportType.DropDownItems.Add(reportTypeMenuItem);
							List<ReportParameter> ps = new List<ReportParameter>();
							if (jProperty.Value["ReportParams"] != null)
							{
								var pList = jProperty.Value["ReportParams"].ToList();
								foreach (JProperty p in pList)
								{
									ps.Add(new ReportParameter(p.Name, p.Value.ToString()));
								}
							}

							reportParams.Add(jProperty.Value["Title"].ToString(), ps);

						}
						if (jProperty.Value["Type"].ToString() == "Divider")
						{
							mnuSelectReportType.DropDownItems.Add(new ToolStripSeparator());
						}
					}
				}
			}

		}

		private void ReportTypeMenuItem_Click(object sender, EventArgs e)
		{
			btnGenerateReport.Enabled = false;

			reportViewer1.Reset();

			foreach (object item in mnuSelectReportType.DropDownItems)
			{
				if (item is ToolStripMenuItem menuItem)
				{
					menuItem.Checked = false;
				}
			}

			((ToolStripMenuItem)sender).Checked = true;

			reportType = ((ToolStripMenuItem)sender).Tag.ToString();

			reportTitle = ((ToolStripMenuItem)sender).Text;

			btnGenerateReport.Enabled = true;

			Text = string.Format("{0}: {1}", threatModelFileName.Split('.')[0], reportType);

		}

		private void btnGenerateReport_Click(object sender, EventArgs e)
		{
			mnuSelectReportType.Enabled = false;

			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport();

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

				reportParams.Clear();

				reportViewer1.Reset();

				threatModelFilePath = openFileDialog1.FileName;

				threatModelFileName = openFileDialog1.SafeFileName;

				CreateReportTypesMenu();

				EnableReportTypeButtons(true);

				reportProcessor = new ThreatReportProcessor(threatModelFilePath);

			}
		}

		private void LoadReport()
		{

			EnableReportTypeButtons(false);

			reportViewer1.LocalReport.ReportPath = string.Format("Reports/{0}.rdlc", reportType);

		}

		private void LoadThreatReport()
		{

			LoadReport();

			CreateThreatReportDataSource();

			EnableReportTypeButtons(true);

		}

		private void CreateThreatReportDataSource()
		{
			if (reportType == "MitigatedComponents")
			{
				ReportDataSource DataSet1 = new ReportDataSource { Name = "Threats", Value = reportProcessor.GetThreatsGroupedByMitigatedComponent() };

				reportViewer1.LocalReport.DataSources.Add(DataSet1);

			}
			else {

				ReportDataSource DataSet1 = new ReportDataSource { Name = "Threats", Value = reportProcessor.GetThreats() };

				reportViewer1.LocalReport.DataSources.Add(DataSet1);

			}

			ReportDataSource DataSet2 = new ReportDataSource { Name = "Notes", Value = reportProcessor.GetNotes() };

			reportViewer1.LocalReport.DataSources.Add(DataSet2);

			ReportDataSource DataSet3 = new ReportDataSource { Name = "Meta", Value = reportProcessor.GetMetaInformation() };

			reportViewer1.LocalReport.DataSources.Add(DataSet3);

			var ps = reportParams.FirstOrDefault(i => i.Key == reportTitle).Value;

			if (ps.Count > 0)
			{

				reportViewer1.LocalReport.SetParameters(ps);

			}

		}

		private async void btnGetSASTReport_ClickAsync(object sender, EventArgs e)
		{

			sonarSource.ParamsBuilder.ShowDialog();

			if (sonarSource.ParamsBuilder.DialogResult == DialogResult.OK) {

				string query = sonarSource.ParamsBuilder.Query;

				reportViewer1.Reset();

				IssuesReport issuesReport = await sonarSource.SonarAPI.GetIssuesReportAsync(query).ConfigureAwait(true);

				reportViewer1.LocalReport.ReportPath = "Reports/SonarIssueReport.rdlc";

				if (issuesReport != null)
				{

					List<Rule> rules = new List<Rule>();

					foreach (var issue in issuesReport.issues) {

						RuleReport ruleReport = await sonarSource.SonarAPI.GetRuleDescAsync(issue.rule).ConfigureAwait(true);

						rules.Add(ruleReport.Rule);
					}

					ReportDataSource DataSet1 = new ReportDataSource { Name = "Issues", Value = issuesReport.issues };

					reportViewer1.LocalReport.DataSources.Add(DataSet1);

					ReportDataSource DataSet2 = new ReportDataSource { Name = "Rules", Value = rules };

					reportViewer1.LocalReport.DataSources.Add(DataSet2);

					reportViewer1.RefreshReport();

				}
			}
		}
	}
}