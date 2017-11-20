using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class User
    {
        public string Nom { get; set; }
        public string Password { get; set; }
        public string SecretQuestion { get; set; }
        public string Answer { get; set; }
        public int Id { get; set; }
        public User(int id, string nom, string password, string qs ,string reponse) 
        {
            this.Nom = nom;
            this.Id = id;
            this.SecretQuestion = qs;
            this.Answer = reponse;
            this.Password = password;
        }
    }
}
