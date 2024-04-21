namespace MessageQueue.Book.Repository.Interface
{
    public interface IBookRepository
    {
        public Task<Model.Book?> GetBook(Guid id);

        public Task<List<Model.Book>> GetAllBooks();
    }
}
