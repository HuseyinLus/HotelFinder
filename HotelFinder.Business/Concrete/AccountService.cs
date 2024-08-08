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
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<User> Login(string name, string lastname)
        {
            return await _accountRepository.Login(name, lastname);
        }
    }
}
