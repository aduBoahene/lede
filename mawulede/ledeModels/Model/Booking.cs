using System;
using System.Collections.Generic;
using System.Text;

namespace ledeModels.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public String Title { get; set; }
        public String FullName { get; set; }
        public DateTime BookingDate { get; set; }
        public int HouseId { get; set; }
        public String PaymentName { get; set; }
        public String Amount { get; set; }
        public String HouseName { get; set; }
        public String Day { get; set; }
        public string Time { get; set; }
        public string BookingNumber { get; set; }
    }
}
