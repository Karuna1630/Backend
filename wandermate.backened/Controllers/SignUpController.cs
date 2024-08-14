// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Hosting.Builder;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using wandermate.backened.Data;
// using wandermate.backened.DTOs.SignUpDTO;
// using wandermate.backened.DTOs.UsersDTO;
// using wandermate.backened.Models;

// namespace wandermate.backened.Controllers
// {
//     [Route("Wandermate_backened/signUp")]
//     [ApiController]
//     public class SignUpController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;


//         public SignUpController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]

//         public async Task<IActionResult> GetAll()
//         {
//             var users = await _context.Users.ToListAsync();
//             if (users == null)
//             {
//                 return NotFound();
//             }

//             var userDTO = users.Select(user => new SignUpDTO
//             {
//                 Id = user.Id,
//                 Username = user.Username,
//                 Email = user.Email,
//                 Password = user.Password


              

//             });

//             return Ok(userDTO);

//         }

//          [HttpGet("{Id}")]
//         public async Task<IActionResult> GetById([FromRoute] int Id)
//         {
//             var user = await _context.Users.Where(u => u.Id == Id).Select(u => new SignUpDTO
//             {
               
//               Username = u.Username,
//               Password = u.Password,


//             }).FirstOrDefaultAsync();
//             if (user == null)
//             {
//                 return NoContent();
//             }
//             return Ok(user);
//         }



//         [HttpPost]
//         public async Task<IActionResult> SignUP([FromBody] CreateSignUpDTO createSignUpDTO )
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             var hashPassword = BCrypt.Net.BCrypt.HashPassword(createSignUpDTO.Password);
//             var user = new Users
//             {
//                     Username = createSignUpDTO.Username,
//                     Email = createSignUpDTO.Email,
//                     Password = hashPassword,
                 

//             };
//              try
//             {
//                 await _context.Users.AddAsync(user);
//                 await _context.SaveChangesAsync();
//                 return CreatedAtAction(nameof(GetById), new { id = user.Id }, createSignUpDTO);
//             }
//             catch (Exception ex)
//             {
                
//                 return StatusCode(500, ex);
//             }
//         }
//          [HttpPut("{id}")]
//         public async Task<IActionResult> EditUser( int id,[FromBody] UpdateDTO updateDTO){
//             var user =  await _context.Users.FindAsync(id);
//             if(user == null){
//                 return NoContent();
//             }
//             user.Username = updateDTO.Username;
//             user.Email = updateDTO.Email;
//             var hashPassword = BCrypt.Net.BCrypt.HashPassword(updateDTO.Password);
//             user.Password = hashPassword;

//             await _context.SaveChangesAsync();
//             return Ok(updateDTO);
//         }
//         [HttpDelete("{id}")]

//         public async Task<IActionResult>DeleteSignUp([FromRoute] int id)
//         {
//             var SignUpToDelete = await _context.Users.FindAsync(id);
//             if(SignUpToDelete == null){
//                 return NotFound();
//             }
//              try
//             {
//                 _context.Users.Remove(SignUpToDelete);
//                 await _context.SaveChangesAsync();
//             }
//             catch (Exception ex)
//             {
               
//                 return StatusCode(500, ex);
//             }

//             return NoContent();
//         }

//     }
// }