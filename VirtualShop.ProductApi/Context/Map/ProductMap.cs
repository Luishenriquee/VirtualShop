using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context.Map;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(255).IsRequired();
        builder.Property(p => p.ImageURL).HasMaxLength(255).IsRequired();
        builder.Property(p => p.Price).HasPrecision(12, 2);
    }
}