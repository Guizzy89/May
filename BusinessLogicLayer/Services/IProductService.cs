using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.BusinessLogicLayer.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(Guid id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
    }
}