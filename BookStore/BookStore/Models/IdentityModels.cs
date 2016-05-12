using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace BookStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser 
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
  


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BookStoreEntities", throwIfV1Schema: false)
        {
        }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Cart> Carty { get; set; }
        public DbSet<Gatunek> Gatunki { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Zamowienie> Zamowiania { get; set; }
        public DbSet<SzczegolyZamowienia> SzczegolyZamowien { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}