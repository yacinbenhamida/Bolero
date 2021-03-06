﻿using Bolero.BL;
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
        Commande cmd = new Commande();
        int id;
        decimal totalArticle = 0;
        decimal totalRemise = 0;
        public ModifierCommande(int id)
        {
            this.id = id;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServeurDAO daos = new ServeurDAO();
            lblComName.Content = "Commande N°"+ id;
            List<Article> lstFetchedArticles = new List<Article>();
            lstFetchedArticles = cdao.listArticle(id);
            dataGrid.DataContext = lstFetchedArticles;
          
            cmd = cdao.getById(id);
            txtNum.Text = cmd.NumTable.ToString();
            Serveur s = new Serveur();
            s = daos.getById(cmd.idserveur);
            if (s.Nom_Serveur == "Serveur 1")
            {
                cmbClient.SelectedIndex = 1;
            }
            else
            {
                cmbClient.SelectedIndex = 2;
            }
            for (int i = 0; i < lstFetchedArticles.Count; i++)
            {
                totalArticle = totalArticle + lstFetchedArticles[i].Prix;
                totalRemise = totalArticle - (totalArticle * decimal.Parse(txtRemise.Text) / 100);
            }
            lblTotal.Content = "Totale : " + totalRemise.ToString();
            
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
            cmdDown.IsEnabled = true;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(txtNum.Text) == 0)
            {
                cmdDown.IsEnabled = false;
            }
            else
            {

                NumValue--;

            }
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
            string nServeur = (string)(selecteditem.Content);
            ServeurDAO daos = new ServeurDAO();
            Serveur s = new Serveur();
            s = daos.getByName(nServeur);
            
            int idd = 1;


            Commande c = new Commande(id, nbTable, s.IdServeur, idd, DateTime.Now);
            
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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<Article> lstFetchedArticles = new List<Article>();
            lstFetchedArticles = cdao.listArticle(id);
            dataGrid.DataContext = lstFetchedArticles;
        }

        int _numRemise = 0;
        public int NumValueR
        {

            get { return _numRemise; }
            set
            {
                _numRemise = value;
                txtRemise.Text = value.ToString();
            }
        }

        private void txtRemise_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRemise == null)
            {
                return;
            }

            if (!int.TryParse(txtRemise.Text, out _numRemise))
                txtRemise.Text = _numRemise.ToString();
        }

        private void cmdUpRemise_Click(object sender, RoutedEventArgs e)
        {

            NumValueR++;
            cmdDownRemise.IsEnabled = true;
            totalRemise = totalArticle - (totalArticle * decimal.Parse(txtRemise.Text) / 100);
            lblTotal.Content = "Totale : " + totalRemise.ToString();
        }

        private void cmdDownRemise_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(txtRemise.Text) == 0)
            {
                cmdDownRemise.IsEnabled = false;
                totalRemise = totalArticle - (totalArticle * decimal.Parse(txtRemise.Text) / 100);
                lblTotal.Content = "Totale : " + totalRemise.ToString();
            }
            else
            {
                cmdDown.IsEnabled = true;
                NumValueR--;
                totalRemise = totalArticle - (totalArticle * decimal.Parse(txtRemise.Text) / 100);
                lblTotal.Content = "Totale : " + totalRemise.ToString();
            }
        }
    }
}
