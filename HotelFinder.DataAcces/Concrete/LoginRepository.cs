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
    public class LoginRepository : ILoginRepository
    {
        public async Task<User> Login(string userName, string lastName)
        {
            using (var loginDbContext = new dbContext())
            {
                var response =  loginDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.UserLastName == lastName);
                if(response?.UserName != userName)
                {
                    return null;
                }
                else
                { 
                return response;
                }
                
            }

        }
    }
}
