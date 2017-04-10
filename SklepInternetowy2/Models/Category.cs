using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Category
    {

        public int CategoryID { get; set; }

        public String Nazwa { get; set; }

        public virtual ICollection<Atrybut> Atrybut { get; set; }

        public virtual ICollection<Produkt> Produkt { get; set; }
    }
}