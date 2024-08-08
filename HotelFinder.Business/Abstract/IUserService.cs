using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> AddNewUser(User user);

        Task DeleteUser(int id);
    }
}
