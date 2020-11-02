using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GGShopMVC.Models;

namespace GGShopMVC.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}