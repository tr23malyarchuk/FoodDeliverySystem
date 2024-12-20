using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

class TestOrderRepository
 : BaseRepository<Order>
{
    public TestOrderRepository(DbContext context)
        : base(context)
    {
    }
}
