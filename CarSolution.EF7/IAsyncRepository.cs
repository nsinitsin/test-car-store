using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarSolution.EF7
{
    public interface IAsyncRepository : IDisposable
    {
        //Task<TEntity> GetByKeyAsync<TEntity>(object keyValue) where TEntity : class;
        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        TEntity First<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        Task<TEntity> FindOneAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        TEntity FindOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        Task<int> CountAsync<TEntity>() where TEntity : class;
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}