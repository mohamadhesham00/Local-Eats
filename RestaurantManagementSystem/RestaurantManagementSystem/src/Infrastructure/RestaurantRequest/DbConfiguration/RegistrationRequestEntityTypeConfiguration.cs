using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Infrastructure.RestaurantRequest.DbConfiguration
{
    public class RegistrationRequestEntityTypeConfiguration : IEntityTypeConfiguration<RegistrationRequest>
    {
        public void Configure(EntityTypeBuilder<RegistrationRequest> RegistrationRequestconfiguration)
        {
            RegistrationRequestconfiguration.ToTable("RegistrationRequests");
            RegistrationRequestconfiguration.HasKey(r => r.Id);
            RegistrationRequestconfiguration.Property(r => r.Name).IsRequired();
            RegistrationRequestconfiguration.Property(r => r.Email).IsRequired();
            RegistrationRequestconfiguration.Property(r => r.Address).IsRequired();
            RegistrationRequestconfiguration.OwnsOne(r => r.ContactInfo, Contact =>
            {
                Contact.Property(c => c.ContactEmail).HasColumnName("ContactEmail").IsRequired();
                Contact.Property(c => c.ContactPhoneNumber).HasColumnName("ContactPhoneNumber").IsRequired();

            });
            
            RegistrationRequestconfiguration.Property(r => r.VerificationCode);
            RegistrationRequestconfiguration.Property(r => r.Status).HasConversion<string>();
            RegistrationRequestconfiguration.Property(r => r.DateCreated);
            RegistrationRequestconfiguration.Property(r => r.VerificationCodeExpiresAt);

        }
    }
}