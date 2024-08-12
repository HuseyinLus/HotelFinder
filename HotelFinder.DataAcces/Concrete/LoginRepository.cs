using Domain;
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
        public async Task<Login> Login(string userName, string password)
        {
            using (var loginDbContext = new dbContext())
            {
                var response = loginDbContext.Logins.FirstOrDefault(x => x.UserName == userName && x.Password == password);
                if (response?.UserName != userName)
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
