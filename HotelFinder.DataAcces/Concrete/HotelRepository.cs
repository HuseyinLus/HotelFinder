﻿using Domain.Entities;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new dbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new dbContext())
            {
                var deleteHotel = await GetHotelById(id);
                hotelDbContext.Hotels.Remove(deleteHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new dbContext())
            {
                return await hotelDbContext.Hotels.FindAsync(id);

            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using (var hotelDbContext = new dbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<List<Hotel>> GetHotels()
        {
            using (var hotelDbContext = new dbContext())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new dbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task<Hotel> GetHotelByCity(string city)
        {
            using (var hotelDbContext = new dbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.City.ToLower() == city.ToLower());
            }
        }

        public async Task<Hotel> GetHotelByCountry(string country)
        {
            using (var hotelDbContext = new dbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Country.ToLower() == country.ToLower());
            }
        }
        public async Task<Hotel> UpdateHotelName(int id, string name)
        {
            using (var hotelDbContext = new dbContext())
            {
                var UpdateHotelName = hotelDbContext.Hotels.Find(id);
                if (UpdateHotelName != null)
                {
                    UpdateHotelName.Name = name;
                    hotelDbContext.Hotels.Update(UpdateHotelName);
                    await hotelDbContext.SaveChangesAsync();
                    return UpdateHotelName;
                }
                return null;
            }
        }
        public async Task<Hotel> UpdateHotelCity(int id, string city)
        {
            using (var hotelDbContext = new dbContext())
            {
                var UpdateHotel = hotelDbContext.Hotels.Find(id);
                if (UpdateHotel != null)
                {
                    UpdateHotel.City = city;
                    hotelDbContext.Update(UpdateHotelCity);
                    await hotelDbContext.SaveChangesAsync();
                    return UpdateHotel;
                }
                return null;
            }
        }
        public async Task<Hotel> UpdateHotelCountry(int id, string country)
        {
            using (var hotelDbContext = new dbContext())
            {
                var UpdateHotelCountry = hotelDbContext.Hotels.Find(id);
                if (UpdateHotelCountry != null)
                {
                    UpdateHotelCountry.Country = country;
                    await hotelDbContext.SaveChangesAsync();
                    hotelDbContext.Update(UpdateHotelCountry);
                    return UpdateHotelCountry;
                }
                return null;
            }
        }

        public async Task<Car> GetHotelsCars(int id)
        {
            using (var hotelDbContext = new dbContext())
            {
                var hotel = hotelDbContext.Hotels.Find(id);
                if (hotel != null)
                {
                    var car = hotel.CarID;
                    return await GetCarById(car);
                   
                }
                return null;
            }
        }
        public async Task<Car> GetCarById(int id)
        {
            using (var hotelDbContext = new dbContext())
            {
                var car = hotelDbContext.Cars.Find(id);
                return car;
            }
        }
        
    }
}