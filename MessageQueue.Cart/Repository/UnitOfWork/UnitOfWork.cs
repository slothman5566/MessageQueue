using MessageQueue.Cart.Data.Db;
using MessageQueue.Cart.Repository.Interface;

namespace MessageQueue.Cart.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CartDbContext _db;
        private readonly IBooksCartItemRepository _booksCartItemRepository;
        private readonly IBooksCartRepository _booksCartRepository;
        public UnitOfWork(CartDbContext libraryDb,
            IBooksCartItemRepository booksCartItemRepository,
            IBooksCartRepository booksCartRepository)
        {
            _db = libraryDb;
            _booksCartItemRepository = booksCartItemRepository;
            _booksCartRepository = booksCartRepository;

        }
     

        public IBooksCartItemRepository BooksCartItemCacheRepository => _booksCartItemRepository;

        public IBooksCartRepository BooksCartRepository => _booksCartRepository;

        public Task<int> SaveChangeAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
