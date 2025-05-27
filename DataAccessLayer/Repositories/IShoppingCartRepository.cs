using WebApplication1.DataAccessLayer.Models;
using System.Collections.Generic;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Delete(CartItem item);
        ShoppingCart GetCartForUser(Guid userId);
    }
}