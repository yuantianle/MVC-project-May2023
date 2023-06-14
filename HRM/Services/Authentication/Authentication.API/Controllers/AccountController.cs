using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Controllers
{        
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
                return CreatedAtRoute("GetUser", new {controller = "account", id = user.Id }, value: "Registration Complete!");
            }

            return BadRequest(result.Errors.Select(e=>e.Description).ToList());
        }

        //GetUserById
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound("Can't find the user with the input ID.");
            }
            return Ok(user);
        }

        //Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new {error = "Please check email/password format"});
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if(user == null)
            {
                return BadRequest("Username does not exist");
            }
            var isAuthenticated = await _userManager.CheckPasswordAsync(user, model.Password);
            if(isAuthenticated)
            {
                //return Ok("User name password valid");
                return Ok(new { token = CreateJWT(user)});
            }

            // we need to create JWT token and return it to the client (SPA, iOS, Android)


            return Unauthorized("User name password is invalid");

        }


        private string CreateJWT(User user) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.UTF8.GetBytes(_configuration["SecretKey"] ?? string.Empty);
           // var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "HRM",
                Audience = "HRM Users",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //key value pair
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim("language", "english"),
                    new Claim("location", "USA/DC"),
                    new Claim("role", "Admin"),
                })

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //GetUserById
    }
}
