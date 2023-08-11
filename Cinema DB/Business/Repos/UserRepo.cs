using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Data;
using Cinema_DB.Data.Models;
using Cinema_DB.Helper.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Business.Repos
{
    public class UserRepo : IUser
    {
        private readonly DataContext _context;

        public UserRepo(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string name) => _context.Users.Where(U => U.Name == name).FirstOrDefault();

        public ICollection<User> GetUsers() => _context.Users.ToList();

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string name) => _context.Users.Where(U => U.Name == name).Any();
    }
}
