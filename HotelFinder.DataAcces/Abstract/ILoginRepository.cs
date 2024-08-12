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
        public Task<Login> Login(string userName, string password);
    }
}
