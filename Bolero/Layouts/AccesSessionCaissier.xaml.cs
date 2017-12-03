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
using System.Data.Sql;
using System.Net;
using System.Data;
using System.Net.Mail;
using Bolero;
using Bolero.BL;
using Bolero.DAL;
using Bolero.SL;
using Bolero.Layouts;


namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour AccesSessionCaissier.xaml
    /// </summary>
    public partial class AccesSessionCaissier : Window
    {
        public AccesSessionCaissier()
        {
            InitializeComponent();

        }
         private static int j = 0; //nb of tries
        List<User> lstU = new List<User>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtPW);
            lstU = UserDAO.getAllUsers();
            if (j == 5) {
                txtPW.IsEnabled = false;
                btnLogin.IsEnabled = false;
                txtNotice.Text = "CONNEXION BLOQUEE";
                txtNotice.Foreground = Brushes.Red;
            }
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
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {   
            if (!(txtPW.Password.ToString().Equals("")))
            {

                try
                {
                    if (LoginSecurity.checkPassword(txtPW.Password.ToString(), 2) == true)
                    {
                        GestionCommandeCaissier gcmd = new GestionCommandeCaissier();
                        this.Visibility = Visibility.Hidden;
                        gcmd.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("MDP ERRRONE");
                        j++;
                        txtNotice.Text = "Il vous reste " + j + " /5 tentatives";
                    }
                }
                catch (Exception exc)
                {
                    
                    MessageBox.Show(exc.Message);
                }
            }
            if (txtPW.Password.ToString().Equals(""))
            {
                MessageBox.Show("mot de passe requis");
                return;
            }
            
            if (j == 5)
            {
                DateTime now = DateTime.Now;
                try
                {
                    //check password
                    txtPW.IsEnabled = false;
                    btnLogin.IsEnabled = false;
                    txtNotice.Text = "CONNEXION BLOQUEE";
                    txtNotice.Foreground = Brushes.Red;
                    if ((txtPW.IsEnabled == false) && (now == DateTime.Now.AddMinutes(3)))
                    {
                        txtPW.IsEnabled = true;
                        btnLogin.IsEnabled = true;
                    }                  
                            //updating pw
                            int i = UserDAO.editUserPWAutomatically(1);
                            if (LoginSecurity.notifyAdminByEmail(2, "yacinbenhamida@hotmail.fr", "Yassine Ben Hamida") == 1)
                            {
                                MessageBox.Show("Le mot de passe a été changé automatiquement veuillez consulter votre mail");
                                
                            }
                    }             
                catch (Exception exe)
                {
                    MessageBox.Show("ERR "+exe.Message);
                }
                return;
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            QuestionSecrete question = new QuestionSecrete(2);
            question.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Authentification auth = new Authentification();
            auth.Show();
        }
    }
}
