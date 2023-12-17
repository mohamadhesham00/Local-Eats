using System.ComponentModel.DataAnnotations;
using RestaurantManagementSystem.Core.Common.Entities;

namespace RestaurantManagementSystem.Core.RestaurantManagement.Entities
{
    public class Restaurant
    {
        [Required]
        public Guid Id;

        [Required]
        public string Name;

        public string? Description;

        [Required]
        public string? Address;

        public double? AvgRating;

        [Required]
        public ContactInfo? ContactInfo;

        public List<DeliveryTime>? DeliveryTime;

        //NavigationProperty
        public List<RestaurantMenuItem>? Menu;

        
    }
}
