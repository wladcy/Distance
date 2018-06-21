namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToAccountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountTypes", "Name");
        }
    }
}
