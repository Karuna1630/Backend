using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Data;
using wandermate.backened.DTOs.CurrentUserBooking;
using wandermate.backened.DTOs.CurrentUserBookingDTO;
using wandermate.backened.Extensions;
using wandermate.backened.Models;

namespace wandermate.backened.Controllers
{
    [Authorize]
    [Route("api/userbookings")]
    [ApiController]
    public class CurrentUserHotelBooking : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CurrentUserHotelBooking(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = User.GetUserId();
            var bookings = await _context.HotelBookings
                .Where(hb => hb.UserId == user)
                .Include(hb => hb.hotel)
                .Include(hb => hb.AppUser)
                .ToListAsync();

            var bookingDTOs = bookings.Select(booking => new UserBookingDTO
            {
                //  select is Same to map in js
                Id = booking.Id,
                HotelName = booking.hotel.Name,
                UserName = booking.AppUser.UserName,
                BookingDate = booking.BookingDate,
                Duration = booking.Duration,
                Checkin = booking.CheckIn,
                Checkout = booking.CheckOut,
                TotalPrice = booking.TotalPrice


            }).ToList();


            return Ok(bookingDTOs);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = User.GetUserId();
            var hotel = await _context.Hotel.FindAsync(bookingDTO.HotelId);

            if (hotel == null)
            {
                return BadRequest("Invalid HotelId.");
            }

            var booking = new Booking
            {
                HotelId = bookingDTO.HotelId,
                UserId = user, // Automatically set the current user's ID
                BookingDate = bookingDTO.BookingDate,
                Duration = bookingDTO.Duration,
                CheckIn = bookingDTO.Checkin,
                CheckOut = bookingDTO.Checkout,
                TotalPrice = bookingDTO.TotalPrice
            };

            try
            {
                await _context.HotelBookings.AddAsync(booking);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAll), new { id = booking.Id }, booking); // Use GetAll as there's no GetById
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

           [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateUserBookingDTO updateUserBookingDTO)
        {
            var user = await _userManager.GetUserAsync(User);
            var bookingInDatabase = await _context.HotelBookings
                .Where(hb => hb.Id == id && hb.UserId == user.Id)
                .FirstOrDefaultAsync();

            if (bookingInDatabase == null)
            {
                return NotFound();
            }

            bookingInDatabase.BookingDate = updateUserBookingDTO.BookingDate;
            bookingInDatabase.Duration = updateUserBookingDTO.Duration;
            bookingInDatabase.CheckIn = updateUserBookingDTO.Checkin;
            bookingInDatabase.CheckOut = updateUserBookingDTO.Checkout;
            bookingInDatabase.TotalPrice = updateUserBookingDTO.TotalPrice;

            _context.Entry(bookingInDatabase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.HotelBookings.Any(hb => hb.Id == id && hb.UserId == user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var bookingToDelete = await _context.HotelBookings
                .Where(hb => hb.Id == id && hb.UserId == user.Id)
                .FirstOrDefaultAsync();

            if (bookingToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _context.HotelBookings.Remove(bookingToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }
}

 
}
