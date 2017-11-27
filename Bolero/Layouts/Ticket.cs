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
            // TODO: This line of code loads data into the 'dSreport.ticket_rep' table. You can move, or remove it, as needed.
            this.ticket_repTableAdapter.Fill(this.dSreport.ticket_rep,id);
            
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
