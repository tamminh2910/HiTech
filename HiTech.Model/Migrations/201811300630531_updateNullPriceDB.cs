namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNullPriceDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetail", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetail", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetail", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetail", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
