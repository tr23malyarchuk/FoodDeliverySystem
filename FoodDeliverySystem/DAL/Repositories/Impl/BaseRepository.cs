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
                .Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
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
