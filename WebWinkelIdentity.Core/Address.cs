using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public string Streetname { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
