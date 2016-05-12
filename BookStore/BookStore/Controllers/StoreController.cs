using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            var gatunek = storeDB.Gatunki.ToList();
            
            return View(gatunek);

        }

        public ActionResult Browse(string gatunek)
        {
            var gatunekModel = storeDB.Gatunki.Include("Ksiazki")
                .Single(g => g.Nazwa == gatunek);
            return View(gatunekModel);


        }

        public ActionResult Details(int id)
        {
            var ksiazka = storeDB.Ksiazki.Find(id);

            return View(ksiazka);
        }
        [ChildActionOnly]
        public ActionResult GatunekMenu()
        {
            var gatunki = storeDB.Gatunki.ToList();
            return PartialView(gatunki);
        }
    }
}