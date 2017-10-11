using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero
{
    class User
    {
        private int id;
        private string name;
        private string password;
        private string secretQuestion;

        public int Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String SecretQuestion { get; set; }
        public string toString() { return "Id : " + Id + " Nom : " + Name + " PW : " + Password + " SQUESTION" +SecretQuestion; }
    }
}
