namespace GGShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "RouteDesc", c => c.String());
            DropColumn("dbo.Categories", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
            DropColumn("dbo.Categories", "RouteDesc");
        }
    }
}
