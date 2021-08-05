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
        public StoreProduct GetStoreProduct(int productId);

        public List<ProductStockChange> GetAllProductStockChanges();
        public List<Product> GetAllProducts();
        public List<Product> GetAllProducts(List<int> productIds);
        public List<StoreProduct> GetAllStoreProducts(List<Product> products);

        public List<Product> GetAllProductsVariations(Product product);
        public List<Product> GetProductsByBrand(int brandId);
        public List<Product> GetProductsByCategory(int categoryId);

        public bool CreateProductStockChange(ProductStockChange productStockChange);
        public Product CreateProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool UpdateProductProperties(Product product, List<Product> products);
        public bool UpdateProducts(List<Product> products);
        public bool UpdateStoreProduct(StoreProduct storeProduct); 
        public bool UpdateStoreProducts(List<StoreProduct> storeProducts);
        public bool DeleteProduct(int id);
        public bool SaveChangesAtleastOne();

        public List<Brand> GetAllBrands();
        public List<Category> GetAllCategories();
    }
}
