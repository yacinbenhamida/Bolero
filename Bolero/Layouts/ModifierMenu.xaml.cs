using Bolero.BL;
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
using Bolero.DAL;
namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour ModifierMenu.xaml
    /// </summary>
    public partial class ModifierMenu : Window
    {
        private List<Article> lstA = new List<Article>();
        public ModifierMenu()
        {
            InitializeComponent();
            this.DataContext = lstA;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblDate.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            try
            {
                //affichage des entrées 
                ArticleDAO dao = new ArticleDAO();
                lstA = dao.getArticlesByType("entree");
                for (int j = 0; j < lstA.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lstA[j].IdArticle;
                    btn.Content = lstA[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Blue;
                    btn.Foreground = Brushes.White;
                    entree.Items.Add(btn);
                }
                //debugging
                MessageBox.Show(lstA.Count + "");
                // a completer pour les autres articles....

            }
            catch (Exception exc) 
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show(b.Name + "");
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            ModifierPlat modif = new ModifierPlat();
                modif.ShowDialog();
        }

        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjoutPlat ajout = new AjoutPlat();
            ajout.ShowDialog();
        }
    }
}
