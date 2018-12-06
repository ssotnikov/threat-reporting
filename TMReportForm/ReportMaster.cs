using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMReportSource;

namespace TMReportForm
{
	public partial class ReportMaster : Form
	{
		private ReportViewer _reportViewer;
		private ReportProcessor _reportProcessor;

		public ReportMaster(ReportViewer reportViewer, string reportType)
		{
			InitializeComponent();
			this._reportViewer = reportViewer;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnShowReport_Click(object sender, EventArgs e)
		{
			//TODO: Create Report Source
		}

	}
}
