using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using wandermate.backened.DTOs.HotelDTO.HotelBookingDTO;

namespace wandermate.backened.Models
{
    public class AppUser:IdentityUser
    {
        public List<Booking> HotelBookings {get;set;} = new List<Booking>();
    }
}