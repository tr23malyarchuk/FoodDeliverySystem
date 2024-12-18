using Catalog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL.EF
{
    public class FoodDeliverySystemContext : DbContext
    {
        // DBSets definition for each entity in a database
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Constructor to pass options to the DbContext base class
        public FoodDeliverySystemContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}