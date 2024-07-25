using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> Get()
        {
            var cars = await _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpPost]
        [Route("CreateCar")]

        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            var createdCar = await _carService.AddNewCar(car);
            return CreatedAtAction("Get", new { id = createdCar.Id }, createdCar);
        }

        [HttpGet]
        [Route("GetCarWithId/{id}")]
        public async Task<IActionResult> GetCarWithId(int id)
        {
            var car = await _carService.GetCarsById(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateCarModel")]

        public async Task<IActionResult> UpdateCarModel(int id, string model)
        {
            var car = await _carService.UpdateCarModel(id, model);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteCar/{id}")]

        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_carService.DeleteCar(id) != null)
            {
                await _carService.DeleteCar(id);
                return Ok();
            }
            return NotFound();
        }

    }
}
