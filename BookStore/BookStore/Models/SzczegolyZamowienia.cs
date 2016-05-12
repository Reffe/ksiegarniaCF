using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BookStore.Models
{
    public class SzczegolyZamowienia
    {
        public int SzczegolyZamowieniaId { get; set; }
        public int ZamowienieId { get; set; }
        public int KsiazkaId { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZaJeden { get; set; }
        public virtual Ksiazka Ksiazka { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}