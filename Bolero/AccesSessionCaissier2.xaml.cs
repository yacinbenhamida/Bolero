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
using System.Net;
using System.Data;
using System.Net.Mail;

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour AccesSessionCaissier2.xaml
    /// </summary>
    public partial class AccesSessionCaissier2 : Window
    {
        private static char[] randomChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', '9', '0' };
        private static readonly Random rand = new Random(); 
       

        public AccesSessionCaissier2()
        {
            InitializeComponent();
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
        private static string getRandomPassword()
        {

            char[] password = new char[5];

            for (int i = 0; i < 5; ++i)

                password[i] = randomChars[rand.Next(0, randomChars.Length)];

            return new string(password);

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String sender1 = "test1@gmail.com ";
            String receiver = "test2@yahoo.fr";
            String email = getRandomPassword();
            String subject = "modification de mot de passe ";
            DateTime now = DateTime.Now;
            double minust = 15;
            int j = 0;
            SqlConnection cnx = connexion.GetConnection();
            string query = "select * from caissier where password ='" + txtPW.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnx);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                //    frmMain objFrmMain = new frmMain();
                this.Hide();
                // objFrmMain.Show();
            }
            else
            {
                MessageBox.Show("Check your  password !!");
                j++;
                if (j == 5)
                {
                    txtPW.IsEnabled = false;
                    if ((txtPW.IsEnabled == false) && (now == now.AddMinutes(minust)))
                    {
                        txtPW.IsEnabled = true;
                    }

                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cnx;
                        cmd.CommandText = "update caissier set  password = @newpass where Nom=@nom";
                        cmd.Parameters.Add("newpass", getRandomPassword().ToString());
                        cmd.Parameters.Add("nom","nom1");
                        int i = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }

                    SmtpClient cv = new SmtpClient("smpt.live.com", 25);
                    cv.EnableSsl = true;
                    cv.Credentials = new NetworkCredential("test1@gmail.com ", "1234");
                    try
                    {
                        cv.Send(sender1, receiver, subject, email);
                        MessageBox.Show("un Email est envoyé a l'administrateur ! ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("email non envoyé !! ! ");
                    }
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            QuestionSecrete question = new QuestionSecrete();
            question.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Authentification auth = new Authentification();
            auth.Show();
        }
    }
}
