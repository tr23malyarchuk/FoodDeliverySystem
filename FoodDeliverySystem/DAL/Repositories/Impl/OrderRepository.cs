using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Impl
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        internal OrderRepository(FoodDeliverySystemContext context) : base(context)
        {
        }

        // Get all orders for a specific client by clientId
        public IEnumerable<Order> GetOrdersByClientId(int clientId)
        {
            return Find(order => order.ClientId == clientId);
        }

        // Get orders by status (case-insensitive comparison)
        public IEnumerable<Order> GetOrdersByStatus(string status)
        {
            return Find(order => order.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        // Get orders within a specific date range
        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return Find(order => order.OrderDate >= startDate && order.OrderDate <= endDate);
        }

        // Find orders where the total amount is greater than a specified value
        public IEnumerable<Order> GetOrdersByTotalAmountGreaterThan(double amount)
        {
            return Find(order => order.TotalAmount > amount);
        }
    }
}
