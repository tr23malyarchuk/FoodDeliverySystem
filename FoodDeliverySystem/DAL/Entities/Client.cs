using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Entities
{
    public class Client : User
    {
        public string Address { get; set; }
        public string CreditCard { get; set; }

    }
}
