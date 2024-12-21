using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

class TestBaseRepository
 : BaseRepository<Order>
{
    public TestBaseRepository(DbContext context)
        : base(context)
    {
    }
}
