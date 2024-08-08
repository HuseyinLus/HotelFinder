using HotelFinder.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("GetIn")]
        public async Task<IActionResult> Login(string name, string lastname)
        {
            var account = await _accountService.Login(name, lastname);
            if (account != null)
            {
                return Ok("Welcome");
            }
            return NotFound();
        }
    }
}
