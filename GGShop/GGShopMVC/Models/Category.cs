using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGShopMVC.Models
{
    public class Category
    {
        //Primary Key
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string RouteDesc { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}