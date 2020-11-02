using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GGShopMVC.Models;
using Glimpse.AspNet;

namespace GGShopMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "StaticPages",
                url: "site/{viewname}.html",
                defaults: new { controller = "Home", action = "StaticContent" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetails",
                url: "product-{id}.html",
                defaults: new { controller = "Store", action = "Details"}
            );

            routes.MapRoute(
                name: "ProductList",
                url: "category/{catname}",
                defaults: new { controller = "Store", action = "List"},
                constraints: new { catname = @"^[a-zA-Z]+([ ][a-zA-Z]*)*$"}
            );
        }
    }
}
