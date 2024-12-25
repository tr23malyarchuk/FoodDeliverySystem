using Catalog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL.Repositories.Impl
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public void Create(T item)
        {
            _set.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                _set.Remove(item);
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate, int pageNumber, int pageSize)
        {
            return _set
                .Where(predicate)  // Apply the filter
                .Skip((pageNumber - 1) * pageSize)  // Skip items for pagination
                .Take(pageSize)  // Take the page size
                .ToList();  // Return as a list
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public List<T> Where(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
    }
}
