using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ledeModels.Model
{
    public class PostBooking
    {
        public int MovieId { get; set; }
        public DateTime BookingDate { get; set; }
        public int PaymentMethodId { get; set; }
        public int HouseId { get; set; }
        public string Amount { get; set; }
        public int ShowMomentId { get; set; }
        public int CustomerId { get; set; }
        public string BookingNumber { get; set; }
    }
}
