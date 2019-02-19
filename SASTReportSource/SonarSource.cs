using SASTReportSource.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SASTReportSource
{
	public class SonarSource
	{
		private readonly HttpClient client = new HttpClient();

		public SonarSource() {
			client.BaseAddress = new Uri("http://localhost:9000/api/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<ProjectsReport> GetProjectsReportAsync() {

			ProjectsReport project = null;

			HttpResponseMessage response = await client.GetAsync("components/search_projects");

			if (response.IsSuccessStatusCode)
			{
				project = await response.Content.ReadAsAsync<ProjectsReport>();
			}

			return project;
		}

		public async Task<IssuesReport> GetIssuesReportAsync(string project, string types)
		{

			IssuesReport report = null;

			HttpResponseMessage response = await client.GetAsync("issues/search?componentKeys=" + project + "&types=" + types);

			if (response.IsSuccessStatusCode)
			{
				report = await response.Content.ReadAsAsync<IssuesReport>();
			}

			return report;
		}

	}
}
