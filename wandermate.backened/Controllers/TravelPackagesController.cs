using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using wandermate.backened.Data;
namespace wandermate.backened.Controllers
{
    [Route("wandermate_backened/travelpackages")]
    [ApiController]
    public class TravelPackagesController:ControllerBase
    {
   
    
        private readonly ApplicationDbContext _context;
        public TravelPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll(){
            var travelPackages = _context.TravelPackages.ToList();
            return Ok(travelPackages);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id){
            var travelPackages = _context.TravelPackages.Find(id);

            if (travelPackages == null){
                return NotFound();

            }
            return Ok(travelPackages);
        }

        

        
    }
}