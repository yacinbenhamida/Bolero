using System;
using System.Collections.Generic;
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
        public int IdCategorie{ get; set; }
        public int PlatDJ { get; set; }

        public Article(int idArticle, string libelle, decimal prix, int idcatg)
        {
            this.IdArticle = idArticle;
            this.Libelle = libelle;
            this.Prix = prix;
            this.IdCategorie = idcatg;
            this.PlatDJ = 0;
        }

      
    }
}
