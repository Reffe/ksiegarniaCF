using BookStore.Models;
namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookStore.Models.ApplicationDbContext";
        }

        protected override void Seed(BookStore.Models.ApplicationDbContext context)
        {

            context.Gatunki.AddOrUpdate(v => v.GatunekId,
                new Gatunek() { GatunekId = 7, Nazwa = "Biznes" },
                new Gatunek() { GatunekId = 8, Nazwa = "Dla dzieci" },
                new Gatunek() { GatunekId = 9, Nazwa = "Romanse" },
                new Gatunek() { GatunekId = 10, Nazwa = "Polityka" },
                new Gatunek() { GatunekId = 11, Nazwa = "Podroze" },
                new Gatunek() { GatunekId = 12, Nazwa = "Poezja" },
                new Gatunek() { GatunekId = 13, Nazwa = "Nauki scisle" }


                );

            context.Gatunki.AddOrUpdate(x => x.GatunekId,
                new Gatunek() { GatunekId = 1, Nazwa = "Dramat" },
                new Gatunek() { GatunekId = 2, Nazwa = "Komedia" },
                new Gatunek() { GatunekId = 3, Nazwa = "Fantasy" },
                new Gatunek() { GatunekId = 4, Nazwa = "Biografia" },
                new Gatunek() { GatunekId = 5, Nazwa = "Historyczne" },
                new Gatunek() { GatunekId = 6, Nazwa = "Sci" }


                );
            context.Autor.AddOrUpdate(x => x.AutorId,
                new Autor() { AutorId = 1, Imie = "Andzej Sapacz" },
                new Autor() { AutorId = 2, Imie = "Wieslaw Als" }
                );

            //  This method will be called after migrating to the latest version.

                   //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                   //  to avoid creating duplicate seed data. E.g.
                   //
                   //    context.People.AddOrUpdate(
                   //      p => p.FullName,
                   //      new Person { FullName = "Andrew Peters" },
                   //      new Person { FullName = "Brice Lambson" },
                   //      new Person { FullName = "Rowan Miller" }
                   //    );
                   //
        }
    }
}
