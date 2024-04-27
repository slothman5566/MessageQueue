using MessageQueue.Book.Model;
using MessageQueue.Core.Repository;

namespace MessageQueue.Book.Repository.Interface
{
    public interface IBookRepository : IGenericRepository<Model.Book, BookId>
    {
    }
}
