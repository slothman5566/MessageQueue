using MessageQueue.Cart.Data.Db;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Data.Db;
using MessageQueue.Core.Repository;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartRepository : GenericRepository<BooksCart, BooksCartId>, IBooksCartRepository
    {
        public BooksCartRepository(CartDbContext db) : base(db)
        {
        }
    }
}
