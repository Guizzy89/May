using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
namespace WebApplication1.DataAccessLayer.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersForUser(Guid userId);
    }
}