using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimisComplaints.DataLayer.Interfaces;

namespace TimisComplaints.DataLayer.Repositories.Base
{
    public class GenericDataRepository<T> : IDisposable
        where T : class, IEntity, new()
    {
        private readonly Entities mContext;
        private readonly DbSet<T> mDbSet;

        protected internal GenericDataRepository()
        {
            mContext = new Entities();
            mDbSet = mContext.Set<T>();
        }

        public virtual Entities Context => mContext;

        protected virtual async Task<IList<T>> GetAllAsync(IList<string> navigationProperties = null)
        {
            var dbQuery = GenerateQuery(navigationProperties);

            var list = await dbQuery.ToListAsync();
            return list;
        }

        protected virtual async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = GenerateQuery(navigationProperties);

            var list = await dbQuery.Where(@where).ToListAsync();

            return list;
        }

        protected virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = GenerateQuery(navigationProperties);

            var item = await dbQuery.FirstOrDefaultAsync(@where);

            return item;
        }

        protected virtual async Task<T> AddAsync(T item)
        {
            mDbSet.Add(item);

            await mContext.SaveChangesAsync();

            return item;
        }

        protected virtual async Task<IList<T>> AddAsync(IList<T> items)
        {
            mDbSet.AddRange(items);

            await mContext.SaveChangesAsync();

            return items;
        }

        protected virtual async Task<T> ChangeAsync(T item)
        {
            mContext.Entry(item).State = EntityState.Modified;

            await mContext.SaveChangesAsync();

            return item;
        }

        protected virtual async Task<IList<T>> ChangeAsync(IList<T> items)
        {
            mContext.Configuration.AutoDetectChangesEnabled = false;

            foreach (var item in items)
            {
                mContext.Entry(item).State = EntityState.Modified;
            }

            mContext.Configuration.AutoDetectChangesEnabled = true;
            await mContext.SaveChangesAsync();

            return items;
        }

        protected virtual async Task DeleteAsync(T item)
        {
            mDbSet.Remove(item);

            await mContext.SaveChangesAsync();
        }

        protected virtual async Task DeleteAsync(IEnumerable<T> items)
        {
            mDbSet.RemoveRange(items);

            await mContext.SaveChangesAsync();
        }

        #region Private methods

        private IQueryable<T> GenerateQuery(IList<string> navigationProperties)
        {
            IQueryable<T> dbQuery = mDbSet;

            return ApplyNavigationProperties(dbQuery, navigationProperties);
        }

        private static IQueryable<T> ApplyNavigationProperties(IQueryable<T> dbQuery, IList<string> navigationProperties)
        {
            if (navigationProperties != null)
            {
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
            }

            return dbQuery;
        }

        #endregion

        #region Disposing logic

        public void Dispose()
        {
            mContext.Dispose();
        }

        #endregion
    }
}