using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Ksiazka ksiazka)
        {
            var cartItem = storeDB.Carty.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.KsiazkaId == ksiazka.KsiazkaId
                );
            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    KsiazkaId = ksiazka.KsiazkaId,
                    CartId = ShoppingCartId,
                    Ilosc = 1,
                    DateCreated = DateTime.Now

                };
                storeDB.Carty.Add(cartItem);
            }
            else
            {
                cartItem.Ilosc++;
            }
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            var cartItem = storeDB.Carty.Single(cart => cart.CartId == ShoppingCartId && cart.RekordId == id);
            int itemCount = 0;
            if(cartItem != null)
            {
                if(cartItem.Ilosc > 1)
                {
                    cartItem.Ilosc--;
                    itemCount = cartItem.Ilosc;
                }
                else
                {
                    storeDB.Carty.Remove(cartItem);
                }
                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = storeDB.Carty.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carty.Remove(cartItem);

            }
            storeDB.SaveChanges();

        }
        public List<Cart> GetCartItems()
        {
            return storeDB.Carty.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetIlosc()
        {
            int? ilosc = (from cartItems in storeDB.Carty
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Ilosc).Sum();
            return ilosc ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeDB.Carty
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Ilosc * cartItems.Ksiazka.Cena).Sum();
            return total ?? decimal.Zero;
        }
        public int ZlozZamowienie (Zamowienie zamowienie)
        {
            decimal zamowienieSuma = 0;
            var cartItems = GetCartItems();
            foreach(var item in cartItems)
            {
                var zamowienieSzczegoly = new SzczegolyZamowienia
                {
                    KsiazkaId = item.KsiazkaId,
                    ZamowienieId = zamowienie.ZamowienieId,
                    CenaZaJeden = item.Ksiazka.Cena,
                    Ilosc = item.Ilosc

                };
                zamowienieSuma += (item.Ilosc * item.Ksiazka.Cena);
                storeDB.SzczegolyZamowien.Add(zamowienieSzczegoly);

            }
            zamowienie.Suma = zamowienieSuma;
            storeDB.SaveChanges();
            EmptyCart();
            return zamowienie.ZamowienieId;
        }
        public string GetCartId(HttpContextBase context)
        {
            if(context.Session[CartSessionKey] == null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carty.Where(
                c => c.CartId == ShoppingCartId);
            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }

    }
}