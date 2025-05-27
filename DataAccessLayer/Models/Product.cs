using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Models
{
    public class Product
    {        
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Category Category { get; private set; }

        internal Product(Guid productId, string name, decimal price, int stockQuantity, Category category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("�������� ������ �� ����� ���� ������.", nameof(name));

            if (price < 0m || stockQuantity < 0)
                throw new ArgumentException("���� � ���������� ������ �� ����� ���� ��������������.", nameof(price));

            if (category is null)
                throw new ArgumentNullException(nameof(category), "��������� ������ �� ����� ���� ������.");

            ProductId = productId;
            Name = name;
            Price = Math.Round(price, 2);
            StockQuantity = stockQuantity;
            Category = category;
        }

        // ����������� ��� ORM (������)
        public Product() { }
    }
}
