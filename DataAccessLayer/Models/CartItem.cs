using System;

namespace WebApplication1.DataAccessLayer.Models
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }

        // Навигационные свойства
        public virtual Product Product { get; set; } // Связь с продуктом
        public virtual Cart Cart { get; set; }      // Связь с корзиной

        // Конструктор с проверкой количества
        public CartItem(Guid cartItemId, Guid productId, int quantity, Guid cartId)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Количество товара должно быть больше нуля.");

            CartItemId = cartItemId;
            ProductId = productId;
            Quantity = quantity;
            CartId = cartId;
        }
    }
}