using Bolero.BL;
using Bolero.DAL;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Bolero.Layouts
{
    /// <summary>
    /// Logique d'interaction pour ModifierCommande.xaml
    /// </summary>
    public partial class ModifierCommande : Window 
    {
        CommandeDAO cdao = new CommandeDAO();
        ArticleDAO adao = new ArticleDAO();

        int id;
        public ModifierCommande(int id)
        {
            this.id = id;
            MessageBox.Show(id.ToString());
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Article> lstFetchedArticles = new List<Article>();
            lstFetchedArticles = cdao.listArticle(id);
            dataGrid.DataContext = lstFetchedArticles;
            
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

        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
             NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int res = 0;
            int nbTable = int.Parse(txtNum.Text);
            ComboBoxItem selecteditem = (ComboBoxItem)(cmbClient.SelectedValue);
            String nServeur = (string)(selecteditem.Content);
            int id = 1;


            Commande c = new Commande(nbTable, DateTime.Now, nServeur, id);
            
           try
            {
                res = cdao.updateCommande(c,id);
                if (res == 0)
                {
                    MessageBox.Show("Update non effectue");
                }
                else
                {
                    MessageBox.Show("Update effectue");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            AffecterPlat affPlat = new AffecterPlat(id);
            affPlat.ShowDialog();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SuppArticle_Click(object sender, RoutedEventArgs e)
        {
            Article art = new Article();
            art = (Article)dataGrid.SelectedValue;
            int idArt = art.IdArticle;
            MessageBox.Show(idArt.ToString());
            ArticleDAO artDAO = new ArticleDAO();

            if (artDAO.deleteArticle(idArt, id) == 0)
            {
                MessageBox.Show("suppression non effectue");
            }
            else
            {
                MessageBox.Show("suppression effectue");
                dataGrid.DataContext = cdao.listArticle(id);
                dataGrid.Items.Refresh();
            }
        }
    }
}
