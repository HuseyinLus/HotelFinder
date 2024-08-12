using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Abstract
{
    public interface IUsersRepository
    {
        public Task<List<Register>> GetUsers();

        public Task<Register> AddNewUser(Register user);

        Task DeleteUser(int id);
    }
}
