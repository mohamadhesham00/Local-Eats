namespace RestaurantManagementSystem.Core.RestaurantManagement.Entities
{
    public class RestaurantMenuItem
    { 
        public Guid Id;
        public Guid RestaurantId;
        public string Name;
        public double Price;
        public string[] Ingredients;
        public string Description;
        
        //NavigationProperty
        public Restaurant Restaurant;

        
    }
}
