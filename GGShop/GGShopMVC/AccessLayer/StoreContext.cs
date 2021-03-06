﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GGShopMVC.Models;

namespace GGShopMVC.AccessLayer
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }


}