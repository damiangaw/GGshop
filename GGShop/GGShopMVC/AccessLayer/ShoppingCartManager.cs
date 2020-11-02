using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GGShopMVC.Models;
using GGShopMVC.AccessLayer;

namespace GGShopMVC.AccessLayer
{
    public class ShoppingCartManager
    {
        private StoreContext db;
        private ISessionManager session;
        public const string CartSessionKey = "CartData";
        public ShoppingCartManager(ISessionManager session, StoreContext db)
        {
            this.session = session;
            this.db = db;
        }

        public void AddToCArt(int productid)
        {
            var cart = GetCart();
            var cartItem = cart.Find(a => a.Product.ProductID == productid);

            if (cartItem != null)
                cartItem.Quantity++;
            else
            {
                var productToAdd = db.Products.SingleOrDefault(b => b.ProductID == productid);
                if (productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };
                    cart.Add(newCartItem);
                }
            }
            session.Set(CartSessionKey, cart);
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }

            return cart;
        }

        public int RemoveFromCart(int productid)
        {
            var cart = GetCart();
            var cartItem = cart.Find(c => c.Product.ProductID == productid);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                    cart.Remove(cartItem);
            }
            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = GetCart();
            return cart.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetCartItemsCount()
        {
            var cart = GetCart();
            int count = cart.Sum(c => c.Quantity);

            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = GetCart();

            newOrder.DateCreated = DateTime.Now;
            //            newOrder.UserId = userId;

            db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
                newOrder.OrderItems = new List<OrderItem>();

            decimal cartTotal = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductID = cartItem.Product.ProductID,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };
                cartTotal += (cartItem.Quantity * cartItem.Product.Price);
                newOrder.OrderItems.Add(newOrderItem);
            }
            newOrder.TotalPrice = cartTotal;
            db.SaveChanges();
            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }
    }
}