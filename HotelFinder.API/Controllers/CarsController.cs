using Domain.Entities;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Route("GetCarById/{id}")]
        public async Task<IActionResult> GetCarByhId(int id)
        {
            var car = await _carService.GetCarsById(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateCarModel/{id}")]

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
                return Ok("the car that has ID number of {id} has been deleted sucsessfully");
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateLicencePlate/{id}")]

        public async Task<IActionResult> UpdateLicencePlate(int id, string plate)
        {
            var car = _carService.UpdateLicencePlate(id, plate);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateContactNumber/{id}")]
        public async Task<IActionResult> UpdateContactNumber(int id, string number)
        {
            var car = _carService.UpdateContactNumber(id,number);
            if (car !=null)
            {
                return Ok(car);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetCarsHotel/{id}")]
        public async Task<IActionResult> GetCarsHotel(int id)
        {
            var car = _carService.GetCarsHotel(id);
            if(car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }
    }
}
