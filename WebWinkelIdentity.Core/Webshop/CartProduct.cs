﻿using WebWinkelIdentity.Core.StoreEntities;

namespace WebWinkelIdentity.Core
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int CartId { get; set; }
    }
}
