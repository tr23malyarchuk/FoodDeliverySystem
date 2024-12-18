using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CreditCard { get; set; }

        public User User { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
