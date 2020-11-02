namespace GGShopMVC.Migrations
{
    using System;
    using GGShopMVC.AccessLayer;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<GGShopMVC.AccessLayer.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GGShopMVC.AccessLayer.StoreContext context)
        {
            StoreInitializer.SeedStoreData(context);
        }
    }
}
