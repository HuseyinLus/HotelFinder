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

    public class HotelsService : IHotelService
    {
        private IHotelRepository _hotelRepository;

        public HotelsService(IHotelRepository hotelRepository)
        {

            _hotelRepository = hotelRepository;
        }


        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id can not be less then 1!");
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _hotelRepository.GetHotels();
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }

        public async Task<Hotel> GetHotelByCity(string city)
        {
            return await _hotelRepository.GetHotelByCity(city);
        }

        public async Task<Hotel> GetHotelByCountry(string country)
        {
            return await _hotelRepository.GetHotelByCountry(country);
        }

        public async Task<Hotel> UpdateHotelName(int id, string name)
        {
            return await _hotelRepository.UpdateHotelName(id, name);
        }

        public async Task<Hotel> UpdateHotelCity(int id, string name)
        {
            return await _hotelRepository.UpdateHotelCity(id, name);
        }

        public async Task<Hotel> UpdateHotelCountry (int id,string country)
        {
            return await _hotelRepository.UpdateHotelCountry(id,country);
        }
    }
}
