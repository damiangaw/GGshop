using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGShopMVC.AccessLayer;
using GGShopMVC.ViewModels;

namespace GGShopMVC.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext db = new StoreContext();

        public CartController()
        {
            sessionManager = new SessionManager();
            shoppingCartManager = new ShoppingCartManager(sessionManager, db);

        }
        // GET: Cart
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            var cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };
            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCArt(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            var shoppingCartManager = new ShoppingCartManager(sessionManager, db);
            return shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int productID)
        {
            var shoppingCartManager = new ShoppingCartManager(sessionManager, db);

            var itemCount = shoppingCartManager.RemoveFromCart(productID);
            var cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = productID,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount
            };
            return Json(result);
        }
    }
}