namespace MessageQueue.Cart.ViewModel
{
    public class BooksCartView
    {
        public Guid Id { get; set; }

        public List<BooksCartItemView> Items { get; set; }
    }

    public class BooksCartItemView
    {

        public Guid BookId { get; set; }

        public int Quantity { get; set; }
    }
}
