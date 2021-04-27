using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECOMMERCE.DATA.Repositories
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        protected readonly ApplicationDbContext _dbDataContext;
        public RepositoryBase(DbContext dbDataContext)
        {
            _dbDataContext = (ApplicationDbContext)dbDataContext;
            this.Table = _dbDataContext.Set<TEntity>();
        }
        private DbSet<TEntity> Table { get; }

        public bool Add(TEntity entity)
        {
            Table.Add(entity);
            return Save();
        }

        public bool Update(TEntity entity)
        {
            Table.Update(entity);
            return Save();
        }

        public bool Delete(TEntity entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public List<TEntity> All()
        {
            return Table.AsNoTracking().ToList();
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> @where)
        {
            return Table.Where(where).ToList();
        }

        public List<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy).ToList();
            return Table.OrderBy(orderBy).ToList();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> single)
        {
            return Table.AsNoTracking().SingleOrDefault(single);
        }

        public TEntity FindById(object id)
        {
            return Table.Find(id);
        }

        private bool Save()
        {
            try
            {
                _dbDataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
