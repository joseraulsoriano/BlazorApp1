using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Contacto
    {
        public String id = "";
        public String nom = "";
        public String app = "";
        public String tel = "";

        public Contacto(String id, String nom, String ap, String tel) 
        { 
            this.id = id;
            this.nom = nom;
            this.app = app;
            this.tel = tel;
        }

    }
}
