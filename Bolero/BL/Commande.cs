using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Commande
    {
        private int IdCommande { get; set; }
        private int NumTable { get; set; }
        private DateTime DateCommande { get; set; }
        private int IdArticle { get; set; }
        private string NomServeur { get; set; }
        private int Id { get; set; }

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
