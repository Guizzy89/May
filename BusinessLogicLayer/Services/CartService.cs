using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;

namespace WebApplication1.BusinessLogicLayer.Services
{
    public class CartService : ICartService
    {
        private readonly IServiceProvider _serviceProvider;

        public CartService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Cart GetCurrentCart(ISession session)
        {
            var cartId = session.GetInt32("CartId") ?? 0;
            if (cartId > 0)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetRequiredService<IRepository<Cart>>();
                    return repo.GetById(cartId);
                }
            }
            else
            {
                return new Cart(); 
            }
        }

        public void AddToCart(ISession session, Guid productId, int qty)
        {
            var currentCart = GetCurrentCart(session);
            var cartItem = currentCart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += qty;
            }
            else
            {
                currentCart.Items.Add(new CartItem(Guid.NewGuid(), productId, qty, currentCart.UserId));
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IRepository<Cart>>();
                repo.Update(currentCart);
            }
        }

        public void RemoveFromCart(ISession session, Guid itemId)
        {
            var currentCart = GetCurrentCart(session);
            var itemToRemove = currentCart.Items.FirstOrDefault(i => i.CartItemId == itemId);
            if (itemToRemove != null)
            {
                currentCart.Items.Remove(itemToRemove);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetRequiredService<IRepository<Cart>>();
                    repo.Update(currentCart);
                }
            }
        }
    }
}
