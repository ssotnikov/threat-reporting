using Microsoft.Reporting.WinForms;
using Newtonsoft.Json.Linq;
using Sonar;
using Sonar.Helpers;
using Sonar.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
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
		private TMTReportProcessor tmtReportProcessor;
		private JObject reportTypes;
		private SonarReportProcessor sonarReportProcessor = new SonarReportProcessor();
		public ReportForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			EnableReportTypeButtons(false);
			btnGenerateReport.Enabled = false;
			CreateMenu(mnuSelectSonarReportTypes, @"SonarReportTypes.json");
		}

		private void EnableReportTypeButtons(bool enable)
		{
			mnuSelectThreatModelReportType.Enabled = enable;
		}

		private void CreateMenu(ToolStripDropDownButton mnuParent, string configFilePath)
		{
			using (StreamReader r = new StreamReader(configFilePath))
			{
				var jsSource = r.ReadToEnd();
				this.reportTypes = JObject.Parse(jsSource);
				var reportTypes = this.reportTypes["ReportTypes"].ToList();

				if (reportTypes.Count > 0)
				{
					mnuParent.DropDownItems.Clear();
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
							if (mnuParent.Tag.ToString() == "ThreatModel")
							{
								reportTypeMenuItem.Click += ThreatModelReportTypeMenuItem_Click;
							}
							if (mnuParent.Tag.ToString() == "Sonar")
							{
								reportTypeMenuItem.Click += SonarReportTypeMenuItem_Click;
							}
							mnuParent.DropDownItems.Add(reportTypeMenuItem);
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
							mnuParent.DropDownItems.Add(new ToolStripSeparator());
						}
					}
				}
			}

		}

		private void ThreatModelReportTypeMenuItem_Click(object sender, EventArgs e)
		{
			btnGenerateReport.Enabled = false;

			reportViewer1.Reset();

			foreach (object item in mnuSelectThreatModelReportType.DropDownItems)
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

			Text = string.Format(CultureInfo.InvariantCulture, "{0}: {1}", threatModelFileName.Split('.')[0], reportType);

		}

		private async void SonarReportTypeMenuItem_Click(object sender, EventArgs e)
		{
			sonarReportProcessor.ParamsBuilder.ShowDialog();

			if (sonarReportProcessor.ParamsBuilder.DialogResult == DialogResult.OK)
			{

				reportViewer1.Reset();

				IssuesReport issuesReport = await sonarReportProcessor.SonarAPI.GetIssuesReportAsync(sonarReportProcessor.ParamsBuilder.QueryString).ConfigureAwait(true);

				reportViewer1.LocalReport.ReportPath = string.Format(CultureInfo.InvariantCulture, "Reports/{0}.rdlc", ((ToolStripMenuItem)sender).Tag.ToString());

				if (issuesReport != null)
				{

					reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource);

					//ReportDataSource DataSet1 = new ReportDataSource { Name = "Issues", Value = issuesReport.Issues };

					//reportViewer1.LocalReport.DataSources.Add(DataSet1);

					List<Rule> rules = await sonarReportProcessor.SonarAPI.GetRulesDescAsync(issuesReport).ConfigureAwait(true);

					ReportDataSource DataSet2 = new ReportDataSource { Name = "Rules", Value = rules };

					reportViewer1.LocalReport.DataSources.Add(DataSet2);

					ReportDataSource DataSet3 = new ReportDataSource { Name = "Params", Value = sonarReportProcessor.ParamsBuilder.QueryParams };

					reportViewer1.LocalReport.DataSources.Add(DataSet3);

					reportViewer1.RefreshReport();

				}
			}
		}

		private async void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
		{

			string ruleKey = e.Parameters["ruleKey"].Values[0];
			
			string dataSourceName = e.DataSourceNames[0];

			IssuesReport issuesReport = await sonarReportProcessor.SonarAPI.GetIssuesReportAsync(sonarReportProcessor.ParamsBuilder.QueryString).ConfigureAwait(true);

			ReportDataSource DataSet1 = new ReportDataSource { Name = "Issues", Value = issuesReport.Issues };

			e.DataSources.Add(DataSet1);

		}

		private void btnGenerateReport_Click(object sender, EventArgs e)
		{
			mnuSelectThreatModelReportType.Enabled = false;

			reportViewer1.LocalReport.DataSources.Clear();

			LoadThreatReport();

			reportViewer1.RefreshReport();

			mnuSelectThreatModelReportType.Enabled = true;
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

				CreateMenu(mnuSelectThreatModelReportType, @"ThreatModellerReportTypes.json");

				EnableReportTypeButtons(true);

				tmtReportProcessor = new ThreatModeller.TMTReportProcessor(threatModelFilePath);

			}
		}

		private void LoadReport()
		{

			EnableReportTypeButtons(false);

			reportViewer1.LocalReport.ReportPath = string.Format(CultureInfo.InvariantCulture, "Reports/{0}.rdlc", reportType);

		}

		private void LoadThreatReport()
		{

			LoadReport();

			CreateThreatModelReportDataSource();

			EnableReportTypeButtons(true);

		}

		private void CreateThreatModelReportDataSource()
		{
			if (reportType == "MitigatedComponents")
			{
				ReportDataSource DataSet1 = new ReportDataSource { Name = "Threats", Value = tmtReportProcessor.GetThreatsGroupedByMitigatedComponent() };

				reportViewer1.LocalReport.DataSources.Add(DataSet1);

			}
			else
			{

				ReportDataSource DataSet1 = new ReportDataSource { Name = "Threats", Value = tmtReportProcessor.GetThreats() };

				reportViewer1.LocalReport.DataSources.Add(DataSet1);

			}

			ReportDataSource DataSet2 = new ReportDataSource { Name = "Notes", Value = tmtReportProcessor.GetNotes() };

			reportViewer1.LocalReport.DataSources.Add(DataSet2);

			ReportDataSource DataSet3 = new ReportDataSource { Name = "Meta", Value = tmtReportProcessor.GetMetaInformation() };

			reportViewer1.LocalReport.DataSources.Add(DataSet3);

			var ps = reportParams.FirstOrDefault(i => i.Key == reportTitle).Value;

			if (ps.Count > 0)
			{

				reportViewer1.LocalReport.SetParameters(ps);

			}

		}

	}
}