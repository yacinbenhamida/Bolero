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
        public int idCrediteur { get; set; }
        public string nomprenom { get; set; }
        public int cin { get; set; }
        public string adresse { get; set; }
        public string tel { get; set; }
        public float MontantCredit { get; set; }




        public Crediteur(int idCrediteur, string nomprenom, int cin, string adresse, string tel, float MontantCredit)
        {
            this.idCrediteur = idCrediteur;
            this.nomprenom = nomprenom;
            this.cin = cin;
            this.adresse = adresse;
            this.tel = tel;
            this.MontantCredit = MontantCredit;
        }
    }
}
