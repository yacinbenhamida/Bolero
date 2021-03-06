﻿using Bolero.BL;
using Bolero.DAL;
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

namespace Bolero.Layouts
{
    /// <summary>
    /// Logique d'interaction pour AffecterPlat.xaml
    /// </summary>
    public partial class AffecterPlat : Window
    {
        ArticleDAO dao = new ArticleDAO();
        private List<Article> lstentree = new List<Article>();
        private List<Article> lstsuite = new List<Article>();
        private List<Article> lsthors = new List<Article>();
        private List<Article> lstdessert = new List<Article>();
        private List<Article> lstboissons = new List<Article>();
        private List<Article> lstplatdj = new List<Article>();

        int id;
        public AffecterPlat(int id)
        {
            this.id = id;
            MessageBox.Show(id.ToString());
            InitializeComponent();

            
            lblDate.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();

            /***************************/

            lstentree = dao.getArticlesByType("entree");
            lstsuite = dao.getArticlesByType("suite");
            lstdessert = dao.getArticlesByType("dessert");
            lstboissons = dao.getArticlesByType("boisson");
            lsthors = dao.getArticlesByType("hors d'oeuvre");
            lstplatdj = dao.getArticlesByEtat(true);

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
            if (hrov.Items.Count == 0)
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

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }

        Article a;

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            btnAnnuler.IsEnabled = true;
            Button b = (Button)sender;
            Button b2 = new Button();
            b2.Name = b.Name;
            b2.Content = b.Content;
            b2.Background = b.Background;
            b2.Foreground = b.Foreground;
            b2.Click += new RoutedEventHandler(this.callBack_AutoGenerated_Buttons);
            ArticleDAO daoart = new ArticleDAO();
            a = daoart.getById(Int32.Parse(b2.Name.Substring(3)));
            lstArticlesCmd.Add(a);
            platCmd.Items.Add(b2);
        }

       
        string idbtn = "";

        List<Article> lstArticlesCmd = new List<Article>();

        private void callBack_AutoGenerated_Buttons(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            idbtn = b.Name;
            MessageBox.Show(idbtn + "");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (platCmd.Items.Count == 0 || lstArticlesCmd.Count == 0)
            {
                MessageBox.Show("vous devez renseigner tous les champs! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            else
            {
                if (dao.addArticleOnCommande(lstArticlesCmd, id) == 1)
                {
                    MessageBox.Show("inséré");
                }
                else
                {
                    MessageBox.Show("la table est occupée !");
                    return;
                }

            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            platCmd.Items.Clear();
            lstArticlesCmd.Clear();
            btnAnnuler.IsEnabled = false;
        }

        private void btnDelArticle_Click(object sender, RoutedEventArgs e)
        {
            platCmd.Items.Remove(idbtn);
            lstArticlesCmd.Remove(a);
            platCmd.Items.Clear();
            for (int j = 0; j < lstArticlesCmd.Count; j++)
            {
                Button btn = new Button();
                btn.Name = "btn" + lstArticlesCmd[j].IdArticle;
                btn.Content = lstArticlesCmd[j].Libelle;
                btn.Click += new RoutedEventHandler(this.callBack_AutoGenerated_Buttons);
                int Type = lstArticlesCmd[j].IdCategorie;
                switch (Type)
                {
                    case 1: btn.Background = Brushes.Green; break;
                    case 2: btn.Background = Brushes.Red; break;
                    case 5: btn.Background = Brushes.Green; break;
                    
                    case 4: btn.Background = Brushes.Blue; break;
                    case 3: btn.Background = Brushes.Violet; break;
                }

                btn.Foreground = Brushes.Black;
                platCmd.Items.Add(btn);
            }

        }
    }
}
