namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarStatusToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        StatusName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "CarStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "CarStatusId");
            AddForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarStatusId", "dbo.CarStatus");
            DropIndex("dbo.Cars", new[] { "CarStatusId" });
            DropColumn("dbo.Cars", "CarStatusId");
            DropTable("dbo.CarStatus");
        }
    }
}
