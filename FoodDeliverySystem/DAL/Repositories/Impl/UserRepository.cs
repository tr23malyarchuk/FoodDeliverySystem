using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Impl
{
    public class UserRepository
        : BaseRepository<User>, IUserRepository
    {
        internal UserRepository(FoodDeliverySystemContext context)
        : base(context)
        {
        }
    }
}
