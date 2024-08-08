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
    public class UserService : IUserService
    {
        private IUsersRepository _userRepository;

        public UserService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddNewUser(User user)
        {
            return await _userRepository.AddNewUser(user);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task DeleteUser(int id)
        {
           await _userRepository.DeleteUser(id);
        }
    }
}
