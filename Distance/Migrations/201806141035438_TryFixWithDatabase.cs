namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryFixWithDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccountTypes", "Name", c => c.String());
        }
    }
}
