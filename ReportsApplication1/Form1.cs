using Microsoft.Reporting.WinForms;
using ReportSource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

			ReportDataSource rds = new ReportDataSource
			{
				Name = "DataSet1",
				Value = ReportProcessor.GetReport()
			};

			reportViewer1.LocalReport.DataSources.Add(rds);

			reportViewer1.RefreshReport();

        }
    }
}