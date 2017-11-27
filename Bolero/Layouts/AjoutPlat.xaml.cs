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
using Bolero.BL;
namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour AjoutPlat.xaml
    /// </summary>
    public partial class AjoutPlat : Window
    {
        ArticleDAO dao;
        Article a;
        public AjoutPlat()
        {
            InitializeComponent();
            dao = new ArticleDAO();
            a = new Article();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtNomPlat.Text)) && (!String.IsNullOrEmpty(txtprix.Text)) && (cmbType.SelectedIndex != -1) && cmbType.SelectedValue != null && cmbType.SelectedItem != null)
            {
                int lastFetchedId = dao.getNumberOfElements();
                a.Libelle = txtNomPlat.Text;
                a.Prix = Decimal.Parse(txtprix.Text);
                
                List<Article> l = new List<Article>();
                l=dao.getArticlesByType(cmbType.Text);
                a.IdCategorie = l[0].IdCategorie;
                a.IdArticle = lastFetchedId + 1;
                try
                {
                    if (!dao.find(a))
                    {
                        if (dao.add(a) == 1)
                        {
                            MessageBox.Show("ajouté avec succes");
                        }
                    }
                    else
                    {
                        MessageBox.Show("article déja ajouté");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                
            }  
        }

      
    }
}
