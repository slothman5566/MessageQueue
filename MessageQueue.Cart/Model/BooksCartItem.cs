using MessageQueue.Core.Model;

namespace MessageQueue.Cart.Model
{
    public class BooksCartItem : Entity<Guid>
    {
        public Guid BookId { get; set; }

        public BooksCartId BooksCartId { get; set; }

        public int Quantity { get; set; }
    }
}
