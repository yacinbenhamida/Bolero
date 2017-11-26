using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Facture
    {
         public Facture() { }
         public Facture(int idfact, decimal totalttc, decimal totalht, decimal totaltva, int idpayement)
         {
             this.IdFact = idfact;
             this.totalTTC = totalTTC;
             this.totalHT = totalHT;
             this.totalTVA = totalTVA;
             this.Idpayement = idpayement;
         
         }

        public int IdFact { get; set; }
        public decimal totalTTC { get; set; }
        public decimal totalHT { get; set; }
        public decimal totalTVA{ get; set; }
        public int Idpayement { get; set; }
    }
}
