using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Core.StoreEntities
{
    public class ProductStockChange
    {
        public int Id { get; set; }
        public int StoreProductId { get; set; }
        public StoreProduct StoreProduct { get; set; }
        public int StockChange { get; set; }
        public DateTime DateChanged { get; set; }
        public string UserId { get; set; }
        public IdentityUser AssociatedUser { get; set; }
    }
}
