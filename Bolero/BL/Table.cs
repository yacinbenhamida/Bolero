using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Table
    {
        private int NumTable { get; set; }
        private Boolean Etat { get; set; }

        public Table(int num, Boolean etar)
        {
            this.NumTable = num;
            this.Etat = Etat;
        }
    }
}
