using EmpApi.Core.IRepositories;
using System.Linq.Expressions;

namespace EmpApi.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public  Repository(DbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> Get(byte id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> Get(short id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> Get(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }
        public async Task<TEntity> FirstOrDefault()
        {
            return _context.Set<TEntity>().FirstOrDefault();
        }
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }
        public async Task<IEnumerable<TResult>> Select<TResult>(Func<TEntity, TResult> selector)
        {
            return _context.Set<TEntity>().Select(selector);
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
