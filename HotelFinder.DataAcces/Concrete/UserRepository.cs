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
    internal class UserRepository : IUsersRepository
    {
        public async Task<User> AddNewUer(User user)
        {
            using (var userDbContext = new dbContext())
            {
                userDbContext.Users.Add(user);
                await userDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task<List<User>> GetaAllUser()
        {
            using (var userDbContext = new dbContext())
            {
                return await userDbContext.Users.ToListAsync();
            }
        }
    }
}
