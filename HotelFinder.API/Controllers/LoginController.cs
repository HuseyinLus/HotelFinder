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
        public async Task<IActionResult> Login(string userName, string lastName)
        {
            var account = await _loginService.Login(userName, lastName);
            if (account != null)
            {
                return Ok("successfully logged in");
            }
            return NotFound("Failed to login");
        }
    }
}
