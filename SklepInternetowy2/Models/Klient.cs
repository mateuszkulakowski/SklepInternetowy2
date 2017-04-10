using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Klient
    {

        public int KlientID { get; set; }

        public String Login { get; set; }

        public String Haslo { get; set; }

        public String Imie { get; set; }

        public String Nazwisko { get; set; }

        public String Nazwa_Firmy { get; set; }

        public int Nr_telefonu { get; set; }

        public String Email { get; set; }

        public virtual ICollection<Adres> Adress { get; set; }

        public virtual ICollection<Opinie> Opinies { get; set; }

        public virtual ICollection<Zamowienie> Zamowienies { get; set; }
    }
}