using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Entities;
namespace ShopApi.Data.EfConfigurations;

public class ShoppingCartEntityConfiguration
    : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("ShoppingCart");
        builder.HasOne(x => x.User)
                .WithMany(x => x.ShoppingCarts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Address)
              .WithMany(x => x.ShoppingCarts)
              .HasForeignKey(x => x.AddressId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}