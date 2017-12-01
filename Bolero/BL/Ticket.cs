using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Ticket
    {
         public Ticket() { }
         public int idticket { get; set; }
        public decimal somme { get; set; }
        public DateTime date { get; set; }
        public string nomSociete { get; set; }


        public Ticket(decimal somme, DateTime date, string nomSociete)
        {
            this.somme = somme;
            this.date = date;
            this.nomSociete = nomSociete;
        }
    }
}
