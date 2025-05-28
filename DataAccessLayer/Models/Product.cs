using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // ������� ���� �� ���������
        public Guid CategoryId { get; set; }

        // ������������� �������� �� ���������
        public virtual Category Category { get; set; }

        // ������������� �������� ��� ��������� �������
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

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
