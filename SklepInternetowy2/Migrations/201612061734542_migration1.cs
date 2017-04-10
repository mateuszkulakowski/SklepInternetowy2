namespace SklepInternetowy2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adres",
                c => new
                    {
                        AdresID = c.Int(nullable: false, identity: true),
                        Ulica = c.String(),
                        Nr_domu = c.Int(nullable: false),
                        Nr_lokalu = c.Int(nullable: false),
                        Kod_pocztowy = c.String(),
                        Miejscowosc = c.String(),
                        Kraj = c.String(),
                        KlientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdresID)
                .ForeignKey("dbo.Klients", t => t.KlientID)
                .Index(t => t.KlientID);
            
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        KlientID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Haslo = c.String(),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Nazwa_Firmy = c.String(),
                        Nr_telefonu = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.KlientID);
            
            CreateTable(
                "dbo.Opinies",
                c => new
                    {
                        OpinieID = c.Int(nullable: false, identity: true),
                        ProduktID = c.Int(nullable: false),
                        KlientID = c.Int(nullable: false),
                        Tresc = c.String(),
                    })
                .PrimaryKey(t => t.OpinieID)
                .ForeignKey("dbo.Klients", t => t.KlientID)
                .ForeignKey("dbo.Produkts", t => t.ProduktID)
                .Index(t => t.ProduktID)
                .Index(t => t.KlientID);
            
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        ProduktID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProducentID = c.Int(nullable: false),
                        Nazwa = c.String(),
                        Cena_netto = c.Double(nullable: false),
                        Procent_vat = c.Int(nullable: false),
                        Opis = c.String(),
                        Ilość = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProduktID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Producents", t => t.ProducentID)
                .Index(t => t.CategoryID)
                .Index(t => t.ProducentID);
            
            CreateTable(
                "dbo.Producents",
                c => new
                    {
                        ProducentID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Ulica = c.String(),
                        Nr_domu = c.Int(nullable: false),
                        Kod_pocztowy = c.String(),
                        Miejscowosc = c.String(),
                        Nr_telefonu = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ProducentID);
            
            CreateTable(
                "dbo.Zamowione_Produkty",
                c => new
                    {
                        Zamowione_ProduktyID = c.Int(nullable: false, identity: true),
                        ZamowienieID = c.Int(nullable: false),
                        ProduktID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Zamowione_ProduktyID)
                .ForeignKey("dbo.Produkts", t => t.ProduktID)
                .ForeignKey("dbo.Zamowienies", t => t.ZamowienieID)
                .Index(t => t.ZamowienieID)
                .Index(t => t.ProduktID);
            
            CreateTable(
                "dbo.Zamowienies",
                c => new
                    {
                        ZamowienieID = c.Int(nullable: false, identity: true),
                        KlientID = c.Int(nullable: false),
                        Data_zamowienia = c.DateTime(nullable: false),
                        Czy_zaplacono = c.Boolean(nullable: false),
                        Czy_zrealizowano = c.Boolean(nullable: false),
                        Data_wysylki = c.DateTime(nullable: false),
                        Rodzaj_dostawyID = c.Int(nullable: false),
                        Sposob_PlatnosciID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieID)
                .ForeignKey("dbo.Klients", t => t.KlientID)
                .ForeignKey("dbo.Rodzaj_Dostawy", t => t.Rodzaj_dostawyID)
                .ForeignKey("dbo.Sposob_Platnosci", t => t.Sposob_PlatnosciID)
                .Index(t => t.KlientID)
                .Index(t => t.Rodzaj_dostawyID)
                .Index(t => t.Sposob_PlatnosciID);
            
            CreateTable(
                "dbo.Rodzaj_Dostawy",
                c => new
                    {
                        Rodzaj_DostawyID = c.Int(nullable: false, identity: true),
                        Koszt = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Rodzaj_DostawyID);
            
            CreateTable(
                "dbo.Sposob_Platnosci",
                c => new
                    {
                        Sposob_PlatnosciID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.Sposob_PlatnosciID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zamowione_Produkty", "ZamowienieID", "dbo.Zamowienies");
            DropForeignKey("dbo.Zamowienies", "Sposob_PlatnosciID", "dbo.Sposob_Platnosci");
            DropForeignKey("dbo.Zamowienies", "Rodzaj_dostawyID", "dbo.Rodzaj_Dostawy");
            DropForeignKey("dbo.Zamowienies", "KlientID", "dbo.Klients");
            DropForeignKey("dbo.Zamowione_Produkty", "ProduktID", "dbo.Produkts");
            DropForeignKey("dbo.Produkts", "ProducentID", "dbo.Producents");
            DropForeignKey("dbo.Opinies", "ProduktID", "dbo.Produkts");
            DropForeignKey("dbo.Produkts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Opinies", "KlientID", "dbo.Klients");
            DropForeignKey("dbo.Adres", "KlientID", "dbo.Klients");
            DropIndex("dbo.Zamowienies", new[] { "Sposob_PlatnosciID" });
            DropIndex("dbo.Zamowienies", new[] { "Rodzaj_dostawyID" });
            DropIndex("dbo.Zamowienies", new[] { "KlientID" });
            DropIndex("dbo.Zamowione_Produkty", new[] { "ProduktID" });
            DropIndex("dbo.Zamowione_Produkty", new[] { "ZamowienieID" });
            DropIndex("dbo.Produkts", new[] { "ProducentID" });
            DropIndex("dbo.Produkts", new[] { "CategoryID" });
            DropIndex("dbo.Opinies", new[] { "KlientID" });
            DropIndex("dbo.Opinies", new[] { "ProduktID" });
            DropIndex("dbo.Adres", new[] { "KlientID" });
            DropTable("dbo.Sposob_Platnosci");
            DropTable("dbo.Rodzaj_Dostawy");
            DropTable("dbo.Zamowienies");
            DropTable("dbo.Zamowione_Produkty");
            DropTable("dbo.Producents");
            DropTable("dbo.Produkts");
            DropTable("dbo.Opinies");
            DropTable("dbo.Klients");
            DropTable("dbo.Adres");
        }
    }
}
