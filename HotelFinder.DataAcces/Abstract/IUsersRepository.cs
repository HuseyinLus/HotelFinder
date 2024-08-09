﻿using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Abstract
{
    public interface IUsersRepository
    {
        Task<List<User>> GetUsers();

        Task<User> AddNewUser(User user);
    }
}
