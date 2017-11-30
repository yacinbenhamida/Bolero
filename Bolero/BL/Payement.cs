using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolero.BL
{
    class Payement
    
    {         public int id { get; set; }
        public int idticket { get; set; }
        public int idcheque { get; set; }
        public int idcmd { get; set; }
        public decimal prix { get; set; }
        public Payement()
        {
            this.idcheque = 1;
            this.idticket = 1;
        }
        public Payement(int id,int idt, int idc, int idcmd,decimal prix)
        {
            this.id = id;
            this.idticket = idt;
            this.idcmd = idcmd;
            this.idcheque = idc;
            this.prix = prix;
        }
        public Payement(int idt,int idc,int idcmd,decimal prix)
        {this.idticket=idt;
            this.idcmd=idcmd;
            this.idcheque=idc;
            this.prix = prix;
        }
        public Payement(int idt, int idcmd,decimal prix )
        {
            this.idticket = idt;
            this.idcmd = idcmd;
            this.prix = prix;
        }
       
    }
}
