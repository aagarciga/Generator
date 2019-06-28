using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Generator.Models
{
    public enum Sex
    {
        Male,
        Female
    }

    public enum PaxType
    {
        Adult,
        Child,
        Infant
    }

    public class Pax
    {

        private string _name;
        private string _lastName;

        public string Name {
            get => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_name);
            set => _name = value.ToLower();
        }
        public string LastName {
            get => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_lastName);
            set => _lastName = value.ToLower();
        }

        public string FullName => string.Format("{0}, {1}", LastName, Name);
        public string Passport { get; set; }
        public string Nationality { get; set; }
        public Sex Gender { get; set; }
        public PaxType PaxType { get; set; }

        public DateTime PassportExpire { get; set; }
        public DateTime BirthDate { get; set; }
        public string FlightBookingPNR { get; set; }
        public string AccommodationBookingPNR { get; set; }
        public string AccommodationBookingStaying { get; set; }
        public uint AccommodationBookingNights { get; set; }

    }
}
