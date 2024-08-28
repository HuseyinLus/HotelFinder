using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        ///// <returns></returns>
        ///
        [HttpGet]
        [Route("GetAllHotels")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetHotels();

            return Ok(hotels);//200 + data
        }
        ///// <summary>
        ///// Get Hotel by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);//200 + data
            }
            return NotFound();//404
        }
        ///// <summary>
        ///// Create Hotel
        ///// </summary>
        ///// <param name="hotel"></param>
        ///// <returns></returns>
        [HttpPost("CreateHotel")]
        [Authorize]

        public async Task<IActionResult> Post([FromBody] Hotel hotel)
        {
            var createdHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel);//201 + data 
        }
        ///// <summary>
        ///// Update Hotel
        ///// </summary>
        ///// <param name="hotel"></param>
        ///// <returns></returns>
        [HttpPut("UpdateHotel")]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id) != null)
            {
                var response = await _hotelService.UpdateHotel(hotel);
                return Ok(response);//200 + data
            }
            return NotFound();
        }
        ///// <summary>
        ///// Delete Hotel 
        ///// </summary>
        ///// <param name="id"></param>

        [HttpDelete("{Id}/DeleteHotel")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();//200
            }
            return NotFound();
        }
        ///// <summary>
        ///// Find Hotel By Name
        ///// </summary>
        ///// <param name="id"></param>
        [HttpGet]
        [Route("GetHotelByName/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();

        }

        [HttpGet]
        [Route("GetHotelByCity/{city}")]
        public async Task<IActionResult> GetHotelByCity(string city)
        {
            var hotel = await _hotelService.GetHotelByCity(city);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetHotelByCountry/{country}")]
        public async Task<IActionResult> GetHotellByCountry(string country)
        {
            var hotel = await _hotelService.GetHotelByCountry(country);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateHotelName/{name}")]
        public async Task<IActionResult> UpdateHotelName(int id, string name)
        {
            if (await _hotelService.UpdateHotelName(id, name) != null)
            {
                var response = await _hotelService.UpdateHotelName(id, name);
                return Ok(response);//200 + data
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateHotelCity/{city}")]
        public async Task<IActionResult> UpdateHotelCity(int id, string city)
        {
            if (await _hotelService.UpdateHotelCity(id, city) != null)
            {
                var repsonse = await _hotelService.UpdateHotelCity(id, city);
                return Ok(repsonse);//200+data
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateHotelCountry/{country}")]
        public async Task<IActionResult> UpdateHotelCountry(int id, string country)
        {
            if (await _hotelService.UpdateHotelCountry(id, country) != null)
            {
                var response = await _hotelService.UpdateHotelCountry(id, country);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetHotelsCars/{id}")]
        public async Task<IActionResult> GetHotelscars(int id)
        {
            var hotel = _hotelService.GetHotelsCar(id);

            if(hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
    }
}
