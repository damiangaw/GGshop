using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GGShopMVC.AccessLayer;
using GGShopMVC.Models;
using GGShopMVC.ViewModels;

namespace GGShopMVC.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);

            return View(product);
        }

        public ActionResult List(string categoryname, string searchQuery = null)
        {
            var category = db.Categories.Include("Products").Single(g => g != null && g.Name.ToUpper() == categoryname.ToUpper());
            var products = category.Products.Where(a => (searchQuery == null ||
                                                  a.ProductName.ToLower().Contains(searchQuery.ToLower()) ||
                                                  a.SellerName.ToLower().Contains(searchQuery.ToLower())) &&
                                                 !a.isHidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", products);
            }


            return View(products);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10000)]
        public ActionResult _CatMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView(categories);
        }

        public ActionResult ProductSuggest(string term)
        {
            var products = db.Products.Where(a => a != null && a.ProductName.ToLower().Contains(term.ToLower())).Take(5).Select(a => new { label = a.ProductName });

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}