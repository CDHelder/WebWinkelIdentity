using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.GenericRepositoryTest;

namespace WebWinkelIdentity.Data.Service.GenericRepositoryTest
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
         
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Repository = new GenericRepository<T>(dbContext);
        }

        public IGenericRepository<T> Repository { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
