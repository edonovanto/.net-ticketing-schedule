namespace TicketingSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .Index(t => t.GigId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "GigId", "dbo.Gigs");
            DropForeignKey("dbo.Attendences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Attendences", new[] { "GigId" });
            DropTable("dbo.Attendences");
        }
    }
}
