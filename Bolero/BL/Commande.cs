using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Commande
    {
<<<<<<< HEAD
        public static int _IdC;
        public int IdCommande { get; set; }
        public int NumTable { get; set; }
        public DateTime DateCommande { get; set; }
       // public int IdArticle { get; set; }
        public string NomServeur { get; set; }
        public int Id { get; set; } // iduser
=======
        public int IdCommande { get; set; }
        public int NumTable { get; set; }
        public DateTime DateCommande { get; set; }
        public int IdArticle { get; set; }
        public string NomServeur { get; set; }
        public int Id { get; set; }
>>>>>>> origin/Gestion-COMMANDES

        public Commande(int numtable, DateTime datecommande, string nomserveur, int id)
        {
            this.IdCommande = System.Threading.Interlocked.Increment(ref _IdC);
            this.NumTable = numtable;
            this.DateCommande = datecommande;
            //this.IdArticle = IdArticle;
            this.NomServeur = nomserveur;
            this.Id = id;  
        }
    }
}
