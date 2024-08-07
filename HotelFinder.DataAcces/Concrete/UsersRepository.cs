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
    public class UsersRepository : IUsersRepository
    {
        public async Task<User> AddNewUser(User name)
        {
            using (var userDbContext = new dbContext())
            {

                userDbContext.Users.Add(name);
                await userDbContext.SaveChangesAsync();
                return name;

            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (var userDbContext = new dbContext())
            {
                return await userDbContext.Users.ToListAsync();
            }
        }
    }
}
