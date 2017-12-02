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
    /// Interaction logic for recettemois.xaml
    /// </summary>
    public partial class recettemois : Window
    {
        
        public recettemois()
        { 
            
          
            InitializeComponent();
            reportrecettemois.Load += ReportViewer_Load;
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
                reportDataSource1.Value = dataset.DataTable1;
                this.reportrecettemois.LocalReport.DataSources.Add(reportDataSource1);
                this.reportrecettemois.LocalReport.ReportPath = "../../Layouts/recettemois.rdlc";
                dataset.EndInit();
                //fill data into WpfApplication4DataSet
                DSreportTableAdapters.DataTable1TableAdapter
                accountsTableAdapter = new
                DSreportTableAdapters.DataTable1TableAdapter();

                accountsTableAdapter.ClearBeforeFill = true;
                accountsTableAdapter.Fill(dataset.DataTable1);
                reportrecettemois.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
    }
}
