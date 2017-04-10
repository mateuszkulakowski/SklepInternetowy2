using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Producent
    {
        public int ProducentID { get; set; }

        public String Nazwa { get; set; }

        public String Ulica { get; set; }

        public int Nr_domu { get; set; }

        public String Kod_pocztowy { get; set; }

        public String Miejscowosc { get; set; }

        public String Nr_telefonu { get; set; }

        public String Email { get; set; }
        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}