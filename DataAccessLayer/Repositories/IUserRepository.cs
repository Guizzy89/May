using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);
        void Update(User user);
    }
}