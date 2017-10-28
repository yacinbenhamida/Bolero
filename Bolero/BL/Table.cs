using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Table
    {
        public int NumTable { get; set; }
        public bool Etat { get; set; }

        public Table(int num, Boolean etar)
        {
            this.NumTable = num;
            this.Etat = Etat;
        }
    }
}
