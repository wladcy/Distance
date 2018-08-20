namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarStatuses (Id, Status) VALUES (1, 'Dostêpny')");
            Sql("INSERT INTO CarStatuses (Id, Status) VALUES (2, 'W trasie')");
        }
        
        public override void Down()
        {
            
        }
    }
}
