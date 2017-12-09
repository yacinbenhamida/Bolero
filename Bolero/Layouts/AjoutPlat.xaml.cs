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
        CategorieDAO catDAO = new CategorieDAO();
        Article a;
        string tbSel;
        public AjoutPlat(string tbSel)
        {
            InitializeComponent();
            dao = new ArticleDAO();
            a = new Article();
            this.tbSel = tbSel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtNomPlat);
            if (tbSel == "entree")
            {
                cmbType.SelectedIndex = 0;
            }
            else if (tbSel == "suite")
            {
                cmbType.SelectedIndex = 1;
            }
            else if (tbSel == "hors d'oeuvre")
            {
                cmbType.SelectedIndex = 2;
            }
            else if (tbSel == "dessert")
            {
                cmbType.SelectedIndex = 3;
            }
            else if (tbSel == "boisson")
            {
                cmbType.SelectedIndex = 4;
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtNomPlat.Text)) && (!String.IsNullOrEmpty(txtprix.Text)) && (cmbType.SelectedIndex != -1) && cmbType.SelectedValue != null && cmbType.SelectedItem != null)
            {
                //int lastFetchedId = dao.getNumberOfElements();
                a.Libelle = txtNomPlat.Text;
                a.Prix = Decimal.Parse(txtprix.Text);

                //List<Article> l = new List<Article>();
                int l = catDAO.getIdByLib(cmbType.Text);
                a.IdCategorie = l;
                //a.IdArticle = lastFetchedId + 1;
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
                catch (Exception ex) { MessageBox.Show(ex.Message, "ERREUR"); }
                
            }  
        }

      
    }
}
