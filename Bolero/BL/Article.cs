using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Article
    {
        
        public int IdArticle { get; set; }
        public string Libelle { get; set; }
        public double Prix { get; set; }
        public string Type { get; set; }


        public Article(int idArticle, string libelle, double prix, string type)
        {
            this.IdArticle = idArticle;
            this.Libelle = libelle;
            this.Prix = prix;
            this.Type = type;
        }
    }
}
