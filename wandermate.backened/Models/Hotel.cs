using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace wandermate.backened.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public List<string> Image { get; set; } = new List<string>();

        public string Description { get; set; } = String.Empty;

        public int Rating { get; set; }

        public bool FreeCancellation { get; set; }

        public bool ReserveNow { get; set; }


        //  ONW TO ONE RELATION
        public Hotelinfo hotelinfo { get; set; }


        // ONE TO MANY RELATION
        public List<Review> HotelReviews { get; set; } = new List<Review>();


        public List<Booking> HotelBookings { get; set; } = new List<Booking>();

    }
}