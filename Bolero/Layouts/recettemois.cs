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
    public partial class recettemois : Form
    {
        public recettemois()
        {
            InitializeComponent();
        }

        private void recettemois_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSreport.Commande1' table. You can move, or remove it, as needed.
            this.commande1TableAdapter.Fill(this.dSreport.Commande1);

            this.reportViewer1.RefreshReport();
        }
    }
}
