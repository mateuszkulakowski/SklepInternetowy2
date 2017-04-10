using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Zamowione_Produkty
    {

        public int Zamowione_ProduktyID { get; set; }

        public int ZamowienieID { get; set; }

        public virtual Zamowienie Zamowienie { get; set; }

        public int ProduktID { get; set; }

        public virtual Produkt Produkt { get; set; }


    }
}