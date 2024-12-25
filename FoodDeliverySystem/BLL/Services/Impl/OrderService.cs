using Catalog.BLL.DTO;
using Catalog.BLL.Services.Interfaces;
using Catalog.CCL.Security;
using Catalog.DAL.UnitOfWork;

namespace Catalog.BLL.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<OrderDTO> GetOrders(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            if (user == null)
            {
                throw new InvalidOperationException("No user found in the context.");
            }

            var foodDeliverySystemId = user.FoodDeliverySystemID;

            var ordersEntities = _database.Orders
                .Where(o => o.FoodDeliverySystemId == foodDeliverySystemId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var ordersDto = ordersEntities.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                ClientId = o.ClientId,
                TotalAmount = o.TotalAmount,
                Status = o.Status
            }).ToList();

            return ordersDto;
        }
    }
}
