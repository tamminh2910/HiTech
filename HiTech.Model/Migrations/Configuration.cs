namespace HiTech.Model.Migrations
{
    using HiTech.Model.Entites;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HiTech.Model.HiTechContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HiTech.Model.HiTechContext context)
        {
            //context.Suppliers.AddOrUpdate(x => x.SupplierID,
            //    new Supplier() { SupplierID = 1, CompanyName = "Apple" });
            //context.Products.AddOrUpdate(x => x.ProductID,
            //    new Product() { ProductID = 1, Name = "Iphone X", UnitPrice = 32000000, CategoryID = 19, SupplierID = 1,Discount=0 ,Description="",Image="",RegisterDate=DateTime.Now},
            //     new Product() { ProductID = 2, Name = "Iphone XS", UnitPrice = 35000000, CategoryID = 19, SupplierID = 1,Discount=0, Description = "", Image = "", RegisterDate = DateTime.Now },
            //      new Product() { ProductID = 3, Name = "Iphone XS Max", UnitPrice = 42000000, CategoryID = 19, SupplierID = 1,Discount=0, Description = "", Image = "", RegisterDate = DateTime.Now },
            //      new Product() { ProductID = 4, Name = "Iphone 8", UnitPrice = 25000000, CategoryID = 19, SupplierID = 1,Discount=0, Description = "", Image = "", RegisterDate = DateTime.Now });
        }
    }
}