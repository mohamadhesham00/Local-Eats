namespace UserManagementSystem.src.Core.Entities;

using System.ComponentModel.DataAnnotations;

public class Restaurant
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string ContactInfo { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }

}
