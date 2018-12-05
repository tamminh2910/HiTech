namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDecimalDisCount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Discount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Discount", c => c.Int());
        }
    }
}
