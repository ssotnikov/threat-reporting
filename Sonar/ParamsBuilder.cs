using Sonar.Helpers;
using Sonar.Objects;
using Sonar.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sonar
{
	public partial class ParamsBuilder : Form
	{
		private SonarAPI sonarAPI = new SonarAPI();

		private DictionariesReport dictionariesReport;

		private List<Facet> selectedFacets = new List<Facet>();

		public string QueryString { get; set; }

		public List<QueryParam> QueryParams { get; set; }

		public ParamsBuilder()
		{
			InitializeComponent();
		}

		private async void ParamsBuilder_LoadAsync(object sender, EventArgs e)
		{
			try
			{
				Enabled = false;

				dictionariesReport = await sonarAPI.GetDictionariesAsync().ConfigureAwait(true);

				if (dictionariesReport != null)
				{

					facetBindingSource.DataSource = dictionariesReport.Facets;

					cmbParamTypes.SelectedItem = dictionariesReport.Facets.Find(f => f.Property == "projects");

					Enabled = true;

				}
			}
			catch (Exception ex)
			{

				DialogResult dr;

				if (ex.InnerException.Message == "Unable to connect to the remote server")
				{

					dr = MessageBox.Show(string.Format("SonarQube is not running at {0}", Settings.Default.SonarBaseUrl));

				}
				else
				{

					dr = MessageBox.Show(ex.InnerException.Message);

				}

				if (dr == DialogResult.OK)
				{

					Enabled = true;

					Close();

				}
			}

		}

		private void LstParams_ItemCheck(object sender, ItemCheckEventArgs e)
		{

			var selectedFacet = (Facet)cmbParamTypes.SelectedItem;

			var item = (Value)lstParams.Items[e.Index];


			var facet = selectedFacets.Find(f => f.Property == selectedFacet.Property);

			if (facet == null)
			{

				facet = new Facet
				{
					Property = selectedFacet.Property,

					Values = new List<Value>()
				};
			}

			if (e.NewValue == CheckState.Checked && !facet.Values.Contains(item))
			{

				facet.Values.Add(item);

				if (selectedFacets.Find(f => f.Property == selectedFacet.Property) == null)
				{
					selectedFacets.Add(facet);
				}
			}

			if (e.NewValue == CheckState.Unchecked && facet.Values.Find(i => i.Val == item.Val) != null)
			{

				facet.Values.RemoveAll(i => i.Val == item.Val);

				if (facet.Values.Count == 0)
				{

					selectedFacets.Remove(facet);

				}
			}

			txtQuery.Text = QueryBuilder.Build(selectedFacets);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			QueryString = txtQuery.Text;

			QueryParams = QueryBuilder.GetQueryParams(selectedFacets);
		}

		private void cmbParamTypes_SelectedValueChanged(object sender, EventArgs e)
		{

			lstParams.ItemCheck -= LstParams_ItemCheck;

			if (dictionariesReport != null)
			{

				var selectedFacet = (Facet)((ComboBox)sender).SelectedItem;

				var facet = dictionariesReport.Facets.Find(f => f.Property == selectedFacet.Property);

				lstParams.Items.Clear();

				foreach (var item in facet.Values)
				{

					lstParams.Items.Add(item);

				}


				var selectedParam = selectedFacets.Find(f => f.Property == selectedFacet.Property);

				if (selectedParam != null)
				{

					var sValues = selectedParam.Values;

					foreach (var value in sValues)
					{

						var inx = facet.Values.FindIndex(i => i.Val == value.Val);

						if (inx > -1)
						{

							lstParams.SetItemChecked(inx, true);

						}

					}

				}

			}

			lstParams.ItemCheck += LstParams_ItemCheck;
		}
	}
}
