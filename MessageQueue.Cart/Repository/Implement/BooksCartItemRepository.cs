using MessageQueue.Cart.Data.Db;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Repository;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartItemRepository : GenericRepository<BooksCartItem, Guid>, IBooksCartItemRepository
    {
        public BooksCartItemRepository(CartDbContext db) : base(db)
        {
        }
    }
}
