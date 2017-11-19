using Bolero.BL;
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
    /// Interaction logic for PayementCommande.xaml
    /// </summary>
    public partial class PayementCommande : Window
    {
        int id;
        Commande c;
        public PayementCommande()
        {
            InitializeComponent();
        }
        public PayementCommande(int id)
        {
            this.id = id;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DAL.CommandeDAO daoc = new DAL.CommandeDAO();
            lblnumcmd.Content = id;
            c = daoc.getById(id);
            decimal sum = daoc.SumCommande(id);
            lbldatee.Content = c.DateCommande;
            lblserveur.Content = c.NomServeur;
            lblnumtab.Content = c.NumTable;
            lbltotal.Content = sum;
            lblDate.Content = DateTime.Now.ToShortDateString();
            lbldatee.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }

        private void btnpayer_Click(object sender, RoutedEventArgs e)
        {

        }

  
        private void btnrouge_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnvert_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnespece_Click(object sender, RoutedEventArgs e)
        {
            decimal t;
            decimal t2;
            Decimal.TryParse(txtEspece.Text, out t);
            Decimal.TryParse(lbltotal.Content.ToString(), out t2);
            if (t > t2)
            {
                MessageBox.Show("montont  invalid");
            }
            else
            {
                lbltotal.Content = t2 - t;
            }

        }
        private void btnticket_Click(object sender, RoutedEventArgs e)
        {
            decimal t;
            decimal t2;
            Decimal.TryParse(txtRest.Text,out t);
            Decimal.TryParse(lbltotal.Content.ToString(), out t2);
            if (t > t2)
            {
                MessageBox.Show("montont invalid");
            }
            else
            {
               lbltotal.Content=t2 - t;
            }
            
        }
        private void btncheque_Click(object sender, RoutedEventArgs e)
        {
            decimal t;
            decimal t2;
            Decimal.TryParse(txtCheque.Text, out t);
            Decimal.TryParse(lbltotal.Content.ToString(), out t2);
            if (t > t2 )
            {
                MessageBox.Show("montont  invalid");
            }
            else
            {
                lbltotal.Content = t2 - t;
            }
        }
        private void btnCredit_Click(object sender, RoutedEventArgs e)
        {
            Commande cm = new Commande();
            DAL.CommandeDAO daoc = new DAL.CommandeDAO();

            EnregCommeCredit credit = new EnregCommeCredit();
            c = daoc.getById(id);
            decimal sum = daoc.SumCommande(id);

            credit.montant.Text = sum.ToString();
            credit.serv.Content = c.NomServeur.ToString();
            credit.setcmd(id);
          
               credit.ShowDialog();
        }

      
    }
}
