using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
namespace WebApplication1.BusinessLogicLayer.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCartForUser(Guid userId);
        void AddItemToCart(CartItem item);
        void RemoveItemFromCart(Guid cartItemId);
        void ClearCart(Guid shoppingCartId);
    }
}
