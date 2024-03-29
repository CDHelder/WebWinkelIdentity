﻿using WebWinkelIdentity.Core.StoreEntities;

namespace WebWinkelIdentity.Core
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}
