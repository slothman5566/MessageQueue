using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartCacheRepository : GenericCacheRepository<BooksCart, BooksCartId, IBooksCartRepository>, IBooksCartRepository
    {
        public BooksCartCacheRepository(IDistributedCache cache, IBooksCartRepository repository) : base(cache, repository)
        {
        }
    }
}
