using MessageQueue.Core.Model;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MessageQueue.Core.Repository
{
    public class GenericCacheRepository<TEntity, TId, TRepo> : IGenericRepository<TEntity, TId> where TEntity : Entity<TId> where TRepo : IGenericRepository<TEntity, TId>
    {
        protected readonly IDistributedCache _cache;
        protected readonly TRepo _repository;

        public GenericCacheRepository(IDistributedCache cache, TRepo repository)
        {
            _cache = cache;
            _repository = repository;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var json = await _cache.GetStringAsync($"{typeof(TEntity).FullName}.List");
            if (json != null)
            {
                return JsonSerializer.Deserialize<List<TEntity>>(json)!;
            }

            var list = await _repository.GetAllAsync();
            await _cache.SetStringAsync($"{typeof(TEntity).FullName}.List", JsonSerializer.Serialize(list));
            return list;
        }


        public async Task<TEntity?> GetById(TId id)
        {
            var json = await _cache.GetStringAsync($"{typeof(TEntity).FullName}:{id}");
            if (json != null)
            {
                return JsonSerializer.Deserialize<TEntity>(json)!;
            }
            var book = await _repository.GetById(id);
            await _cache.SetStringAsync($"{typeof(TEntity).FullName}:{id}", JsonSerializer.Serialize(book));
            return book;
        }

        public async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
            await _cache.SetStringAsync($"{typeof(TEntity).FullName}:{entity.Id}", JsonSerializer.Serialize(entity));
            await RemoveListCache();
        }

        public async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
            await _cache.RemoveAsync($"{typeof(TEntity).FullName}:{entity.Id}");
            await RemoveListCache();
        }

        public async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
            await _cache.SetStringAsync($"{typeof(TEntity).FullName}:{entity.Id}", JsonSerializer.Serialize(entity));
            await RemoveListCache();
        }

        protected virtual Task RemoveListCache()
        {
            _cache.RemoveAsync($"{  typeof(TEntity).FullName}.List");
            return Task.CompletedTask;
        }
    }
}
