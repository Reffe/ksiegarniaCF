namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gatuneks", "Opis");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gatuneks", "Opis", c => c.String());
        }
    }
}
