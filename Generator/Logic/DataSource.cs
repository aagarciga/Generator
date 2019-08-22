using Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generator.Logic
{
    public static class DataSource
    {
        public static List<Pax> GetPaxList()
        {
            return new List<Pax>
            {
                new Pax { Name="Yenislexis",       LastName="Pereira Pereira",  Gender=Sex.Female,    Passport="", FlightBookingPNR="8W2CNJ ", AccommodationBookingPNR="HM4503", AccommodationBookingStaying="09 Aug - 13 Aug", AccommodationBookingNights=4},
                new Pax { Name="Yeniseys",     LastName="Hernandez Pereira", Gender=Sex.Female,  Passport=" ", FlightBookingPNR="8W2CNJ ", AccommodationBookingPNR="HM4503", AccommodationBookingStaying="09 Aug - 13 Aug", AccommodationBookingNights=4}
            };
        }


        public static AccommodationReservation GetAccommodationReservation()
        {
            var pnr = "HM4503";
            var checkIn = new DateTime(2019, 8, 9);
            var checkOut = new DateTime(2019, 8, 13);

            return new AccommodationReservation
            {
                PNR = pnr,
                CheckIn = checkIn,
                CheckOut = checkOut,
                IssueDate = DateTime.Now,
                AccommodationServices = new List<AccommodationService>
                {
                    new AccommodationService
                    {
                        MealPlan = MealPlan.MAP,
                        RoomType = RoomType.Double,
                        Rate = 44.00
                    }
                },
                Guests = new List<Pax>
                {

                    new Pax
                    {
                        Name = "Yenislexis",
                        LastName = "Pereira Pereira",
                        Gender = Sex.Female,
                        Passport = "",
                        FlightBookingPNR = "8W2CNJ",
                        PaxType = PaxType.Adult,                            
                        PassportExpire = new DateTime(2024, 9, 12), // Not
                        BirthDate = new DateTime(1993, 2, 9), // Not
                        Nationality = "CU",
                        AccommodationBookingPNR = pnr,
                        AccommodationBookingNights = (uint)(checkOut - checkIn).Days,
                        AccommodationBookingStaying = string.Format("{0} - {1}", checkIn.ToString("dd MMMM"), checkOut.ToString("dd MMMM"))
                    },
                     new Pax
                    {
                        Name = "Yeniseys",
                        LastName = "Hernandez Pereira",
                        Gender = Sex.Female,
                        Passport = "",
                        FlightBookingPNR = "8W2CNJ",
                        PaxType = PaxType.Adult,
                        PassportExpire = new DateTime(2024, 9, 12),
                        BirthDate = new DateTime(1993, 2, 9),
                        Nationality = "CU",
                        AccommodationBookingPNR = pnr,
                        AccommodationBookingNights = (uint)(checkOut - checkIn).Days,
                        AccommodationBookingStaying = string.Format("{0} - {1}", checkIn.ToString("dd MMMM"), checkOut.ToString("dd MMMM"))
                    }
                },
                CommercialDocuments = new List<CommercialDocument> {
                    new CommercialDocument{
                         Id = 1,
                         BookingId = pnr,
                         Code = string.Format( "{0}-01", pnr),
                         Currency = Currency.USD,
                         Amount = 0
                    }
                }
            };
        }
    }
}
