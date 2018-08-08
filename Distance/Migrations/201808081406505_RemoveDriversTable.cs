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
            DropTable("dbo.AccountTypeViewModels");
            DropTable("dbo.DriverViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DriverViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Birthdate = c.DateTime(),
                        IsPremiumAccount = c.Boolean(nullable: false),
                        AccountTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTypeViewModels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.DriverViewModels", "AccountTypeId");
            AddForeignKey("dbo.DriverViewModels", "AccountTypeId", "dbo.AccountTypeViewModels", "Id", cascadeDelete: true);
        }
    }
}
