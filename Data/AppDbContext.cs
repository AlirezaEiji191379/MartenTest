using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
