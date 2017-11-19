using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Archive
    {
           public Archive() { }
        public int idCommande { get; set; }
        public int numTable { get; set; }
        public DateTime Datecommande { get; set; }
        public string nomServeur { get; set; }
        public string caissier { get; set; }
        public float sumprix { get; set; }


        public Archive() { }
        public Archive(int idCommande, int numTable, DateTime Datecommande, string nomServeur,string caissier, float sumprix) {

            this.idCommande = idCommande;
            this.numTable = numTable;
            this.Datecommande = Datecommande;
            this.nomServeur = nomServeur;
            this.caissier = caissier;
            this.sumprix = sumprix;
        
        
        }

    }

    
}
