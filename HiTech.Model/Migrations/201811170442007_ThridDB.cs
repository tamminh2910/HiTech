namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThridDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            RenameTable(name: "dbo.Roles", newName: "Role");
            RenameTable(name: "dbo.OrderDetails", newName: "OrderDetail");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Shippers", newName: "Shipper");
            RenameTable(name: "dbo.States", newName: "State");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Suppliers", newName: "Supplier");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Supplier", newName: "Suppliers");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.State", newName: "States");
            RenameTable(name: "dbo.Shipper", newName: "Shippers");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.OrderDetail", newName: "OrderDetails");
            RenameTable(name: "dbo.Role", newName: "Roles");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
