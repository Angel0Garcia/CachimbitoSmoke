using Microsoft.EntityFrameworkCore;

namespace CachimbitoSmoke.API.Models
{
    public class CachimbitoSmokeDbContext : DbContext
    {
        CachimbitoSmokeDbContext(DbContextOptions<CachimbitoSmokeDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Prodcuto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prodcuto>().HasIndex(c => c.name).IsUnique();
        }
    }
}
