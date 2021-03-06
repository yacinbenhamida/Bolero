﻿using System;
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
using System.Data;
namespace Bolero.Layouts
{
    /// <summary>
    /// Logique d'interaction pour GestionCommandeCaissier.xaml
    /// </summary>
    public partial class GestionCommandeCaissier : Window
    {
        public GestionCommandeCaissier()
        {
            InitializeComponent();
        }

        ArticleDAO dao = new ArticleDAO();
        private List<Commande> lstCom = new List<Commande>();
        private List<Article> lstentree = new List<Article>();
        private List<Article> lstsuite = new List<Article>();
        private List<Article> lsthors = new List<Article>();
        private List<Article> lstdessert = new List<Article>();
        private List<Article> lstboissons = new List<Article>();
        private List<Article> lstplatdj = new List<Article>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.DataContext = daoc.getAll();  
            lblDate.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            btnAnnuler.IsEnabled = false;
            
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
        
        List<Article> lstArticlesCmd = new List<Article>(); //articles commandés
        // les articles ajoutées au listBox
        private void callBack_AutoGenerated_Buttons(object sender, RoutedEventArgs e) 
        { 
            Button b = (Button)sender;
            idbtn = b.Name;
            //MessageBox.Show(idbtn + "");

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
        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }
        CommandeDAO daoc = new CommandeDAO();
        Commande tobeAdded;

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (platCmd.Items.Count == 0 || lstArticlesCmd.Count == 0 || cmbServ.SelectedIndex == -1 || cmbTable.SelectedIndex == -1 || cmbServ.Text == "Serveur" || cmbTable.Text == "Table")
            {
                MessageBox.Show("vous devez renseigner tous les champs! ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            else 
            {
                int NumTb = int.Parse(cmbTable.Text.Substring(6));
                string nomserv = cmbServ.Text;
                ServeurDAO daos = new ServeurDAO();
                Serveur s = new Serveur();
                s = daos.getByName(nomserv);
                tobeAdded = new Commande(0, NumTb, s.IdServeur, 2, DateTime.Now);
                if (daoc.addMultipleArticlesInOneC(lstArticlesCmd, tobeAdded) == 1)
                {
                    MessageBox.Show("inséré");
                    List<Commande> lstCom = new List<Commande>();
                    lstCom = daoc.getAll();
                    dataGrid.DataContext = lstCom;

                }
                else {
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

       
       


      

      

       

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGereUltil_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnModiMenu_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Paiement_Click(object sender, RoutedEventArgs e)
        {
            Layouts.PayementCommande payment = new Layouts.PayementCommande();
            payment.ShowDialog();
        }

        private void Fact_Click(object sender, RoutedEventArgs e)
        {
            Commande cm1 = (Commande)dataGrid.SelectedValue;
            int id = cm1.IdCommande;
            //MessageBox.Show(""+id);
            Bolero.Layouts.TK_et_FK tk = new Bolero.Layouts.TK_et_FK(id);
            
            DataSet DSreport = new DSreport();
            DSreport.Reset();
            
            tk.Show();

        }

        private void supp_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void modif_Click(object sender, RoutedEventArgs e)
        {
            Commande cm = new Commande();
             cm = (Commande)dataGrid.SelectedValue;
             int id = cm.IdCommande;
            Layouts.ModifierCommande modi = new Layouts.ModifierCommande(id);
            modi.ShowDialog();
        }
     
        private void btnrecettemois_Click(object sender, RoutedEventArgs e)
        {
            Bolero.Layouts.recettemois r = new Bolero.Layouts.recettemois();

            DataSet DSreport = new DSreport();
            DSreport.Reset();

            r.Show();
        }


        private void Paiement_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
