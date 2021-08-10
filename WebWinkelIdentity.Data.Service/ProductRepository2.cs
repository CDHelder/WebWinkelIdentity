using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Data.Service
{
    public class ProductRepository2 : IProductRepository2
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository2(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            return SaveChanges();
        }

        public bool DeleteProduct(int productId)
        {

            var excists = GetProductByFunc()
        }

        public IEnumerable<Product> GetProduct(Expression<Func<Product, bool>> filter = null,
            IOrderedQueryable<Product> orderBy = null, 
            params Expression<Func<Product, object>>[] includeProperties)
        {
            IQueryable<Product> query = _dbContext.Products;

            if (filter != null)
                query = query.Where(filter);

            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0 ? true : false;
        }
    }
}
