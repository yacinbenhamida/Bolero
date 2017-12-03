using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bolero.BL;
using Bolero.DAL;
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
    /// Interaction logic for TK_et_FK.xaml
    /// </summary>
    public partial class TK_et_FK : Window
    {
        int id;
       
        public TK_et_FK(int id)
        {
            this.id = id;
            FactureDao daof = new FactureDao();
            CommandeDAO daoc = new CommandeDAO();
            Commande c = daoc.getById(id);
            Facture f = new Facture();

            f.totalHT = c.prixtotal - ((c.prixtotal * 18) / 100);
            f.totalTTC = c.prixtotal;
            f.totalTVA = ((c.prixtotal * 18) / 100);
            daof.add(f);
            daoc.updatefct(c, daof.getlastfct());
            
            InitializeComponent();
            reportTicket.Load += ReportViewer_Load;
            reportFacture.Load += ReportViewer2_Load;
        }
        private bool _isReportViewerLoaded;
        private bool _isReportViewerLoaded2;
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
                reportDataSource1.Value = dataset.ticket_rep;
                this.reportTicket.LocalReport.DataSources.Add(reportDataSource1);
                this.reportTicket.LocalReport.ReportPath = "../../Layouts/ticket.rdlc";
                dataset.EndInit();
                //fill data into WpfApplication4DataSet
                DSreportTableAdapters.ticket_repTableAdapter
                accountsTableAdapter = new
                DSreportTableAdapters.ticket_repTableAdapter();

                accountsTableAdapter.ClearBeforeFill = true;
                accountsTableAdapter.Fill(dataset.ticket_rep,id);
               reportTicket.RefreshReport();
                _isReportViewerLoaded = true;
            }
        }
        private void ReportViewer2_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded2)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new
                  Microsoft.Reporting.WinForms.ReportDataSource();
                DSreport dataset = new DSreport();
                dataset.BeginInit();
                reportDataSource1.Name = "DataSet1";
                //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.ticket_rep;
                this.reportFacture.LocalReport.DataSources.Add(reportDataSource1);
                this.reportFacture.LocalReport.ReportPath = "../../Layouts/repFacture.rdlc";
                dataset.EndInit();
                //fill data into WpfApplication4DataSet
                DSreportTableAdapters.ticket_repTableAdapter
                facture = new
                DSreportTableAdapters.ticket_repTableAdapter();

                facture.ClearBeforeFill = true;
                facture.Fill(dataset.ticket_rep,id);
               reportFacture.RefreshReport();
                _isReportViewerLoaded2 = true;
            }
        }

        
    }
}
