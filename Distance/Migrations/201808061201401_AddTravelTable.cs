namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTravelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, nullable: false),
                        CarId = c.Int(nullable: false),
                        CarMileageStart = c.Int(nullable: false),
                        CarMileageStop = c.Int(nullable: false),
                        TravelDate = c.DateTime(nullable: false),
                        Purpose = c.String(nullable: false),
                        Notes = c.String(),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        ModyfiTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Travels", "CarId", "dbo.Cars");
            DropIndex("dbo.Travels", new[] { "CarId" });
            DropIndex("dbo.Travels", new[] { "UserId" });
            DropTable("dbo.Travels");
        }
    }
}
