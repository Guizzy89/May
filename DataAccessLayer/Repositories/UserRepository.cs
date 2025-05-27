using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer;
using WebApplication1.DataAccessLayer.Repositories;
using System.Linq;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Repositories
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