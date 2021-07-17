using System;
using System.Collections.Generic;
using WebWinkelIdentity.Core;
using Xunit;

namespace WebWinkelTester
{
    public class RepositoryTester
    {
        [Fact]
        public void SearchProducts()
        {
            
        }

        public void SearchProductsInStore(string searchTerm, int storeId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllStoreProducts(int storeid)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
