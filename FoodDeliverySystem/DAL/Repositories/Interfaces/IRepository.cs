﻿namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate, int pageNumber, int pageSize);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        List<T> Where(Func<T, bool> predicate);

    }
}
