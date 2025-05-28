using WebApplication1.DataAccessLayer.Models;
using System.Collections.Generic;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        void Delete(CartItem item);
        Cart GetCartForUser(Guid userId);
    }
}