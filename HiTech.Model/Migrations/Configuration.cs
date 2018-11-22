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
            //context.Employees.AddOrUpdate(new Employee() { EmployeeID = 1, EmployeeName = "Nguyễn Minh Tâm", UserName = "tamminh2910", Password = "123456" });
            //context.SaveChanges();
        }
    }
}