using MessageQueue.Book.Model;
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

        public async Task Add(Model.Book entity)
        {
            await _cache.SetStringAsync($"Book:{entity.Id}", JsonSerializer.Serialize(entity));
        }

        public async Task<List<Model.Book>> GetAllAsync()
        {
            var json = await _cache.GetStringAsync("Books");
            if (json == null)
            {
                return new List<Model.Book> { };
            }
          
            var list = JsonSerializer.Deserialize<List<Model.Book>>(json)!;
            return list;
        }


        public async Task<Model.Book?> GetById(BookId id)
        {
            var json = await _cache.GetStringAsync($"Book:{id}");
            if (json == null)
            {
                return null;
            }
            var book = JsonSerializer.Deserialize<Model.Book>(json)!;
            return book;
        }

        public async Task Remove(Model.Book entity)
        {
            await _cache.RemoveAsync($"Book:{entity.Id}");
        }

        public async Task Update(Model.Book entity)
        {
           await  _cache.SetStringAsync($"Book:{entity.Id}", JsonSerializer.Serialize(entity));
        }
    }
}
