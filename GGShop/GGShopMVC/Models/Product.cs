using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GGShopMVC.Models
{
    public class Product
    {
        // Primary key
        public int ProductID { get; set; }
        //Foreign key
        public int CategoryID { get; set; }
        //Rest
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public DateTime DateAdded { get; set; }
        public string CoverFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isBest { get; set; }
        public bool isHidden { get; set; }

        public virtual Category Category { get; set; }
    }
}