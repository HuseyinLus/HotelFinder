using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Register user)
        {
            var createdUser = await _userService.AddNewUser(user);
            return CreatedAtAction("Get", new { id = createdUser.Id }, createdUser);//201 + data 
        }

        [HttpDelete]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
            
        }
    }
}
