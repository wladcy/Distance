namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToDriverName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Drivers", "Surname", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "Surname", c => c.String());
            AlterColumn("dbo.Drivers", "Name", c => c.String());
        }
    }
}
