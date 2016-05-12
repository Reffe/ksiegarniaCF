namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SzczegolyZamowienias",
                c => new
                    {
                        SzczegolyZamowieniaId = c.Int(nullable: false, identity: true),
                        ZamowienieId = c.Int(nullable: false),
                        KsiazkaId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaZaJeden = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SzczegolyZamowieniaId)
                .ForeignKey("dbo.Ksiazkas", t => t.KsiazkaId, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienies", t => t.ZamowienieId, cascadeDelete: true)
                .Index(t => t.ZamowienieId)
                .Index(t => t.KsiazkaId);
            
            CreateTable(
                "dbo.Ksiazkas",
                c => new
                    {
                        KsiazkaId = c.Int(nullable: false, identity: true),
                        GatunekId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                        Tytul = c.String(nullable: false, maxLength: 150),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KsiazkaLogo = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.KsiazkaId)
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .ForeignKey("dbo.Gatuneks", t => t.GatunekId, cascadeDelete: true)
                .Index(t => t.GatunekId)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Gatuneks",
                c => new
                    {
                        GatunekId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.GatunekId);
            
            CreateTable(
                "dbo.Zamowienies",
                c => new
                    {
                        ZamowienieId = c.Int(nullable: false, identity: true),
                        NazwaUzytkownika = c.String(),
                        Imie = c.String(nullable: false, maxLength: 160),
                        Nazwisko = c.String(nullable: false, maxLength: 160),
                        Adres = c.String(nullable: false, maxLength: 70),
                        Miasto = c.String(nullable: false, maxLength: 40),
                        KodPocztowy = c.String(nullable: false, maxLength: 10),
                        NumerTel = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Suma = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataZamowienia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ZamowienieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SzczegolyZamowienias", "ZamowienieId", "dbo.Zamowienies");
            DropForeignKey("dbo.SzczegolyZamowienias", "KsiazkaId", "dbo.Ksiazkas");
            DropForeignKey("dbo.Ksiazkas", "GatunekId", "dbo.Gatuneks");
            DropForeignKey("dbo.Ksiazkas", "AutorId", "dbo.Autors");
            DropIndex("dbo.Ksiazkas", new[] { "AutorId" });
            DropIndex("dbo.Ksiazkas", new[] { "GatunekId" });
            DropIndex("dbo.SzczegolyZamowienias", new[] { "KsiazkaId" });
            DropIndex("dbo.SzczegolyZamowienias", new[] { "ZamowienieId" });
            DropTable("dbo.Zamowienies");
            DropTable("dbo.Gatuneks");
            DropTable("dbo.Autors");
            DropTable("dbo.Ksiazkas");
            DropTable("dbo.SzczegolyZamowienias");
        }
    }
}
