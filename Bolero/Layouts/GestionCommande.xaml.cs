using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bolero.DAL;
using Bolero.BL;
using Microsoft.Reporting.WinForms;
using Bolero.Layouts;
namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class GestionCommande : Window
    {
        TableDAO daot = new TableDAO();
        ArticleDAO dao = new ArticleDAO();
        CommandeDAO cdao = new CommandeDAO();
        private List<BL.Table> listT = new List<BL.Table>();
        private List<Commande> lstCom = new List<Commande>();
        private List<Article> lstentree = new List<Article>();
        private List<Article> lstsuite = new List<Article>();
        private List<Article> lsthors = new List<Article>();
        private List<Article> lstdessert = new List<Article>();
        private List<Article> lstboissons = new List<Article>();
        private List<Article> lstplatdj = new List<Article>();

        public GestionCommande()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Decimal totalmois = 0;
            Decimal totaljour = 0;

            DateTime now = DateTime.Now;
            String month = now.Month.ToString();
            dataGridVente.DataContext = dao.historiqueArticle();
            dataGrid.DataContext = daoc.getAll();
            dgmois.DataContext = cdao.getAllMois();
                 dgjour.DataContext = cdao.getAllJour();
            totalmois = cdao.getAllMoistot();
            totaljour = cdao.getAlljourtot();
            totalibm.Content = "Total"+totalmois;
            totalibj.Content = "Total"+totaljour;
            jourlib.Content = DateTime.Now.ToShortDateString();
            moislib.Content = month.ToString() ;
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
                    case 3: btn.Background = Brushes.Green; break;
                    case 4: btn.Background = Brushes.Yellow; break;
                    case 5: btn.Background = Brushes.Blue; break;
                    case 6: btn.Background = Brushes.Violet; break;
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
        ServeurDAO daoserv = new ServeurDAO();
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
                
                ServeurDAO daos = new ServeurDAO();
                Serveur s = new Serveur();
                s = daos.getByName(cmbServ.Text);
                int idserv = s.IdServeur;         
                tobeAdded = new Commande(0,NumTb, idserv, 1,DateTime.Now);
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
                dataGridVente.DataContext = dao.historiqueArticle();
                this.PerformRefresh();
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
            ModifierMenu mm = new ModifierMenu();
           mm.ShowDialog();
        }

        private void Paiement_Click(object sender, RoutedEventArgs e)
        {
            Commande cm1 = (Commande)dataGrid.SelectedValue;
            int id = cm1.IdCommande;
            int index = dataGrid.SelectedIndex;
            Layouts.PayementCommande payment = new Layouts.PayementCommande(id, index, this);
            payment.ShowDialog();
        }
        public void PerformRefresh()
        {
            
            List<Commande> lstCom = new List<Commande>();
            lstCom = daoc.getAll();
            
            dataGrid.DataContext = lstCom;
            dataGrid.Items.Refresh();
            dgmois.DataContext = cdao.getAllMois();
            dgjour.DataContext = cdao.getAllJour();
            dgmois.Items.Refresh();
            dgjour.Items.Refresh();
            platCmd.Items.Clear();
            cmbServ.SelectedIndex = 0;
            cmbTable.SelectedIndex = 0;
        }
        private void Fact_Click(object sender, RoutedEventArgs e)
        {
            Commande cm1 = (Commande)dataGrid.SelectedValue;
            int id = cm1.IdCommande;
            
          
            DataSet DSreport = new DSreport();
            DSreport.Reset();
          
            TK_et_FK ne = new TK_et_FK(id);
            ne.ShowDialog();

        }

        private void supp_Click(object sender, RoutedEventArgs e)
        {
            Commande cm = (Commande)dataGrid.SelectedValue;

            int id = cm.IdCommande;

            if (cdao.delete(id) == 0)
            {
                MessageBox.Show("Suppresion non effectue");
            }

            else
            {
                dataGrid.DataContext = cdao.getAll();

                MessageBox.Show("Suppresion effectue");
            }
        
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
            Properties.Settings.Default.nombreArticle = 0;
            Properties.Settings.Default.totalPrix = 0;
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            artVendu.Text = Properties.Settings.Default.nombreArticle.ToString() + " Article Vendus";
            txtPrixVente.Text = Properties.Settings.Default.totalPrix.ToString() + " TND";
            Properties.Settings.Default.Save();
        }

        private void btnmois_Click(object sender, RoutedEventArgs e)
        {
            recettemois mois = new recettemois();
            mois.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            recettejour jour = new recettejour();
            jour.ShowDialog();
        }



        private void etat(Button button)
        {

            int i;

            string a = button.Name;
            string b = a.Substring(1, 1);

            listT = daot.getAll();


            for (i = 0; i < 10; i++)
                if (listT[i].Etat == true && listT[i].NumTable == int.Parse(b))
                {
                    button.IsEnabled = false;

                }
                else
                    button.IsEnabled = true;

        }

        private void t1_Click(object sender, RoutedEventArgs e)
        {
            etat(t1);
        }

        private void t2_Click(object sender, RoutedEventArgs e)
        {
            etat(t2);
        }

        private void t3_Click(object sender, RoutedEventArgs e)
        {
            etat(t3);
        }

        private void t4_Click(object sender, RoutedEventArgs e)
        {
            etat(t4);
        }

        private void t5_Click(object sender, RoutedEventArgs e)
        {
            etat(t5);
        }

        private void t6_Click(object sender, RoutedEventArgs e)
        {
            etat(t6);
        }

        private void t7_Click(object sender, RoutedEventArgs e)
        {
            etat(t7);
        }

        private void t8_Click(object sender, RoutedEventArgs e)
        {
            etat(t8);
        }

        private void t9_Click(object sender, RoutedEventArgs e)
        {
            etat(t9);
        }




    }
}