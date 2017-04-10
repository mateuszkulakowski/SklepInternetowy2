using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Opinie
    {
        public int OpinieID { get; set; }

        public int ProduktID { get; set; }

        public virtual Produkt Produkt { get; set; }

        public int KlientID { get; set; }

        public virtual Klient Klient { get; set; }

        public String Tresc { get; set; }
    }
}