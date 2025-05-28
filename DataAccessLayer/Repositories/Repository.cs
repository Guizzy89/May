using Microsoft.EntityFrameworkCore;
using WebApplication1.BusinessLogicLayer.Services;
using WebApplication1.DataAccessLayer;
using WebApplication1.DataAccessLayer.Models;
using WebApplication1.DataAccessLayer.Repositories;

namespace WebApplication1.DataAccessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StoreDbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(StoreDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(object id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => _dbSet.Remove(entity);

        public void SaveChanges() => _context.SaveChanges();
    }
}