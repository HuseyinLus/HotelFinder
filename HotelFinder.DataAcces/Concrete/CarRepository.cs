using Domain.Entities;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.DataAcces.Migrations;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Concrete
{
    public class CarRepository : ICarRepository
    {
        public async Task<Car> AddNewCar(Car car)
        {
            using (var carDbCotext = new dbContext())
            {
                carDbCotext.Cars.Add(car);
                var id = carDbCotext.Hotels.FindAsync(car.Id);

                await carDbCotext.SaveChangesAsync();
                return car;
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var HotelDbContext = new dbContext())
            {
                var deleteCar = await GetCarsById(id);
                HotelDbContext.Cars.Remove(deleteCar);
                await HotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            using (var HotelDbContext = new dbContext())
            {
                return await HotelDbContext.Cars.ToListAsync();
            }
        }

        public async Task<Car> GetCarsById(int id)
        {
            using (var carDbContext = new dbContext())
            {
                return await carDbContext.Cars.FindAsync(id);
            }
        }

        public async Task<Car> UpdateCarModel(int id, string model)
        {
            using (var HotelDbContext = new dbContext())
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
            using (var HotelDbContext = new dbContext())
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
            using (var carDbCotext = new dbContext())
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
        public async Task<Hotel>GetHotelById(int id)
        {
            using (var hoteldbContext = new dbContext())
            {
                var hotel = hoteldbContext.Hotels.Find(id);
                return hotel;
            }
        }
        public async Task<Hotel> GetCarsHotel(int id)
        {
            using (var carDbContext = new dbContext())
            {
                var car = carDbContext.Cars.Find(id);
                if (car != null)
                {
                    var hotelId = car.HotelId;
                    var hotel =  await GetHotelById(hotelId);
                    return hotel;
                }
                throw new NotImplementedException("Car Repositotry car is null");
            }
        }


        //public async task<list<hotel, car>> getcarsandhotel(int id)
        //{
        //    using (var cardbcontext = new hoteldbcontext())
        //    {
        //        var car = cardbcontext.cars.find(id);
        //        if (car != null)
        //        {
        //            var hotelid = car.hotelid;
        //            var hotel = await gethotelbyid(hotelid);
        //            return (car, hotel);
        //        }
        //        throw new notimplementedexception("car repositotry car is null");
        //    }
        //}
    }
}
