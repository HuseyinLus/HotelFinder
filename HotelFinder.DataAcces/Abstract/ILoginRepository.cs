using Domain;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces.Abstract
{
    public interface ILoginRepository
    {
        public Task<Register> Login(string userName, string password);

        public Task<Register> GetUserInfo(string userName);
    }
}
