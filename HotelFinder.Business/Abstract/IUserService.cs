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
        Task<List<Register>> GetUsers();

        Task<Register> AddNewUser(Register user);

        Task DeleteUser(int id);
    }
}
