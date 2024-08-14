using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.Models
{
    public class Booking
    {
        [Key]
        public int Id{get;set;}
        public int HotelId{get;set;}
        public Hotel? hotel{get;set;}//navigation property it can be null also

        // public int UserId{get;set;}
        // public Users? user{get;set;}

        public DateTime BookingDate{get;set;}
        public int Duration{get;set;}
        public DateTime CheckIn{get;set;}

        public DateTime CheckOut{get;set;}
        public int TotalPrice{get;set;}
    }
}