using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Gatunek
    {
        public int GatunekId { get; set; }
        
        public string Nazwa { get; set; }
        public List<Ksiazka> Ksiazki { get; set; }
    }
}