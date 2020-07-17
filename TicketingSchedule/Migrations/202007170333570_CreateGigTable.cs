namespace TicketingSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artis_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artis_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Artis_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artis_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
