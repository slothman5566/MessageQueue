namespace MessageQueue.Cart.ViewModel
{
    public class BooksCartCreateRequest
    {
        public List<BooksCartCreateItemRequest> Items { get; set; }
    }

    public class BooksCartCreateItemRequest
    {
        public Guid BookId { get; set; }

        public int Quantity { get; set; }
    }
}
