using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Produkt
    {
        public int ProduktID { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public int ProducentID { get; set; }

        public virtual Producent Producent { get; set; }

        public String Nazwa { get; set; }

        public Double Cena_netto { get; set; }

        public int Procent_vat { get; set; }

        public String Opis { get; set; }

        public int Ilość { get; set; }


        public virtual ICollection<Atrybut_Wartosc> Atrybut_Wartoscs { get; set; }

        public virtual ICollection<Opinie> Opinies { get; set; }

        public virtual ICollection<Zamowione_Produkty> Zamowione_Produktys { get; set; }

    }
}