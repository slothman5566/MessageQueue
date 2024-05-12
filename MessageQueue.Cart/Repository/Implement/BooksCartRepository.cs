using MessageQueue.Cart.Data.Db;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Cart.Repository.Implement
{
    public class BooksCartRepository : GenericRepository<BooksCart, BooksCartId>, IBooksCartRepository
    {
        public BooksCartRepository(CartDbContext db) : base(db)
        {
        }

        public override Task<List<BooksCart>> GetAllAsync()
        {
            return _db.Set<BooksCart>().Include(i => i.Items).ToListAsync();
        }
    }
}
