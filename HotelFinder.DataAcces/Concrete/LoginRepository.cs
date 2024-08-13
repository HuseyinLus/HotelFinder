using Domain;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<Register> Login(string userName, string password)
        {
            using (var loginDbContext = new dbContext())
            {
                var response = loginDbContext.Registers.FirstOrDefault(x => x.Username == userName && x.Password == password);
                if (response?.Username != userName)
                {
                    return null;
                }
                else
                {
                    return response;
                }

            }


        }
        public async Task<Register> GetUserInfo(string userName)
        {
            using (var loginDbContext = new dbContext())
            {
                var response = loginDbContext.Registers.FirstOrDefault(x => x.Name == userName);
                if(response?.Name != userName)
                {
                    return null;
                }
                return response;
            }
        }
        
    }
}
