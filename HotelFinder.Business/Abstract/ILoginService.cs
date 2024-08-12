using Domain;
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
       Task<Login> Login(string userName, string lastName);
    }
}
