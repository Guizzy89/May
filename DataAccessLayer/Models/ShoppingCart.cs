using System.Collections.Generic;

namespace WebApplication1.DataAccessLayer.Models
{
    public class ShoppingCart
    {
        public Guid ShoppingCartId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItem> Items { get; set; } = [];
    }
}