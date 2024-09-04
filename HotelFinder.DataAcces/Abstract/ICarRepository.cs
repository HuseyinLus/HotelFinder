using Domain.Entities;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Abstract
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetAllCars();

        public Task<Car> GetCarsById(int id);

        public Task<Car> AddNewCar(Car car);

        public Task<Car> UpdateCarModel(int id, string model);

        public Task<Car> UpdateLicencePlate(int id, string plate);

        public Task<Car> UpdateContactNumber(int id, string number);

        public Task<Hotel> GetCarsHotel(int id);

        public Task<Hotel> GetHotelById(int id);
        Task DeleteCar(int id);


    }
}
