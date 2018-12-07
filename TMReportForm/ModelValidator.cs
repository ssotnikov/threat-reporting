using System.Windows.Forms;
using TMReportSource;

namespace TMReportForm
{
	internal static class ModelValidator
	{
		internal static bool ThreatModelIsValid(ThreatModel model) {

			if (string.IsNullOrEmpty(model.MetaInformation[0].ThreatModelName))
			{

				var result = MessageBox.Show("Theat Model Name has not been defined. Please, fill up the model meta information");

				if (result == DialogResult.OK)
				{
					return false;
				}

			}

			return true;

		}
	}
}
