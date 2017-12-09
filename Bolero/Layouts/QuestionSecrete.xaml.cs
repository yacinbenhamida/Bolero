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
using System.Data.SqlClient;
using System.Data;
using Bolero.SL;

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class QuestionSecrete : Window
    {
       private int id = 0;

        public QuestionSecrete(int iduser)
        {
            InitializeComponent();
            this.id = iduser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {

              //  MessageBox.Show(LoginSecurity.checkSecurityQuestionConformity(id, cmbQues.Text.ToString(), txtRep.Text.ToString())+"");
                if (LoginSecurity.checkSecurityQuestionConformity(id, cmbQues.Text.ToString(), txtRep.Text.ToString()) == 1)
                {
                    NewPassword NP = new NewPassword(id);
                    this.Close();
                    NP.Show();
                }
                else
                {
                    MessageBox.Show("vérifier la reponse svp !  !!");
                }
            }
            catch (Exception p) { MessageBox.Show(p.Message, "ERREUR"); }
        }
    }
}
