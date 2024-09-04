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
    public class UserRepository : IUsersRepository
    {
        public async Task<Register> AddNewUser(Register user)
        {
            using (var userDbContext = new dbContext())
            {
                userDbContext.Registers.Add(user);
                await userDbContext.SaveChangesAsync();
                return user;
            }
        }
        public async Task<List<Register>> GetUsers()
        {
            using (var userDbContext = new dbContext())
            {
                return await userDbContext.Registers.ToListAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var userDbContext = new dbContext())
            {
                var remove = await userDbContext.Registers.FindAsync(id);
                userDbContext.Registers.Remove(remove);
                await userDbContext.SaveChangesAsync();
                
            }
        }
    }
}
