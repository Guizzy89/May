using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;
namespace WebApplication1.BusinessLogicLayer.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCart GetCartForUser(Guid userId)
        {
            return _shoppingCartRepository.GetCartForUser(userId);
        }

        public void AddItemToCart(CartItem item)
        {
            var cart = GetCartForUser(item.UserId);
            if (cart == null)
            {
                cart = new ShoppingCart { UserId = item.UserId };
                _shoppingCartRepository.Add(cart);
            }
            cart.Items.Add(item);
            _shoppingCartRepository.SaveChanges();
        }

        public void RemoveItemFromCart(Guid cartItemId)
        {
            var cartItem = _shoppingCartRepository.GetById(cartItemId);
            if (cartItem != null)
            {
                _shoppingCartRepository.Delete(cartItem);
                _shoppingCartRepository.SaveChanges();
            }
        }

        public void ClearCart(Guid shoppingCartId)
        {
            var cart = _shoppingCartRepository.GetById(shoppingCartId);
            if (cart != null)
            {
                foreach (var item in cart.Items)
                    _shoppingCartRepository.Delete(item);
                _shoppingCartRepository.SaveChanges();
            }
        }
    }
}
