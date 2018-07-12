namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectPhoneNumberColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DicCountries", "CountryDirectPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DicCountries", "CountryDirectPhoneNumber");
        }
    }
}
