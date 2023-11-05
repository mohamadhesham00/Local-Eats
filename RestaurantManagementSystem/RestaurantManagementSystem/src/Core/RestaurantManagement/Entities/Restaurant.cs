
using RestaurantManagementSystem.src.Core.Common.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace RestaurantManagementSystem.src.Core.RestaurantManagement.Entities
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
