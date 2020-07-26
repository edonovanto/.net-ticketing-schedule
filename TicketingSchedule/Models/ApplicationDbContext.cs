using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TicketingSchedule.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gig { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public DbSet<Attendence> Attendences { get; set; }

        public DbSet<Following> Followings { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendence>()
                .HasRequired(m=>m.Gig)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(m=>m.Followers)
                .WithRequired(m=>m.followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(m=>m.Followees)
                .WithRequired(m=>m.follower)
                .WillCascadeOnDelete(false);
                

            base.OnModelCreating(modelBuilder);
        }
    }
}