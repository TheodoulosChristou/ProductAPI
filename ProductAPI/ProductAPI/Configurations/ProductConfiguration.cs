using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Entities;
using System.Reflection.Emit;

namespace ProductAPI.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductName).HasMaxLength(250);

            builder.Property(p => p.ProductPrice).HasMaxLength(100);

            builder.Property(p => p.ProductPrice).HasPrecision(18, 2);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
