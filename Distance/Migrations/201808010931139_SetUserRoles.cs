namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles(Id, Name) VALUES('1', 'ADMINISTRATOR')");
            Sql("INSERT INTO AspNetRoles(Id, Name) VALUES('2', 'KIEROWCA')");
        }
        
        public override void Down()
        {
        }
    }
}
