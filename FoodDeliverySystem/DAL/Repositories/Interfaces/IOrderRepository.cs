using Catalog.DAL.Entities;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
        : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByClientId(int clientId);
        IEnumerable<Order> GetOrdersByStatus(string status);
        IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Order> GetOrdersByTotalAmountGreaterThan(double amount);
    }
}
