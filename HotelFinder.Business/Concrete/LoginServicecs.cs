using HotelFinder.Business.Abstract;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class LoginServicecs : ILoginService
    {
        private ILoginRepository _loginRepository;

        public LoginServicecs(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<User> Login(string name, string lastname)
        {
            var res =  await _loginRepository.Login(name, lastname);
            return res;
        }
    }
}
