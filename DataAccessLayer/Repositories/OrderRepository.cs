using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccessLayer.Repositories;
using WebApplication1.DataAccessLayer;
using System.Linq;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StoreDbContext context) : base(context) { }

        public IEnumerable<Order> GetOrdersForUser(Guid userId)
        {
            return _dbSet.Where(o => o.UserId == userId);
        }
    }
}