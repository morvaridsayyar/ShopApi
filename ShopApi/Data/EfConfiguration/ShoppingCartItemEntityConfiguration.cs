using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Entities;
namespace ShopApi.Data.EfConfigurations;

public class ShoppingCartItemEntityConfiguration
    : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.ToTable("ShoppingCartItems");
        builder.HasOne(x => x.ShoppingCart)
            .WithMany(x => x.ShoppingCartItems)
            .HasForeignKey(x => x.ShoppingCartId);
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ShoppingCartItems)
            .HasForeignKey(x => x.ProductId);
    }
}