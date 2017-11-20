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
        public string adresse { get; set; }
        public string tel { get; set; }
        public float MontantCredit { get; set; }
        public int Idcmd { get; set; }



        public Crediteur( int idcrediteur, string nomprenom, int cin, string adresse, string tel, float MontantCredit,int idcmd)
        {
            this.IdCrediteur = idcrediteur;
            this.nomprenom = nomprenom;
            this.cin = cin;
            this.adresse = adresse;
            this.tel = tel;
            this.MontantCredit = MontantCredit;
            this.Idcmd = idcmd;
        }
    }
}
