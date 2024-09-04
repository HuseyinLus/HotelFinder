using Domain.Entities;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();

        Task<Car> GetCarsById(int id);

        Task<Car> AddNewCar(Car car);

        Task<Car> UpdateCarModel(int id, string model);

        Task<Car> UpdateLicencePlate(int id, string plate);

        Task<Car> UpdateContactNumber(int id, string number);

        Task<Hotel> GetCarsHotel(int id);

        Task<Hotel> GetHotelById(int id);

        Task DeleteCar(int id);

    }
}
