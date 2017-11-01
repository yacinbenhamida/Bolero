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
        private int Id { get; set; }
        ArticleDAO dao = new ArticleDAO();
       
        private List<Article> lstentree = new List<Article>();
        private List<Article> lstsuite = new List<Article>();
        private List<Article> lsthors = new List<Article>();
        private List<Article> lstdessert = new List<Article>();
        private List<Article> lstboissons = new List<Article>();
        private List<Article> lstplatdj = new List<Article>();
        public ModifierMenu()
        {
            InitializeComponent();
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
            
        }

        public void initUI() 
        {
            lstentree = dao.getArticlesByType("entree");
            lstsuite = dao.getArticlesByType("suite");
            lstdessert = dao.getArticlesByType("dessert");
            lstboissons = dao.getArticlesByType("boisson");
            lsthors = dao.getArticlesByType("hors d'oeuvre");
            lstplatdj = dao.getArticlesByType("plat du jour");

            entree.DataContext = lstentree;
            Suite.DataContext = lstsuite;
            boisson.DataContext = lstboissons;
            hrov.DataContext = lsthors;
            PJ.DataContext = lstplatdj;
            dessert.DataContext = lstdessert;
            if (entree.Items.Count == 0)
            {
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
            }
            if (Suite.Items.Count == 0)
            {
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
            }
            if (hrov.Items.Count==0)
            {
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
            }
            if (boisson.Items.Count == 0)
            {
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
            }
            if (dessert.Items.Count == 0)
            {
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
            }
            if (PJ.Items.Count == 0)
            {
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
            }
        }
        private void clearUI(string tab) 
        {
            switch (tab)
            {
                case ("entree"):
                    entree.Items.Clear();break;
                case ("suite"):
                    Suite.Items.Clear();break;
                case ("boisson"):
                    boisson.Items.Clear(); break;
                case ("hors d'oeuvre"):
                    hrov.Items.Clear(); break;
                case ("plat du jour"):
                    PJ.Items.Clear(); break;
                case ("dessert"):
                    dessert.Items.Clear(); break;

            }
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
                initUI();

            }
            catch (Exception exc) 
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            btnModifier.IsEnabled = true;
            btnSupprimer.IsEnabled = true;
            Button b = (Button)sender;
            String nombtn=b.Name.Substring(3);
           Id = Int32.Parse(nombtn);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String nombtn=b.Name.Substring(3);
            if (nombtn != null)
            {
                dao.delete(Id);
                MessageBox.Show("article supprimé");
                lstentree = dao.getArticlesByType("entree");
                refreshTabs();
                initUI();
            }
            else MessageBox.Show("vous devez selectionner un article !");
          
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            ModifierPlat modif = new ModifierPlat(Id);
            modif.Closing += new System.ComponentModel.CancelEventHandler(this.Window2_Closing);
                modif.ShowDialog();
                
        }

      
        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sauvegardé !");
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {   
            AjoutPlat ajout = new AjoutPlat();
            ajout.Closing += new System.ComponentModel.CancelEventHandler(this.Window3_Closing);
            ajout.ShowDialog();
        }

        private void refreshTabs() 
        {
            if (tbEnt.IsSelected)
            {
                clearUI("entree");
            }
            else if (tbDes.IsSelected)
            {
                clearUI("dessert");
            }
            else if (tbHO.IsSelected)
            {
                clearUI("hors d'oeuvre");
            }
            else if (tbPJ.IsSelected)
            {
                clearUI("plat du jour");
            }
            else if (tbSuite.IsSelected)
            {
                clearUI("suite");
            }
            else if (tbBoiss.IsSelected)
            {
                clearUI("boisson");
            }
        }

        private void Window3_Closing(object sender, EventArgs e)
        {
            refreshTabs();
            initUI();
        }

        private void Window2_Closing(object sender, EventArgs e)
        {
            refreshTabs();
            initUI();
        }
        
       
    }
}
