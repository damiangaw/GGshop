﻿namespace GGShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProductName = c.String(),
                        SellerName = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        CoverFileName = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isBest = c.Boolean(nullable: false),
                        isHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 140),
                        LastName = c.String(nullable: false, maxLength: 140),
                        CodeCity = c.String(nullable: false, maxLength: 70),
                        Address = c.String(),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.OrderItems", new[] { "ProductID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
