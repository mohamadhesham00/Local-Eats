using RestaurantManagementSystem.src.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.src.UseCases.GetRegistrationRequests
{
    public class RestaurantRegistrationResponseDTO
    {
        public Guid Id;
        [Required]
        public string Name { get; }
        [Required]
        public string Email { get; }
        [Required]
        public string Address { get; }
        [Required]
        public ContactInfo ContactInfo { get; }
        public RegistrationRequestStatus Status { get; }
        public DateTime DateCreated { get; }

        public RestaurantRegistrationResponseDTO (Guid id,string name,string email,string address,ContactInfo contactInfo
            ,RegistrationRequestStatus status,DateTime dateCreated)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            ContactInfo = contactInfo;
            Status = status;
            DateCreated = dateCreated;
        }
        public static List<RestaurantRegistrationResponseDTO> from(List<RegistrationRequest> registrationRequests)
        {
            List<RestaurantRegistrationResponseDTO> RestautantRegistrationResponseDtos = new List<RestaurantRegistrationResponseDTO>();

            foreach (var registrationRequest in registrationRequests)
            {
                var registrationRequestDto = new RestaurantRegistrationResponseDTO
                (                
                    registrationRequest.Id,
                    registrationRequest.Name,
                    registrationRequest.Email,
                    registrationRequest.Address,
                    registrationRequest.ContactInfo,
                    registrationRequest.Status,
                    registrationRequest.DateCreated
                );

                RestautantRegistrationResponseDtos.Add(registrationRequestDto);
            }
            return RestautantRegistrationResponseDtos;

        }
    }
}
