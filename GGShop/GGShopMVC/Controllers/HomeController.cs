using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGShopMVC.AccessLayer;
using GGShopMVC.Models;
using GGShopMVC.ViewModels;

namespace GGShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Home
        public ActionResult Index() //zapytania Linq
        {
            var categories = db.Categories.ToList();

            var bestseller = db.Products.Where(a => !a.isHidden && a.isBest).OrderBy(g => Guid.NewGuid()).Take(3)
                .ToList();
            var products = db.Products.Where(j => !j.isHidden && !j.isBest).OrderBy(h => Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Bestsellers = bestseller,
                Categories = categories,
                Products = products
            };

            return View(vm);
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}