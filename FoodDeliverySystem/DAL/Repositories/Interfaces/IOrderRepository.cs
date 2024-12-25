using Catalog.DAL.Entities;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
        : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByClientId(int clientId, int pageNumber, int pageSize);
        IEnumerable<Order> GetOrdersByStatus(string status, int pageNumber, int pageSize);
        IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate, int pageNumber, int pageSize);
        IEnumerable<Order> GetOrdersByTotalAmountGreaterThan(double amount, int pageNumber, int pageSize);
    }
}
