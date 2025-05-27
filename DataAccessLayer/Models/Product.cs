public class Product
{
	private readonly Guid _productId;
	private readonly string _name;
	private readonly decimal _price;
	private readonly int _stockQuantity;
	private readonly Category _category;

	public Guid ProductId => _productId;
	public string Name => _name;
	public decimal Price => _price;
	public int StockQuantity => _stockQuantity;
	public Category Category => _category;

	public Product(Guid productId, string name, decimal price, int stockQuantity, Category category)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("�������� ������ �� ����� ���� ������.", nameof(name));

		if (price < 0m || stockQuantity < 0)
			throw new ArgumentException("���� � ���������� ������ �� ����� ���� ��������������.", nameof(price));

		if (category is null)
			throw new ArgumentNullException(nameof(category), "��������� ������ �� ����� ���� ������.");

		_productId = productId;
		_name = name;
		_price = Math.Round(price, 2);
		_stockQuantity = stockQuantity;
		_category = category;
	}
}