using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Data.Service.GenericRepositoryTest
{
    class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
         
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
