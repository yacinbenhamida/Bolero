using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Article
    {
        public Article() { }

        public int IdArticle { get; set; }
        public string Libelle { get; set; }
        public decimal Prix { get; set; }
        public string Type { get; set; }


        public Article(int idArticle, string libelle, decimal prix, string type)
        {
            this.IdArticle = idArticle;
            this.Libelle = libelle;
            this.Prix = prix;
            this.Type = type;
        }
        public override string ToString()
        {
            return IdArticle + " " + Libelle + " " + Prix + " " + Type;
        }

    }
}
