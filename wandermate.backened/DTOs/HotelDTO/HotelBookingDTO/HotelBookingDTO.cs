using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.DTOs.HotelDTO.HotelBookingDTO
{
    public class HotelBookingDTO
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public int Duration { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int TotalPrice { get; set; }
    }
}