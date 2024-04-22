namespace MessageQueue.Cart.Model
{
    public class BooksCartItem
    {
        public Guid BookId { get; set; }

        public Guid BooksCartId { get; set; }

        public int Quantity { get; set; }
    }
}
