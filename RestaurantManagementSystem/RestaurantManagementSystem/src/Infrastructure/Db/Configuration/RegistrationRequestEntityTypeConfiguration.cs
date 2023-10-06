using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Db;

namespace RestaurantManagementSystem.src.Infrastructure.Configuration
{
    public class RegistrationRequestEntityTypeConfiguration : IEntityTypeConfiguration<RegistrationRequest>
    {
        public void Configure(EntityTypeBuilder<RegistrationRequest> waitinglistRestaurantconfiguration)
        {
            waitinglistRestaurantconfiguration.ToTable("RegistrationRequests");
            waitinglistRestaurantconfiguration.HasKey(r => r.Id);
            waitinglistRestaurantconfiguration.Property(r => r.Name).IsRequired();
            waitinglistRestaurantconfiguration.Property(r => r.Email).IsRequired();
            waitinglistRestaurantconfiguration.Property(r => r.Address).IsRequired();
            waitinglistRestaurantconfiguration.OwnsOne(r => r.ContactInfo, Contact =>
            {
                Contact.Property(c => c.ContactEmail).HasColumnName("ContactEmail").IsRequired();
                Contact.Property(c => c.ContactPhoneNumber).HasColumnName("ContactPhoneNumber").IsRequired();

            });
            
            waitinglistRestaurantconfiguration.Property(r => r.VerificationCode);
            waitinglistRestaurantconfiguration.Property(r => r.Status);
            waitinglistRestaurantconfiguration.Property(r => r.DateCreated);
            waitinglistRestaurantconfiguration.Property(r => r.VerificationCodeExpiresAt);

        }
    }
}