using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using HotelFinder.DataAcces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace HotelFinder.Business.Concrete
{
    public class CarsService : ICarService
    {

        private ICarRepository _carRepository;

        public CarsService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<Car>> GetAllCars()
        {
            return await _carRepository.GetAllCars();
        }

        public async Task<Car> AddNewCar(Car car)
        {
            return await _carRepository.AddNewCar(car);
        }

        public async Task<Car> GetCarsById(int id)
        {
            if (id > 0)
            {
                return await _carRepository.GetCarsById(id);
            }
            throw new Exception("id can not be less then 1!");
        }

        public async Task DeleteCar(int id)
        {
            await _carRepository.DeleteCar(id);
        }

        public async Task<Car> UpdateCarModel(int id, string model)
        {
            return await _carRepository.UpdateCarModel(id, model);
        }

        public async Task<Car> UpdateLicencePlate(int id, string plate)
        {
            return await _carRepository.UpdateLicencePlate(id, plate);
        }

        public async Task<Car> UpdateContactNumber(int id, string number)
        {
            return await _carRepository.UpdateContactNumber(id, number);
        }

        public async Task<Hotel> GetCarsHotel(int id)
        {
            return await _carRepository.GetCarsHotel(id);
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _carRepository.GetHotelById(id);
        }
    }
}

