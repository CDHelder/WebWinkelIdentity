using System.Collections.Generic;

namespace WebWinkelIdentity.Core
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Product> Products { get; set; }
    }
}