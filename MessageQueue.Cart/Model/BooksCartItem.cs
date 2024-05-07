using MessageQueue.Core.Model;

namespace MessageQueue.Cart.Model
{
    public class BooksCartItem : Entity<Guid>
    {
        public BooksCartId BookId { get; set; }

        public Guid BooksCartId { get; set; }

        public int Quantity { get; set; }
    }
}
