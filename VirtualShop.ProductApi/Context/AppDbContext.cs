using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context.Map;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories {  get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(c => c.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

        //Popular tabela
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

        base.OnModelCreating(modelBuilder);
    }
}