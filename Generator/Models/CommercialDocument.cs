using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generator.Models
{
    public enum Currency {
        USD,
        EUR
    }
    public class CommercialDocument
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }

        public string BookingId { get; set; }

        public string Code { get; set; }
    }
}
