using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wandermate.backened.Models
{
    public class Review
    {
        [Key]

        public int ReviewId{get;set;}

        public int Rating{get;set;}
        public string ReviewText {get;set;} = String.Empty;

        public DateTime CreatedOn{get;set;} = DateTime.UtcNow;

        public int? HotelId {get;set;}
        public Hotel? Hotel{get;set;}

                 
    }
}