using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Zamowienie
    {

        public int ZamowienieID { get; set; }

        public int KlientID { get; set; }

        public virtual Klient Klient { get; set; }

        public DateTime Data_zamowienia { get; set; }

        public Boolean Czy_zaplacono { get; set; }

        public Boolean Czy_zrealizowano { get; set; }

        public DateTime Data_wysylki { get; set; }

        public int Rodzaj_dostawyID { get; set; }

        public virtual Rodzaj_Dostawy Rodza_Dostawy { get; set; }

        public int Sposob_PlatnosciID { get; set; }

        public virtual Sposob_Platnosci Sposob_Platnosci { get; set; }


        public virtual ICollection<Zamowione_Produkty> Zamowione_Produktys { get; set; }
    }
}