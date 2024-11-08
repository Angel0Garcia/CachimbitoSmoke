using Microsoft.EntityFrameworkCore;

namespace CachimbitoSmoke.API.Models
{
    public class CachimbitoSmokeDbContext : DbContext
    {
        public CachimbitoSmokeDbContext(DbContextOptions<CachimbitoSmokeDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>().HasIndex(c => c.name).IsUnique();
        }
    }
}
