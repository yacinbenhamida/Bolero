using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Serveur
    {         public int IdServeur { get; set; }
        public string Nom_Serveur { get; set; }
        public Serveur()
        { }
        public Serveur(int id, String nom)
        {
            this.IdServeur = id;
            this.Nom_Serveur = nom;
        }
    }
}
