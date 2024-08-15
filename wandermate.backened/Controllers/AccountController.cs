using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.DTOs.AccountsDTO;
using wandermate.backened.Extensions;
using wandermate.backened.Interface;
using wandermate.backened.Models;
using wandermate.backened.Service;

namespace wandermate.backened.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public readonly UserManager<AppUser> _userManager;
        public readonly ITokenService _tokenService;
        public readonly SignInManager<AppUser> _signinManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {

            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;

        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email
                };
                var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDTO
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.UserName);

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            return Ok(
                new NewUserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    UserId = user.Id,
                }
            );
        }



        [HttpPut("userUpdate")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("user  not found");
            }

            user.Email = userUpdateDTO.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to update user details.");
            }



            return Ok("User details Updated");


        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();


            var userDTO = users.Select(user => new NewUserDTO
            {
                //  select is Same to map in js
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),


            }).ToList();


            return Ok(userDTO);
        }


        [HttpDelete("{UserName}")]
public async Task<IActionResult> DeleteUser([FromRoute] string UserName)
{
    // Find the user by their username
    var userToDelete = await _userManager.FindByNameAsync(UserName);

    if (userToDelete == null)
    {
        return NotFound("usernotfound");
    }

    try
    {
        // Attempt to delete the user
        var result = await _userManager.DeleteAsync(userToDelete);
        if (!result.Succeeded)
        {
            // If deletion fails, return a 500 status with error details
            return StatusCode(500, result.Errors);
        }
    }
    catch (Exception ex)
    {
        // Catch any exception and return a 500 status with the exception details
        return StatusCode(500, ex);
    }

    // Return a 204 No Content status on success
    return NoContent();
}


    }
}