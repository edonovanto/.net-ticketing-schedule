namespace TicketingSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToGig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artis_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Genre_Id", newName: "IX_GenreId");
            AddColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false));
            AlterColumn("dbo.Gigs", "Artis_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Gigs", "Artis_Id");
            AddForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artis_Id" });
            AlterColumn("dbo.Gigs", "Artis_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Gigs", "ArtistId");
            RenameIndex(table: "dbo.Gigs", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Gigs", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Gigs", "Artis_Id");
            AddForeignKey("dbo.Gigs", "Artis_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
