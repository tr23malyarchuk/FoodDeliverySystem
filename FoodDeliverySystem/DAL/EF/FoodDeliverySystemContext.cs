using Catalog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL.EF
{
    public class FoodDeliverySystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public FoodDeliverySystemContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}