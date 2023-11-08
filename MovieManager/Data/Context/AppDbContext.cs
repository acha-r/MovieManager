using Microsoft.EntityFrameworkCore;
using MovieManager.Models.Entities;

namespace MovieManager.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(p => p.Genre)
                    .HasConversion(
                        e => string.Join(',', e),
                        e => e.Split(',', StringSplitOptions.RemoveEmptyEntries));
            });
        }
    }
}
