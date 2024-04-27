using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MessageQueue.Book.Repository.Implement
{
    public class BookCacheRepository : IBookRepository
    {
        private readonly IDistributedCache _cache;
        private readonly IBookRepository _bookRepository;
        public BookCacheRepository(IDistributedCache cache, IBookRepository bookRepository)
        {
            _cache = cache;
            _bookRepository = bookRepository;
        }



        public async Task<List<Model.Book>> GetAllAsync()
        {

            var json = await _cache.GetStringAsync("Books");
            if (json != null)
            {
                return JsonSerializer.Deserialize<List<Model.Book>>(json)!;
            }

            var list = await _bookRepository.GetAllAsync();
            await _cache.SetStringAsync("Books", JsonSerializer.Serialize(list));
            return list;
        }


        public async Task<Model.Book?> GetById(BookId id)
        {
            var json = await _cache.GetStringAsync($"Book:{id}");
            if (json != null)
            {
                return JsonSerializer.Deserialize<Model.Book>(json)!;
            }
            var book = await _bookRepository.GetById(id);
            await _cache.SetStringAsync($"Book:{id}", JsonSerializer.Serialize(book));
            return book;
        }

        public async Task Add(Model.Book entity)
        {
            await _bookRepository.Add(entity);
            await _cache.SetStringAsync($"Book:{entity.Id}", JsonSerializer.Serialize(entity));
            await RemoveBooksCache();
        }

        public async Task Remove(Model.Book entity)
        {
            await _bookRepository.Remove(entity);
            await _cache.RemoveAsync($"Book:{entity.Id}");
            await RemoveBooksCache();
        }

        public async Task Update(Model.Book entity)
        {
            await _bookRepository.Update(entity);
            await _cache.SetStringAsync($"Book:{entity.Id}", JsonSerializer.Serialize(entity));
            await RemoveBooksCache();
        }

        private Task RemoveBooksCache()
        {
            return _cache.RemoveAsync("Books");
        }
    }
}
