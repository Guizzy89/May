using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Внешний ключ на категорию
        public Guid CategoryId { get; set; }

        // Навигационное свойство на категорию
        public virtual Category Category { get; set; }

        // Навигационное свойство для элементов корзины
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        internal Product(Guid productId, string name, decimal price, int stockQuantity, Category category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название товара не может быть пустым.", nameof(name));

            if (price < 0m || stockQuantity < 0)
                throw new ArgumentException("Цена и количество товара не могут быть отрицательными.", nameof(price));

            if (category is null)
                throw new ArgumentNullException(nameof(category), "Категория товара не может быть пустой.");

            ProductId = productId;
            Name = name;
            Price = Math.Round(price, 2);
            StockQuantity = stockQuantity;
            Category = category;
        }

        // Конструктор для ORM (пустой)
        public Product() { }
    }
}
