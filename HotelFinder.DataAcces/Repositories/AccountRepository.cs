using HotelFinder.DataAcces.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<User> Login(string name, string lastname)
        {
            using (var accDbContext = new dbContext())
            {
                return await accDbContext.Users.FirstOrDefaultAsync(x => x.UserName == name && x.UserLastName == lastname);
            }
        }
    }
}
