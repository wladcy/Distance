namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Birthdate");
        }
    }
}
