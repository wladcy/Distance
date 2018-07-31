namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DirectPhoneNumberId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DirectPhoneNumberId", c => c.Int(nullable: false));
        }
    }
}
