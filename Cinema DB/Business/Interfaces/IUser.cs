using Cinema_DB.Domain.Entities;
using Cinema_DB.Helper.ViewModels;

namespace Cinema_DB.Business.Interfaces
{
    public interface IUser
    {
        ICollection<User> GetUsers();
        User GetUser(string name);
        bool UserExists(string name);
        bool CreateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
