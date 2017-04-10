using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Atrybut_Wartosc
    {

        public int Atrybut_WartoscID { get; set; }

        public int AtrybutID { get; set; }

        public virtual Atrybut Atrybut { get; set; }

        public int ProduktID { get; set; }

        public virtual Produkt Produkt { get; set; }

        public String Wartosc { get; set; }
    }
}