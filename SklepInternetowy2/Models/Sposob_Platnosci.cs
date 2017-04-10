using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Sposob_Platnosci
    {
        public int Sposob_PlatnosciID { get; set; }

        public String Nazwa { get; set; }

        public virtual ICollection<Zamowienie> Zamowienies { get; set; }
    }
}