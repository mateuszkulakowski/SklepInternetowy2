namespace SklepInternetowy2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrtion2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atrybuts",
                c => new
                    {
                        AtrybutID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(),
                        Nazwa = c.String(),
                        Typ = c.String(),
                    })
                .PrimaryKey(t => t.AtrybutID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atrybuts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Atrybuts", new[] { "CategoryID" });
            DropTable("dbo.Atrybuts");
        }
    }
}
