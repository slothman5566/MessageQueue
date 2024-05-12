using MessageQueue.Core.Data.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MessageQueue.Cart.Data.Db
{
    public class CartDbContext : BaseDbContext
    {
        public CartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Model.BooksCart> BooksCarts => Set<Model.BooksCart>();
        public DbSet<Model.BooksCartItem> BooksCartItems => Set<Model.BooksCartItem>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
