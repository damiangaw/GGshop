using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GGShopMVC.Models;

namespace GGShopMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Bestsellers { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}