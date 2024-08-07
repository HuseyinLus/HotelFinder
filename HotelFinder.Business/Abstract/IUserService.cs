﻿using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    internal interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> AddNewUser(User user);
    }
}
