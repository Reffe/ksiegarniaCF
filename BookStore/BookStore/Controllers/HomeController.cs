using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var ksiazki = TopSellingKsiazki(8);
            return View(ksiazki);
        }
        private List<Ksiazka>TopSellingKsiazki(int count)
        {
            return storeDB.Ksiazki
                .OrderByDescending(a => a.SzczegolyZamowien.Count())
                .Take(count)
                .ToList();
        }
    }
}