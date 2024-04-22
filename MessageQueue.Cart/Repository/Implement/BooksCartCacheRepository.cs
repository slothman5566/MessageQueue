using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartCacheRepository : IBooksCartRepository
    {
        private readonly IDistributedCache _cache;
        public BooksCartCacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<Guid> AddCart(BooksCart booksCart)
        {
            await _cache.SetStringAsync($"BooksCart:{booksCart.Id}", JsonSerializer.Serialize(booksCart));
            var json = await _cache.GetStringAsync("BooksCarts");
            var list = new List<BooksCart>();
            if (json != null)
            {
                list = JsonSerializer.Deserialize<List<BooksCart>>(json)!;
            }
            list.Add(booksCart);
            await _cache.SetStringAsync("BooksCarts", JsonSerializer.Serialize(list));
            return booksCart.Id;
        }

        public async Task<List<BooksCart>> GetAllBooksCart()
        {
            var json = await _cache.GetStringAsync("BooksCarts");
            var list = new List<BooksCart>();
            if (json != null)
            {
                list = JsonSerializer.Deserialize<List<BooksCart>>(json)!;
            }
            return list;
        }

        public async Task<BooksCart?> GetCart(Guid id)
        {
            var json = await _cache.GetStringAsync($"BooksCart:{id}");
            if (json == null)
            {
                return null;
            }
            return JsonSerializer.Deserialize<BooksCart>(json)!;
        }
    }
}
