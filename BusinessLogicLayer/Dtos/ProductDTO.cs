namespace WebApplication1.BusinessLogicLayer.Dtos
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
