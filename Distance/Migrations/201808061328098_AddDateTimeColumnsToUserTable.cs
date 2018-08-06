namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeColumnsToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreateTime", c => c.DateTime(nullable: true));
            AddColumn("dbo.AspNetUsers", "ModyfiTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ModyfiTime");
            DropColumn("dbo.AspNetUsers", "CreateTime");
        }
    }
}
