using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Impl
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodDeliverySystemContext context)
            : base(context)
        {
        }

        public IEnumerable<Order> GetOrdersByClientId(int clientId, int pageNumber, int pageSize)
        {
            return Find(order => order.ClientId == clientId, pageNumber, pageSize);
        }

        public IEnumerable<Order> GetOrdersByStatus(string status, int pageNumber, int pageSize)
        {
            return Find(order => order.Status.Equals(status, StringComparison.OrdinalIgnoreCase), pageNumber, pageSize);
        }

        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            return Find(order => order.OrderDate >= startDate && order.OrderDate <= endDate, pageNumber, pageSize);
        }

        public IEnumerable<Order> GetOrdersByTotalAmountGreaterThan(double amount, int pageNumber, int pageSize)
        {
            return Find(order => order.TotalAmount > amount, pageNumber, pageSize);
        }

    }
}
