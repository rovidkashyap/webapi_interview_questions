using Microsoft.EntityFrameworkCore;

namespace paging_sorting_filtering_in_web_api.Models
{ 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        // Seed Data for Dummy Purpose
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product 1", Price = 10.00m, Category = "Category 1" },
            new Product { Id = 2, Name = "Product 2", Price = 20.00m, Category = "Category 2" },
            new Product { Id = 3, Name = "Product 3", Price = 30.00m, Category = "Category 1" },
            new Product { Id = 4, Name = "Product 4", Price = 40.00m, Category = "Category 3" },
            new Product { Id = 5, Name = "Product 5", Price = 50.00m, Category = "Category 2" },
            new Product { Id = 6, Name = "Product 6", Price = 60.00m, Category = "Category 3" },
            new Product { Id = 7, Name = "Product 7", Price = 70.00m, Category = "Category 1" },
            new Product { Id = 8, Name = "Product 8", Price = 80.00m, Category = "Category 2" },
            new Product { Id = 9, Name = "Product 9", Price = 90.00m, Category = "Category 3" },
            new Product { Id = 10, Name = "Product 10", Price = 100.00m, Category = "Category 1" }
            );
        }
    }
}
