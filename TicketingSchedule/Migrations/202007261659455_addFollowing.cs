namespace TicketingSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFollowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        followeeId = c.String(nullable: false, maxLength: 128),
                        followerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.followeeId, t.followerId })
                .ForeignKey("dbo.AspNetUsers", t => t.followerId)
                .ForeignKey("dbo.AspNetUsers", t => t.followeeId)
                .Index(t => t.followeeId)
                .Index(t => t.followerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "followeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "followerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "followerId" });
            DropIndex("dbo.Followings", new[] { "followeeId" });
            DropTable("dbo.Followings");
        }
    }
}
