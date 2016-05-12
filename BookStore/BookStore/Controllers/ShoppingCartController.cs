using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var dodanaKsiazka = storeDB.Ksiazki.
                Single(ksiazka => ksiazka.KsiazkaId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(dodanaKsiazka);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string nazwaKsiazki = storeDB.Carty.
                Single(item => item.RekordId == id).Ksiazka.Tytul;
            int itemCount = cart.RemoveFromCart(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(nazwaKsiazki) + "Ksizka zostala usunieta z twojego koszyka",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetIlosc(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        [ChildActionOnly]
        public ActionResult PodsumowanieKoszyka()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetIlosc();
            return PartialView("PodsumowanieKoszyka");
        }

    }
}