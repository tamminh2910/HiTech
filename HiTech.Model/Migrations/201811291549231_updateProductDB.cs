namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Product", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Product", "Price");
        }
    }
}
