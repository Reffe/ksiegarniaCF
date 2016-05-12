using System.Data.Entity;

namespace BookStore.Models
{
    public class BookStoreEntities : DbContext
    {
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Gatunek> Gatunki { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Cart> Carty { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<SzczegolyZamowienia> SzczegolyZamowien { get; set; }


    }
}