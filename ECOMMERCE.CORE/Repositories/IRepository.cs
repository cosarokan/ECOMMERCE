using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        List<TEntity> All();
        List<TEntity> Where(Expression<Func<TEntity, bool>> where);
        List<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool isDesc);
        TEntity Single(Expression<Func<TEntity, bool>> single);
        TEntity FindById(object id);
    }
}