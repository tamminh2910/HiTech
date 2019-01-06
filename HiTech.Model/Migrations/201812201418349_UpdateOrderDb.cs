namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            AddColumn("dbo.Order", "CustomerName", c => c.String());
            AddColumn("dbo.Order", "Phone", c => c.String());
            AddColumn("dbo.Order", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Email");
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "CustomerName");
            CreateIndex("dbo.Order", "CustomerID");
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID");
        }
    }
}
