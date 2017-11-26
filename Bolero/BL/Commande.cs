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
        public decimal prixtotal { get; set; }
        public int NumTable { get; set; }  
        public int idserveur { get; set; }
        public int Id { get; set; } // iduser
        public int idfacture { get; set; }
        public DateTime datecommande { get; set; }

        public Commande() { }
        public Commande(int IdC, decimal prixtotal, int numtable, int nomserveur, int idOp, int idfacture, DateTime datecommande)
        {
            this.IdCommande = IdC ;
            this.prixtotal = prixtotal;
            this.NumTable = numtable;
            this.datecommande = datecommande;
            this.idserveur = nomserveur;
            this.idfacture = idfacture;
            this.Id = idOp;  
        }
    }
}
