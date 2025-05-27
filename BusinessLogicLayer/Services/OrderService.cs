using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
namespace WebApplication1.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataAccessLayer.Repositories.IOrderRepository _orderRepository;

        public OrderService(DataAccessLayer.Repositories.IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order PlaceOrder(Order order)
        {
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return order;
        }

        public IEnumerable<Order> GetOrdersForUser(Guid userId)
        {
            return _orderRepository.GetAll().Where(o => o.UserId == userId);
        }
    }
}
