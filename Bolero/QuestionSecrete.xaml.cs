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

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class QuestionSecrete : Window
    {
        public QuestionSecrete()
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

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection cnx = connexion.GetConnection();
                string question = cmbQues.Text.ToString();
                string query = "select * from Utilisateur where choixqs ='" + question+ "'and questionsecrete ='" + txtRep.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, cnx);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    int iduser = 0;
                    foreach (DataRow row in dtbl.Rows)
                    {
                        iduser = (int)row["Id"];

                    }
                    NewPassword NP = new NewPassword(iduser);
                    this.Close();
                    NP.Show();
                }
                else
                {
                    MessageBox.Show("vérifier la reponse svp !  !!");
                }


            }
            catch (Exception p) { MessageBox.Show(p.Message); }


        }
    }
}
