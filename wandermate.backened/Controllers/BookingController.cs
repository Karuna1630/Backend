// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using wandermate.backened.Data;
// using wandermate.backened.DTOs.HotelDTO.HotelBookingDTO;
// using wandermate.backened.Models;


// namespace wandermate.backened.Controllers
// {
//     [Route("wandermate_backned/booking")]
//     [ApiController]
//     public class BookingController: ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//         public BookingController(ApplicationDbContext context)
//         {
//             _context=context;
//         }


//         [HttpGet]
//                public async Task< IActionResult> GetAll(){
//             var booking = await _context.HotelBookings
//                 .Include(hb => hb.hotel)
//                 .Include(hb => hb.user)
//                 .ToListAsync();

//             var  bookingDTOs= booking.Select(booking=> new HotelBookingDTO{
//                 //  select is Same to map in js
//               Id = booking.Id,
//                 HotelName = booking.hotel.Name,
//                 UserName = booking.user.Username,
//                 BookingDate = booking.BookingDate,
//                 Duration = booking.Duration,
//                 Checkin = booking.CheckIn,
//                 Checkout = booking.CheckOut,
//                 TotalPrice = booking.TotalPrice


//             }).ToList();


//             return Ok(bookingDTOs);
//         }

//      [HttpGet("{id}")]
//         public async Task<IActionResult> GetById([FromRoute] int id)
//         {
//             var booking = await _context.HotelBookings
//                 .Where(hb => hb.Id == id)
//                 .Include(hb => hb.hotel)
//                 .Include(hb => hb.user)
//                 .Select(hb => new HotelBookingDTO
//                 {
//                     Id = hb.Id,
//                     HotelName = hb.hotel.Name,
//                     UserName = hb.user.Username,
//                     BookingDate = hb.BookingDate,
//                     Duration = hb.Duration,
//                     Checkin = hb.CheckIn,
//                     Checkout = hb.CheckOut,
//                     TotalPrice = hb.TotalPrice
//                 })
//                 .FirstOrDefaultAsync();

//             if (booking == null)
//             {
//                 return NotFound();
//             }

//             return Ok(booking);
//         }
//          [HttpPost]
//         public async Task<IActionResult> CreateBooking([FromBody] CreateHotelBookingDTO bookingDTO)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             var hotel = await _context.Hotel.FindAsync(bookingDTO.HotelId);
//             var user = await _context.Users.FindAsync(bookingDTO.UserId);

//             if (hotel == null || user == null)
//             {
//                 return BadRequest("Invalid HotelId or UserId.");
//             }

//             var booking = new Booking
//             {
//                 HotelId = bookingDTO.HotelId,
//                 UserId = bookingDTO.UserId,
//                 BookingDate = bookingDTO.BookingDate,
//                 Duration = bookingDTO.Duration,
//                 CheckIn = bookingDTO.Checkin,
//                 CheckOut = bookingDTO.Checkout,
//                 TotalPrice = bookingDTO.TotalPrice
//             };
//                try
//             {
//                 await _context.HotelBookings.AddAsync(booking);
//                 await _context.SaveChangesAsync();
//                 return CreatedAtAction(nameof(GetById), new { id = booking.Id }, bookingDTO);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, ex.Message);
//             }
//         }

            
//         [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateHotelBookingDTO bookingDTO)
//         {
//             var bookingInDatabase = await _context.HotelBookings.FindAsync(id);
//             if (bookingInDatabase == null)
//             {
//                 return NotFound();
//             }

//             bookingInDatabase.BookingDate = bookingDTO.BookingDate;
//             bookingInDatabase.Duration = bookingDTO.Duration;
//             bookingInDatabase.CheckIn = bookingDTO.Checkin;
//             bookingInDatabase.CheckOut = bookingDTO.Checkout;
//             bookingInDatabase.TotalPrice = bookingDTO.TotalPrice;

//             _context.Entry(bookingInDatabase).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!_context.HotelBookings.Any(hb => hb.Id == id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, ex.Message);
//             }

//             return NoContent();
//         }
        


//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteBooking([FromRoute] int id)
//         {
//             var bookingToDelete = await _context.HotelBookings.FindAsync(id);

//             if (bookingToDelete == null)
//             {
//                 return NotFound();
//             }

//             try
//             {
//                 _context.HotelBookings.Remove(bookingToDelete);
//                 await _context.SaveChangesAsync();
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, ex.Message);
//             }

//             return NoContent();
//         }
//     }
// }