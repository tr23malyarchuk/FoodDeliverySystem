using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IClientRepository Clients { get; }
        IUserRepository Users { get; }
        void Save();
    }
}
