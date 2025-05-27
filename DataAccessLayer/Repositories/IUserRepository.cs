using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Repositories;

namespace MyStore.DataAccessLayer.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);
    }
}