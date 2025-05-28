using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.BusinessLogicLayer.Services
{
    public interface ICartService
    {
        Cart GetCurrentCart(ISession session);

        void AddToCart(ISession session, Guid productId, int quantity);

        void RemoveFromCart(ISession session, Guid itemId);
    }
}
