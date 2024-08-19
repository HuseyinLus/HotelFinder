using Domain.Entities;
using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        private IConfiguration _configuration;

        public LoginController(ILoginService loginService,IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> Login([FromForm]string userName,[FromForm] string password)
        {
            var user = await Authentication(userName,password);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        public string Generate(Register user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.GivenName,user.Name),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(ClaimTypes.Email,user.Email),
                
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audiece"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public async Task<Register> Authentication(string userName,string password)
        {
            var account = await _loginService.Login(userName,password);
            if (account != null)
            {
                return account;
            }
            return null;
        }

        //[HttpGet]
        //[Route("SignIn")]
        //public async Task<IActionResult> Login(string userName, string password)
        //{
        //    var account = await _loginService.Login(userName, password);
        //    if (account != null)
        //    {
        //        var login = await _loginService.GetUserInfo(userName);
        //        return Ok(new
        //        {
        //            Message = $"Welcome {userName}",
        //            UserInfo = login
        //        });

        //    }
        //    return NotFound("Failed to login");
        //}
    }
}
