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
                new Pax { Name="ALBERTO ALEJANDRO",       LastName="GONZALEZ DIEGUEZ",  Gender=Sex.Male,  Passport="J738417", FlightBookingPNR="8W27IO", AccommodationBookingPNR="HM4494", AccommodationBookingStaying="24 Jun - 1 Jul", AccommodationBookingNights=7},
                new Pax { Name="MARGARITA",     LastName="FERRANDO BRINGAS",    Gender=Sex.Female,  Passport="K468865", FlightBookingPNR="8W27IO", AccommodationBookingPNR="HM4494", AccommodationBookingStaying="24 Jun - 1 Jul", AccommodationBookingNights=7},
                new Pax { Name="BARAINA",       LastName="MENENDEZ ROMERO",     Gender=Sex.Female,  Passport="K439853", FlightBookingPNR="8W27IO", AccommodationBookingPNR="HM4494", AccommodationBookingStaying="24 Jun - 1 Jul", AccommodationBookingNights=7}
            };
        }

        public static AccommodationReservation GetAccommodationReservation()
        {
            var pnr = "HM4495";
            var checkIn = new DateTime(2019, 7, 15);
            var checkOut = new DateTime(2019, 7, 22);

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
                        RoomType = RoomType.Single,
                        Rate = 44.00
                    }
                },
                Guests = new List<Pax>
                {
                    new Pax
                    {
                        Name = "Miguel Emilio",
                        LastName = "Ceballos Dominguez",
                        Gender = Sex.Male,
                        Passport = "K041930",
                        FlightBookingPNR = "8W285B",
                        PaxType = PaxType.Adult,                            
                        PassportExpire = new DateTime(2025, 01, 25),
                        BirthDate = new DateTime(1983, 04, 14),
                        Nationality = "CU",
                        AccommodationBookingPNR = pnr,
                        AccommodationBookingNights = (uint)(checkOut - checkIn).Days,
                        AccommodationBookingStaying = string.Format("{0} - {1}", checkIn.ToString("dd MMMM"), checkOut.ToString("dd MMMM"))
                    }
                }
            };
        }
    }
}
