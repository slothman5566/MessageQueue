namespace MessageQueue.Cart.Repository.Interface
{
    public interface IBooksCartRepository
    {
        public Task<Model.BooksCart> GetCart(Guid id);

        public Task<Guid> AddCart(Model.BooksCart booksCart);

        public Task<List<Model.BooksCart?>> GetAllBooksCart();
    }
}
