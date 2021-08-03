using System.Collections.Generic;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;

namespace WebWinkelIdentity.Data.Service.Interfaces
{
    public interface IStoreRepository
    {
        public Store GetStoreInfo(int id);
        public List<Store> GetAllStores();
        public bool UpdateStoreProductsStock(List<Store> stores);
        public bool SaveChangesAtleastOne();
    }
}
