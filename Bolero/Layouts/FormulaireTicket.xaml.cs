using Bolero.BL;
using Bolero.DAL;
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
    /// Logique d'interaction pour FormulaireTicket.xaml
    /// </summary>
    public partial class FormulaireTicket : Window
    {
        decimal prix;
      public PayementCommande p;
        int com;
        GestionCommande g;
        public FormulaireTicket()
        {
            Keyboard.Focus(txtSomme);
            InitializeComponent();
        }
        public FormulaireTicket(decimal prix,PayementCommande p, int id, GestionCommande g)
        {
            InitializeComponent();
            this.prix = prix;
            this.p = p;
            this.com = id;
            this.g = g;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            

        }
        private void txtSomme_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSomme.Text = "";
        }

        private void txtDate_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDate.Text = "";
        }

        private void txtNomSo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNomSo.Text = "";
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            double som;
            string s = txtSomme.Text.ToString();

            if (txtSomme.Text.ToString() == "" || txtDate.Text.ToString() == "" || txtNomSo.Text.ToString() == "")
            {
                MessageBox.Show("Les champs sant obligatoire !");
            }
            else if (!double.TryParse(s, out som))
            {
                MessageBox.Show("Montant doit etre un reel !");
            }
            decimal sum;

            decimal.TryParse(txtSomme.Text, out sum);
            sum = sum - ((sum * 10) / 100);
            if (sum >= prix)
            {
                TK_et_FK tk = new TK_et_FK(com);
                

                tk.ShowDialog();
                CommandeDAO daoc = new CommandeDAO();
                daoc.updateEtat(com);
                decimal some;
                DateTime d;
                TicketDAO daoch = new TicketDAO();
                DateTime.TryParse(txtDate.Text, out d);
                Decimal.TryParse(txtSomme.Text, out some);
                int lastch = daoch.getLasttk();
                Ticket tkt = new Ticket(some, d, txtNomSo.Text);

                Payement pa = new Payement(lastch, 1, com, sum);
                PayementDAO daop = new PayementDAO();
                daop.addPayTicket(pa);
                g.PerformRefresh();
                TableDAO table = new TableDAO();
                Commande c = daoc.getById(com);
                table.update(c.NumTable, false);
                decimal res = prix - sum;
                this.p.txtEspece.Text = "" + res;
                this.p.lbltotal.Content = "" + res;
                this.Close();
                p.Close();
                g.PerformRefresh();
            }
            else
            {
                
                CommandeDAO daoc = new CommandeDAO();
                
                decimal some;
                DateTime d;
                TicketDAO daoch = new TicketDAO();
                DateTime.TryParse(txtDate.Text, out d);
                Decimal.TryParse(txtSomme.Text, out some);
                int lastch = daoch.getLasttk();
                Ticket tkt = new Ticket(some, d, txtNomSo.Text);
                decimal cl = some - ((some * 10)/100);
                Payement pa = new Payement(lastch, 1, com, cl);
                PayementDAO daop = new PayementDAO();
                daop.addPayTicket(pa);
                g.PerformRefresh();
                TableDAO table = new TableDAO();
                Commande c = daoc.getById(com);
                
                decimal res = prix - cl;
                this.p.txtEspece.Text = "" + res;
                this.p.lbltotal.Content = "" + res;
                this.Close();
                g.PerformRefresh();
            }
            
           
        }


        
    }
}