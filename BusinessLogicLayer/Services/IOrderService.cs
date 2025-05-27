using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
namespace WebApplication1.BusinessLogicLayer.Services
{
    public interface IOrderService
    {
        Order PlaceOrder(Order order);
        IEnumerable<Order> GetOrdersForUser(Guid userId);
    }
}
