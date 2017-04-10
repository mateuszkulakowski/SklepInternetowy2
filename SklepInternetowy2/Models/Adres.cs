using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Adres
    {
        public int AdresID { get; set; }

        public String Ulica { get; set; }

        public int Nr_domu { get; set; }

        public int Nr_lokalu { get; set; }

        public String Kod_pocztowy { get; set; }

        public String Miejscowosc { get; set; }

        public String Kraj { get; set; }

        public int KlientID { get; set; }

        public virtual Klient Klient { get; set; }
    }
}