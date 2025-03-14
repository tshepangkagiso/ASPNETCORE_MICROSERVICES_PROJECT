using Microsoft.EntityFrameworkCore;
using ShirtsApp.Api.Data.Models;

namespace ShirtsApp.Api.Data.Database_Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){ }
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shirt>().HasData(
              new Shirt {ShirtID=1, Brand = "Polo",Color="Black", Size=30 },
                new Shirt { ShirtID = 2, Brand = "Nike", Color = "Gray", Size = 50 },
                new Shirt { ShirtID = 3, Brand = "D&G", Color = "Red", Size = 28 },
                new Shirt { ShirtID = 4, Brand = "Puma", Color = "Blue", Size = 14 }
            );
        }
    }
}
