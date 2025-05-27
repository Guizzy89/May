using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
        User Register(User user);
        User Authenticate(string email, string password);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}