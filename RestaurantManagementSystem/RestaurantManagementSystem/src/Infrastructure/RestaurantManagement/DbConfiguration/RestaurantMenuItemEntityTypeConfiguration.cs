using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;

namespace RestaurantManagementSystem.src.Infrastructure.RestaurantManagement.DbConfiguration
{
    public class RestaurantMenuItemEntityTypeConfiguration : IEntityTypeConfiguration<RestaurantMenuItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantMenuItem> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal(18,2)").IsRequired(); // Example data type for Price
            builder.Property(m => m.Ingredients).IsRequired();
            builder.Property(m => m.Description).IsRequired();

            // Define the many-to-one relationship with Restaurant
            builder.HasOne(m => m.Restaurant)
                .WithMany(r => r.Menu)
                .HasForeignKey(m => m.RestaurantId);

        }
    }
}
