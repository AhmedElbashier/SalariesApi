using System;
using System.Collections.Generic;
using System.Linq;
using SalariesApi.Domain.Helpers;
using SalariesApi.Domain.Models.Settings;

namespace SalariesApi.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Find(int id);
        User CreateUser(UserDto UserDto);
        UserDto ToUserDto(User User);
        User GetUser(int id);
        List<User> GetUserByName(string Name);


    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Find(int id)
        {
            return _context.Users.Find(id);
        }

        public User CreateUser(UserDto UserDto)
        {   
            var User = ToUser(UserDto);
            _context.Users.Add(User);
            this._context.SaveChanges();
            return User;
        }

        private User ToUser(UserDto UserDto)
        {
            return new User
            {   

                Name= UserDto.Name,
                Username = UserDto.Username,
                Password= UserDto.Password,
                Role = UserDto.Role,
                RoleId = UserDto.RoleId
                
            };
        }

        public UserDto ToUserDto(User User)
        {
            return new UserDto
            {
                Id= User.Id,
                Name= User.Name,
                Username = User.Username,
                Password= User.Password,
                Role = User.Role,
                RoleId = User.RoleId

            };
        }
         public List<User> GetUserByName(string Name)
        {
        
            return _context.Users.Where(x =>
                x.Username==(Name)).ToList();

        }
          public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }
         public List<User> GetALL()
        {
            return _context.Users.ToList();
        }
    }
}