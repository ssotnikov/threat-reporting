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

		private List<Facet> selectedParams = new List<Facet>();

		public string Query { get; set; }
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

					facetBindingSource.DataSource = dictionariesReport.facets;

					cmbParamTypes.SelectedItem = dictionariesReport.facets.Find(f => f.property == "projects");

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


			var facet = selectedParams.Find(f => f.property == selectedFacet.property);

			if (facet == null)
			{

				facet = new Facet
				{
					property = selectedFacet.property,

					values = new List<Value>()
				};
			}

			if (e.NewValue == CheckState.Checked && !facet.values.Contains(item))
			{

				facet.values.Add(item);

				if (selectedParams.Find(f => f.property == selectedFacet.property) == null)
				{
					selectedParams.Add(facet);
				}
			}

			if (e.NewValue == CheckState.Unchecked && facet.values.Find(i => i.val == item.val) != null)
			{

				facet.values.RemoveAll(i => i.val == item.val);

				if (facet.values.Count == 0)
				{

					selectedParams.Remove(facet);

				}
			}

			txtQuery.Text = QueryBuilder.Build(selectedParams);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Query = txtQuery.Text;
		}

		private void cmbParamTypes_SelectedValueChanged(object sender, EventArgs e)
		{

			lstParams.ItemCheck -= LstParams_ItemCheck;

			if (dictionariesReport != null)
			{

				var selectedFacet = (Facet)((ComboBox)sender).SelectedItem;

				var facet = dictionariesReport.facets.Find(f => f.property == selectedFacet.property);

				lstParams.Items.Clear();

				foreach (var item in facet.values)
				{

					lstParams.Items.Add(item);

				}


				var selectedParam = selectedParams.Find(f => f.property == selectedFacet.property);

				if (selectedParam != null)
				{

					var sValues = selectedParam.values;

					foreach (var value in sValues)
					{

						var inx = facet.values.FindIndex(i => i.val == value.val);

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
