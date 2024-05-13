using MessageQueue.Cart.Repository.Implement;
using MessageQueue.Cart.Repository.Interface;

namespace MessageQueue.Cart.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBooksCartItemRepository BooksCartItemRepository { get; }

        IBooksCartRepository BooksCartRepository { get; }

        Task<int> SaveChangeAsync();
    }
}
