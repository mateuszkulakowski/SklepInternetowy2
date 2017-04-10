using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SklepInternetowy2.Models
{
    public class DBContext : System.Data.Entity.DbContext
    {
        public DBContext() : base("BazaSklep") { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Adres> Adres { get; set; }

        public DbSet<Atrybut> Atrybuts { get; set; }

        public DbSet<Atrybut_Wartosc> Atrybut_Wartoscs { get; set; }

        public DbSet<Klient> Klients { get; set; }

        public DbSet<Opinie> Opinies { get; set; }

        public DbSet<Producent> Producents { get; set; }

        public DbSet<Produkt> Produkts { get; set; }

        public DbSet<Rodzaj_Dostawy> Rodzaj_Dostawys { get; set; }

        public DbSet<Sposob_Platnosci> Sposob_Platnoscis { get; set; }

        public DbSet<Zamowienie> Zamowienies { get; set; }

        public DbSet<Zamowione_Produkty> Zamowione_Produktys { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}