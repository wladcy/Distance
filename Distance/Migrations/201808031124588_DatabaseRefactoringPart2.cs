namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseRefactoringPart2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatuses");
            DropIndex("dbo.Cars", new[] { "CarStatusId" });
            AddColumn("dbo.Cars", "CarStatusID_Id", c => c.Byte());
            CreateIndex("dbo.Cars", "CarStatusID_Id");
            AddForeignKey("dbo.Cars", "CarStatusID_Id", "dbo.CarStatuses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarStatusID_Id", "dbo.CarStatuses");
            DropIndex("dbo.Cars", new[] { "CarStatusID_Id" });
            DropColumn("dbo.Cars", "CarStatusID_Id");
            CreateIndex("dbo.Cars", "CarStatusId");
            AddForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatuses", "Id", cascadeDelete: true);
        }
    }
}
