using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Cheque
    { public Cheque() { }
        public int IdCheque { get; set; }
        public float somme { get; set; }
        public DateTime dateCheque { get; set; }
        public string nom_prenomCli { get; set; }
        public string CINcli { get; set; }
          public string RIBcompte { get; set; }
          public string numCheque { get; set; }

          public Cheque(int IdCheque, float somme, DateTime dateCheque, string nom_prenomCli, string CINcli, string RIBcompte, string numCheque)
          {
              this.IdCheque = IdCheque;
              this.somme = somme;
              this.dateCheque = dateCheque;
              this.nom_prenomCli = nom_prenomCli;
              this.CINcli = CINcli;
              this.RIBcompte = RIBcompte;
              this.numCheque = numCheque;
          }

    }



    

}
