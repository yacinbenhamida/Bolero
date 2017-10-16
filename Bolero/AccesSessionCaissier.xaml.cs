﻿using System;
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
    /// Logique d'interaction pour AccesSessionCaissier.xaml
    /// </summary>
    public partial class AccesSessionCaissier : Window
    {
        private static char[] randomChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', '9', '0' };
        private static readonly Random rand = new Random();
        private static int j = 0;

        public AccesSessionCaissier()
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
        private static string getRandomPassword()
        { char[] password = new char[5];
        for (int i = 0; i < 5; ++i)
        {
            password[i] = randomChars[rand.Next(0, randomChars.Length)];
        }
            return new string(password);

        }


        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
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
                    if ((txtPW.IsEnabled == false) && (now == DateTime.Now.AddMinutes(15)))
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
                        cmd.Parameters.AddWithValue("nom", "Caissier1");
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0) MessageBox.Show("updating done");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ERR UPDATING");
                    }
                    // ur email here
                    var fromAddress = new MailAddress("@gmail.com", "username");
                    var toAddress = new MailAddress("@hotmail.fr", "Admin");
                    const string fromPassword = "";
                    string sujet = "Changement du mot de passe du compte de votre caissier 1 ";
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
                    SqlCommand cmd = new SqlCommand("SELECT Count(*) from Utilisateur where password='" + txtPW.Password.ToString() + "' AND Nom='Caissier2'", cnx);
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
                        MainDashboard mdb = new MainDashboard(2);
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
            Authentification auth = new Authentification();
            auth.Show();
        }
    }
}
