namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDicCountriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DicCountries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCodeA2 = c.String(maxLength:2),
                        CountryCodeA3 = c.String(maxLength:3),
                        CountryFlagData = c.Binary(),
                        CountryFlagMimeType = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DicCountries");
        }
    }
}
