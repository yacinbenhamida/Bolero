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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Authentification : Window
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
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

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AccesSession admin = new AccesSession();
            admin.Show();
            this.Close();
        }

        private void btnCaissier1_Click(object sender, RoutedEventArgs e)
        {
            AccesSessionCaissier caissier1 = new AccesSessionCaissier();
            caissier1.Show();
            this.Close();
        }

        private void btnCaissier2_Click(object sender, RoutedEventArgs e)
        {
            AccesSessionCaissier2 caissier2 = new AccesSessionCaissier2();
            caissier2.Show();
            this.Close();
        }
    }
}
