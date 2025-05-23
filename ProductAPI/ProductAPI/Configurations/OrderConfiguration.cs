using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Entities;

namespace ProductAPI.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => new { o.OrderId, o.ProductId, o.UserId });

            builder.HasOne(o=>o.Product)
                .WithMany(p=>p.Orders)
                .HasForeignKey(o=>o.ProductId);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
        }
    }
}
