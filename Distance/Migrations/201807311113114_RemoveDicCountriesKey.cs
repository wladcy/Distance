namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDicCountriesKey : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DirectPhoneNumberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DirectPhoneNumberId", c => c.Int());
        }
    }
}
