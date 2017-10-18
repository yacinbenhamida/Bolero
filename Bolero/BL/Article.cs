using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Article
    {
        public int idArticle { get; set; }
        public String libelle { get; set; }
        public Double prix { get; set; }
        public String type { get; set; }


        public Article(int idArticle, String libelle, Double prix, String type)
        {
            this.idArticle = idArticle;
            this.libelle = libelle;
            this.prix = prix;
            this.type = type;
        }
    }
}
