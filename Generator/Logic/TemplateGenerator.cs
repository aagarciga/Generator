using Generator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Logic
{

    public enum Accommodation
    {
        HotelMaretraite
    }

    public enum ReportType {
        ReservationConfirmation,
        Invoice
    }

    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            uint counter = 1;
            List<Pax> passengers = DataSource.GetPaxList();

            StringBuilder sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'>
                                    <img id='logo' src='data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAfUAAAH0CAYAAAAkFLS0AAAACXBIWXMAAAsSAAALEgHS3X78AAAdbklEQVR4nO3dza + dZbnA4acnjoEzPdGIM6Im1glGJtZEAmdE / QgMKQbG7IY5pYwPoYwlbRlKFDYjIZBYJxKdWBIlzMRoYGjxH9gnd1dfuthde + 318X48z / 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'/>
                                    <p>Airlineproxy</p>                                    
                                    <h1>Passenger Name List</h1>
                                </div>
                                <table align='center'>
                                    <tr>
                                        <th>No.</th>
                                        <th>Full Name</th>                                    
                                        <th>Gender</th>
                                        <th>Passport</th>
                                        <th>Fligth Booking</th>
                                        <th>Accommodation Booking</th>
                                        <th>Staying</th>
                                        <th>Nights</th>
                                    </tr>");

            foreach (Pax passenger in passengers)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                  </tr>",
                                  counter++,
                                  passenger.FullName,
                                  passenger.Gender,
                                  passenger.Passport,
                                  passenger.FlightBookingPNR,
                                  passenger.AccommodationBookingPNR,
                                  passenger.AccommodationBookingStaying,
                                  passenger.AccommodationBookingNights);
                
            }

            sb.Append(@"
                                </table>

                                <footer>
                                    <ul>
                                        <li>Phone: +597 867-7537</li>
                                        <li>WhatsApp: +597 867-7537</li>
                                        <li>Facebook: @airlineproxy</li>
                                    </ul>
                                </footer>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public static string GetHTMLForHotelMaretraiteReservationConfirmation(AccommodationReservation model, bool commissionable = false)
        {
            const double COMMISSION_VALUE = 3.0;
            const string LONG_DATE_FORMAT = "dd MMMM yyyy";
            const string CURRENCY_FORMAT = "$0,0.00";

            string templatePath = Path.Combine(@"C:\Users\Alex\source\repos\Generator\", "Assets", "Templates", "Reports");
            string templateName = "Reservation.Confirmation.Hotel.Maretraite.Template.html";

            double total = calculateTotal(model);
            int nights = (model.CheckOut - model.CheckIn).Days;
            double paidInAdvance = commissionable ? (nights * COMMISSION_VALUE) : 0;
            double totalDue = total - paidInAdvance;

            string result = File.ReadAllText(Path.Combine(templatePath, templateName));

            result = result.Replace("{IssueDate}", model.IssueDate.ToShortDateString());
            result = result.Replace("{AccommodationPNR}", model.PNR);
            result = result.Replace("{CheckIn}",  model.CheckIn.ToString(LONG_DATE_FORMAT));
            result = result.Replace("{CheckOut}",  model.CheckOut.ToString(LONG_DATE_FORMAT)); 
            
            result = result.Replace("{TBodyAccommodationServices}", buildAccommodationServiceTableBody(model, nights, total, CURRENCY_FORMAT));
            result = result.Replace("{Total}",total.ToString(CURRENCY_FORMAT));
            result = result.Replace("{PaidInAdvance}", paidInAdvance.ToString(CURRENCY_FORMAT));
            result = result.Replace("{TotalDue}", totalDue.ToString(CURRENCY_FORMAT));

            result = result.Replace("{TBodyGuests}", buildGuestsTableBody(model));

            return result;
        }


        private static double calculateTotal(AccommodationReservation model) {
            double result = 0;
            int nights = (model.CheckOut - model.CheckIn).Days;

            foreach (var accommodationService in model.AccommodationServices)
            {
                result += nights * accommodationService.Rate;
            }

            return result;
        }

        private static string buildAccommodationServiceTableBody(AccommodationReservation model, int nights, double total, string currencyFormat) {
            StringBuilder result = new StringBuilder();

            foreach (AccommodationService accommodationService in model.AccommodationServices)
            {
                result.AppendFormat(
                $@"
                    <tr>
                        <td>{{0}}</td>
                        <td>{{1}}</td>
                        <td>{{2}}</td>
                        <td>{{3}}</td>
                        <td>{{4:{currencyFormat}}}/night</td>
                        <td>{{5:{currencyFormat}}}</td>
                    </tr>",


                model.AccommodationServices.Count,
                accommodationService.RoomType,
                accommodationService.MealPlan,
                nights,
                accommodationService.Rate,
                total
                );               
            }
            return result.ToString();
        }

        private static string buildGuestsTableBody(AccommodationReservation model)
        {
            StringBuilder result = new StringBuilder();
            foreach (Pax pax in model.Guests)
            {
                result.AppendFormat(
                @"
                    <tr>
                        <td>{0}</td>
                        <td>{1}</td>
                        <td>{2}</td>
                    </tr>
                ",
                (pax.Gender == Sex.Male?"Mr.": "Mrs."),
                pax.FullName,
                pax.Passport
                );
            }
            return result.ToString();
        }
       
    }
}
