using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero
{
    class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Password { get; set; }
        public string Questionsecrete { get; set; }
        public string choixQs { get; set; }

        public User(int id, string nom, string pw, string qs, string chqs) 
        {
            this.choixQs = chqs;
            this.Questionsecrete = qs;
            this.Nom = nom;
            this.Id = id;
            this.Password = pw;
        }

    }
}
