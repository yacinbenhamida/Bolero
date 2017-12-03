using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    



        class Facture
        {
            public int IdFact { get; set; }
            public Decimal totalTTC { get; set; }
            public Decimal totalHT { get; set; }
            public Decimal totalTVA { get; set; }
            public int Idpayement { get; set; }
            public Facture()
            {
            }
            public Facture(int idfact, Decimal totalttc, Decimal totalht, Decimal totaltva, int idpayement)
            {
                this.IdFact = idfact;
                this.totalTTC = totalTTC;
                this.totalHT = totalHT;
                this.totalTVA = totalTVA;
                this.Idpayement = idpayement;

            }
            public Facture(Decimal totalttc, Decimal totalht, Decimal totaltva)
            {

                this.totalTTC = totalTTC;
                this.totalHT = totalHT;
                this.totalTVA = totalTVA;
            }

        }
    }


