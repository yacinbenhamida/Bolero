using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Categorie
    {   public int idcatg{get; set;}
        public String libCatg{get ; set ; }
        public Categorie()
        { }
        public Categorie(int id, String lib)
        {
            this.idcatg = id;
            this.libCatg = lib;
        }
    }
}
