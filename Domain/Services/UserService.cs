using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;
using SalariesApi.Domain.Repositories;

namespace SalariesApi.Domain.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        List<UserDto> GetALl();
        User CreateUser(UserDto UserDto);
        List<User> GetUserByName(string Name);

    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;    
        }
        
       
        public User GetUser(int id)
        {
            return _UserRepository.GetUser(id);
        }

        public List<User> GetUserByName(string Name)
        {
            return _UserRepository.GetUserByName(Name);
        }

        public User CreateUser(UserDto UserDto)
        {
            return _UserRepository.CreateUser(UserDto);
        }
        public List<UserDto> GetALl()
        {
            return _UserRepository.GetAll().Select(_UserRepository.ToUserDto).ToList();
        }

    }
}