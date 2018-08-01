namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wirdMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountTypes", newName: "AccountTypeViewModels");
            RenameTable(name: "dbo.Cars", newName: "CarViewModels");
            RenameTable(name: "dbo.CarStatus", newName: "CarStatusViewModels");
            RenameTable(name: "dbo.Drivers", newName: "DriverViewModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DriverViewModels", newName: "Drivers");
            RenameTable(name: "dbo.CarStatusViewModels", newName: "CarStatus");
            RenameTable(name: "dbo.CarViewModels", newName: "Cars");
            RenameTable(name: "dbo.AccountTypeViewModels", newName: "AccountTypes");
        }
    }
}
