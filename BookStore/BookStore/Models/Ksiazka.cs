using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BookStore.Models
{
    [Bind(Exclude ="KsizkaId")]
    public class Ksiazka

    {
        [ScaffoldColumn(false)]
        public int KsiazkaId { get; set; }
        [DisplayName("Gatunek")]
        public int GatunekId { get; set; }
        [DisplayName("Autor")]
        public int AutorId { get; set; }
        [Required(ErrorMessage ="Podaj tytuł ksiażki")]
        [StringLength(150)]
        [DisplayName("Tytuł")]
        public string Tytul { get; set; }
        [Required(ErrorMessage ="Podaj cene")]
        [Range(0.01,100.00,ErrorMessage ="Dopuszczalna cena od 0.01 do 1000.00")]
        public decimal Cena { get; set; }
        [DisplayName("Scieżka do okładki")]
        [StringLength(1024)]
        public string KsiazkaLogo { get; set; }
        [Required(ErrorMessage ="Podaj opis")]
        [StringLength(1024)]
        public string Opis { get; set; }
        public virtual Gatunek Gatunek { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual List<SzczegolyZamowienia> SzczegolyZamowien { get; set; }

    }
}