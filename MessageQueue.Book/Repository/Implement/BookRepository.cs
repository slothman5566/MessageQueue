using MessageQueue.Book.Data.Db;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.Interface;
using MessageQueue.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Book.Repository.Implement
{
    public class BookRepository : GenericRepository<Model.Book, BookId>, IBookRepository
    {
     
        public BookRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
          
        }
    }
}
