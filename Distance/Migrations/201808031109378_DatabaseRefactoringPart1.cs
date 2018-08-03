namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseRefactoringPart1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarViewModels", "CarStatusId", "dbo.CarStatusViewModels");
            DropIndex("dbo.CarViewModels", new[] { "CarStatusId" });
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Model = c.String(),
                        CarPlate = c.String(),
                        EngineCapacity = c.Single(nullable: false),
                        KmAge = c.Int(nullable: false),
                        CarStatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarStatuses", t => t.CarStatusId, cascadeDelete: true)
                .Index(t => t.CarStatusId);
            
            CreateTable(
                "dbo.CarStatuses",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.CarViewModels");
            DropTable("dbo.CarStatusViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarStatusViewModels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        StatusName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Model = c.String(),
                        CarPlate = c.String(),
                        KmAge = c.Int(nullable: false),
                        CarStatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatuses");
            DropIndex("dbo.Cars", new[] { "CarStatusId" });
            DropTable("dbo.CarStatuses");
            DropTable("dbo.Cars");
            CreateIndex("dbo.CarViewModels", "CarStatusId");
            AddForeignKey("dbo.CarViewModels", "CarStatusId", "dbo.CarStatusViewModels", "Id", cascadeDelete: true);
        }
    }
}
