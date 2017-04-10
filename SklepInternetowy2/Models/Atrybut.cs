using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class Atrybut
    {
        [Key]
        public int AtrybutID { get; set; }

        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }


        public String Nazwa { get; set; }


        public String Typ { get; set; }


        public virtual ICollection<Atrybut_Wartosc> Atrybut_Wartoscs { get; set; }

    }
}