using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Crediteur
    {

        public Crediteur() { }
      
        public int IdCrediteur { get; set; }
        public string nomprenom { get; set; }
        public int cin { get; set; }
        public string tel { get; set; }
        public decimal MontantCredit { get; set; }
        public int Idcmd { get; set; }



        public Crediteur(int idcrediteur, string nomprenom, int cin, decimal MontantCredit, string tel, int idcmd)
        {
            this.IdCrediteur = idcrediteur;
            this.nomprenom = nomprenom;
            this.cin = cin;
            this.MontantCredit = MontantCredit;
            this.tel = tel;  
            this.Idcmd = idcmd;
        }
    }
}
