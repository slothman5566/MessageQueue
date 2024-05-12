using MessageQueue.Core.Data.Db;
using MessageQueue.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Core.Repository
{
    public class GenericRepository<TEntity, T> : IGenericRepository<TEntity, T> where TEntity : Entity<T>
    {

        protected readonly BaseDbContext _db;
        public GenericRepository(BaseDbContext db)
        {
            _db = db;
        }
        public virtual Task Add(TEntity entity)
        {
            _db.Add(entity);
            return Task.CompletedTask;
        }

        public virtual Task<List<TEntity>> GetAllAsync() => _db.Set<TEntity>().ToListAsync();

        public virtual Task<TEntity?> GetById(T id) => _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));

        public virtual Task Remove(TEntity entity)
        {
            _db.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task Update(TEntity entity)
        {

            _db.Update(entity);
            return Task.CompletedTask;
        }
    }
}
