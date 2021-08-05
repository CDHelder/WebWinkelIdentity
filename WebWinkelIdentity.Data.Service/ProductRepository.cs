using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Data.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Brand> GetAllBrands()
        {
            return _dbContext.Brands
                .Include(b => b.Products)
                .Include(b => b.Supplier)
                .ToList();
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories
                .Include(c => c.Products)
                .ToList();
        }

        public List<Product> GetAllProducts()
        {
            //Geeft een unieke lijst terug
            return _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToList()
                .GroupBy(p => new { p.Name, p.Price, p.Color, p.Fabric, p.BrandId, p.CategoryId })
                .Select(p => p.First())
                .ToList();

            // Get alle producten
            //return _dbContext.Products
            //    .Include(p => p.Brand)
            //    .Include(p => p.Category)
            //    .ToList();
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            return _dbContext.Products.Where(p => p.BrandId == brandId)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _dbContext.Products.Where(p => p.CategoryId == categoryId)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToList();
        }

        public Product CreateProduct(Product product)
        {
            if (product != null)
            {
                _dbContext.Products.Add(product);
                if (SaveChangesAtleastOne() == true)
                {
                    return product;
                }
            }
            return null;
        }

        public List<Product> SearchProduct(string searchTerm)
        {
            return _dbContext.Products.Where(p =>
            p.Brand.Name.Contains(searchTerm) ||
            p.Brand.Supplier.Name.Contains(searchTerm) ||
            p.Category.Name.Contains(searchTerm) ||
            p.Color.Contains(searchTerm) ||
            p.Fabric.Contains(searchTerm) ||
            p.Name.Contains(searchTerm) ||
            p.Size.Contains(searchTerm)
            ).Include(p => p.Brand)
                .Include(p => p.Category)
                .ToList();
        }

        public bool UpdateProduct(Product product)
        {
            var excistingproduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (excistingproduct == null)
            {
                return false;
            }

            _dbContext.Products.Attach(product).State = EntityState.Modified;
            if (SaveChangesAtleastOne() == true)
            {
                return true;
            }

            return false;
        }

        public bool SaveChangesAtleastOne()
        {
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                if (SaveChangesAtleastOne() == true)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Product> GetAllProductsVariations(Product product)
        {
            return _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(p =>
                    p.BrandId == product.BrandId &&
                    p.CategoryId == product.CategoryId &&
                    p.Color == product.Color &&
                    p.Fabric == product.Fabric &&
                    p.Name == product.Name &&
                    p.Price == product.Price)
                .ToList()
                .GroupBy(p => new { p.Size })
                .Select(p => p.First())
                .ToList();
        }

        public bool UpdateProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                _dbContext.Products.Attach(product).State = EntityState.Modified;
            }

            return SaveChangesAtleastOne();
        }

        public bool UpdateProductProperties(Product product, List<Product> products)
        {
            foreach (var prod in products)
            {
                prod.BrandId = product.BrandId;
                prod.CategoryId = product.CategoryId;
                prod.Color = product.Color;
                prod.Description = product.Description;
                prod.Fabric = product.Fabric;
                prod.Name = product.Name;
                prod.Price = product.Price;
            }

            return UpdateProducts(products);
        }

        public List<StoreProduct> GetAllStoreProducts(List<Product> products)
        {
            List<StoreProduct> storeProducts = new();

            foreach (var product in products)
            {
                storeProducts.AddRange(_dbContext.StoreProducts
                .Include(sp => sp.Store)
                .Include(sp => sp.Product)
                .Where(sp => sp.ProductId == product.Id)
                .ToList()
                .GroupBy(p => new { p.StoreId, p.ProductId })
                .Select(sp => sp.First())
                .ToList());
            }

            return storeProducts;
        }

        public bool UpdateStoreProducts(List<StoreProduct> storeProducts)
        {
            foreach (var product in storeProducts)
            {
                _dbContext.StoreProducts.Attach(product).State = EntityState.Modified;
            }

            return SaveChangesAtleastOne();
        }

        public StoreProduct GetStoreProduct(int productId)
        {
            return _dbContext.StoreProducts
                .Include(sp => sp.Product)
                .Include(sp => sp.Store)
                .FirstOrDefault(sp => sp.ProductId == productId);
        }

        public bool UpdateStoreProduct(StoreProduct storeProduct)
        {
            var excists = _dbContext.StoreProducts.FirstOrDefault(sp => sp.Id == storeProduct.Id);
            if (excists == null)
            {
                return false;
            }

            _dbContext.StoreProducts.Attach(excists).State = EntityState.Modified;

            return SaveChangesAtleastOne();
        }

        public List<Product> GetAllProducts(List<int> productIds)
        {
            var distinctProductIds = productIds.Distinct();
            return _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(p => distinctProductIds.Contains(p.Id))
                .ToList();
        }

        public bool CreateProductStockChange(ProductStockChange productStockChange)
        {
            if (productStockChange != null)
            {
                _dbContext.ProductStockChanges.Add(productStockChange);
            }

            return SaveChangesAtleastOne();
        }

        public List<ProductStockChange> GetAllProductStockChanges()
        {
            return _dbContext.ProductStockChanges
                .Include(psc => psc.Product)
                .ThenInclude(p => p.Brand)
                .Include(psc => psc.Product)
                .ThenInclude(p => p.Category)
                .Include(psc => psc.AssociatedUser)
                .ToList();
        }
    }
}
