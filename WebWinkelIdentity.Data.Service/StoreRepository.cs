using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Data.Service
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StoreRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<Store> GetAllStores()
        {
            return _dbContext.Stores.ToList();
        }

        public List<Store> GetAllStores(Product product)
        {
            return _dbContext.Stores
                .Include(s => s.Address)
                .Include(s => s.Products.Where(p =>
                    p.BrandId == product.BrandId &&
                    p.CategoryId == product.CategoryId &&
                    p.Color == product.Color &&
                    p.Fabric == product.Fabric &&
                    p.Name == product.Name &&
                    p.Price == product.Price))
                .ToList();
        }

        public Store GetStoreInfo(int id)
        {
            return _dbContext.Stores.FirstOrDefault(s => s.Id == id);
        }
    }
}
