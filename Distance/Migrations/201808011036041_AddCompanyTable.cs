namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable:false),
                        Street = c.String(),
                        HouseNumber = c.String(nullable:false),
                        FlatNumber = c.String(),
                        ZipCode = c.String(nullable:false),
                        City = c.String(nullable:false),
                        NIP = c.String(nullable:false),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.UserInCompanies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.UserId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInCompanies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInCompanies", "CompanyId", "dbo.Companies");
            DropIndex("dbo.UserInCompanies", new[] { "UserId" });
            DropIndex("dbo.UserInCompanies", new[] { "CompanyId" });
            DropTable("dbo.UserInCompanies");
            DropTable("dbo.Companies");
        }
    }
}
