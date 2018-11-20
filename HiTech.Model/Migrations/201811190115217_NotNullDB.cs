namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Order", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Order", "ShipperID", "dbo.Shipper");
            DropForeignKey("dbo.Order", "StateID", "dbo.State");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.Order", new[] { "EmployeeID" });
            DropIndex("dbo.Order", new[] { "ShipperID" });
            DropIndex("dbo.Order", new[] { "StateID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            AlterColumn("dbo.Order", "CustomerID", c => c.Int());
            AlterColumn("dbo.Order", "EmployeeID", c => c.Int());
            AlterColumn("dbo.Order", "ShipperID", c => c.Int());
            AlterColumn("dbo.Order", "StateID", c => c.Int());
            AlterColumn("dbo.Product", "CategoryID", c => c.Int());
            AlterColumn("dbo.Product", "SupplierID", c => c.Int());
            CreateIndex("dbo.Order", "CustomerID");
            CreateIndex("dbo.Order", "EmployeeID");
            CreateIndex("dbo.Order", "ShipperID");
            CreateIndex("dbo.Order", "StateID");
            CreateIndex("dbo.Product", "CategoryID");
            CreateIndex("dbo.Product", "SupplierID");
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID");
            AddForeignKey("dbo.Order", "EmployeeID", "dbo.Employee", "EmployeeID");
            AddForeignKey("dbo.Order", "ShipperID", "dbo.Shipper", "ShipperID");
            AddForeignKey("dbo.Order", "StateID", "dbo.State", "StateID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID");
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Order", "StateID", "dbo.State");
            DropForeignKey("dbo.Order", "ShipperID", "dbo.Shipper");
            DropForeignKey("dbo.Order", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Order", new[] { "StateID" });
            DropIndex("dbo.Order", new[] { "ShipperID" });
            DropIndex("dbo.Order", new[] { "EmployeeID" });
            DropIndex("dbo.Order", new[] { "CustomerID" });
            AlterColumn("dbo.Product", "SupplierID", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "StateID", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "ShipperID", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "SupplierID");
            CreateIndex("dbo.Product", "CategoryID");
            CreateIndex("dbo.Order", "StateID");
            CreateIndex("dbo.Order", "ShipperID");
            CreateIndex("dbo.Order", "EmployeeID");
            CreateIndex("dbo.Order", "CustomerID");
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "StateID", "dbo.State", "StateID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "ShipperID", "dbo.Shipper", "ShipperID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "EmployeeID", "dbo.Employee", "EmployeeID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID", cascadeDelete: true);
        }
    }
}
