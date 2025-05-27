using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.DataAccessLayer.Repositories;

namespace MyStore.DataAccessLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(StoreDbContext context) : base(context) { }

        public User FindByEmail(string email)
        {
            return _dbSet.FirstOrDefault(u => u.Email == email);
        }
    }
}