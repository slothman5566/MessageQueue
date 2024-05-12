using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartItemCacheRepository : GenericCacheRepository<BooksCartItem, Guid, IBooksCartItemRepository>, IBooksCartItemRepository
    {
        public BooksCartItemCacheRepository(IDistributedCache cache, IBooksCartItemRepository repository) : base(cache, repository)
        {
        }
    }
}
