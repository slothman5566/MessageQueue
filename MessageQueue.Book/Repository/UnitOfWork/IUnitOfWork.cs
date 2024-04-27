using MessageQueue.Book.Repository.Interface;

namespace MessageQueue.Book.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
