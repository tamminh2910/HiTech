namespace HiTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionOrderDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Description");
        }
    }
}
