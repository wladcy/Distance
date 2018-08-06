namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnectionCarsWithCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CompanyId");
            AddForeignKey("dbo.Cars", "CompanyId", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Cars", new[] { "CompanyId" });
            DropColumn("dbo.Cars", "CompanyId");
        }
    }
}
