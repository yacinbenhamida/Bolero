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
using Bolero.DAL;
namespace Bolero.Layouts
{
    /// <summary>
    /// Logique d'interaction pour EnregCommeCredit.xaml
    /// </summary>
    public partial class EnregCommeCredit : Window
    {
        int id;
        decimal tot;
        CrediteurDAO credao = new CrediteurDAO();
        
        public EnregCommeCredit()
        {
            InitializeComponent();
        }
        public void setcmd(int idcmd)
        {
            this.id= idcmd;
            InitializeComponent();
        }
        public void settot(decimal tot)
        {
            this.tot = tot;
            InitializeComponent();
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            idcmd.Content = idcmd.Content+"  "+id ;
            lblDate.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Layouts.GestionCommandeCaissier CP = new GestionCommandeCaissier();
            CP.ShowDialog();
            }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            Crediteur c = new Crediteur();

            c.nomprenom = nomPrenom.Text.ToString();
            c.MontantCredit = float.Parse(montant.Text);
            c.tel = numTel.Text.ToString();
            c.adresse = adres.Text.ToString();
            c.cin = int.Parse(CIN.Text);
            c.Idcmd = id;


            if (credao.add(c) == 1) {
                MessageBox.Show("ajout térmminé!");
            }
            else MessageBox.Show("ajout nn térmminé!");

        }
    }
}
