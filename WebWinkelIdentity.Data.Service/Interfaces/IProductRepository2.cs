using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;

namespace WebWinkelIdentity.Data.Service.Interfaces
{
    public interface IProductRepository2
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProduct(Expression<Func<Product, bool>> filter = null,
            IOrderedQueryable<Product> orderBy = null, 
            params Expression<Func<Product, object>>[] includeProperties);
        bool CreateProduct(Product product);
        bool DeleteProduct(int productId);
        bool UpdateProduct(Product product);
        bool SaveChanges();
    }
}
