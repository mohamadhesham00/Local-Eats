using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementSystem.Src.Core.Entities
{
    [Table("Users")]
    public class User
    {
        public User(string firstName, string lastName, string email, string password) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}