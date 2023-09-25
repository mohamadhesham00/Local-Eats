namespace UserManagementSystem.Src.Core.Entities;

using System.ComponentModel.DataAnnotations;

public class User
{
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
