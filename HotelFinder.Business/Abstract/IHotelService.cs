﻿using Domain.Entities;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotelById(int id);

        Task<Hotel> GetHotelByName(string name);

        Task<Hotel> CreateHotel(Hotel hotel);

        Task<Hotel> UpdateHotel(Hotel hotel);

        Task DeleteHotel(int id);

        Task<Hotel> GetHotelByCity(string city);

        Task<Hotel> GetHotelByCountry(string country);

        Task<Hotel> UpdateHotelName(int id, string name);

        Task<Hotel> UpdateHotelCity(int id, string city);

        Task<Hotel> UpdateHotelCountry(int id, string country);

        Task<Car> GetHotelsCar(int id);

        Task<Car> GetCarById(int id);
    }
}
