using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = [];

        public Category() { }

        public Category(int categoryId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ќазвание категории не может быть пустым.", nameof(name));

            this.CategoryId = categoryId;
            this.Name = name;
        }
    }
}