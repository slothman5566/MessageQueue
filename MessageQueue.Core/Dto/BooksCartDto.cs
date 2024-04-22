namespace MessageQueue.Core.Dto
{
    public class BooksCartDto
    {
        public Guid CartId { get; set; }

        public List<BooksCartItemDto> List { get; set; }    
    }
    public class BooksCartItemDto()
    {
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }
}
