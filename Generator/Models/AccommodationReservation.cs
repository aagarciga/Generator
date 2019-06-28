using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generator.Models
{
    public class AccommodationReservation
    {
        public string PNR { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public double Total { get; set; }

        public List<AccommodationService> AccommodationServices { get; set; }
        public List<Pax> Guests { get; set; }
       
    }
}
