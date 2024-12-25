using Catalog.BLL.DTO;

namespace Catalog.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetOrders(int page);
    }
}
