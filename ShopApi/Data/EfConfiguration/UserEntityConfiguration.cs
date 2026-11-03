using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Entities;

namespace ShopApi.Data.EfConfigurations;

public class UserEntityConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Mobile)
              .HasMaxLength(11)
              .IsRequired();

        builder.Property(x => x.PasswordHash)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasMany(x => x.ProductComments)
          .WithOne(x => x.User)
          .HasForeignKey(x => x.UserId);
    }
}