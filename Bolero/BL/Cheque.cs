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
        public decimal somme { get; set; }
        public DateTime dateCheque { get; set; }
        public string nom_prenomCli { get; set; }
        public string CINcli { get; set; }
          public string numCheque { get; set; }

          public Cheque( decimal somme, DateTime dateCheque, string nom_prenomCli, string CINcli, string numCheque)
          {
          
              this.somme = somme;
              this.dateCheque = dateCheque;
              this.nom_prenomCli = nom_prenomCli;
              this.CINcli = CINcli;
              this.numCheque = numCheque;
          }
          public Cheque(int IdCheque, decimal somme, DateTime dateCheque, string nom_prenomCli, string CINcli, string numCheque)
          {
              this.IdCheque = IdCheque;
              this.somme = somme;
              this.dateCheque = dateCheque;
              this.nom_prenomCli = nom_prenomCli;
              this.CINcli = CINcli;
              
              this.numCheque = numCheque;
          }

    }



    

}
