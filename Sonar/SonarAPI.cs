﻿using Sonar.Objects;
using Sonar.Objects.Common;
using Sonar.Properties;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sonar
{
	public class SonarAPI
	{
		private readonly HttpClient client = new HttpClient();
		private readonly Dictionaries dictionaries = new Dictionaries();

		public SonarAPI()
		{
			client.BaseAddress = new Uri(Settings.Default.SonarBaseUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<DictionariesReport> GetDictionariesAsync()
		{

			DictionariesReport dictionariesReport = null;

			HttpResponseMessage response = await client.GetAsync("issues/search?ps=1&facets=" + string.Join(",", dictionaries.FacetTypes) + "&additionalFields=_all");

			if (response.IsSuccessStatusCode)
			{
				dictionariesReport = await response.Content.ReadAsAsync<DictionariesReport>();
			}

			return dictionariesReport;
		}

		public async Task<IssuesReport> GetIssuesReportAsync(string query)
		{

			IssuesReport report = null;

			HttpResponseMessage response = await client.GetAsync("issues/search" + query + "&ps=500&facets=severities%2Ctypes&additionalFields=_all");

			if (response.IsSuccessStatusCode)
			{
				report = await response.Content.ReadAsAsync<IssuesReport>();
			}

			return report;
		}

		public async Task<RuleReport> GetRuleDescAsync(string ruleKey) {

			RuleReport report = null;

			HttpResponseMessage response = await client.GetAsync("rules/show?key=" + ruleKey);

			if (response.IsSuccessStatusCode)
			{
				report = await response.Content.ReadAsAsync<RuleReport>();
			}

			return report;
		}

		public async Task<List<Rule>> GetRulesDescAsync(IssuesReport issuesReport) {

			var selectedRules = issuesReport.Rules;

			List<Rule> result = new List<Rule>();

			foreach (var rule in selectedRules) {

				var report = await GetRuleDescAsync(rule.Key);

				result.Add(report.Rule);
			}

			return result;
		}
	}
}
