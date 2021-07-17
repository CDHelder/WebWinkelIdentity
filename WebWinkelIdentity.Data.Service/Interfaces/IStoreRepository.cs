using System.Collections.Generic;
using WebWinkelIdentity.Core;

namespace WebWinkelIdentity.Data.Service.Interfaces
{
    public interface IStoreRepository
    {
        public Store GetStoreInfo(int id);
        public List<Store> GetAllStores();
        public List<Store> GetAllStores(Product product);
    }
}
