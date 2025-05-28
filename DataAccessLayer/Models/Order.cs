namespace WebApplication1.DataAccessLayer.Models
{
    public class Order
    {
        private readonly Guid? _orderId;
        private readonly DateTime? _createdAt;
        private readonly decimal? _totalPrice;
        private readonly Guid? _userId;
        private readonly string? _adress;
        private readonly string? _description;

        public Guid? OrderId => _orderId;
        public DateTime? CreatedAt => _createdAt;
        public decimal? TotalPrice => _totalPrice;
        public Guid? UserId => _userId;
        public string? Adress => _adress;
        public string? Description => _description;

        public Order() { }

        public Order(
            decimal totalPrice,
            Guid userId,
            string adress,
            string description)
        {
                if (userId == Guid.Empty)
                    throw new ArgumentException("Идентификатор пользователя не может быть пустым.", nameof(userId));

                if (string.IsNullOrWhiteSpace(adress))
                    throw new ArgumentException("Адрес доставки не может быть пустым.", nameof(adress));

            _orderId = Guid.NewGuid();
            _createdAt = DateTime.Now;
            _totalPrice = totalPrice;
            _userId = userId;
            _adress = adress;
            _description = description ?? "";
        }
    }
}
