namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ksiazkas", "Opis", c => c.String(nullable: false, maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ksiazkas", "Opis");
        }
    }
}
