using Domain;
using Domain.Entities;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface ILoginService
    {
        Task<Register> Login(string userName,string password);

        Task<Register> GetUserInfo(string userName);


    }
}
