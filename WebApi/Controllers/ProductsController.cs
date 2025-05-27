using Microsoft.AspNetCore.Mvc;
using MyStore.BusinessLogicLayer.Services;
using System.Collections.Generic;

namespace MyStore.WebApi.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] Guid id, [FromBody] Product updatedProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();

            var updatedProductWithId = new Product(
                id,
                updatedProduct.Name,
                updatedProduct.Price,
                updatedProduct.StockQuantity,
                updatedProduct.Category
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