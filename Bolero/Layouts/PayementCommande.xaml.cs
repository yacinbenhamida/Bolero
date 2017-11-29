using Bolero.BL;
using Bolero.DAL;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PayementCommande.xaml
    /// </summary>
    public partial class PayementCommande : Window
    {
        int id;
        int index;
        Commande c;
        public PayementCommande()
        {
            InitializeComponent();
        }
        public PayementCommande(int id, int index, GestionCommande g)
        {
            this.id = id;
            this.g = g;
            this.index = index;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtEspece);
            DAL.CommandeDAO daoc = new DAL.CommandeDAO();
            lblnumcmd.Content = id;
            c = daoc.getById(id);
            decimal sum = c.prixtotal;
            lbldatee.Content = c.datecommande;
            lblserveur.Content = c.idserveur;
            lblnumtab.Content = c.NumTable;
            lbltotal.Content = sum;
            lblDate.Content = DateTime.Now.ToShortDateString();
            lbldatee.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            txtEspece.Text = "" + c.prixtotal;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }
        GestionCommande g = new GestionCommande();
        private void btnpayer_Click(object sender, RoutedEventArgs e)
        {
            Layouts.Ticket_et_Facture t = new Ticket_et_Facture();
            t.setid(id);
            t.Show();
            this.Close();
            Commande c = new Commande();

            DAL.CommandeDAO daoc = new DAL.CommandeDAO();

            c = daoc.getById(id);

            DataSet DSreport = new DSreport();
            DSreport.Reset();
            List<Commande> lstCom = new List<Commande>();
            lstCom = daoc.getAll();
            g.dataGrid.DataContext = lstCom;
            g.PerformRefresh();
        }
        private void btnrouge_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnvert_Click(object sender, RoutedEventArgs e)
        {
            DAL.CommandeDAO daoc = new DAL.CommandeDAO();
            lblnumcmd.Content = id;
            c = daoc.getById(id);

            lbldatee.Content = c.datecommande;
            lblserveur.Content = c.idserveur;
            lblnumtab.Content = c.NumTable;
            lbltotal.Content = c.prixtotal;
            lblDate.Content = DateTime.Now.ToShortDateString();
            lbldatee.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();

            txtEspece.Clear();


        }
        private void btnespece_Click(object sender, RoutedEventArgs e)
        {
            decimal t;
            decimal t2;
            Decimal.TryParse(txtEspece.Text, out t);
            Decimal.TryParse(lbltotal.Content.ToString(), out t2);
            if (t > t2)
            {
                decimal rest = t2 - t;
                MessageBox.Show("reste de Commande = "+rest+"DT");
                Ticket tk = new Ticket();
                tk.setid(id);
                tk.Width = 355;
                tk.Height = 800;
                tk.ShowDialog();
                CommandeDAO daoc = new CommandeDAO();
                daoc.updateEtat(id);
                ChequeDAO daoch = new ChequeDAO();
                int lastch = daoch.getLastCheque() + 1;
                Payement pa = new Payement(1, id);
                PayementDAO daop = new PayementDAO();
                daop.addesp(pa);
                g.PerformRefresh();
                TableDAO table = new TableDAO();
                Commande c = daoc.getById(id);
                table.update(c.NumTable, false);
                this.Close();
            }
            else if(t<t2)
            {
                lbltotal.Content = t2 - t;
            }
            else {
                Ticket tk = new Ticket();
                tk.setid(id);
                tk.Width = 355;
                tk.Height = 800;
                tk.ShowDialog();
                CommandeDAO daoc = new CommandeDAO();
                daoc.updateEtat(id);
                
                ChequeDAO daoch = new ChequeDAO();
                
                

                int lastch = daoch.getLastCheque() + 1;

                
                


                Payement pa = new Payement(1, id);
                PayementDAO daop = new PayementDAO();
                daop.addesp(pa);
                g.PerformRefresh();
                TableDAO table = new TableDAO();
                Commande c = daoc.getById(id);
                table.update(c.NumTable, false);
                this.Close();
                
            }

        }
        private void btnticket_Click(object sender, RoutedEventArgs e)
        {


        }
        private void btncheque_Click(object sender, RoutedEventArgs e)
        {
            decimal pr;

            Decimal.TryParse(txtEspece.Text, out pr);
            FormulaireCheque ch = new FormulaireCheque(pr, this, id, g);
            ch.ShowDialog();
        }
        private void btnCredit_Click(object sender, RoutedEventArgs e)
        {
            Commande cm = new Commande();
            DAL.CommandeDAO daoc = new DAL.CommandeDAO();
            DAL.ServeurDAO daos = new DAL.ServeurDAO();
            Serveur s = new Serveur();
            s = daos.getById(c.idserveur);
            EnregCommeCredit credit = new EnregCommeCredit();
            c = daoc.getById(id);
            decimal sum = c.prixtotal;

            credit.montant.Text = c.prixtotal.ToString();
            credit.serv.Content = s.Nom_Serveur;
            credit.setcmd(id);

            credit.ShowDialog();
        }


    }
}
