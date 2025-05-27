using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLogicLayer.Services;
using WebApplication1.BusinessLogicLayer.Dtos;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = new CategoryDTO
                {
                    CategoryId = p.Category.CategoryId,
                    Name = p.Category.Name
                }
            }));
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product(
                productDto.ProductId,
                productDto.Name,
                productDto.Price,
                productDto.StockQuantity,
                new Category(productDto.Category.CategoryId, productDto.Category.Name)
            );

            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = new CategoryDTO
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name
                }
            });
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] Guid id, [FromBody] ProductDTO updatedProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();

            var updatedProduct = new Product(
                id,
                updatedProductDto.Name,
                updatedProductDto.Price,
                updatedProductDto.StockQuantity,
                new Category(updatedProductDto.Category.CategoryId, updatedProductDto.Category.Name)
            );

            _productService.UpdateProduct(updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            var productToRemove = _productService.GetProductById(id);
            if (productToRemove == null)
                return NotFound();

            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}