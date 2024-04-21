using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MessageQueue.Book.Data
{
    public static class DataSeeder
    {
        public static async Task SeedData(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var cache = scope.ServiceProvider.GetRequiredService<IDistributedCache>();
            var books = new List<Model.Book>()
            {
                new()
                {
                    Id=Guid.NewGuid(),
                    Title="A"
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    Title="B"
                },
                new()
                {
                    Id=Guid.NewGuid(),
                    Title="C"
                }
            };
            await cache.SetStringAsync("Books", JsonSerializer.Serialize(books));
            foreach (var book in books)
            {
                await cache.SetStringAsync($"Book:{book.Id}", JsonSerializer.Serialize(book));
            }

        }


    }
}
