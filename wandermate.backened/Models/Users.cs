// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;

// namespace wandermate.backened.Models
// {
//     public class Users
//     {
//         [Key]
//         public int Id { get; set; }
//         [Required]

//         public string Username { get; set; } = String.Empty;

//         public string Email { get; set; } = String.Empty;

//         public string Password { get; set; } = String.Empty;
//         public string ConfirmPassword { get; set; } = String.Empty;


// // ONe to many relation
//         public List<Booking> HotelBooking { get; set; } = new List<Booking>();



//     }
// }