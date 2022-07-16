using System.Linq.Expressions;

namespace EmpApi.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Get(short id);
        Task<TEntity> Get(byte id);
        Task<TEntity> Get(long id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefault();
        Task<IEnumerable<TResult>> Select<TResult>(Func<TEntity, TResult> selector);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
