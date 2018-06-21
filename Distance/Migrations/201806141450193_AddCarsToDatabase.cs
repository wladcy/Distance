namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Model = c.String(),
                        CarPlate = c.String(),
                        KmAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
