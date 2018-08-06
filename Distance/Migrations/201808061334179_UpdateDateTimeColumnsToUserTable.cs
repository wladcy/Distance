namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateTimeColumnsToUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "ModyfiTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ModyfiTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
