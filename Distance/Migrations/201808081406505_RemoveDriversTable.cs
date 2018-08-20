namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDriversTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DriverViewModels", "AccountTypeId", "dbo.AccountTypeViewModels");
            DropIndex("dbo.DriverViewModels", new[] { "AccountTypeId" });
            DropTable("dbo.DriverViewModels");
        }
        
        public override void Down()
        {

        }
    }
}
