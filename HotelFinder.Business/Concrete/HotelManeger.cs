using HotelFinder.Business.Abstract;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.DataAcces.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{

    public class HotelManeger : IHotelService
    {
        private IHotelRepository1 _hotelRepository1;

        public HotelManeger(IHotelRepository1 hotelRepository)
        {

            _hotelRepository1 = hotelRepository;
        }


        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository1.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository1.DeleteHotel(id);
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository1.GetHotelById(id);
            }
            throw new Exception("id can not be less then 1!");
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository1.GetHotelByName(name);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _hotelRepository1.GetHotels();
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository1.UpdateHotel(hotel);
        }

        public async Task<Hotel> GetHotelByCity(string city)
        {
            return await _hotelRepository1.GetHotelByCity(city);
        }

        public async Task<Hotel> GetHotelByCountry(string country)
        {
            return await _hotelRepository1.GetHotelByCountry(country);
        }

        public async Task<Hotel> UpdateHotelName(int id, string name)
        {
            return await _hotelRepository1.UpdateHotelName(id, name);
        }

        public async Task<Hotel> UpdateHotelCity(int id, string name)
        {
            return await _hotelRepository1.UpdateHotelCity(id, name);
        }

        public async Task<Hotel> UpdateHotelCountry (int id,string country)
        {
            return await _hotelRepository1.UpdateHotelCountry(id,country);
        }
    }
}
