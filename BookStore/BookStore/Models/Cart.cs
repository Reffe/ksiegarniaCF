
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BookStore.ViewModels;

namespace BookStore.Models
{
    public class Cart
    {
        [Key]
        public int RekordId { get; set; }
        public string CartId { get; set; }
        public int KsiazkaId { get; set; }
        public int Ilosc { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Ksiazka Ksiazka { get; set; }
        //public int ZamowienieId { get; set; }
    }
}