﻿using HotelFinder.DataAcces.Abstract;
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
            using (var carDbCotext = new HotelDbContext())
            {
                carDbCotext.Cars.Add(car);
                var id = carDbCotext.Hotels.FindAsync(car.Id);

                await carDbCotext.SaveChangesAsync();
                return car;
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var HotelDbContext = new HotelDbContext())
            {
                var deleteCar = await GetCarsById(id);
                HotelDbContext.Cars.Remove(deleteCar);
                await HotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            using (var HotelDbContext = new HotelDbContext())
            {
                return await HotelDbContext.Cars.ToListAsync();
            }
        }

        public async Task<Car> GetCarsById(int id)
        {
            using (var carDbContext = new HotelDbContext())
            {
                return await carDbContext.Cars.FindAsync(id);
            }
        }

        public async Task<Car> UpdateCarModel(int id, string model)
        {
            using (var HotelDbContext = new HotelDbContext())
            {
                var UpdateCarModel = HotelDbContext.Cars.Find(id);
                if (UpdateCarModel != null)
                {
                    UpdateCarModel.CarModel = model;
                    HotelDbContext.Cars.Update(UpdateCarModel);
                    await HotelDbContext.SaveChangesAsync();
                    return UpdateCarModel;
                }
                return null;
            }
        }
        public async Task<Car> UpdateLicencePlate(int id, string plate)
        {
            using (var HotelDbContext = new HotelDbContext())
            {
                var UpdateLicencePlate = HotelDbContext.Cars.Find(id);
                if (UpdateLicencePlate != null)
                {
                    UpdateLicencePlate.LicencePlate = plate;
                    HotelDbContext.Cars.Update(UpdateLicencePlate);
                    await HotelDbContext.SaveChangesAsync();
                    return UpdateLicencePlate;
                }
                return null;
            }
        }
        public async Task<Car> UpdateContactNumber(int id, string number)
        {
            using (var carDbCotext = new HotelDbContext())
            {
                var UpdateContactNumber = carDbCotext.Cars.Find(id);
                if (UpdateContactNumber != null)
                {
                    UpdateContactNumber.ContactNumber = number;
                    carDbCotext.Cars.Update(UpdateContactNumber);
                    await carDbCotext.SaveChangesAsync();
                    return UpdateContactNumber;
                }
                return null;
            }
        }
    }
}
