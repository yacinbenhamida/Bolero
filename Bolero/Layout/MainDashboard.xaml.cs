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

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour MainDashboard.xaml
    /// </summary>
    public partial class MainDashboard : Window
    {
        protected int id = 0;
        public MainDashboard(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (id == 3)
            {
                AccesSessionCaissier2 acc = new AccesSessionCaissier2();
                acc.Visibility = Visibility.Visible;
            }
            else if (id == 2)
            {
                AccesSessionCaissier acc = new AccesSessionCaissier();
                acc.Visibility = Visibility.Visible;
            }
            else if (id == 1)
            {
                AccesSession acc = new AccesSession();
                acc.Visibility = Visibility.Visible;
            }
        }
    }
}
