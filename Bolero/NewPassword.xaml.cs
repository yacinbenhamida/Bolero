using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class NewPassword : Window
    {
        int idOfFetchedUser = 0;
        public NewPassword(int iduser)
        {
            InitializeComponent();
            idOfFetchedUser = iduser;
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
                if (txtNPW.Password.ToString() == "" || txtConfi.Password.ToString() == "") 
                {
                    MessageBox.Show("les deux champs sont requis !");
                    return;
                }
                if (txtNPW.Password.ToString().Contains(" ") || txtConfi.Password.ToString().Contains(" ")) 
                {
                    MessageBox.Show("Pas d'espaces dans votre mot de passe !");
                    return;
                }
                if (txtNPW.Password.Length < 4 || txtConfi.Password.Length < 4) 
                {
                    MessageBox.Show("Le mdp doit etre au moins de 5 caractéres");
                    return;
                }   
                
                  if (txtNPW.ToString() == txtConfi.ToString())
                     {
                      try
                            {
                        SqlConnection cnx = connexion.GetConnection();
                        SqlCommand cmd = new SqlCommand("UPDATE Utilisateur SET password=@pw WHERE Id=@id",cnx);
                        cmd.Parameters.AddWithValue("id",idOfFetchedUser);
                        cmd.Parameters.AddWithValue("pw", txtNPW.Password.ToString());
                          int ret = (int)cmd.ExecuteNonQuery();
                          MessageBox.Show("Mot de passe changé avec succés");
                          if (ret > 0) { this.Close(); 
                          } 
                             }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                      finally { connexion.closeConnection(); }
                     }   
                         
                     
                else{
                       MessageBox.Show("Les deux mot de passe ne sont pas identique !");
                       MessageBox.Show("Veuillez entre un nouveau mot de passe !");}
            }
            catch (Exception n)
            {
                MessageBox.Show(n.Message);
            }
        }
    }
}
