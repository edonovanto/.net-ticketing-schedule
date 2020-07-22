namespace TicketingSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyArtis : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artis_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Artis_Id", newName: "ArtisId");
            AlterColumn("dbo.Gigs", "ArtisId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "ArtisId");
            AddForeignKey("dbo.Gigs", "ArtisId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Gigs", "ArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false));
            DropForeignKey("dbo.Gigs", "ArtisId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtisId" });
            AlterColumn("dbo.Gigs", "ArtisId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Gigs", name: "ArtisId", newName: "Artis_Id");
            CreateIndex("dbo.Gigs", "Artis_Id");
            AddForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
