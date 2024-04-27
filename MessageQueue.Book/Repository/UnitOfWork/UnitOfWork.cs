using MessageQueue.Book.Data.Db;
using MessageQueue.Book.Repository.Interface;

namespace MessageQueue.Book.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _db;
        private readonly IBookRepository _bookRepository;
        public UnitOfWork(LibraryDbContext libraryDb, IBookRepository bookRepository)
        {
            _db = libraryDb;
            _bookRepository = bookRepository;
        }
        public IBookRepository BookRepository => _bookRepository;

        public Task<int> SaveChangeAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
