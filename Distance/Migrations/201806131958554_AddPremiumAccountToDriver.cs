namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPremiumAccountToDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Surname", c => c.String());
            AddColumn("dbo.Drivers", "IsPremiumAccount", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "IsPremiumAccount");
            DropColumn("dbo.Drivers", "Surname");
        }
    }
}
