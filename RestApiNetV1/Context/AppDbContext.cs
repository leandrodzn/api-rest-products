using Microsoft.EntityFrameworkCore;
using RestApiNetV1.Models;

namespace RestApiNetV1.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Setting precision and scale for Price property
            modelBuilder.Entity<Product>()
                 .Property(p => p.Price)
                .HasPrecision(18, 2); //18 total digits and 2 after period

            base.OnModelCreating(modelBuilder);
        }
    }
}
