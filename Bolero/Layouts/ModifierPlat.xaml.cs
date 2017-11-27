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
    /// Logique d'interaction pour ModifierPlat.xaml
    /// </summary>
    public partial class ModifierPlat : Window
    {
         public int idTransferred;
         Article a;
          ArticleDAO dao;
        public ModifierPlat(int idPlat)
        {          
            InitializeComponent();
            this.idTransferred = idPlat;
            dao = new ArticleDAO();
            a = dao.getById(idTransferred);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtNomPlat);
            txtprix.Text = a.Prix.ToString();
            txtNomPlat.Text = a.Libelle.ToString();
            ArticleDAO daoa = new ArticleDAO();
            
           if(a.IdCategorie.Equals(1))
            {
                cmbType.SelectedIndex = 0;
            }
            else if (a.IdCategorie.Equals(2))
            {
                cmbType.SelectedIndex = 1;
            }
            else if (a.IdCategorie.Equals(5))
            {
                cmbType.SelectedIndex = 2;
            }

           else if (a.IdCategorie.Equals(3))
            {
                cmbType.SelectedIndex = 4;
            }
           else if (a.IdCategorie.Equals(4))
            {
                cmbType.SelectedIndex = 5;
            }
            
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((!String.IsNullOrEmpty(txtNomPlat.Text)) && (!String.IsNullOrEmpty(txtprix.Text)) && (cmbType.SelectedIndex != -1) && cmbType.SelectedValue!=null && cmbType.SelectedItem !=null)
                {   CategorieDAO daoc=new CategorieDAO();
                    
                    int catg = daoc.getIdByLib(cmbType.Text);
                    Article ab = new Article(idTransferred, txtNomPlat.Text, decimal.Parse(txtprix.Text),catg);

                    if (dao.update(ab) == 1)
                    {
                        MessageBox.Show("màj faite!");
                        this.Close();
                    }
                    else MessageBox.Show("erreur!");
                }
                else MessageBox.Show("Vous devez remplir les champs !");
           }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        
    }
}
