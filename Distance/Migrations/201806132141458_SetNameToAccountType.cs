namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameToAccountType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AccountTypes SET Name = 'BRAK' WHERE Id = 1");
            Sql("UPDATE AccountTypes SET Name = 'MIESIÊCZNE' WHERE Id = 2");
            Sql("UPDATE AccountTypes SET Name = 'KWARTALNE' WHERE Id = 3");
            Sql("UPDATE AccountTypes SET Name = 'ROCZNE' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
