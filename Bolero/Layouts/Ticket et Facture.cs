﻿using System;
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
    public partial class Ticket_et_Facture : Form
    {
       int id;
        public Ticket_et_Facture()
        {
            InitializeComponent();
        }
        public void setid(int id)
        {
            this.id = id;
        }
        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ticket ticket= new Ticket();
            ticket.setid(id);
            ticket.MdiParent = this;
            ticket.Width = 355;
            ticket.Height = 800;
            ticket.Show();
        }

        private void factureToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Facture facture = new Facture();
            facture.setid(id);
            facture.MdiParent = this;
            facture.Show();
        }

       
    }
}

