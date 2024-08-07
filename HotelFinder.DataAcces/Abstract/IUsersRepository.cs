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
        public Task<List<User>> GetaAllUser();

        public Task<User> AddNewUer(User user);
    }
}
