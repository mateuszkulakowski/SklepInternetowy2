using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Rodzaj_Dostawy
    {
        public int Rodzaj_DostawyID { get; set; }

        public Double Koszt { get; set; }

        public virtual ICollection<Zamowienie> Zamowienies { get; set; }
    }
}