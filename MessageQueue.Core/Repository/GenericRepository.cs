using MessageQueue.Core.Data.Db;
using MessageQueue.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Core.Repository
{
    public class GenericRepository<TEntity, T> : IGenericRepository<TEntity, T> where TEntity : Entity<T>
    {

        private readonly BaseDbContext _db;
        public GenericRepository(BaseDbContext db)
        {
            _db = db;
        }
        public Task Add(TEntity entity)
        {
            _db.Add(entity);
            return Task.CompletedTask;
        }

        public Task<List<TEntity>> GetAllAsync() => _db.Set<TEntity>().ToListAsync();

        public Task<TEntity?> GetById(T id) => _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));

        public Task Remove(TEntity entity)
        {
            _db.Remove(entity);
            return Task.CompletedTask;
        }

        public Task Update(TEntity entity)
        {

            _db.Update(entity);
            return Task.CompletedTask;
        }
    }
}
