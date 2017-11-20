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
    public partial class Ticket : Form
    {
        int id;
        public Ticket()
        {
            InitializeComponent();
        }
        public void setid(int id)
        {
            this.id = id;
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.dSreport.DataTable1, id);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
