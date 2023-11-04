using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;

namespace RestaurantManagementSystem.src.Infrastructure.RestaurantManagement.DbConfiguration
{
    public class RestaurantEntityTypeConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r =>r.Id);
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Address).IsRequired();
            builder.Property(r => r.AvgRating).HasColumnType("decimal(18,2)"); // Example data type for AvgRating
            builder.OwnsOne(r => r.ContactInfo, Contact =>
            {
                Contact.Property(c => c.ContactEmail).HasColumnName("ContactEmail").IsRequired();
                Contact.Property(c => c.ContactPhoneNumber).HasColumnName("ContactPhoneNumber").IsRequired();

            });

            builder.Property(r => r.DeliveryTime)
            .HasColumnType("jsonb"); // Use jsonb data type in the database

            // Define the one-to-many relationship between Restaurant and RestaurantMenuItem
            builder.HasMany(r => r.Menu)
                .WithOne(m => m.Restaurant)
                .HasForeignKey(m => m.RestaurantId);

        }
    }
    
}
