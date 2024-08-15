using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}

        public int HotelId{get;set;}
        public Hotel? hotel{get;set;}//navigation property it can be null also

        public string UserId{get;set;}
        public AppUser? AppUser{get;set;}

        public DateTime BookingDate{get;set;}
        public int Duration{get;set;}
        public DateTime CheckIn{get;set;}

        public DateTime CheckOut{get;set;}
        [Range(0.01, double.MaxValue)]
        public decimal TotalPrice{get;set;}
    }
}