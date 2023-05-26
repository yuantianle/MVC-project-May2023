﻿using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{        
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            //save the user info to user table
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Errors.Any())
            {
                return CreatedAtRoute("GetUser", new {controller = "account", id = user.Id });
            }

            return BadRequest(result.Errors.Select(e=>e.Description).ToList());
        }
        //Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new {error = "Please check email/password format"});
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return BadRequest("Username does not exist");
            }
            var isAuthenticated = await _userManager.CheckPasswordAsync(user, model.Password);
            if(isAuthenticated)
            {
                return Ok("User name password valid");
            }
            return Unauthorized("User name password is invalid");

        }

        //GetUserById
    }
}
