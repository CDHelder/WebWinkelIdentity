using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;

namespace WebWinkelIdentity.Data.Service.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> SearchProduct(string searchTerm);

        public Product GetProduct(int id);
        public List<Product> GetAllProducts();
        public List<StoreProduct> GetAllStoreProducts(List<Product> products);
        public List<Product> GetAllProductsVariations(Product product);
        public List<Product> GetProductsByBrand(int brandId);
        public List<Product> GetProductsByCategory(int categoryId);

        public Product AddProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool UpdateProductProperties(Product product, List<Product> products);
        public bool UpdateProducts(List<Product> products);
        public bool DeleteProduct(int id);
        public bool SaveChangesAtleastOne();

        public List<Brand> GetAllBrands();
        public List<Category> GetAllCategories();
    }
}
