using SASTReportSource;
using System;
using System.Windows.Forms;

namespace TMReportForm
{
	public partial class SastParamsForm : Form
	{

		public string ReportName { get; private set; }

		public SastParamsForm()
		{
			InitializeComponent();
		}

		private async void SastParamsForm_Load(object sender, EventArgs e)
		{
			SonarSource ss = new SonarSource();

			SASTReportSource.Objects.ProjectsReport projectsReport = await ss.GetProjectsReportAsync().ConfigureAwait(true);

			if (projectsReport != null) {
				componentBindingSource.DataSource = projectsReport.components;
			}

		}

		private void cmdProjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			ReportName = cmdProjects.SelectedValue.ToString();
		}
	}
}
