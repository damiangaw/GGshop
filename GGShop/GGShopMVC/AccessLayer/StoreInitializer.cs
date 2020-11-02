using GGShopMVC.Migrations;
using GGShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GGShopMVC.AccessLayer
{
    public class StoreInitializer : MigrateDatabaseToLatestVersion<StoreContext, Configuration>
    {
        public static void SeedStoreData(StoreContext context)
        {
            var categories = new List<Category>
            {
                new Category() {CategoryID = 1, Name = "Pies Karma Sucha", RouteDesc = "pies-karma-sucha"},
                new Category() {CategoryID = 2, Name = "Pies Karma Mokra", RouteDesc = "pies-karma-mokra"},
                new Category() {CategoryID = 3, Name = "Pies Akcesoria", RouteDesc = "pies-akcesoria"},
                new Category() {CategoryID = 4, Name = "Kot Karma Sucha", RouteDesc = "kot-karma-sucha"},
                new Category() {CategoryID = 5, Name = "Kot Karma Mokra", RouteDesc = "kot-karma-mokra"},
                new Category() {CategoryID = 6, Name = "Kot Akcesoria", RouteDesc = "kot-akcesoria"}
            };

            categories.ForEach(g => context.Categories.AddOrUpdate(g));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product() {ProductID = 17, ProductName = "Maximo Lamb 20kg", SellerName = "Delikan", Price = 149, CoverFileName = "delikan-maximo-lamb-20kg.jpg", Description = "Delikan MAXIMO Lamb 20kg to kompletna karma dla psów o wrażliwym organizmie, podatnych na alergię. Klasa Premium. Nie zawiera pszenicy i soi. ", isBest = true, DateAdded = new DateTime(2020, 01, 7), CategoryID = 1},
                new Product() {ProductID = 2, ProductName = "SUPRA Chicken and Rice 1kg", SellerName = "Delikan", Price = 16, CoverFileName = "delikan-supra-chicken-and-rice-1kg.jpg", Description = "Karma Delikan SUPRA Chicken and Rice 1kg jest przeznaczona dla psów dużych ras o wrażliwym organizmie w wieku od 8 miesięcy, alergicznych na wołowinę i wieprzowinę. Nie zawiera pszenicy i soi. " , isBest = true, DateAdded = new DateTime(2020, 01, 7), CategoryID = 1},
                new Product() {ProductID = 3, ProductName = "Dog Chow PUPPY Z Jagnięciną 2,5kg", SellerName = "Purina", Price = 25, CoverFileName = "purina-dog-chow-puppy-z-jagniecina-2-5kg.png", Description = "DOG CHOW Puppy (Jagnięcina lub kurczak) karma ta dostarcza w 100% pełnoporcjowe i zbilansowane żywienie, dostosowane do potrzeb szczeniąt, aby wspierać ich zdrowy wzrost i rozwój. ", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 1},
                new Product() {ProductID = 4, ProductName = "Premium Bogata w Dziczyznę puszka 400g", SellerName = "Dolina Noteci", Price = 6, CoverFileName = "dolina-noteci-premium-bogata-w-dziczyzne-puszka-400g.jpg", Description = "Pełno-porcjowa karma dla dorosłych psów wszystkich ras bogata w dziczyznę 400g. ", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 2},
                new Product() {ProductID = 5, ProductName = "Miska na gumie, kolorowy nadruk, czarna 1,8L", SellerName = "Barry King", Price = 32, CoverFileName = "barry-king-miska-na-gumie-kolorowy-nadrukczarna-18-l.png", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3},
                new Product() {ProductID = 6, ProductName = "Stojak regulowany z miskami 1,8L", SellerName = "Barry King", Price = 59, CoverFileName = "barry-king-stojak-regulowany-z-miskami-18l-malowany.png", isBest = true, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3},
                new Product() {ProductID = 7, ProductName = "Krzyż czarny", SellerName = "Barry King", Price = 37, CoverFileName = "barry-king-krzyz-czarny-125cm.png", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3},
                new Product() {ProductID = 8, ProductName = "Dog Chow Adult Light Indyk 2,5kg", SellerName = "Purina", Price = 25, CoverFileName = "purina-dog-chow-adult-light-indyk-2-5kg.png", Description = "DOG CHOW Adult Light z Indykiem dostarcza w 100% pełnoporcjowe i zbilansowane żywienie dostosowane do potrzeb psów z nadwagą. ", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 1},
                new Product() {ProductID = 9, ProductName = "N&D GF Pumpkin BOAR&APPLE Adult mini 2,5kg", SellerName = "Farmina", Price = 90, CoverFileName = "farmina-nd-gf-pumpkin-boarapple-adult-mini-2kg.jpg", Description = "Dzik, dynia i jabłko. Pełnoporcjowa karma dla dorosłych psów.", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 1},
                new Product() {ProductID = 10, ProductName = "N&D Low Grain CHICKEN&POMEGRANATE adult medium dog 800g ", SellerName = "Farmina", Price = 27, CoverFileName = "farmina-nd-low-grain-chickenpomegranate-adult-medium-dog-800g.jpg", Description = "Orkisz, owies, kurczak, owoc granatu. Pełnoporcjowa karma dla dorosłych psów średnich ras. ", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 1},
                new Product() {ProductID = 11, ProductName = "Premium Bogata w Indyka puszka 400g", SellerName = "Dolina Noteci", Price = 6, CoverFileName = "dolina-noteci-premium-bogata-w-indyka-puszka-400g.jpg", Description = "Pełno-porcjowa karma dla dorosłych psów wszystkich ras bogata w indyka 400g. ", isBest = true, DateAdded = new DateTime(2020, 01, 7), CategoryID = 2},
                new Product() {ProductID = 12, ProductName = "Premium z Cielęciną, Pomidorami i Makaronem puszka 185g", SellerName = "Dolina Noteci", Price = 4, CoverFileName = "dolina-noteci-premium-z-cielecina-pomidorami-i-makaronem-puszka-185g.jpg", Description = "Karma pełno-porcjowa dla dorosłych psów małych ras z cielęciną, pomidorami i makaronem 185g. ", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 2},
                new Product() {ProductID = 13, ProductName = "Piłka pełna L czerwona 7,5cm ", SellerName = "Barry King", Price = 21, CoverFileName = "barry-king-pilka-pelna-l-czerwona-75cm.png", isBest = true, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3},
                new Product() {ProductID = 14, ProductName = "Piłka sznurowa z jutą S 5cm/65g ", SellerName = "Barry King", Price = 7, CoverFileName = "barry-king-pilka-sznurowa-z-juta-s-5cm-65g.png", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3},
                new Product() {ProductID = 15, ProductName = "Transporter niebieski Zolux", SellerName = "SMART", Price = 89, CoverFileName = "transporter-smart-t1-nieb-zolux.png", isBest = false, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3},
                new Product() {ProductID = 16, ProductName = "Transporter Pet Inn medium", SellerName = "AQUAEL", Price = 98, CoverFileName = "aquael-pet-inn-medium-585x38x385cm.png", isBest = true, DateAdded = new DateTime(2020, 01, 7), CategoryID = 3}
            };

            products.ForEach(a => context.Products.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}