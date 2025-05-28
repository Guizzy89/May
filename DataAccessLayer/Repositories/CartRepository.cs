using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.DataAccessLayer.Models;
namespace WebApplication1.DataAccessLayer.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(StoreDbContext context) : base(context) { }

        public void Delete(CartItem item)
        {
            throw new NotImplementedException();
        }

        public Cart GetCartForUser(Guid userId)
        {
            return _dbSet.Include(cart => cart.Items).FirstOrDefault(c => c.UserId == userId);
        }
    }
}
