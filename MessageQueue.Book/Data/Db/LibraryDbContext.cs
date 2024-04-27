using MessageQueue.Core.Data.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MessageQueue.Book.Data.Db
{
    public class LibraryDbContext : BaseDbContext, ILibraryDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Model.Book> Books => Set<Model.Book>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
