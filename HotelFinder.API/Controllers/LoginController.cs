using HotelFinder.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string usernme, string lastname)
        {
            var account = await _loginService.Login(usernme, lastname);
            if (account != null)
            {
                return Ok("Welcome");
            }
            return NotFound("Failed to login");
        }
    }
}
