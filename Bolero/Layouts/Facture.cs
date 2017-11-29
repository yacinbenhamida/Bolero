using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bolero.Layouts
{
    public partial class Facture : Form
    {
        int id;
        public Facture()
        {
            InitializeComponent();
        }
        public void setid(int id)
        {
        this.id=id;}

        private void Facture_Load(object sender, EventArgs e)
        {
            this.ticket_repTableAdapter.Fill(this.dSreport.ticket_rep, id);
           //this.dataTable1TableAdapter.Fill(this.dSreport.DataTable1, id);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
