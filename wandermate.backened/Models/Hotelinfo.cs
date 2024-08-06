using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.Models
{
    public class Hotelinfo
    {
        [Key]
        public int Id{get;set;}

        public string Details{get;set;} = String.Empty;

        [ForeignKey("Hotel")]

        public int HotelId {get;set;}

        public Hotel hotel {get;set;}
    }
}