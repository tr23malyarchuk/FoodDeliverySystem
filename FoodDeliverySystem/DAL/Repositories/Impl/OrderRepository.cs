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

        public IEnumerable<Order> GetOrdersByClientId(int clientId)
        {
            return Find(order => order.ClientId == clientId);
        }

        public IEnumerable<Order> GetOrdersByStatus(string status)
        {
            return Find(order => order.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return Find(order => order.OrderDate >= startDate && order.OrderDate <= endDate);
        }

        public IEnumerable<Order> GetOrdersByTotalAmountGreaterThan(double amount)
        {
            return Find(order => order.TotalAmount > amount);
        }
    }
}
