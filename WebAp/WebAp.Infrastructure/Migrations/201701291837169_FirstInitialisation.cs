namespace WebAp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstInitialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Country = c.String(),
                        Aliases = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artist");
        }
    }
}
