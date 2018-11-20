namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullAllDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Birthday", c => c.DateTime());
            AlterColumn("dbo.Employee", "Birthday", c => c.DateTime());
            AlterColumn("dbo.OrderDetail", "Discount", c => c.Int());
            AlterColumn("dbo.Order", "ShippedDate", c => c.DateTime());
            AlterColumn("dbo.Product", "State", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "State", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Order", "ShippedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderDetail", "Discount", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
