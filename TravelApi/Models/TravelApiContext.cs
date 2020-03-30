using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public TravelApiContext(DbContextOptions<TravelApiContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries {get; set;}
        public DbSet<Review> Cities { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}