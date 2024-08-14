using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wandermate.backened.Data;
using wandermate.backened.Models;

namespace wandermate.backened.Controllers
{
    [Route("api/HotelReviews")]
    [ApiController]
    public class HotelReviewsController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HotelReviewsController(ApplicationDbContext context)
          {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var review = _context.HotelReviews.ToList();
            return Ok(review);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id){
            var review = _context.HotelReviews.Find(id);
              if (review == null){
                return NotFound();

            }

            return Ok(review);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Review review){
            if(review == null){
                return BadRequest();
            }
            _context.HotelReviews.Add(review);
            _context.SaveChanges();

            return Ok(review);
        
        }

         [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Review data ){
            var update = _context.HotelReviews.Find(id);
            if(data == null){
                return BadRequest();

            }
            update.Rating = data.Rating;
            update.ReviewText = data.ReviewText;

            _context.HotelReviews.Update(update);
            _context.SaveChanges();
            return Ok(update);
          
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromBody] Review data){
            var delete = _context.HotelReviews.Find(id);
            if (data ==null){
                return BadRequest();
            }
            _context.HotelReviews.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }

      


    }
}