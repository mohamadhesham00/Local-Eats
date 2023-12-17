using System.ComponentModel.DataAnnotations;
using MediatR;
using RestaurantManagementSystem.Core.Common.Entities;
using RestaurantManagementSystem.Core.Common.Exceptions.CodeGeneratorExceptions;
using RestaurantManagementSystem.Core.RestaurantRequest.DomainEvents;
using RestaurantManagementSystem.Core.RestaurantRequest.Exceptions;

namespace RestaurantManagementSystem.Core.RestaurantRequest.Entities
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
            , string verificationCode
            , RegistrationRequestStatus status, DateTime dateCreated
            , DateTime verificationCodeExpiresAt)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.ContactInfo = contactInfo;
            this.VerificationCode = verificationCode;
            this.Status = status;
            this.DateCreated = dateCreated;
            this.VerificationCodeExpiresAt = verificationCodeExpiresAt;
        }
        //create method
        public static RegistrationRequest Create(string name, string email
            , string address, string contactinfoEmail, string contactinfoPhoneNumber, string verificationCode
            )
        {
            Guid id = Guid.NewGuid();
            ContactInfo Contact = ContactInfo.Create(contactinfoEmail, contactinfoPhoneNumber);
            RegistrationRequestStatus Status = RegistrationRequestStatus.PendingVerification;
            DateTime DateCreated = DateTime.Now.ToUniversalTime();
            DateTime VerificationCodeExpiresAt = DateCreated.AddHours(24);
            return new RegistrationRequest(id, name, email, address, Contact, verificationCode, Status, DateCreated, VerificationCodeExpiresAt);
        }

        private List<INotification> _domainEvents= new List<INotification>();
        public List<INotification> DomainEvents => _domainEvents;
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        //check if they are equal 

        public void VertifyCode(string providedcode)
        {
            if(this.Status != RegistrationRequestStatus.PendingVerification)
            {
                throw new EmailIsAlreadyConfirmedException();
            }
            if(DateTime.Now >this.VerificationCodeExpiresAt)
            {
                throw new CodeExpiredException();
            }
            if (providedcode != this.VerificationCode)
            {
                throw new WrongVerificationCodeException();
            }
            this.Status = RegistrationRequestStatus.WaitingForAdminResponse;
            this.VerificationCode = "Approved";
        }
        
        public void ApproveRequest()
        {
            if(this.Status != RegistrationRequestStatus.WaitingForAdminResponse)
            {
                throw new RequestCannotBeAcceptedException();
            }
                this.Status = RegistrationRequestStatus.Approved;
                AddDomainEvent(new RequestApprovedDomainEvent(this));
        }

    }
}
