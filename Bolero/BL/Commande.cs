using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Commande
    {

       // public static int _IdC;
        public int IdCommande { get; set; }
        public int NumTable { get; set; }
        public DateTime DateCommande { get; set; }
        public string NomServeur { get; set; }
        public int Id { get; set; } // iduser

        public Commande() { }
        public Commande(int IdC,int numtable, DateTime datecommande, string nomserveur, int idOp)
        {
            this.IdCommande = IdC ;
            this.NumTable = numtable;
            this.DateCommande = datecommande;
            this.NomServeur = nomserveur;
            this.Id = idOp;  
        }
    }
}
