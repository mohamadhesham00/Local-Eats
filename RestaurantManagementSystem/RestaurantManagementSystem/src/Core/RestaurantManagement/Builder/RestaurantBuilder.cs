using RestaurantManagementSystem.src.Core.Common.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;

namespace RestaurantManagementSystem.src.Core.RestaurantManagement.Builder
{
    public class RestaurantBuilder
    {
        private Guid id;
        private string name;
        private string description;
        private string address;
        private double avgRating;
        private ContactInfo contactInfo;
        private List<RestaurantMenuItem> menu;
        private List<DeliveryTime> deliveryTime;

        public RestaurantBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public RestaurantBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public RestaurantBuilder WithDescription(string description)
        {
            this.description = description;
            return this;
        }
        
        public RestaurantBuilder WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public RestaurantBuilder WithAvgRating(double avgRating)
        {
            this.avgRating = avgRating;
            return this;
        }

        public RestaurantBuilder WithContactInfo(ContactInfo contactInfo)
        {
            this.contactInfo = contactInfo;
            return this;
        }

        public RestaurantBuilder WithMenu(List<RestaurantMenuItem> menu)
        {
            this.menu = menu;
            return this;
        }

        public RestaurantBuilder WithDeliveryTimes(List<DeliveryTime> deliveryTimes)
        {
            
            this.deliveryTime = deliveryTimes;
            return this;
        }
        public Restaurant Build()
        {
            return new Restaurant
            {
                Id = id,
                Name = name,
                Description = description,
                Address = address,
                AvgRating = avgRating,
                ContactInfo = contactInfo,
                Menu = menu,
                DeliveryTime = deliveryTime
            };
        }
    }

}
