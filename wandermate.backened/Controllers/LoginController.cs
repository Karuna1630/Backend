using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Data;
using wandermate.backened.DTOs.HotelDTO;


namespace wandermate.backened.Controllers
{
    [Route("Wandermate_backened/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var registered = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginDTO.Username);
            if (registered == null)
            {
                return NotFound("User Not found!");
            }
             bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDTO.Password,registered.Password);
            if (!isPasswordValid)
            {
                return BadRequest("password didnot match!");

            }
            return Ok(registered);
        }
    }
}