using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;

namespace WebApplication1.BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetProducts() => _repository.GetAll();

        public Product GetProductById(Guid id) => _repository.GetById(id);

        public void CreateProduct(Product product)
        {
            _repository.Add(product);
            _repository.SaveChanges(); 
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
            _repository.SaveChanges(); 
        }

        public void DeleteProduct(Guid id)
        {
            var product = _repository.GetById(id); 
            if (product != null)
            {
                _repository.Delete(product);
                _repository.SaveChanges(); 
            }
        }
    }
}