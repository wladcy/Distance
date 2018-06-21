namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Drivers", "AccountTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Drivers", "AccountTypeId");
            AddForeignKey("dbo.Drivers", "AccountTypeId", "dbo.AccountTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Drivers", new[] { "AccountTypeId" });
            DropColumn("dbo.Drivers", "AccountTypeId");
            DropTable("dbo.AccountTypes");
        }
    }
}
