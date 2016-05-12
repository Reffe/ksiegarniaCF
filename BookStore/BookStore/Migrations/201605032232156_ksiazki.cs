namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ksiazki : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RekordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        KsiazkaId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RekordId)
                .ForeignKey("dbo.Ksiazkas", t => t.KsiazkaId, cascadeDelete: true)
                .Index(t => t.KsiazkaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "KsiazkaId", "dbo.Ksiazkas");
            DropIndex("dbo.Carts", new[] { "KsiazkaId" });
            DropTable("dbo.Carts");
        }
    }
}
