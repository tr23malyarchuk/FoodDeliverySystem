﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }

    }
}