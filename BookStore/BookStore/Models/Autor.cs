using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BookStore.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        [DisplayName("Autor")]
        public string Imie { get; set; }
        
    }
}