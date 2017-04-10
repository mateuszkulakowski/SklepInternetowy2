namespace SklepInternetowy2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atrybut_Wartosc",
                c => new
                    {
                        Atrybut_WartoscID = c.Int(nullable: false, identity: true),
                        AtrybutID = c.Int(nullable: false),
                        ProduktID = c.Int(nullable: false),
                        Wartosc = c.String(),
                    })
                .PrimaryKey(t => t.Atrybut_WartoscID)
                .ForeignKey("dbo.Atrybuts", t => t.AtrybutID)
                .ForeignKey("dbo.Produkts", t => t.ProduktID)
                .Index(t => t.AtrybutID)
                .Index(t => t.ProduktID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atrybut_Wartosc", "ProduktID", "dbo.Produkts");
            DropForeignKey("dbo.Atrybut_Wartosc", "AtrybutID", "dbo.Atrybuts");
            DropIndex("dbo.Atrybut_Wartosc", new[] { "ProduktID" });
            DropIndex("dbo.Atrybut_Wartosc", new[] { "AtrybutID" });
            DropTable("dbo.Atrybut_Wartosc");
        }
    }
}
