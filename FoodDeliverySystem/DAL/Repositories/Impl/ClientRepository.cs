using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Impl
{
    public class ClientRepository
        : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(FoodDeliverySystemContext context)
            : base(context)
        {
        }
    }
}
