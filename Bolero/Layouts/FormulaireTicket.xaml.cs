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
        public FormulaireTicket()
        {
            InitializeComponent();
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
         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
