using EcommerceManagementProject.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceManagementProject.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<CartsModel>
    {
        public void Configure(EntityTypeBuilder<CartsModel> builder)
        {
            builder.ToTable("Carts");
            builder.HasOne(x => x.User)
                .WithOne(x => x.Carts)
                .HasForeignKey<CartsModel>(x => x.UserId)
                .HasPrincipalKey<CartsModel>(x => x.CartId)
                .IsRequired(false);
        }
    }
}
