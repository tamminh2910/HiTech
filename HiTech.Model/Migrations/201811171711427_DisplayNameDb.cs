namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayNameDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "State", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Customer", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Product", "Discount", c => c.Int());
            DropColumn("dbo.Product", "Discounted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Discounted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Product", "Discount", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employee", "Password", c => c.String());
            AlterColumn("dbo.Employee", "UserName", c => c.String());
            AlterColumn("dbo.Customer", "Password", c => c.String());
            AlterColumn("dbo.Customer", "UserName", c => c.String());
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 250));
            DropColumn("dbo.Product", "State");
        }
    }
}
