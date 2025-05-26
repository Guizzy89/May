public class CartItem
{
	private readonly Guid _cartItemId;
	private readonly Guid _productId;
	private readonly int _quantity;
	private readonly Guid _userId;

	public Guid CartItemId => _cartItemId;
	public Guid ProductId => _productId;
	public int Quantity => _quantity;
	public Guid UserId => _userId;

	public CartItem(Guid cartItemId, Guid productId, int quantity, Guid userId)
	{
		if (quantity <= 0)
			throw new ArgumentOutOfRangeException(nameof(quantity), " оличество товара должно быть больше нул€.");

		_cartItemId = cartItemId;
		_productId = productId;
		_quantity = quantity;
		_userId = userId;
	}
}