using RestaurantManagementSystem.src.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using shortid;
using shortid.Configuration;
using RestaurantManagementSystem.src.Core.Exceptions;

namespace RestaurantManagementSystem.src.Core.Entities
{
    public class RegistrationRequest
    {
        
        //props
        public Guid Id;
        [Required]
        public string Name {get; }
        [Required]
        public string Email { get; }
        [Required]
        public string Address { get; }
        [Required]
        public ContactInfo ContactInfo { get;  }
        public string VerificationCode { get; private set; }
        public RegistrationRequestStatus Status { get; private set; }
        public DateTime DateCreated {  get; }
        public DateTime VerificationCodeExpiresAt {  get; }

        // Private constructor for EF
        private RegistrationRequest() { }

        //constructor
        private RegistrationRequest(Guid id, string name, string email
            , string address, ContactInfo contactInfo
            , string verificationcode
            , RegistrationRequestStatus status, DateTime datecreated
            , DateTime verificationcodeexpiresat)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.ContactInfo = contactInfo;
            this.VerificationCode = verificationcode;
            this.Status = status;
            this.DateCreated = datecreated;
            this.VerificationCodeExpiresAt = verificationcodeexpiresat;
        }
        //create method
        public static RegistrationRequest Create(string name, string email
            , string address, string contactinfoemail, string contactinfophonenumber, string verificationcode
            )
        {
            Guid id = Guid.NewGuid();
            ContactInfo Contact = ContactInfo.Create(contactinfoemail, contactinfophonenumber);
            RegistrationRequestStatus Status = RegistrationRequestStatus.PendingVerification;
            DateTime DateCreated = DateTime.Now.ToUniversalTime();
            DateTime VerificationCodeExpiresAt = DateCreated.AddHours(24);
            return new RegistrationRequest(id, name, email, address, Contact, verificationcode, Status, DateCreated, VerificationCodeExpiresAt);
        }

        //check if they are equal 
        
        public  void VertifyCode(string providedcode)
        {
            if(this.Status != RegistrationRequestStatus.PendingVerification)
            {
                throw new EmailIsAlreadyConfirmedException();
            }
            if (providedcode != this.VerificationCode)
            {
                throw new WrongVerificationCodeException();
            }
            this.Status = RegistrationRequestStatus.WaitingForAdminResponse;
            this.VerificationCode = null;
        }

    }
}
