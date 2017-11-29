using System;
using Bolero.DAL;
using Bolero.BL;
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
    /// Logique d'interaction pour FormulaireCheque.xaml
    /// </summary>
    public partial class FormulaireCheque : Window
    {
        decimal prix;
        public PayementCommande p;
        int com;
        GestionCommande g;
        public FormulaireCheque()
        {
            Keyboard.Focus(somme);
            InitializeComponent();
        }
        public FormulaireCheque(Decimal prix, PayementCommande p, int id, GestionCommande g)
        {
            InitializeComponent();
            this.prix = prix;
            this.p = p;
            this.com = id;
            this.g = g;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChequeDAO daoch = new ChequeDAO();
            int lastch = daoch.getLastCheque() + 1;
            idCheque.Text = "";//+ lastch;

        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            double som;
            string s = somme.Text.ToString();
            string cinC = cinClient.Text.ToString();
            string numC = numCheque.Text.ToString();

            if (somme.Text.ToString() == "" || numCheque.Text.ToString() == "" || nomClient.Text.ToString() == "" || cinClient.Text.ToString() == "")
            {
                MessageBox.Show("Les champs sant obligatoire !");
            }
            else if (!double.TryParse(s, out som))
            {
                MessageBox.Show("Montant doit etre un reel !");
            }

            else if (!double.TryParse(cinC, out som))
            {
                MessageBox.Show("CIN doit etre un entier !");
            }
            else if (!double.TryParse(numC, out som))
            {
                MessageBox.Show("Numéro du compte doit etre un entier !");
            }
            else if (nomClient.Text == "")
            {
                MessageBox.Show("Nom et prénom incorect !");
            }
            decimal sum;

            decimal.TryParse(somme.Text, out sum);
            if (prix == sum)
            {

                Ticket tk = new Ticket();
                tk.setid(com);
                tk.Width = 355;
                tk.Height = 800;
                tk.ShowDialog();
                CommandeDAO daoc = new CommandeDAO();
                daoc.updateEtat(com);
                decimal some;
                DateTime d;
                ChequeDAO daoch = new ChequeDAO();
                DateTime.TryParse(dateCheque.Text, out d);
                Decimal.TryParse(somme.Text, out some);

                int lastch = daoch.getLastCheque() + 1;

                Cheque cheque = new Cheque(some, d, nomClient.Text, cinClient.Text, numCheque.Text);
                daoch.add(cheque);


                Payement pa = new Payement(1, lastch, com);
                PayementDAO daop = new PayementDAO();
                daop.addPaycheque(pa);
                g.PerformRefresh();
                TableDAO table = new TableDAO();
                Commande c = daoc.getById(com);
                table.update(c.NumTable, false);
                this.Close();
                p.Close();
            }
            else
            {
                decimal res = prix - sum;
                this.p.txtEspece.Text = "" + res;
                this.p.lbltotal.Content = "" + res;
                decimal some;
                DateTime d;
                ChequeDAO daoch = new ChequeDAO();
                DateTime.TryParse(dateCheque.Text, out d);
                Decimal.TryParse(somme.Text, out some);

                int lastch = daoch.getLastCheque() + 1;
                Cheque cheque = new Cheque(some, d, nomClient.Text, cinClient.Text, numCheque.Text);
                daoch.add(cheque);
                Payement p = new Payement(lastch, com);
                PayementDAO daop = new PayementDAO();
                daop.add(p);

                this.Close();
                //g.PerformRefresh();

            }
        }

        private void somme_GotFocus(object sender, RoutedEventArgs e)
        {
            somme.Text = "";
        }
        private void numCheque_GotFocus(object sender, RoutedEventArgs e)
        {
            numCheque.Text = "";
        }
        private void nomClient_GotFocus(object sender, RoutedEventArgs e)
        {
            nomClient.Text = "";
        }

        private void cinClient_GotFocus(object sender, RoutedEventArgs e)
        {
            cinClient.Text = "";
        }
    }
}
