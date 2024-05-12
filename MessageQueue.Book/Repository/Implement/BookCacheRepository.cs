using MessageQueue.Book.Repository.Interface;
using MessageQueue.Core.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace MessageQueue.Book.Repository.Implement
{
    public class BookCacheRepository : GenericCacheRepository<Model.Book, Model.BookId, IBookRepository>, IBookRepository
    {
        public BookCacheRepository(IDistributedCache cache, IBookRepository repository) : base(cache, repository)
        {
        }
    }
}
