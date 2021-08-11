using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Data.Service.GenericRepositoryTest
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IGenericRepository<T> Repository { get; }
        Task SaveChanges();
    }
}
