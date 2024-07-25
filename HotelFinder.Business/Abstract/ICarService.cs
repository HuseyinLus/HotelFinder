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

        Task DeleteCar(int id);

    }
}
