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
         public int IdTicketResto { get; set; }
        public float somme { get; set; }
        public DateTime date { get; set; }
        public string nomSociete { get; set; }


        public Ticket(int IdTicketResto, float somme, DateTime date, string nomSociete)
        {

            this.IdTicketResto = IdTicketResto;
            this.somme = somme;
            this.date = date;
            this.nomSociete = nomSociete;
        }
    }
}
