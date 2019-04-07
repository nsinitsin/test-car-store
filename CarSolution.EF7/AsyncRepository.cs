using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarSolution.EF7;
using Microsoft.EntityFrameworkCore;

namespace CatSolutions.EFEntity
{
    public class AsyncRepository : IAsyncRepository
    {
#if DEBUG
        private Guid debugId = Guid.NewGuid();
#endif

        private readonly DbContext dbContext;
        //private readonly ObjectContext objectContext;

        public AsyncRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            //objectContext = (dbContext as IObjectContextAdapter).ObjectContext;
        }

        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {

            return dbContext.Set<TEntity>();

        }

        public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria);
        }

        public Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().SingleAsync<TEntity>(criteria);
        }

        public TEntity First<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().First(criteria);
        }

        public Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().FirstAsync(criteria);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            var entities = Find<TEntity>(criteria);

            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {

        }

        public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria);
        }

        public Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Task.FromResult(GetQuery<TEntity>().Where(criteria));
        }

        public Task<TEntity> FindOneAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria).FirstOrDefaultAsync();
        }

        public TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            return sortOrder == SortOrder.Ascending
                ? GetQuery<TEntity>().OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable()
                : GetQuery<TEntity>().OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending) where TEntity : class
        {
            return sortOrder == SortOrder.Ascending
                ? GetQuery<TEntity>().Where(criteria).OrderBy(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable()
                : GetQuery<TEntity>().Where(criteria).OrderByDescending(orderBy).Skip(pageIndex).Take(pageSize).AsEnumerable();
        }

        public Task<int> CountAsync<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().CountAsync();
        }

        public Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().CountAsync(criteria);
        }

        public int SaveChanges()
        {
            var result = dbContext.SaveChanges();
            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (dbContext != null)
                        dbContext.Dispose(); 
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}