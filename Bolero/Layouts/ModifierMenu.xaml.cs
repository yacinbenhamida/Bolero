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
        private List<Article> lstentree = new List<Article>();
        private List<Article> lstsuite = new List<Article>();
        private List<Article> lsthors = new List<Article>();
        private List<Article> lstdessert = new List<Article>();
        private List<Article> lstboissons = new List<Article>();
        private List<Article> lstplatdj = new List<Article>();
        public ModifierMenu()
        {
            InitializeComponent();
            entree.DataContext = lstentree;
            Suite.DataContext = lstsuite;
            boisson.DataContext = lstboissons;
            hrov.DataContext = lsthors;
            PJ.DataContext = lstplatdj;
            dessert.DataContext = lstdessert;
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
                lstentree = dao.getArticlesByType("entree");
                lstsuite= dao.getArticlesByType("suite");
                lstdessert = dao.getArticlesByType("dessert");
                lstboissons= dao.getArticlesByType("boisson");
                lsthors = dao.getArticlesByType("hors d'oeuvre");
                lstplatdj= dao.getArticlesByType("plat de jour");
                for (int j = 0; j < lstentree.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lstentree[j].IdArticle;
                    btn.Content = lstentree[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Green;
                    btn.Foreground = Brushes.White;
                    entree.Items.Add(btn);
                }
                for (int j = 0; j < lstsuite.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lstsuite[j].IdArticle;
                    btn.Content = lstsuite[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Red;
                    btn.Foreground = Brushes.White;
                    Suite.Items.Add(btn);
                }
            
                for (int j = 0; j < lsthors.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lsthors[j].IdArticle;
                    btn.Content = lsthors[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Gray;
                    btn.Foreground = Brushes.White;
                     hrov.Items.Add(btn);
                }
                for (int j = 0; j < lstboissons.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lstboissons[j].IdArticle;
                    btn.Content = lstboissons[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Blue;
                    btn.Foreground = Brushes.White;
                    boisson.Items.Add(btn);
                }
                for (int j = 0; j < lstdessert.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lstdessert[j].IdArticle;
                    btn.Content = lstdessert[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Purple;
                    btn.Foreground = Brushes.White;
                    dessert.Items.Add(btn);
                }
                for (int j = 0; j < lstplatdj.Count; j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + lstplatdj[j].IdArticle;
                    btn.Content = lstplatdj[j].Libelle;
                    btn.Click += new RoutedEventHandler(this.btn_Click);
                    btn.Background = Brushes.Yellow;
                    btn.Foreground = Brushes.Black;
                    PJ.Items.Add(btn);
                }
                //debugging
                //MessageBox.Show(lstentree.Count + "");
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
