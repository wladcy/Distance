namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarStatusExampleOptions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarStatus (Id, StatusName) VALUES (1, 'Dostepny')");
            Sql("INSERT INTO CarStatus (Id, StatusName) VALUES (2, 'Niedostepny')");
            Sql("INSERT INTO CarStatus (Id, StatusName) VALUES (3, 'W naprawie')");
        }
        
        public override void Down()
        {
        }
    }
}
