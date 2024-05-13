using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Model;
using MessageQueue.Core.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartItemCacheRepository : GenericCacheRepository<BooksCartItem, Guid, IBooksCartItemRepository>, IBooksCartItemRepository
    {
        public BooksCartItemCacheRepository(IDistributedCache cache, IBooksCartItemRepository repository) : base(cache, repository)
        {
        }

        public override Task Add(BooksCartItem entity)
        {
            _cache.RemoveAsync($"{typeof(BooksCart).FullName}:{entity.Id}");
            return base.Add(entity);
        }

        public override Task Update(BooksCartItem entity)
        {
            _cache.RemoveAsync($"{typeof(BooksCart).FullName}:{entity.Id}");
            return base.Update(entity);
        }

        public override Task Remove(BooksCartItem entity)
        {
            _cache.RemoveAsync($"{typeof(BooksCart).FullName}:{entity.Id}");
            return base.Remove(entity);
        }
    }
}
