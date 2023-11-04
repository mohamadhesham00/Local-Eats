using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace RestaurantManagementSystem.src.Core.Common.Entities
{
    public class ContactInfo
    {
        public ContactInfo()
        {

        }
        private ContactInfo(string contactEmail, string contactPhoneNumber)
        {
            ContactEmail = contactEmail;
            ContactPhoneNumber = contactPhoneNumber;
        }
        public static ContactInfo Create(string contactEmail, string contactPhoneNumber)
        {
            return new ContactInfo(contactEmail, contactPhoneNumber);
        }
        public string ContactEmail { get; private set; }
        public string ContactPhoneNumber { get; private set; }

    }
}
