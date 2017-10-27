using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Commande
    {
        public int IdCommande { get; set; }
        public int NumTable { get; set; }
        public DateTime DateCommande { get; set; }
        public int IdArticle { get; set; }
        public string NomServeur { get; set; }
        public int Id { get; set; }

        public Commande(int idcommande, int numtable, DateTime datecommande, int idarticle, string nomserveur, int id)
        {
            this.IdCommande = idcommande;
            this.NumTable = numtable;
            this.DateCommande = datecommande;
            this.IdArticle = idarticle;
            this.NomServeur = nomserveur;
            this.Id = id;  
        }
    }
}
