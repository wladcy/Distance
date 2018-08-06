namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTraveltableAndChangeUserTableAndAddDatetimeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "ModyfiTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.CarStatuses", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.CarStatuses", "ModyfiTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "ModyfiTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserInCompanies", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserInCompanies", "ModyfiTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "HouseNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "FlatNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "FlatNumber");
            DropColumn("dbo.AspNetUsers", "HouseNumber");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.UserInCompanies", "ModyfiTime");
            DropColumn("dbo.UserInCompanies", "CreateTime");
            DropColumn("dbo.Companies", "ModyfiTime");
            DropColumn("dbo.Companies", "CreateTime");
            DropColumn("dbo.CarStatuses", "ModyfiTime");
            DropColumn("dbo.CarStatuses", "CreateTime");
            DropColumn("dbo.Cars", "ModyfiTime");
            DropColumn("dbo.Cars", "CreateTime");
        }
    }
}
