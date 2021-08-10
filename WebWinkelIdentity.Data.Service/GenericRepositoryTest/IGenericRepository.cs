using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Data.Service.GenericRepositoryTest
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetById(int id);
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Update(List<TEntity> objs);
        void Delete(int id);
        void Delete(TEntity entity);
        //bool SaveChanges();
    }
}
