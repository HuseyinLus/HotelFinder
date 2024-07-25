using HotelFinder.DataAcces.Abstract;
using HotelFinder.DataAcces.Migrations;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Concrete
{
    public class CarRepository : ICarRepository
    {
        public async Task<Car> AddNewCar(Car car)
        {
            using (var carDbCotext = new CarDbContext())
            {
                carDbCotext.Cars.Add(car);
                await carDbCotext.SaveChangesAsync();
                return car;
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var carDbContext = new CarDbContext())
            {
                var deleteCar = await GetCarsById(id);
                carDbContext.Cars.Remove(deleteCar);
                await carDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            using (var carDbContext = new CarDbContext())
            {
                return await carDbContext.Cars.ToListAsync();
            }
        }

        public async Task<Car> GetCarsById(int id)
        {
            using (var carDbContext = new CarDbContext())
            {
                return await carDbContext.Cars.FindAsync(id);
            }
        }

        public async Task<Car> UpdateCarModel(int id, string model)
        {
            using (var carDbContext = new CarDbContext())
            {
                var UpdateCarModel = carDbContext.Cars.Find(id);
                if (UpdateCarModel != null)
                {
                    UpdateCarModel.CarModel = model;
                    carDbContext.Cars.Update(UpdateCarModel);
                    await carDbContext.SaveChangesAsync();
                    return UpdateCarModel;
                }
                return null;
            }
        }

        //public Task<Car> UpdateCarsHotel(int id, string hotel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
