using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Book.Data.Db
{
    public interface ILibraryDbContext
    {
        DbSet<Model.Book> Books { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
