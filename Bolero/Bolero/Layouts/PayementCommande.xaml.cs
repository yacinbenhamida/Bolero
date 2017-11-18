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
        public PayementCommande()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        }

        private void btnvert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCredit_Click(object sender, RoutedEventArgs e)
        {
            EnregCommeCredit credit = new EnregCommeCredit();
            credit.ShowDialog();
        }

      
    }
}
