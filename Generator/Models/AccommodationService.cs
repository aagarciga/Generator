using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generator.Models
{
    public enum MealPlan
    {
        EP,
        CP,
        MAP,
        AP
    }
    public enum RoomType
    {
        Single,
        Double,
        Triple
    }
    public class AccommodationService
    {
        public RoomType RoomType { get; set; }
        public double Rate { get; set; }

        public MealPlan MealPlan { get; set; }
    }
}
