using DayOfWeek = RestaurantManagementSystem.Core.Common.Entities.DayOfWeek;

namespace RestaurantManagementSystem.Core.RestaurantManagement.Entities
{
    public class DeliveryTime
    {
        public string Name;
        public DayOfWeek DayOfWeek;
        public TimeSpan StartTime;
        public TimeSpan EndTime;

        
        private static DayOfWeek DetermineDay(int day)
        {
            DayOfWeek[] DaysOfWeek = { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday
                    ,DayOfWeek.Wednesday,DayOfWeek.Thursday,DayOfWeek.Friday,DayOfWeek.Saturday
            };
            return DaysOfWeek[day];
        }
    }
}
