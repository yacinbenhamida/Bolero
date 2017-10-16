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

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class AccesSession : Window
    {
        private static char[] randomChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', '9', '0' };
        private static readonly Random rand = new Random();
        private static int j = 0; //nb of tries
        Authentification auth = new Authentification();
        public AccesSession()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (j == 5) {
                txtPW.IsEnabled = false;
                btnLogin.IsEnabled = false;
                txtNotice.Text = "CONNEXION BLOQUEE";
                if (auth.IsVisible || auth.IsActive || auth.IsLoaded ) auth.Close();
                
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

        private static string getRandomPassword()
        {
            char[] password = new char[5];
            for (int i = 0; i < 5; ++i)
            {
                password[i] = randomChars[rand.Next(0, randomChars.Length)];
            }
            return new string(password);

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx;
            if (j == 5)
            {
                DateTime now = DateTime.Now;
                try
                {
                    string newp = null;
                    cnx = Connexion.GetConnection();
                    string query = "select * from Utilisateur where password ='" + txtPW.Password.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, cnx);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);

                    txtPW.IsEnabled = false;
                    btnLogin.IsEnabled = false;
                    txtNotice.Text = "CONNEXION BLOQUEE";
                    txtNotice.Foreground = Brushes.Red;
                    if ((txtPW.IsEnabled == false) && (now == DateTime.Now.AddMinutes(3)))
                    {
                        txtPW.IsEnabled = true;
                        btnLogin.IsEnabled = true;
                    }
                    try
                    {
                        //updating pw
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cnx;
                        cmd.CommandText = "update Utilisateur set  password = @newpass where Nom=@nom";
                        newp = getRandomPassword().ToString();
                        cmd.Parameters.AddWithValue("newpass", newp);
                        cmd.Parameters.AddWithValue("nom", "Admin");
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0) MessageBox.Show("updating done");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ERR UPDATING");
                    }
                    //email here
                    var fromAddress = new MailAddress("zikoubenhmida@gmail.com", "Ben Hmida Zakaria");
                    var toAddress = new MailAddress("benhmida.zakaria@hotmail.com", "Zakaria Ben Hmida");
                    const string fromPassword = "afterlife18";
                    string sujet = "Changement du mot de passe du compte de votre compte (ADMIN)";
                    string body = "Nous avons remarqué des problemes de connectivité, voici  le nouveau mot de passe " + newp;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = sujet,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                        MessageBox.Show("Le mot de passe a été changé veuillez contacter l'admin", "Tentatives epuisées", MessageBoxButton.OK, MessageBoxImage.Stop);
                        AccesSession thisInstance = new AccesSession();
                        this.Close();
                        thisInstance.Show();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("ERR");
                }
                finally { Connexion.closeConnection(); }
                return;
            }

            if (txtPW.Password.ToString().Equals(""))
            {
                MessageBox.Show("mot de passe requis");
                return;
            }
            if (!(txtPW.Password.ToString().Equals("")))
            {

                try
                {
                    cnx = Connexion.GetConnection();
                    SqlCommand cmd = new SqlCommand("SELECT Count(*) from Utilisateur where password='" + txtPW.Password.ToString() + "' AND Nom='Admin'", cnx);
                    int verif = (int)cmd.ExecuteScalar();
                    if (verif == 0)
                    {
                        MessageBox.Show(" Mot de passe incorrecte");
                        j++;
                        txtNotice.Text = "il vous reste " + j + " /5 tentatives !";
                        return;
                    }
                    else if (verif > 0)
                    {
                        MainDashboard mdb = new MainDashboard(1);
                        mdb.Show();
                        this.Visibility = Visibility.Hidden;
                    }

                }
                catch (SqlException except)
                {
                    MessageBox.Show("BD ERROR" + except.Message);
                }
                finally { Connexion.closeConnection(); }

            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            QuestionSecrete question = new QuestionSecrete();
            question.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            auth.Show();
        }
    }
}
