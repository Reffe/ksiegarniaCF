using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var genres = new List<Gatunek>
            {
                new Gatunek { Nazwa = "Rock" },
                new Gatunek { Nazwa = "Jazz" },
                new Gatunek { Nazwa = "Metal" },
                new Gatunek { Nazwa = "Alternative" },
                new Gatunek { Nazwa = "Disco" },
                new Gatunek { Nazwa = "Blues" },
                new Gatunek { Nazwa = "Latin" },
                new Gatunek { Nazwa = "Reggae" },
                new Gatunek { Nazwa = "Pop" },
                new Gatunek { Nazwa = "Classical" }
            };

            var artists = new List<Autor>
            {
                new Autor { Imie = "Aaron Copland & London Symphony Orchestra" },
                new Autor { Imie = "Aaron Goldberg" },
                new Autor { Imie = "AC/DC" },
                new Autor { Imie = "Accept" },
                new Autor { Imie = "Adrian Leaper & Doreen de Feis" },
                new Autor { Imie = "Aerosmith" },
                new Autor { Imie = "Aisha Duo" },
                new Autor { Imie = "Alanis Morissette" },
                new Autor { Imie = "Alberto Turco & Nova Schola Gregoriana" },
                new Autor { Imie = "Alice In Chains" },
                new Autor { Imie = "Amy Winehouse" },

            };

            new List<Ksiazka>
            {
                new Ksiazka { Tytul = "A Copland Celebration, Vol. I", Gatunek = genres.Single(g => g.Nazwa == "Classical"), Cena = 8.99M, Autor = artists.Single(a => a.Imie == "Aaron Copland & London Symphony Orchestra"), KsiazkaLogo = "/Content/Images/placeholder.gif" },
                new Ksiazka { Tytul = "Worlds", Gatunek = genres.Single(g => g.Nazwa == "Jazz"), Cena = 8.99M, Autor = artists.Single(a => a.Imie == "Aaron Goldberg"), KsiazkaLogo = "/Content/Images/placeholder.gif" },
                new Ksiazka { Tytul = "For Those About To Rock We Salute You", Gatunek = genres.Single(g => g.Nazwa == "Rock"), Cena = 8.99M, Autor = artists.Single(a => a.Imie == "AC/DC"), KsiazkaLogo = "/Content/Images/placeholder.gif" },
                new Ksiazka { Tytul = "Let There Be Rock", Gatunek = genres.Single(g => g.Nazwa == "Rock"), Cena = 8.99M, Autor = artists.Single(a => a.Imie == "AC/DC"), KsiazkaLogo = "/Content/Images/placeholder.gif" },
                new Ksiazka { Tytul = "Let There", Gatunek = genres.Single(g => g.Nazwa == "Pop"), Cena = 8.92M, Autor = artists.Single(a => a.Imie == "Accept"), KsiazkaLogo = "/Content/Images/placehoder.gif" },

            }.ForEach(a => context.Ksiazki.Add(a));
        }
    }
}