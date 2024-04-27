using MessageQueue.Book.Data.Db;
using MessageQueue.Book.Model;
using Microsoft.EntityFrameworkCore;
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
            using var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
            var books = new List<Model.Book>();
            if (await dbContext.Books.AnyAsync())
            {
                books = await dbContext.Books.ToListAsync();
            }
            else
            {
                books = new List<Model.Book>()
                {
                new()
                {
                    Id=BookId.Of(Guid.NewGuid()),
                    Title="A"
                },
                new()
                {
                    Id=BookId.Of(Guid.NewGuid()),
                    Title="B"
                },
                new()
                {
                    Id=BookId.Of(Guid.NewGuid()),
                    Title="C"
                }
                };
                dbContext.Books.AddRange(books);
                await dbContext.SaveChangesAsync();
            }

            await cache.SetStringAsync("Books", JsonSerializer.Serialize(books));
            foreach (var book in books)
            {
                await cache.SetStringAsync($"Book:{book.Id}", JsonSerializer.Serialize(book));
            }


        }


    }
}
