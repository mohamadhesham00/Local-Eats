using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace RestaurantManagementSystem.src.Core.RestaurantManagement.Entities
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
