using Microsoft.EntityFrameworkCore;
using WSM.Catalog.Api.Models;

namespace WSM.Catalog.Api.Context;

public class AppDbContextCatalog : DbContext
{
    public AppDbContextCatalog(DbContextOptions<AppDbContextCatalog> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    //Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
        modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(c => c.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                Name = "Material Escolar"
            },
            new Category
            {
                CategoryId = 2,
                Name = "Acessórios"
            }
        );


        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.ImagenUrl).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(12,2);  
        


        base.OnModelCreating(modelBuilder);
    }

}
