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
    public class HotelRepository : IHotelRepository1
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deleteHotel = await GetHotelById(id);
                hotelDbContext.Hotels.Remove(deleteHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FindAsync(id);

            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
                //return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            }
        }

        public async Task<List<Hotel>> GetHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task<Hotel> GetHotelByCity(string city)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.City.ToLower() == city.ToLower());
            }
        }

        public async Task<Hotel> GetHotelByCountry(string country)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Country.ToLower() == country.ToLower());
            }
        }
        public async Task<Hotel> UpdateHotelName(int id, string name)
        {
            using (var hotelDbContext = new HotelDbContext())
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
        public async async UpdateHotelCity(int id,string city)
        {
            using (var hotelDbContext = new HotelDbContext())
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
        public async async UpdateHotelCity(int id,string country)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var UpdateHotelCountry = hotelDbContext.Hotels.Find(id);
                if (UpdateHotelCountry != null)
                {
                    UpdateHotelCountry.Country = country;
                    await hotelDbContext.SaveChangesAsync();
                    return UpdateHotelCountry;
                }
                return null;
            }
        }
    }
}