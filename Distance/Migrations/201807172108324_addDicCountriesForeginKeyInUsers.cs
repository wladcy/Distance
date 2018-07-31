namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDicCountriesForeginKeyInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DirectPhoneNumberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DirectPhoneNumberId");
        }
    }
}
