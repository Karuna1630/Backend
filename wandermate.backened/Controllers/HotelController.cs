using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Data;
using wandermate.backened.DTOs.HotelDTO;
using wandermate.backened.Models;


namespace wandermate.backened.Controllers
{
    [Route("wandermate_backened/hotel")]
    [ApiController]
    public class HotelController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task< IActionResult> GetAll(){
            var hotels = await _context.Hotel.ToListAsync();

            var hotelDTO = hotels.Select(hotel=> new HotelDTO{
                Id = hotel.Id,
                Name = hotel.Name,
                Price = hotel.Price,
                Description = hotel.Description,
                Rating = hotel.Rating,
                FreeCancellation = hotel.FreeCancellation,
                ReserveNow = hotel.ReserveNow,


            }).ToList();


            return Ok(hotelDTO);
        }

        [HttpGet("{id}")]

      public async Task<IActionResult> GetById([FromRoute] int id) 
        {
             var hotel = await _context.Hotel.Where(h => h.Id == id)
             .Select(h => new HotelDTO
                {
                    Id = h.Id,
                    Name = h.Name,
                    Price = h.Price,
                    Image = h.Image,
                    Description = h.Description,
                    Rating = h.Rating,
                    FreeCancellation = h.FreeCancellation,
                    ReserveNow = h.ReserveNow
                })
                .FirstOrDefaultAsync();

             if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

    [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotelDTO) 
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel = new Hotel
            {
                Name = hotelDTO.Name,
                Price = hotelDTO.Price,
                Image = hotelDTO.Image,
                Description = hotelDTO.Description,
                Rating = hotelDTO.Rating,
                FreeCancellation = hotelDTO.FreeCancellation,
                ReserveNow = hotelDTO.ReserveNow
            };
               try
            {
                await _context.Hotel.AddAsync(hotel);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotelDTO);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }

       
    

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO hotelDTO)
        {

           var hotelInDatabase = await _context.Hotel.FindAsync(id);
            if (hotelInDatabase == null)
            {
                return NotFound();
            }

            hotelInDatabase.Name = hotelDTO.Name;
            hotelInDatabase.Price = hotelDTO.Price;
            hotelInDatabase.Image = hotelDTO.Image;
            hotelInDatabase.Description = hotelDTO.Description;
            hotelInDatabase.Rating = hotelDTO.Rating;
            hotelInDatabase.FreeCancellation = hotelDTO.FreeCancellation;
            hotelInDatabase.ReserveNow = hotelDTO.ReserveNow;

            _context.Entry(hotelInDatabase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hotel.Any(h => h.Id == id))
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
              
                return StatusCode(500, ex);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id) 
        {
            var hotelToDelete = await _context.Hotel.FindAsync(id);

            if (hotelToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _context.Hotel.Remove(hotelToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, ex);
            }

            return NoContent();
        }
    }
}