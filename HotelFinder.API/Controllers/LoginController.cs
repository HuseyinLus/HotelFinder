using HotelFinder.Business.Abstract;
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
        private readonly IConfiguration _configuration;



        public LoginController(ILoginService loginService,IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("SignIn")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var account = await _loginService.Login(userName, password);
            if (account != null)
            {
                var token = GenerateAccessToken(userName);
                // return access token for user's use
                return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
                
            }
            return NotFound("Failed to login");
        }
        private JwtSecurityToken GenerateAccessToken(string userName)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, userName),
        // Additional claims can be added here
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

    }
}
