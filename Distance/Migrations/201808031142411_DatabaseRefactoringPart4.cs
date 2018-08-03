namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseRefactoringPart4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CarStatusID_Id", "dbo.CarStatuses");
            DropIndex("dbo.Cars", new[] { "CarStatusID_Id" });
            DropColumn("dbo.Cars", "CarStatusId");
            RenameColumn(table: "dbo.Cars", name: "CarStatusID_Id", newName: "CarStatusId");
            AlterColumn("dbo.Cars", "CarStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "CarStatusId");
            AddForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatuses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatuses");
            DropIndex("dbo.Cars", new[] { "CarStatusId" });
            AlterColumn("dbo.Cars", "CarStatusId", c => c.Byte());
            RenameColumn(table: "dbo.Cars", name: "CarStatusId", newName: "CarStatusID_Id");
            AddColumn("dbo.Cars", "CarStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "CarStatusID_Id");
            AddForeignKey("dbo.Cars", "CarStatusID_Id", "dbo.CarStatuses", "Id");
        }
    }
}
