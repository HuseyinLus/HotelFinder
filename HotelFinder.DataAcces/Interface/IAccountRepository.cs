using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Abstract
{
    public interface IAccountRepository
    {
        public Task<User> Login(string name, string lastname);
    }
}
