using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        const string PromoCode = "FREE";

        public ActionResult AdressAndPayment()
        {
            return View();
        }
        // GET: Checkout
        [HttpPost]
        public ActionResult AdressAndPayment(FormCollection values)
        {
            var zamowienie = new Zamowienie();
            TryUpdateModel(zamowienie);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(zamowienie);
                }
                else
                {
                    zamowienie.NazwaUzytkownika = User.Identity.Name;
                    zamowienie.DataZamowienia = DateTime.Now;

                    storeDB.Zamowiania.Add(zamowienie);
                    storeDB.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.ZlozZamowienie(zamowienie);
                    storeDB.SaveChanges();

                    return RedirectToAction("Complete",
                        new { id = zamowienie.ZamowienieId });
                    
                }
            }
            catch
            {
                return View(zamowienie);
            }
        }
        public ActionResult Complete (int id)
        {
            bool isValid = storeDB.Zamowiania.Any(
                o => o.ZamowienieId == id &&
                o.NazwaUzytkownika == User.Identity.Name);

            if(isValid)
            {
                return View(id);
            }
            else
            {
                return View("error");
            }
        }

    }
}