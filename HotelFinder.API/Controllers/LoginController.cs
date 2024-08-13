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
        [Route("SignIn")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var account = await _loginService.Login(userName, password);
            if (account != null)
            {
                var login = await _loginService.GetUserInfo(userName);
                return Ok(new
                {
                    Message = $"Welcome {userName}",
                    UserInfo = login
                });
                
            }
            return NotFound("Failed to login");
        }
    }
}
