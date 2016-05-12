using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.Models
{
    //[Bind(Exclude ="ZamowienieId")]
    public class Zamowienie
    {
        [ScaffoldColumn(false)]
        public int ZamowienieId { get; set; }
        [ScaffoldColumn(false)]
        public string NazwaUzytkownika { get; set; }
        [Required(ErrorMessage ="Podaj swoje imię")]
        [DisplayName("Imię")]
        [StringLength(160)]
        public string Imie { get; set; }
        [Required(ErrorMessage ="Podaj swoje nazwisko")]
        [DisplayName("Nazwisko")]
        [StringLength(160)]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage ="Podaj adres")]
        [StringLength(70)]
        public string Adres { get; set; }
        [Required(ErrorMessage ="Podaj miasto")]
        [StringLength(40)]
        public string Miasto { get; set; }
        [Required(ErrorMessage ="Podaj kod pocztowy")]
        [DisplayName("Kod pocztowy")]
        [StringLength(10)]
        public string KodPocztowy { get; set; }
        [Required(ErrorMessage ="Podaj telefon")]
        [DisplayName("Numer telefonu")]
        [StringLength(24)]
        public string NumerTel { get; set; }
        [Required(ErrorMessage ="Podaj swój email")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
           ErrorMessage ="To nie jest email." )]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Suma { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataZamowienia { get; set; }
        public List<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
    }
}