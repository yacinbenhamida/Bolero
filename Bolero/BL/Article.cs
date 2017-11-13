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
        public int qte { get; set; }
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

        public Article(int qte)
        {
            // TODO: Complete member initialization
            this.qte = qte;
        }
        public override string ToString()
        {
            return IdArticle + " " + Libelle + " " + Prix + " " + Type;
        }
    }
}
