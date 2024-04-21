using MessageQueue.Book.Repository.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MessageQueue.Book.Repository.Implement
{
    public class BookCacheRepository : IBookRepository
    {
        private readonly IDistributedCache _cache;
        public BookCacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<List<Model.Book>> GetAllBooks()
        {
            var json = await _cache.GetStringAsync("Books");
            if (json == null)
            {
                return new List<Model.Book> { };
            }
            var list = JsonSerializer.Deserialize<List<Model.Book>>(json)!;
            return list;
        }

        public async Task<Model.Book?> GetBook(Guid id)
        {
            var json = await _cache.GetStringAsync($"Book:{id}");
            if (json == null)
            {
                return null;
            }
            var book = JsonSerializer.Deserialize<Model.Book>(json)!;
            return book;
        }
    }
}
