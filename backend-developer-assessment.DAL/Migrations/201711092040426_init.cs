namespace backend_developer_assessment.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ArtistName = c.String(nullable: false, maxLength: 1024),
                        CountryCode = c.String(maxLength: 5),
                        ArtistAliases = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artists");
        }
    }
}
