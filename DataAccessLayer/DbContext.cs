using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyStore.DataAccessLayer
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Products.db");
        }
    }
}