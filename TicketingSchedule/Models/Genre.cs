using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TicketingSchedule.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }

    public class GenreDbContext : DbContext
    {
        public GenreDbContext()
        {

        }

        public static GenreDbContext Create()
        {
            return new GenreDbContext();
        }
        public DbSet<Genre> Genre { get; set; }
    }
}