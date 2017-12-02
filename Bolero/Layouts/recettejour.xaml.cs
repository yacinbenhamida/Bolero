using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolero.Layouts
{
    /// <summary>
    /// Interaction logic for recettejour.xaml
    /// </summary>
    public partial class recettejour : Window
    {
        public recettejour()
        {
            InitializeComponent();
            reportrecettejour.Load += ReportViewer_Load;
            InitializeComponent();
        }
        private bool _isReportViewerLoaded;
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new
                  Microsoft.Reporting.WinForms.ReportDataSource();
                DSreport dataset = new DSreport();
                dataset.BeginInit();
                reportDataSource1.Name = "DataSet1";
                //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.DataTable2;
                this.reportrecettejour.LocalReport.DataSources.Add(reportDataSource1);
                this.reportrecettejour.LocalReport.ReportPath = "../../Layouts/recettejour.rdlc";
                dataset.EndInit();
                //fill data into WpfApplication4DataSet
                DSreportTableAdapters.DataTable2TableAdapter
                accountsTableAdapter = new
                DSreportTableAdapters.DataTable2TableAdapter();

                accountsTableAdapter.ClearBeforeFill = true;
                accountsTableAdapter.Fill(dataset.DataTable2);
                reportrecettejour.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
    }
}
