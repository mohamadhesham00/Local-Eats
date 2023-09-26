using RestaurantManagementSystem.src.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using shortid;
using shortid.Configuration;

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
        public string VerificationCode { get; }
        public Status Status { get; private set; }
        public DateTime DateCreated {  get; }
        public DateTime VerificationCodeExpiresAt {  get; }

        // Private constructor for EF
        private RegistrationRequest() { }

        //constructor
        private RegistrationRequest(Guid id, string name, string email
            , string address, ContactInfo contactInfo
            , string verificationcode
            , Status status, DateTime datecreated
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
            , string address, string contactinfoemail, string contactinfophonenumber,Status status, string verificationcode
            )
        {
            Guid id = Guid.NewGuid();
            DateTime datecreated = DateTime.Now.ToUniversalTime();
            DateTime verificationvodeexpiresAt = datecreated.AddHours(24);
            ContactInfo contact = ContactInfo.Create(contactinfoemail, contactinfophonenumber);
            return new RegistrationRequest(id, name, email, address, contact, verificationcode, status, datecreated, verificationvodeexpiresAt);
        }

        //check if they are equal 
        
        public  void VertifyCode(string providedcode)
        {
            if(this.Status ==Status.PendingVerification){
                if (providedcode == this.VerificationCode)
                {
                    this.Status = Status.WaitingForAdminResponse;
                }
            }
        }
        
    }
}
