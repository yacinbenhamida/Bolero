using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class ligneCommande
    {
        public int article { get; set; }
        public int commande { get; set; }
        public int Qte { get; set; }

        public ligneCommande() { }
        public ligneCommande(int commande, int article, int qte)
        {
            this.commande = commande;
            this.article = article;
            this.Qte = qte;
        }
    }
}
