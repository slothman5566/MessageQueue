namespace MessageQueue.Cart.Model
{
    public class BooksCart
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<BooksCartItem> Items { get; set; }
    }
}
